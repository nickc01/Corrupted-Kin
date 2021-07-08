using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class WaveSystem : MonoBehaviour 
{
	//Used for sorting the splits list whenever one gets added. They are sorted by vertex position, from left to right on the wave
	class SplitSorter : IComparer<SplitPoint>
	{
		Comparer<int> numberComparer;

		public SplitSorter()
		{
			numberComparer = Comparer<int>.Default;
		}

		int IComparer<SplitPoint>.Compare(SplitPoint x, SplitPoint y)
		{
			return numberComparer.Compare(x.VertexPoint, y.VertexPoint);
		}
	}

	//Used for sorting wave generators by their priority
	class GeneratorSorter : IComparer<IWaveGenerator>
	{
		Comparer<int> numberComparer;

		public GeneratorSorter()
		{
			numberComparer = Comparer<int>.Default;
		}

		int IComparer<IWaveGenerator>.Compare(IWaveGenerator x, IWaveGenerator y)
		{
			return numberComparer.Compare(x.Priority, y.Priority);
		}
	}

	//Used for sorting blanker generators by their priority
	class BlankerGeneratorSorter : IComparer<IWaveBlankerGenerator>
	{
		Comparer<int> numberComparer;

		public BlankerGeneratorSorter()
		{
			numberComparer = Comparer<int>.Default;
		}

		int IComparer<IWaveBlankerGenerator>.Compare(IWaveBlankerGenerator x, IWaveBlankerGenerator y)
		{
			return numberComparer.Compare(x.Priority, y.Priority);
		}
	}


	//Represents a position on the wave where it gets split into two parts temporarily, and then recombines after a set amount of time
	[Serializable]
	class SplitPoint
	{
		public float WaveX; //The x position of where the split is located
		public int VertexPoint; //The vertex the split is occuring at
		public int BaseVertexPoint; //Same as VertexPoint, but with all previous splits not accounted for. Used for removing the split later
		public int SplitAmount; //How much of a split
		public float SplitTime; //How long the split will occur
		public bool OutOfBounds; //Whether the split is on the wave, or out of bounds. Out of bounds waves are easier to calculate

		public float _timer; //The internal timer of the split
	}

	//Represents a line that scrolls across the wave, covering the texture below it. This is used to hide obvious seams when the wave is split
	[Serializable]
	class BlankerLine
	{
		public float WaveX; //The current position of the blanker
		public int Vertex; //The current vertex of the blanker
		public float Acceleration; //How fast the blanker will accelerate to the terminal velocity
		public float TerminalVelocity; //The maximum speed of the blanker. Once it reaches this velocity, it will start deaccelerating
		public float Deacceleration; //How fast the blanker will deaccelerate to a stop
		public float StartingWaitTime; //How long the blanker will wait before it starts to move
		public int Spread; //How spread out the blanker is (in vertex count)
		public float DecayRate; //How fast the Intensity will decay

		public float _velocity; //The internal velocity of the blanker
		public float _intensity; //The internal intensity of the blanker
		public float _waitTime; //The internal waiting timer of the blanker
		public bool _reachedTerminalVelocity; //Whether the blanker has reached its terminal velocity
	}

	[SerializeField]
	[Range(50,1000)]
	[Tooltip("Determines how many verticies the wave will have. The more points, the higher quality the wave will be, but it can get laggier with high values")]
	int wavePoints = 50;
	[SerializeField]
	[Tooltip("The base height of the wave. Use this to adjust the overall height")]
	float baseHeight = 0.5f;
	[SerializeField]
	[Range(0f,5f)]
	[Tooltip("How squished the contents of the wave can get")]
	float squashFactor = 0f;
	[SerializeField]
	[Tooltip("An offset to the polygon collider")]
	Vector2 colliderOffset;
	[SerializeField]
	[Tooltip("Determines the quality of the polygon collider. 1 is the highest quality, and higher values result in lower quality")]
	[Range(1, 100)]
	int colliderQuality = 1;



	[Space]
	[Header("Internal")]
	[SerializeField]
	[Tooltip("A curve applied to splits. Do not change this unless you know what you are doing")]
	AnimationCurve splitCurve;
	[SerializeField]
	[Tooltip("How fast the blanking color decays. Do not change this unless you know what you are doing")]
	float blankingColorDecay = 0.5f;
	[SerializeField]
	[Tooltip("The base movement of the wave when nothing is happening")]
	float ambientMovement = 0f;

	//A list of verticies that are a part of the wave mesh
	List<Vector3> meshVerticies;
	//A list of triangles that are a part of the wave mesh
	List<int> meshTriangles;
	//A list of UVs that are a part of the wave mesh. The Z component is how much of the blanking color should apply
	List<Vector3> meshUVs;
	//The collider points that are a part of the polygon collider
	List<Vector2> colliderPoints;
	//The mesh that combines the verticies, triangles, and uvs together
	Mesh mesh;

	//The material used for rendering the wave
	Material waveMaterial;
	//The renderer that will render the wave material
	new MeshRenderer renderer;
	//The filter used for assigning the mesh to the material
	MeshFilter filter;
	//The polygon collider for the wave collision
	PolygonCollider2D polyCollider;

	//Used for sorting splits
	SplitSorter splitSorter = new SplitSorter();
	//A list of currently active splits on the wave
	List<SplitPoint> splits = new List<SplitPoint>();

	//A list of verticies that have splits occuring on them
	HashSet<int> verticiesThatAreSplit = new HashSet<int>();
	//A list of currently active blanking lines on the wave
	List<BlankerLine> blankers = new List<BlankerLine>();

	//Used for sorting wave generators
	GeneratorSorter generatorSorter = new GeneratorSorter();
	//Used for sorting blanking generators
	BlankerGeneratorSorter blankerGeneratorSorter = new BlankerGeneratorSorter();
	//A list of currently active wave generators
	List<IWaveGenerator> generators = new List<IWaveGenerator>();
	//A list of currently active blanker generators
	List<IWaveBlankerGenerator> blankerGenerators = new List<IWaveBlankerGenerator>();

	/// <summary>
	/// How wide the wave is in in-game units
	/// </summary>
	public float WaveWidth
	{
		get
		{
			return transform.localScale.x;
		}
	}

	protected virtual void Awake()
	{
		mesh = GenerateWaveMesh(out meshVerticies,out meshTriangles,out meshUVs);
		renderer = GetComponent<MeshRenderer>();
		filter = GetComponent<MeshFilter>();
		polyCollider = GetComponent<PolygonCollider2D>();
		colliderPoints = GenerateColliderPoints(meshVerticies);
		UpdatePolygonCollider(colliderPoints);
		filter.mesh = mesh;

		waveMaterial = renderer.sharedMaterial;
		RunWaveCalculation();
	}

	protected virtual void Update()
	{
		//Update the wave splits
		CalculateSplits();
		//Update the blanker lines
		CalculateBlankerLines();
		//This causes the blanking colors to gradually fade away
		DecayBlankers();

		//Updates the shape of the wave and it's collider
		RunWaveCalculation();
	}

	//Causes the blanking color for all the mesh UVs to decay over time
	private void DecayBlankers()
	{
		var decay = blankingColorDecay * Time.deltaTime;
		var ambientOffset = ambientMovement * Time.deltaTime;
		//For each UV in the wave mesh, cause their blanking color amount (z value) to decrease
		for (int i = 0; i < meshUVs.Count; i++)
		{
			var uv = meshUVs[i];
			uv.z -= decay;
			uv.x -= ambientOffset;
			if (uv.z < 0f)
			{
				uv.z = 0f;
			}

			//If there are any blanking color generators attached, then run those over all the mesh UVs
			if (blankerGenerators.Count > 0)
			{
				float previousValue = uv.z;

				var x_pos = WaveXToWorld(meshVerticies[i].x) + (WaveWidth / 2f);

				for (int j = 0; j < blankerGenerators.Count; j++)
				{
					previousValue = blankerGenerators[j].GetBlankingColorAtPos(x_pos, previousValue);
				}

				uv.z = previousValue;
			}

			meshUVs[i] = uv;

#if UNITY_EDITOR
			//Error checking to see if the UVs are lining up correctly along the wave
			if (i - 1 >= 0)
			{
				var diff = (meshUVs[i].x - meshUVs[i - 1].x);
				if (diff > 0.01f + ((float)1 / wavePoints))
				{
					Debug.Log("ERROR: DIFF = " + diff);
					Debug.Log("LEFT V = " + (i - 1));
					Debug.Log("RIGHT V = " + (i - 1));
				}
			}
#endif
		}

		//If the mesh UVs have gone too far to the right, then wrap around to the opposite side
		if (meshUVs[meshUVs.Count - 2].x > 2f)
		{
			for (int i = 0; i < meshUVs.Count; i++)
			{
				var uv = meshUVs[i];
				uv.z -= 1f;
			}
		}
		//If the mesh UVs have gone too far to the left, then wrap around to the opposite side
		else if (meshUVs[0].x < -1f)
		{
			for (int i = 0; i < meshUVs.Count; i++)
			{
				var uv = meshUVs[i];
				uv.z += 1f;
			}
		}
	}

	//Updates the positions of the blanker lines
	private void CalculateBlankerLines()
	{
		//Loop over all the currently running blankers
		for (int i = blankers.Count - 1; i >= 0; i--)
		{
			var blanker = blankers[i];

			//If the blanker's intensity is now zero
			if (blanker._intensity <= 0f)
			{
				//Remove it and continue to the next blanker
				blankers.RemoveAt(i);
				continue;
			}

			float intensity = 0;
			//If the blanker is still waiting to start, then interpolate to the max intensity based on the wait time
			if (blanker.StartingWaitTime > 0f && blanker._waitTime > 0f)
			{
				intensity = ((blanker.StartingWaitTime - blanker._waitTime) / blanker.StartingWaitTime) * blanker._intensity;
			}
			//Otherwise, just use the intensity as is
			else
			{
				intensity = blanker._intensity;
			}

			//If the blanker is no longer waiting to move
			if (blanker._waitTime == 0f)
			{
				//If the blanker has already reached its terminal velocity
				if (blanker._reachedTerminalVelocity)
				{
					//Store the sign of the velocity
					var signBefore = Mathf.Sign(blanker._velocity);

					//Apply deacceleration
					blanker._velocity -= blanker.Deacceleration * Time.deltaTime;
					//Get the new sign of the velocity
					var signAfter = Mathf.Sign(blanker._velocity);

					//If the direction of the velocity changed
					if (signBefore != signAfter)
					{
						//Reset the velocity to zero
						blanker._velocity = 0f;
						blanker.Deacceleration = 0f;
					}
				}
				//If the blanker has not yet reached its terminal velocity
				else
				{
					//Increase the velocity
					blanker._velocity += blanker.Acceleration * Time.deltaTime;
					//If the velocity has reached the terminal velocity
					if ((blanker.TerminalVelocity >= 0f && blanker._velocity >= blanker.TerminalVelocity) || (blanker.TerminalVelocity < 0f && blanker._velocity <= blanker.TerminalVelocity))
					{
						blanker._reachedTerminalVelocity = true;
						blanker._velocity = blanker.TerminalVelocity;
					}
				}

				var oldVertex = blanker.Vertex;

				//Move the blanker by a set amount
				blanker.WaveX += blanker._velocity * Time.deltaTime;
				//Update it's wave x position
				blanker.Vertex = GetVertexAtWaveX(blanker.WaveX);

				//If the blanker line has traveled to the right, set the blanking color of any verticies the blanker has passed along the way
				if (blanker.Vertex >= oldVertex)
				{
					for (int b = oldVertex; b < blanker.Vertex; b += 2)
					{
						if (b >= 0 && b < meshVerticies.Count)
						{
							SetBlankIntensity(b, intensity);
						}
					}
				}
				//If the blanker line has traveled to the left, set the blanking color of any verticies the blanker has passed along the way
				else
				{
					for (int b = blanker.Vertex - 1; b >= oldVertex; b -= 2)
					{
						if (b >= 0 && b < meshVerticies.Count)
						{
							SetBlankIntensity(b, intensity);
						}
					}
				}

#if UNITY_EDITOR
				//Draw the location of the blanker line
				var worldPos = ConvertToWorldCoordinates(blanker.WaveX, 1f);
				Debug.DrawLine(worldPos, (Vector3)worldPos + new Vector3(0f, 10f, 0f), Color.magenta);
#endif
				//Decay the intensity by a set amount
				blanker._intensity -= blanker.DecayRate * Time.deltaTime;
			}
			//If the blanker is waiting to start
			else
			{
				//Decrease the waiting timer. When the timer's zero, the blanker can move
				blanker._waitTime -= Time.deltaTime;
				if (blanker._waitTime < 0f)
				{
					blanker._waitTime = 0f;
				}
			}

			//Set the blanking color of the vertex the blanker line is currently sitting on top of
			if (blanker.Vertex >= 0 && blanker.Vertex < meshVerticies.Count)
			{
				SetBlankIntensity(blanker.Vertex, intensity);
			}

			//SPREAD CODE - This is used for settings the blanking color of any UVs nearby the blanking line
			//This is used to create an anti-aliasing effect around the blanking line
			int spreadVertexCounter = blanker.Vertex;
			//Loop over all nearby points that are to the left of the blanking line to apply a spread effect
			for (int z = 0; z < blanker.Spread; z++)
			{
				if (spreadVertexCounter >= 0 && spreadVertexCounter < meshVerticies.Count)
				{
					SetBlankIntensity(spreadVertexCounter, Mathf.Min(intensity,1f) * (1 - (z / (float)blanker.Spread)));
					if (verticiesThatAreSplit.Contains(spreadVertexCounter - 2))
					{
						z--;
					}

					spreadVertexCounter -= 2;
				}
				else
				{
					break;
				}
			}

			spreadVertexCounter = blanker.Vertex;

			//Loop over all nearby points that are to the right of the blanking line to apply a spread effect
			for (int z = 0; z < blanker.Spread; z++)
			{
				if (spreadVertexCounter >= 0 && spreadVertexCounter < meshVerticies.Count)
				{
					SetBlankIntensity(spreadVertexCounter,  Mathf.Min(intensity, 1f) * (1 - (z / (float)blanker.Spread)));
					if (verticiesThatAreSplit.Contains(spreadVertexCounter))
					{
						z--;
					}

					spreadVertexCounter += 2;
				}
				else
				{
					break;
				}
			}
		}
	}

	//Used for updating the wave splits
	private void CalculateSplits()
	{
		var textureScale = waveMaterial.mainTextureScale;
		for (int s = 0; s < splits.Count; s++)
		{
			var split = splits[s];

#if UNITY_EDITOR
			//Draw where the split is occuring
			var worldPos = ConvertToWorldCoordinates(split.WaveX, 0f);
			Debug.DrawLine(worldPos, worldPos + new Vector2(0f, 10f), Color.green);
#endif

			//If the split time is up
			if (split._timer >= split.SplitTime)
			{
				//Remove the split
				DeleteSplit(split);
				splits.RemoveAt(s);
				splits.Sort(splitSorter);
				continue;
			}

			//Get the current position value
			var previousValue = splitCurve.Evaluate(split._timer / split.SplitTime);
			split._timer += Time.deltaTime;
			if (split._timer >= split.SplitTime)
			{
				split._timer = split.SplitTime;
			}

			//Get the next position value
			var nextValue = splitCurve.Evaluate(split._timer / split.SplitTime);

			//Get the difference between the previous and next value
			var difference = ((nextValue - previousValue) * split.SplitAmount) / textureScale.x;

			//If the split is out of bounds
			if (split.OutOfBounds)
			{
				//If the split is offscreen to the right of the wave
				if (split.WaveX >= 1f)
				{
					//Loop over all the meshUVs and shift the x uvs to the right, creating a leftwards motion
					for (int i = 0; i < meshUVs.Count; i++)
					{
						meshUVs[i] = meshUVs[i] + new Vector3(difference / 2f, 0f, 0f);
					}
				}
				//If the split is offscreen to the left of the wave
				else if (split.WaveX <= 0f)
				{
					//Loop over all the meshUVs and shift the x uvs to the left, creating a rightwards motion
					for (int i = 0; i < meshUVs.Count; i++)
					{
						meshUVs[i] = meshUVs[i] - new Vector3(difference / 2f, 0f, 0f);
					}
				}
			}
			//If the split is not out of bounds
			else
			{
				//Loop over all the UVs in the wave mesh
				for (int i = 0; i < meshUVs.Count; i++)
				{
					//If the UV is to the left of the split, or is on top of the split
					if (i <= (split.VertexPoint + 1))
					{
						//Shift the x uv to the right, creating a leftwards motion
						meshUVs[i] = meshUVs[i] + new Vector3(difference / 2f, 0f, 0f);
					}
					else
					{
						//Shift the x uv to the left, creating a rightwards motion
						meshUVs[i] = meshUVs[i] - new Vector3(difference / 2f, 0f, 0f);
					}
				}
			}
		}
	}

	//Converts a WaveX value to world space coordinates
	//In WaveX coordinates, 0 represents the leftmost part of the wave, and 1 represents the rightmost part of the wave
	float WaveXToWorld(float waveX)
	{
		var scale = transform.localScale;
		return (scale.x * waveX) + (transform.position.x - (scale.x / 2f));
	}

	//Converts a world space coordinate to WaveX coordinates
	//In WaveX coordinates, 0 represents the leftmost part of the wave, and 1 represents the rightmost part of the wave
	float WorldToWaveX(float position)
	{
		var scale = transform.localScale;
		return (position - (transform.position.x - (scale.x / 2f))) / scale.x;
	}

	//Updates the shape of the wave and it's collider
	void RunWaveCalculation()
	{
		//Loop over all the verticies of the wave mesh
		for (int i = 0; i < meshVerticies.Count; i += 2)
		{
			//Get its wave-x coordinate
			var waveX = meshVerticies[i].x;

			//Convert it to world coordinates, and use to calculate the wave height at that particular point
			var heightValue = baseHeight - 0.5f + CalculateWave(WaveXToWorld(waveX));

			//Set the new height value of the vertex
			meshVerticies[1 + i] = new Vector3(waveX, heightValue, 0f);
			//Update the UVs y component to reflect the new vertex height
			meshUVs[1 + i] = new Vector3(meshUVs[1 + i].x, Mathf.LerpUnclamped(heightValue + 0.5f,1f,squashFactor), meshUVs[1 + i].z);
		}
		//Clear the mesh data
		mesh.Clear();
		//Set the mesh's vertex data
		mesh.SetVertices(meshVerticies);
		//Set the mesh's triangle data
		mesh.SetTriangles(meshTriangles, 0);
		//Set the mesh's UV data
		mesh.SetUVs(0, meshUVs);

		//Recalculate the mesh normals and bounds
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		//Using the vertex data, update the wave's collider points
		UpdateColliderPoints(colliderPoints, meshVerticies);
		//Apply the new collider points to the wave's polygon collider
		UpdatePolygonCollider(colliderPoints);
	}

	//Generates the initial mesh for the wave
	Mesh GenerateWaveMesh(out List<Vector3> verticies, out List<int> triangles, out List<Vector3> uv)
	{
		var mesh = new Mesh();

		//Marked dynamic since the mesh is getting updated every frame
		mesh.MarkDynamic();

		//Create the list of vertexes
		verticies = new List<Vector3>(wavePoints * 2);
		//Create the list of triangles
		triangles = new List<int>((wavePoints - 1) * 6);
		//Create the list of UVs
		uv = new List<Vector3>(wavePoints * 2);

		//Initialize the vertex and uv lists with default values
		for (int i = 0; i < wavePoints; i++)
		{
			verticies.Add(new Vector3(-0.5f + (i / (wavePoints - 1f)), -0.5f, 0f));
			verticies.Add(new Vector3(-0.5f + (i / (wavePoints - 1f)), 0.5f, 0f));

			uv.Add(new Vector3(i / (wavePoints - 1f), 0f, 0f));
			uv.Add(new Vector3(i / (wavePoints - 1f), 1f, 0f));
		}

		//Initialize the triangle list
		for (int i = 0; i < (wavePoints - 1); i++)
		{
			triangles.Add(0 + (i * 2));
			triangles.Add(1 + (i * 2));
			triangles.Add(2 + (i * 2));

			triangles.Add(1 + (i * 2));
			triangles.Add(3 + (i * 2));
			triangles.Add(2 + (i * 2));
		}

		//Set the mesh's vertex data
		mesh.SetVertices(verticies);
		//Set the mesh's triangle data
		mesh.SetTriangles(triangles, 0);
		//Set the mesh's UV data
		mesh.SetUVs(0, uv);
		//Recalculate the mesh normals and bounds
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		return mesh;
	}

	//Generates a list of collision points for the wave
	List<Vector2> GenerateColliderPoints(List<Vector3> verticies)
	{
		//Initialize the list with default values
		var length = verticies.Count;
		List<Vector2> colliderPoints = new List<Vector2>((length / 2) + 2);
		for (int i = 0; i < (length / 2) + 2; i++)
		{
			colliderPoints.Add(default(Vector2));
		}

		//Update the list based on the vertex data
		UpdateColliderPoints(colliderPoints,verticies);
		return colliderPoints;
	}

	//Given a list of verticies, calculate the wave's collision points
	void UpdateColliderPoints(List<Vector2> colliderPoints, List<Vector3> verticies)
	{
		var length = verticies.Count;
		for (int i = 0; i < (length / 2); i++)
		{
			colliderPoints[i] = (Vector2)verticies[1 + (i * 2)] + colliderOffset;
		}
		colliderPoints[length / 2] = new Vector2(0.5f, -0.5f);
		colliderPoints[(length / 2) + 1] = new Vector2(-0.5f, -0.5f);
	}

	Vector2[] tempArray;

	//Update the polygon collider of the wave
	//Some points will be rejected to save performance, since the collider does not have to have the same level of quality as the mesh
	void UpdatePolygonCollider(List<Vector2> colliderPoints)
	{
		//Calculates how many collider points will be assigned to the polygon collider
		var retainedPoints = (((colliderPoints.Count - 2) / 2) / colliderQuality) + 3;

		//A temp array is used to minimize memory allocations every frame
		if (tempArray == null || tempArray.GetLength(0) != (retainedPoints))
		{
			tempArray = new Vector2[retainedPoints];
		}

		//Copy over points from the collider points array to the temp array.
		//The colliderQuality variable determines how many of the points are copied over.
		//If colliderQuality is 2 for example, then only half of the points get copied over
		for (int i = 0; i < (colliderPoints.Count - 2) / 2; i++)
		{
			if (i % colliderQuality == 0)
			{
				tempArray[i / colliderQuality] = colliderPoints[i * 2];
			}
		}

		//Copy over the bottom-left, bottom-right, and top-right points so the collider is a full shape
		tempArray[retainedPoints - 3] = colliderPoints[colliderPoints.Count - 3];
		tempArray[retainedPoints - 2] = colliderPoints[colliderPoints.Count - 2];
		tempArray[retainedPoints - 1] = colliderPoints[colliderPoints.Count - 1];

		//Set the points of the polygon collider
		polyCollider.points = tempArray;
	}

	//Converts wave-x and wave-y coordinates to world-space coordinates
	//In Wave coordinates, 0 represents the leftmost part of the wave, and 1 represents the rightmost part of the wave
	Vector2 ConvertToWorldCoordinates(float waveX, float waveY)
	{
		return ConvertToWorldCoordinates(new Vector2(waveX,waveY));
	}

	//Converts wave-x and wave-y coordinates to world-space coordinates
	//In Wave coordinates, 0 represents the leftmost part of the wave, and 1 represents the rightmost part of the wave
	Vector2 ConvertToWorldCoordinates(Vector2 waveCoords)
	{
		var scale = transform.localScale;
		var position = transform.position - (scale / 2f);

		return new Vector2((waveCoords.x * scale.x) + position.x,(waveCoords.y * scale.y) + position.y);
	}

	//Converts world-space coordinates to wave-x and wave-y coordinates
	//In Wave coordinates, 0 represents the leftmost part of the wave, and 1 represents the rightmost part of the wave
	Vector2 ConvertToWaveCoordinates(float worldX, float worldY)
	{
		return ConvertToWaveCoordinates(new Vector2(worldX,worldY));
	}

	//Converts world-space coordinates to wave-x and wave-y coordinates
	//In Wave coordinates, 0 represents the leftmost part of the wave, and 1 represents the rightmost part of the wave
	Vector2 ConvertToWaveCoordinates(Vector2 worldCoords)
	{
		var scale = transform.localScale;
		var position = transform.position - (scale / 2f);

		return new Vector2((worldCoords.x - position.x) / scale.x, (worldCoords.y - position.y) / scale.y);
	}

	//Rounds a wave x position to the nearest vertex position
	float RoundWaveXToNearestVertex(float waveX)
	{
		return Mathf.RoundToInt(waveX * (wavePoints - 1f)) / (wavePoints - 1f);
	}

	//Adds a split line to the wave generator
	void Internal_AddSplitPoint(float waveX, int splitAmount, float splitTime)
	{
		//Round the wave x position to the nearest vertex
		waveX = RoundWaveXToNearestVertex(waveX);

		//Gets the split that is already at that wave x position, if there is one
		SplitPoint sharedSplit = GetSplitAtWaveX(waveX);

		//Check if the split is being spawned outside of the wave's visible area.
		//Out of bounds splits are handled differently
		bool outOfBounds = waveX <= 0f || waveX >= 1f;

		//Create the split object
		var split = new SplitPoint
		{
			WaveX = waveX,
			SplitAmount = splitAmount,
			SplitTime = splitTime,
			OutOfBounds = outOfBounds,
			_timer = 0
		};

		//If the new split is being shared with another split on the same vertex
		if (sharedSplit != null)
		{
			//Set it to use the same vertex points as the shared one
			split.VertexPoint = sharedSplit.VertexPoint;
			split.BaseVertexPoint = sharedSplit.BaseVertexPoint;
		}

		//If the split is not out of bounds and is not shared with any other split, then it will split the mesh apart
		if (!outOfBounds && sharedSplit == null)
		{
			int baseVertexPosition = 0;
			//Calculate the vertex position of the split. Also get the base vertex position, which doesn't account for previous splits
			int vertexPosition = GetVertexAtWaveX(waveX, out baseVertexPosition);

			//Set the vertex points
			split.VertexPoint = vertexPosition;
			split.BaseVertexPoint = baseVertexPosition;

			//Add the vertex to the list of verticies that are being split apart
			verticiesThatAreSplit.Add(split.VertexPoint);

			//Any splits that are to the right of this newly created one are shifted right to realign them
			for (int i = 0; i < splits.Count; i++)
			{
				if (!splits[i].OutOfBounds && splits[i].WaveX > waveX)
				{
					splits[i].VertexPoint += 2;
				}
			}

			//Any blankers that are to the right of this newly created split are shifted right to realign them
			for (int i = 0; i < blankers.Count; i++)
			{
				if (blankers[i].WaveX <= 1f && blankers[i].WaveX >= 0f && blankers[i].Vertex > vertexPosition)
				{
					blankers[i].Vertex += 2;
				}
			}

			//The code below inserts two new vertexes into the mesh to split the mesh into two parts, and this allows the UVs on both sides of the mesh to be scrolled independently
			//This is why the blankers and splits in the code above needed to be shifted

			var bottomVertex = meshVerticies[vertexPosition];
			var topVertex = meshVerticies[vertexPosition + 1];

			//Insert two new vertexes
			meshVerticies.Insert(vertexPosition + 2, topVertex);
			meshVerticies.Insert(vertexPosition + 2, bottomVertex);

			var uvBottom = meshUVs[vertexPosition];
			var uvTop = meshUVs[vertexPosition + 1];

			//Insert two new UVs
			meshUVs.Insert(vertexPosition + 2, uvTop);
			meshUVs.Insert(vertexPosition + 2,uvBottom);

			//Insert a new collider point
			colliderPoints.Insert((vertexPosition / 2) + 1,colliderPoints[vertexPosition / 2]);

			var trianglePosition = baseVertexPosition * 3;

			//All triangles to the right of this newly inserted vertex gets shifted right
			for (int i = trianglePosition; i < meshTriangles.Count; i++)
			{
				meshTriangles[i] += 2;
			}
		}

		//Add the new split
		splits.Add(split);
		//Sort the splits list
		splits.Sort(splitSorter);
	}

	//Deletes a split from the wave
	void DeleteSplit(SplitPoint split)
	{
		//If the split is out of bounds or there is no singular split on the vertex, then verticies do not need to be rearranged, so exit out
		if (split.OutOfBounds || GetSplitsOnVertex(split.VertexPoint) != 1)
		{
			return;
		}
		//Remove the split from the list of verticies that are split
		verticiesThatAreSplit.Remove(split.VertexPoint);

		//Calculate the difference between the left side of the split and the right side of the split
		//This is used later to adjust the UV values
		var uvDifference = meshUVs[split.VertexPoint].x - meshUVs[split.VertexPoint + 2].x;

		//Any splits that are to the right of this split get shifted back to compensate
		ShiftBackOtherSplits(split.VertexPoint);

		//Remove the mesh verticies at the split
		meshVerticies.RemoveAt(split.VertexPoint + 3);
		meshVerticies.RemoveAt(split.VertexPoint + 2);

		//Remove the mesh UVs at the split
		meshUVs.RemoveAt(split.VertexPoint + 3);
		meshUVs.RemoveAt(split.VertexPoint + 2);

		//Remove the collider points at the split
		colliderPoints.RemoveAt((split.VertexPoint / 2) + 1);

		//All UVS that are to the right of the vertex point get their uvs shifted
		for (int i = split.VertexPoint + 2; i < meshUVs.Count; i++)
		{
			var currentUV = meshUVs[i];
			currentUV.x += uvDifference;
			meshUVs[i] = currentUV;
		}

		//Calculate the triangle that is located at the split point
		var trianglePosition = split.BaseVertexPoint * 3;

		//All triangles after it get shifted back to remove the split
		for (int i = trianglePosition; i < meshTriangles.Count; i++)
		{
			meshTriangles[i] -= 2;
		}
	}

	//Adds a new blanker line to the wave. Blankers are used to cover a section of the wave with a solid color, and is primarily used to cover up seams caused by splits
	void Internal_AddBlankerLine(float waveX, float acceleration, float terminalVelocity, float deacceleration, float startingIntensity, float startingWaitTime, float spread, float decayRate)
	{
		//Add the new blanker line
		blankers.Add(new BlankerLine
		{
			Acceleration = acceleration,
			Deacceleration = deacceleration,
			StartingWaitTime = startingWaitTime,
			WaveX = waveX,
			Vertex = GetVertexAtWaveX(waveX),
			TerminalVelocity = terminalVelocity,
			_intensity = startingIntensity,
			_waitTime = startingWaitTime,
			DecayRate = decayRate,
			Spread = Mathf.RoundToInt(spread * wavePoints * 2f)
		});
	}

	/// <summary>
	/// Gets the split at the specified wave X. Returns null if no split was found
	/// </summary>
	/// <param name="waveX">The wave x position</param>
	/// <returns>The split at that position. Returns null if no split was found</returns>
	SplitPoint GetSplitAtWaveX(float waveX)
	{
		for (int i = 0; i < splits.Count; i++)
		{
			if (splits[i].WaveX == waveX)
			{
				return splits[i];
			}
		}
		return null;
	}

	/// <summary>
	/// Gets the split at the specified vertex. Returns null if no split was found
	/// </summary>
	/// <param name="vertex">The vertex position</param>
	/// <returns>The split at that position. Returns null if no split was found</returns>
	SplitPoint GetSplitAtVertex(int vertex)
	{
		for (int i = 0; i < splits.Count; i++)
		{
			if (splits[i].VertexPoint == vertex)
			{
				return splits[i];
			}
		}
		return null;
	}

	//Gets the vertex index at the specified wave-x
	int GetVertexAtWaveX(float waveX)
	{
		int b;
		return GetVertexAtWaveX(waveX, out b);
	}

	//Gets the vertex index at the specified wave-x
	//The baseVertexPosition is similar to the return value, but does not account for any of the splits
	int GetVertexAtWaveX(float waveX, out int baseVertexPosition)
	{
		var vertexPosition = Mathf.RoundToInt(waveX * (wavePoints - 1)) * 2;
		baseVertexPosition = vertexPosition;

		for (int i = 0; i < splits.Count; i++)
		{
			if (!splits[i].OutOfBounds && vertexPosition > splits[i].VertexPoint)
			{
				if (i > 0 && splits[i].VertexPoint == splits[i - 1].VertexPoint)
				{
					continue;
				}
				else
				{
					vertexPosition += 2;
				}
			}
		}

		return vertexPosition;
	}

	//Sets the intensity of the blanking color at a specified UV index
	void SetBlankIntensity(int uvPoint, float intensity)
	{
		var point = meshUVs[uvPoint];
		meshUVs[uvPoint] = point.With(z: Math.Max(point.z, intensity));
		meshUVs[uvPoint + 1] = point.With(z: Math.Max(point.z, intensity));

		if (verticiesThatAreSplit.Contains(uvPoint))
		{
			point = meshUVs[uvPoint + 2];
			meshUVs[uvPoint + 2] = point.With(z: Math.Max(point.z, intensity));
			meshUVs[uvPoint + 3] = point.With(z: Math.Max(point.z, intensity));
		}

		if (verticiesThatAreSplit.Contains(uvPoint - 2))
		{
			point = meshUVs[uvPoint - 2];
			meshUVs[uvPoint - 2] = point.With(z: Math.Max(point.z, intensity));
			meshUVs[uvPoint - 1] = point.With(z: Math.Max(point.z, intensity));
		}
	}

	/// <summary>
	/// Any splits that are to the right of the specified <paramref name="vertex"/> will be shifted left by 2 verticies to compensate
	/// </summary>
	/// <param name="vertex"></param>
	void ShiftBackOtherSplits(int vertex)
	{
		for (int i = splits.Count - 1; i >= 0; i--)
		{
			if (!splits[i].OutOfBounds && splits[i].VertexPoint > vertex)
			{
				splits[i].VertexPoint -= 2;
			}
		}
	}

	/// <summary>
	/// Any splits that are to the right of the specified <paramref name="vertex"/> will be shifted right by 2 verticies
	/// </summary>
	/// <param name="vertex"></param>
	void ShiftSplitsPastVertex(int vertex)
	{
		for (int i = 0; i < splits.Count; i++)
		{
			if (!splits[i].OutOfBounds && splits[i].VertexPoint > vertex)
			{
				splits[i].VertexPoint += 2;
			}
		}
	}

	//Gets how many splits are on a specific vertex
	int GetSplitsOnVertex(int vertex)
	{
		int sharedCount = 0;
		for (int i = 0; i < splits.Count; i++)
		{
			if (splits[i].VertexPoint == vertex)
			{
				sharedCount++;
			}
		}
		return sharedCount;
	}

	//Used for calculating the height of a wave at a certain point
	float CalculateWave(float x)
	{
		//Converts the x value from a range of (-WaveWidth/2 : +WaveWidth/2) to a range of (0 : WaveWidth)
		x += WaveWidth / 2f;
		float value = 0f;
		//Loop over all the wave generators and calculate the height of a wave at the particular x position
		for (int i = 0; i < generators.Count; i++)
		{
			value = generators[i].Calculate(x, value);
		}
		return value;
	}

	//Adds a wave generator to the wave
	public void AddGenerator(IWaveGenerator generator)
	{
		if (!generators.Contains(generator))
		{
			generators.Add(generator);
			generators.Sort(generatorSorter);
			generator.OnWaveStart(this);
		}
	}

	//Removes a wave generator from the wave
	public void RemoveGenerator(IWaveGenerator generator)
	{
		if (generators.Contains(generator))
		{
			generator.OnWaveEnd(this);
			generators.Remove(generator);
			generators.Sort(generatorSorter);
		}
	}

	public bool HasGenerator(IWaveGenerator generator) => generators.Contains(generator);
	public bool HasGenerator<T>() where T : IWaveGenerator => generators.Any(g => g is T);

	/// <summary>
	/// Adds a blanking line to the wave
	/// </summary>
	/// <param name="position">The x-position of the blanking line</param>
	/// <param name="acceleration">How fast the blanking line will accelerate. A negative value will cause the wave to accelerate left</param>
	/// <param name="terminalVelocity">The maximum speed of the blanking line. The blanking line will continue to accelerate until this limit is reached. Make sure this value is negative if the acceleration is also negative</param>
	/// <param name="deacceleration">How fast the blanking line will deccelerate. Make sure this value's negative if the wave is traveling left</param>
	/// <param name="blankerIntensity">How intense the blanking color of the line will be. This value will decay overtime, based on what is set for the <paramref name="decayRate"/></param>
	/// <param name="startingWaitTime">How long the blanking line will wait before it starts to move</param>
	/// <param name="spread">How much of a spread does the blanking line have. This is similar to having an anti-aliasing effect around the line</param>
	/// <param name="decayRate">How fast the <paramref name="blankerIntensity"/> will decay over time</param>
	public void AddBlanker(float position, float acceleration, float terminalVelocity, float deacceleration, float blankerIntensity, float startingWaitTime, float spread, float decayRate)
	{
		//Convert all the vlaues from world-space coords to wave-x coords
		var wavePosition = WorldToWaveX(position);
		var waveAcceleration = acceleration / WaveWidth;
		var waveTerminalVelocity = terminalVelocity / WaveWidth;
		var waveDeacceleration = deacceleration / WaveWidth;
		var waveSpread = spread / WaveWidth;


		Internal_AddBlankerLine(wavePosition,waveAcceleration,waveTerminalVelocity,waveDeacceleration,blankerIntensity,startingWaitTime,waveSpread,decayRate);
	}

	//Adds a blanker generator for customizing what parts of the wave should be blanked out with the blanking color
	public void AddBlankerGenerator(IWaveBlankerGenerator generator)
	{
		if (!blankerGenerators.Contains(generator))
		{
			blankerGenerators.Add(generator);
			blankerGenerators.Sort(blankerGeneratorSorter);
		}
	}

	//Removes a blanker generator from the wave
	public void RemoveBlankerGenerator(IWaveBlankerGenerator generator)
	{
		if (blankerGenerators.Contains(generator))
		{
			blankerGenerators.Remove(generator);
			blankerGenerators.Sort(blankerGeneratorSorter);
		}
	}

	/// <summary>
	/// Adds a split in the wave
	/// </summary>
	/// <param name="position">Where the split should occur</param>
	/// <param name="splitAmount">How big the split will be</param>
	/// <param name="splitTime">How long the split will last</param>
	public void AddSplit(float position, int splitAmount, float splitTime)
	{
		var waveX = WorldToWaveX(position);

		Internal_AddSplitPoint(waveX, splitAmount, splitTime);
	}
}
