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

/// <summary>
/// A window for creating a scene using the dumped collision info
/// </summary>
public class CreateCollisionScene : EditorWindow
{
	//The dump file to be used when creating the scene
	UnityEditor.DefaultAsset dumpFile;

	//The prefab used to display a normal collider
	static GameObject defaultVisualPrefab;

	//The prefab used to display a trigger collider
	static GameObject triggerVisualPrefab;


	//Called when the window is opened
	private void Awake()
	{
		dumpFile = null;
	}


	//The MenuItem attribute will create a new menu item at the top of the window, and when the option is clicked, this function will run
	[MenuItem("Onryo/Tools/Create Collision Scene")]
	public static void OpenWindow()
	{
		//Show the CreateCollisionScene Window
		EditorWindow.GetWindow<CreateCollisionScene>().Show();
	}

	//This is called whenever the GUI gets updated. This is used to draw the UI elements within the window
	void OnGUI()
	{
		//Display an object field. This field will allow us to select the file that contains the collision information
		dumpFile = (UnityEditor.DefaultAsset)EditorGUILayout.ObjectField(new GUIContent("Dump file", "The file containing all the dumped collision information"), dumpFile, typeof(UnityEditor.DefaultAsset), false);
		//Display a button. This returns true if the button is clicked.
		if (GUILayout.Button("Create Collision Scene"))
		{
			//If the button is clicked, start creating the scene
			CreateScene();
		}
	}

	void CreateScene()
	{
		//The two lines below loads up the visuals used for both the default colliders and trigger colliders.

		/*
		 The steps involved are:
		1: Call AssetDatabase.FindAssets to get a list of assets that share the name we are looking for. The list contains a list of GUID strings correlating to the assets
		2: Call AssetDatabase.GUIDToAssetPath to convert the asset GUID into an asset path
		3: Call AssetDatabase.LoadAssetAtPath to load the asset at that path
		 */

		defaultVisualPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("Default_Visual")[0]));
		triggerVisualPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("Trigger_Visual")[0]));

		//Create a new empty scene
		var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

		//Set this scene as active. Any new objects we create will automatically be placed in this scene
		EditorSceneManager.SetActiveScene(scene);

		//Get the path to the dump file to load from
		var path = AssetDatabase.GetAssetPath(dumpFile);

		//Load all the json text from the file
		var json = File.ReadAllText(path);

		//Take the json data and convert it back to it's object form
		var collisionData = Newtonsoft.Json.JsonConvert.DeserializeObject<DumpColliders.SceneDump>(json);

		//Loop over all the root objects and create objects from their data
        for (int i = 0; i < collisionData.rootObjects.Length; i++)
        {
			CreateObject(collisionData.rootObjects[i], null);
        }

		EditorSceneManager.SaveScene(scene);
	}

	//Creates an object from the dump information
	void CreateObject(DumpColliders.DumpedObject source, GameObject parent)
    {
		//Create the new object
		var obj = new GameObject(source.name);

		//If a parent was specified, then set the object's parent
        if (parent != null)
        {
			obj.transform.SetParent(parent.transform);
        }

		//Set the position, rotation, and scale
		obj.transform.localPosition = source.position;
		obj.transform.localRotation = source.rotation;
		obj.transform.localScale = source.scale;

		//Loop over all the colliders on the object and create them
        for (int i = 0; i < source.colliders.Length; i++)
        {
			SetupCollider(obj,source.colliders[i]);
        }

		//Loop over all the child objects on the object and create them too
        for (int i = 0; i < source.childObjects.Length; i++)
        {
			CreateObject(source.childObjects[i],obj);
        }
    }

	//Sets up a collider
	Collider2D SetupCollider(GameObject obj, DumpColliders.DumpedCollider source)
    {
		Collider2D collider = null;

        switch (source.colliderType)
        {
			//If the collider is a BoxCollider2D
            case DumpColliders.ColliderType.Box:
				var box = obj.AddComponent<BoxCollider2D>();
				box.size = source.colliderSize;
				collider = box;
                break;
			//If the collider is a CapsuleCollider2D
			case DumpColliders.ColliderType.Capsule:
				var capsule = obj.AddComponent<CapsuleCollider2D>();
				capsule.size = source.colliderSize;
				capsule.direction = source.capsuleColliderDirection;
				collider = capsule;
				break;
			//If the collider is a CircleCollider2D
			case DumpColliders.ColliderType.Circle:
				var circle = obj.AddComponent<CircleCollider2D>();
				circle.radius = source.colliderRadius;
				collider = circle;
				break;
			//If the collider is a PolygonCollider2D
			case DumpColliders.ColliderType.Poly:
				var poly = obj.AddComponent<PolygonCollider2D>();
				poly.points = source.colliderPoints;
				collider = poly;
				break;
			//If the collider is a EdgeCollider2D
			case DumpColliders.ColliderType.Edge:
				var edge = obj.AddComponent<PolygonCollider2D>();
				edge.points = source.colliderPoints;
				collider = edge;
				break;
            default:
                break;
        }

		//If a collider wasn't created, then return null
        if (collider == null)
        {
			return null;
        }

		//Set the collider offset
		collider.offset = source.colliderOffset;

		//Create the object to visually show the collider in the scene
		CreateColliderVisual(collider,source);

		return collider;
    }

	//Creates an object used to show the collider visually in the scene
	void CreateColliderVisual(Collider2D collider, DumpColliders.DumpedCollider dumpSource)
    {
        GameObject visual;
		//if the collider is a trigger
        if (dumpSource.isTrigger)
        {
			visual = GameObject.Instantiate(triggerVisualPrefab);
        }
		else
        {
			visual = GameObject.Instantiate(defaultVisualPrefab);
		}

		//Set the visual's parent, position, rotation, and scale
		visual.transform.SetParent(collider.transform);

		visual.transform.localPosition = Vector3.zero;
		visual.transform.localRotation = Quaternion.identity;
		visual.transform.localScale = Vector3.one;

		//Get the mesh filter on the visual object
		var filter = visual.GetComponent<MeshFilter>();

		//Create a mesh that represents the collider
		var mesh = collider.CreateMesh(false, false);

		//Get the verticies on the mesh
		List<Vector3> verticies = new List<Vector3>();
		mesh.GetVertices(verticies);

		//Loop over all the mesh verticies and convert them from world space to local space
        for (int i = 0; i < mesh.vertexCount; i++)
        {
			verticies[i] = collider.transform.InverseTransformPoint(verticies[i]) - new Vector3(0f,0f,-collider.transform.localPosition.z / collider.transform.localScale.z);
        }

		//Update the mesh vertex list
		mesh.SetVertices(verticies);

		//Since the verticies have been updated, the bounds, normals, and tangents need to be Recalculated
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		mesh.RecalculateTangents();

		//Apply the mesh to the filter
		filter.mesh = mesh;
	}
}
