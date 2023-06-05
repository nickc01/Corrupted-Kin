using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

//This is to make sure that the Newtonsoft Serializer DOESN't include properties, only field data
public class IgnorePropertiesContractResolver : DefaultContractResolver
{
	protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
	{
		var property = base.CreateProperty(member, memberSerialization);

		//If the member is a property, then don't serialize it
        if (member is PropertyInfo)
        {
			property.ShouldSerialize = i => false;
			property.Ignored = true;
		}

		return property;
	}
}


/// <summary>
/// A window for dumping all collider information from a scene
/// </summary>
public class DumpColliders : EditorWindow
{
	[Serializable]
	public class SceneDump
	{
		public DumpedObject[] rootObjects;
	}

	[Serializable]
	public enum ColliderType
	{
		None,
		Box,
		Capsule,
		Circle,
		Poly,
		Edge
	}

	[Serializable]
	public class DumpedCollider
	{
		public ColliderType colliderType;
		public Vector2 colliderOffset;
		public Vector2 colliderSize;

		public CapsuleDirection2D capsuleColliderDirection;
		public float colliderRadius;
		public Vector2[] colliderPoints;

		public bool isTrigger;
	}

	[Serializable]
	public class DumpedObject
	{
		public string name;
		public DumpedObject[] childObjects;

		public DumpedCollider[] colliders;

		public Vector3 position;
		public Quaternion rotation;
		public Vector3 scale;
	}


	SceneAsset scene;

	string outputFolder;


	//Called when the window is opened
	private void Awake()
	{
		scene = null;
	}

	//The MenuItem attribute will create a new menu item at the top of the window, and when the option is clicked, this function will run
	[MenuItem("Onryo/Tools/Dump Scene Colliders")]
	public static void OpenWindow()
	{
		//Show the DumpColliders Window
		EditorWindow.GetWindow<DumpColliders>().Show();
	}

	//This is called whenever the GUI gets updated. This is used to draw the UI elements within the window
	void OnGUI()
	{
		//Display an object field. This field will allow us to select a scene
		scene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("Scene", "The scene to extract the collider information from"), scene, typeof(SceneAsset), false);

		//Displays a text field. This allows us to specify an output folder
		outputFolder = EditorGUILayout.TextField(new GUIContent("Output Folder", "The folder the dumped data will be placed in"), outputFolder);

		//Display a button. This returns true if the button is clicked.
		if (GUILayout.Button("Extract Colliders"))
		{
			//If the button is clicked, start extracting all info from the scene
			ExtractAllInfo();
		}
	}

	void ExtractAllInfo()
	{
		//Get the asset path to the scene (needed for below)
		var scenePath = AssetDatabase.GetAssetPath(scene);

		//Open the scene in the editor so we can see it's objects
		var loadedScene = EditorSceneManager.OpenScene(scenePath);

		//Initialize the scene dump object
		var dump = new SceneDump();

		//Get all the root objects in the scene. These are all the objects in the scene with no parents.
		var rootSceneObjects = loadedScene.GetRootGameObjects();

		//Initialize the root objects array
		dump.rootObjects = new DumpedObject[rootSceneObjects.Length];

		//Loop over all the root objects in the scene
		for (int i = 0; i < rootSceneObjects.Length; i++)
		{
			//For each object, dump the object's contents
			dump.rootObjects[i] = DumpObject(rootSceneObjects[i]);
		}

		//Create the contract resolver to ignore properties, and only allow fields to be serialized
		var jsonResolver = new IgnorePropertiesContractResolver();

		//Take the entire scene dump object and convert it into a json string
		var dumpOutputData = Newtonsoft.Json.JsonConvert.SerializeObject(dump, Newtonsoft.Json.Formatting.Indented,new JsonSerializerSettings
        {
			ContractResolver = jsonResolver
		});

		//Setup the output directory
		var outputDir = new DirectoryInfo("Assets/" + outputFolder);

		//if the output directory doesn't exist
		if (!outputDir.Exists)
		{
			//...Then create it
			outputDir.Create();
		}

		//The name of the dump file
		var fileName = loadedScene.name + "_DUMP.dat";

		//Write all the json data to the file. This function automatically creates the file if it doesn't already exist
		File.WriteAllText(outputDir.FullName + "/" + fileName, dumpOutputData);

		//Import the newly created file into the Unity Project
		AssetDatabase.ImportAsset("Assets/" + outputFolder + "/" + fileName);
	}

	//Takes the information from the "source" object and dumps the information
	DumpedObject DumpObject(GameObject source)
	{
		var dump = new DumpedObject();

		//Copy over the object's name, position, rotation and scale
		dump.name = source.name;
		dump.position = source.transform.localPosition;
		dump.rotation = source.transform.localRotation;
		dump.scale = source.transform.localScale;

		//Get all the colliders on the object
		var colliders = source.GetComponents<Collider2D>();

		//Initialize the collider dump array
		dump.colliders = new DumpedCollider[colliders.Length];

		//Loop over all the colliders on the object
		for (int i = 0; i < colliders.Length; i++)
		{
			//The collider we are copying information from
			var sourceCollider = colliders[i];

			//The dump object we are copying the information to
			var dumpedCollider = new DumpedCollider();

			//Get the collider type of the collider
			dumpedCollider.colliderType = GetColliderType(sourceCollider);
			switch (dumpedCollider.colliderType)
			{
				case ColliderType.None:
					break;
				//If the collider type is a BoxCollider2D
				case ColliderType.Box:
					//Copy over the collider's size
					dumpedCollider.colliderSize = (sourceCollider as BoxCollider2D).size;
					break;
				//If the collider type is a CapsuleCollider2D
				case ColliderType.Capsule:
					//Copy over the collider's size and direction
					dumpedCollider.colliderSize = (sourceCollider as CapsuleCollider2D).size;
					dumpedCollider.capsuleColliderDirection = (sourceCollider as CapsuleCollider2D).direction;
					break;
				//If the collider type is a CircleCollider2D
				case ColliderType.Circle:
					//Copy over the collider's radius
					dumpedCollider.colliderRadius = (sourceCollider as CircleCollider2D).radius;
					break;
				//If the collider type is a PolygonCollider2D
				case ColliderType.Poly:
					//Copy over the collider's points
					dumpedCollider.colliderPoints = (sourceCollider as PolygonCollider2D).points;
					break;
				//If the collider type is a EdgeCollider2D
				case ColliderType.Edge:
					//Copy over the collider's points
					dumpedCollider.colliderPoints = (sourceCollider as EdgeCollider2D).points;
					break;
			}
			//Copy over the collider's offset
			dumpedCollider.colliderOffset = sourceCollider.offset;

			dumpedCollider.isTrigger = sourceCollider.isTrigger;

			dump.colliders[i] = dumpedCollider;
		}

		//Initialize the children array
		dump.childObjects = new DumpedObject[source.transform.childCount];

		//Loop over all the object's children
		for (int i = 0; i < source.transform.childCount; i++)
		{
			var child = source.transform.GetChild(i);

			//Dump the child object's information. This is a recursive call that will also dump the children of the chidl object, and so on 
			dump.childObjects[i] = DumpObject(child.gameObject);
		}
		return dump;
	}

	//Gets the type of the collider
	ColliderType GetColliderType(Collider2D collider)
	{
		if (collider is BoxCollider2D)
		{
			return ColliderType.Box;
		}
		else if (collider is CircleCollider2D)
		{
			return ColliderType.Circle;
		}
		else if (collider is PolygonCollider2D)
		{
			return ColliderType.Poly;
		}
		else if (collider is EdgeCollider2D)
		{
			return ColliderType.Edge;
		}
		else if (collider is CapsuleCollider2D)
		{
			return ColliderType.Capsule;
		}
		else
		{
			return ColliderType.None;
		}
	}
}
