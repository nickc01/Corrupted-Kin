using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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


	[Space]
	[Header("TEST STUFF")]
	public float test_waveX;
	public float test_acceleration;
	public float test_terminalVelocity;
	public float test_deacceleration;
	public float test_startingIntensity;
	public float test_startingWaitTime;
	public float test_spread;
	public float test_decayRate;

	public float SplitTime;
	public int SplitAmount;

	List<Vector3> meshVerticies;
	List<int> meshTriangles;
	List<Vector3> meshUVs;
	List<Vector2> colliderPoints;
	Mesh mesh;

	Material waveMaterial;
	new MeshRenderer renderer;
	MeshFilter filter;
	PolygonCollider2D polyCollider;

	SplitSorter splitSorter = new SplitSorter();
	List<SplitPoint> splits = new List<SplitPoint>();

	HashSet<int> verticiesThatAreSplit = new HashSet<int>();
	List<BlankerLine> blankers = new List<BlankerLine>();

	GeneratorSorter generatorSorter = new GeneratorSorter();
	List<IWaveGenerator> generators = new List<IWaveGenerator>();

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


		//AddSplitPoint(0.25f,1,1f);
		//AddSplitPoint(0.5f,1,1f);
		//AddSplitPoint(0.6f,1,1f);
		//AddSplitPoint(0.7f,1,1f);
		//AddSplitPoint(0.8f,1,1f);
		//AddSplitPoint(0.9f,1,1f);
		//AddSplitPoint(1f,1,1f);
		/*AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);
		AddSplitPoint(0.5f,1, 1f);*/
		//AddSplitPoint(0.5f, 0.01f);
		//AddSplitPoint(0.5f, 1, 2f);
		StartCoroutine(AddSplitAfterSecond());
	}

	IEnumerator AddSplitAfterSecond()
	{
		yield return new WaitForSeconds(1f);
		//AddSplitPoint(0.5f, 1, 2f);

		//AddSplitPoint(-1f, SplitAmount * 10, SplitTime);

		/*AddSplitPoint(0f, SplitAmount, SplitTime);
		AddSplitPoint(0.2f, SplitAmount, SplitTime);
		AddSplitPoint(0.4f, SplitAmount, SplitTime);
		AddSplitPoint(0.6f, SplitAmount, SplitTime);
		AddSplitPoint(0.8f, SplitAmount, SplitTime);
		AddSplitPoint(1f, SplitAmount, SplitTime);

		AddSplitPoint(0f, SplitAmount, SplitTime);
		AddSplitPoint(0.2f, SplitAmount, SplitTime);
		AddSplitPoint(0.4f, SplitAmount, SplitTime);
		AddSplitPoint(0.6f, SplitAmount, SplitTime);
		AddSplitPoint(0.8f, SplitAmount, SplitTime);
		AddSplitPoint(1f, SplitAmount, SplitTime);*/

		/*for (int i = 0; i < splits.Count; i++)
		{
			Debug.Log("FINAL SPLIT = " + splits[i].VertexPoint);
		}

		for (int i = 0; i < verticies.Count; i += 2)
		{
			if (i - 2 >= 0 && Mathf.Abs(verticies[i].x - verticies[i - 2].x) < 0.00110102f)
			{
				Debug.Log("SPLIT FOUND: Left = " + (i - 2) + " Right = " + i);
			}
		}*/

		//AddSplitPoint(test_waveX, SplitAmount, SplitTime);
		//AddSplitPoint(test_waveX, SplitAmount, SplitTime);
		//AddBlankerLine(test_waveX, test_acceleration, test_terminalVelocity, test_deacceleration, 1 + (blankingColorDecay * SplitTime), test_startingWaitTime, test_spread, test_decayRate);
		//AddBlankerLine(test_waveX, -test_acceleration, -test_terminalVelocity, -test_deacceleration, 1 + (blankingColorDecay * SplitTime), test_startingWaitTime, test_spread, test_decayRate);

		foreach (var generator in GetComponentsInChildren<SlamWave>())
		{
			AddGenerator(generator);
		}
		//AddGenerator(GetComponentInChildren<SlamWave>());
	}

	protected virtual void Update()
	{
		CalculateSplits();
		CalculateBlankerLines();
		DecayBlankers();

		RunWaveCalculation();
	}

	private void DecayBlankers()
	{
		var decay = blankingColorDecay * Time.deltaTime;
		var ambientOffset = ambientMovement * Time.deltaTime;
		//THIS CAN BE MADE TO RUN IN PARALLEL FOR FASTER EXECUTION
		for (int i = 0; i < meshUVs.Count; i++)
		{
			var uv = meshUVs[i];
			uv.z -= decay;
			uv.x -= ambientOffset;
			if (uv.z < 0f)
			{
				uv.z = 0f;
			}
			meshUVs[i] = uv;

#if UNITY_EDITOR
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

		if (meshUVs[meshUVs.Count - 2].x > 2f)
		{
			for (int i = 0; i < meshUVs.Count; i++)
			{
				var uv = meshUVs[i];
				uv.z -= 1f;
			}
		}
		else if (meshUVs[0].x < -1f)
		{
			for (int i = 0; i < meshUVs.Count; i++)
			{
				var uv = meshUVs[i];
				uv.z += 1f;
			}
		}
	}

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

			//If the blanker is moving
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

				//Set the blanking color of any verticies the blanker has passed along the way
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
				var worldPos = ConvertToWorldCoordinates(blanker.WaveX, 1f);
				Debug.DrawLine(worldPos, (Vector3)worldPos + new Vector3(0f, 10f, 0f), Color.magenta);
#endif
				//Decay the intensity by a set amount
				blanker._intensity -= blanker.DecayRate * Time.deltaTime;
			}
			//If the blanker is waiting to start
			else
			{
				//Decrease the timer. When the timer's zero, the blanker can move
				blanker._waitTime -= Time.deltaTime;
				if (blanker._waitTime < 0f)
				{
					blanker._waitTime = 0f;
				}
			}

			if (blanker.Vertex >= 0 && blanker.Vertex < meshVerticies.Count)
			{
				SetBlankIntensity(blanker.Vertex, intensity);
			}

			//SPREAD CODE
			int spreadVertexCounter = blanker.Vertex;
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

	private void CalculateSplits()
	{
		var textureScale = waveMaterial.mainTextureScale;
		for (int s = 0; s < splits.Count; s++)
		{
			var split = splits[s];

#if UNITY_EDITOR
			var worldPos = ConvertToWorldCoordinates(split.WaveX, 0f);
			Debug.DrawLine(worldPos, worldPos + new Vector2(0f, 10f), Color.green);
#endif

			//If the split time is up
			if (split._timer >= split.SplitTime)
			{
				//Remove the split
				RemoveSplit(split);
				continue;
			}

			var previousValue = splitCurve.Evaluate(split._timer / split.SplitTime);
			split._timer += Time.deltaTime;
			if (split._timer >= split.SplitTime)
			{
				split._timer = split.SplitTime;
			}

			var nextValue = splitCurve.Evaluate(split._timer / split.SplitTime);

			var difference = ((nextValue - previousValue) * split.SplitAmount) / textureScale.x;

			if (split.OutOfBounds)
			{
				if (split.WaveX >= 1f)
				{
					//CAN BE MADE PARRALEL
					for (int i = 0; i < meshUVs.Count; i++)
					{
						meshUVs[i] = meshUVs[i] + new Vector3(difference / 2f, 0f, 0f);
					}
				}
				else if (split.WaveX <= 0f)
				{
					//CAN BE MADE PARRALEL
					for (int i = 0; i < meshUVs.Count; i++)
					{
						meshUVs[i] = meshUVs[i] - new Vector3(difference / 2f, 0f, 0f);
					}
				}
			}
			else
			{
				//CAN BE MADE PARRALEL
				for (int i = 0; i < meshUVs.Count; i++)
				{
					if (i <= (split.VertexPoint + 1))
					{
						meshUVs[i] = meshUVs[i] + new Vector3(difference / 2f, 0f, 0f);
					}
					else
					{
						meshUVs[i] = meshUVs[i] - new Vector3(difference / 2f, 0f, 0f);
					}
				}
			}
		}
	}

	float WaveXToWorld(float waveX)
	{
		var scale = transform.localScale;

		return (scale.x * waveX) + (transform.position.x - (scale.x / 2f));
	}

	float WorldToWaveX(float position)
	{
		var scale = transform.localScale;

		//return (scale.x * waveX) + (transform.position.x - (scale.x / 2f));

		return (position - (transform.position.x - (scale.x / 2f))) / scale.x;
	}

	void RunWaveCalculation()
	{
		//THIS CAN BE RUN IN PARALLEL
		for (int i = 0; i < meshVerticies.Count; i += 2)
		{
			var waveX = meshVerticies[i].x;

			var heightValue = baseHeight - 0.5f + CalculateWave(WaveXToWorld(waveX));

			meshVerticies[1 + i] = new Vector3(waveX, heightValue, 0f);
			meshUVs[1 + i] = new Vector3(meshUVs[1 + i].x, Mathf.LerpUnclamped(heightValue + 0.5f,1f,squashFactor), meshUVs[1 + i].z);
		}
		mesh.Clear();
		mesh.SetVertices(meshVerticies);
		mesh.SetTriangles(meshTriangles, 0);
		mesh.SetUVs(0, meshUVs);

		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		UpdateColliderPoints(colliderPoints, meshVerticies);
		UpdatePolygonCollider(colliderPoints);
	}

	Mesh GenerateWaveMesh(out List<Vector3> verticies, out List<int> triangles, out List<Vector3> uv)
	{
		var mesh = new Mesh();

		mesh.MarkDynamic();

		verticies = new List<Vector3>(wavePoints * 2);
		triangles = new List<int>((wavePoints - 1) * 6);
		//uv = new Vector3[wavePoints * 2];
		uv = new List<Vector3>(wavePoints * 2);

		for (int i = 0; i < wavePoints; i++)
		{
			verticies.Add(new Vector3(-0.5f + (i / (wavePoints - 1f)), -0.5f, 0f));
			verticies.Add(new Vector3(-0.5f + (i / (wavePoints - 1f)), 0.5f, 0f));

			uv.Add(new Vector3(i / (wavePoints - 1f), 0f, 0f));
			uv.Add(new Vector3(i / (wavePoints - 1f), 1f, 0f));
		}

		for (int i = 0; i < (wavePoints - 1); i++)
		{
			triangles.Add(0 + (i * 2));
			triangles.Add(1 + (i * 2));
			triangles.Add(2 + (i * 2));

			triangles.Add(1 + (i * 2));
			triangles.Add(3 + (i * 2));
			triangles.Add(2 + (i * 2));
		}

		mesh.SetVertices(verticies);
		mesh.SetTriangles(triangles, 0);
		mesh.SetUVs(0, uv);
		mesh.RecalculateNormals();

		return mesh;
	}

	List<Vector2> GenerateColliderPoints(List<Vector3> verticies)
	{
		var length = verticies.Count;
		List<Vector2> colliderPoints = new List<Vector2>((length / 2) + 2);

		for (int i = 0; i < (length / 2) + 2; i++)
		{
			colliderPoints.Add(default(Vector2));
		}

		UpdateColliderPoints(colliderPoints,verticies);
		return colliderPoints;
	}

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

	void UpdatePolygonCollider(List<Vector2> colliderPoints)
	{
		var retainedPoints = (((colliderPoints.Count - 2) / 2) / colliderQuality) + 3;

		var rejectedPoints = ((colliderPoints.Count - 2) / 2) - retainedPoints;

		if (tempArray == null || tempArray.GetLength(0) != (retainedPoints))
		{
			tempArray = new Vector2[retainedPoints];
		}

		for (int i = 0; i < (colliderPoints.Count - 2) / 2; i++)
		{
			if (i % colliderQuality == 0)
			{
				tempArray[i / colliderQuality] = colliderPoints[i * 2];
			}
		}

		tempArray[retainedPoints - 3] = colliderPoints[colliderPoints.Count - 3];
		tempArray[retainedPoints - 2] = colliderPoints[colliderPoints.Count - 2];
		tempArray[retainedPoints - 1] = colliderPoints[colliderPoints.Count - 1];

		polyCollider.points = tempArray;
	}

	Vector2 ConvertToWorldCoordinates(float waveX, float waveY)
	{
		return ConvertToWorldCoordinates(new Vector2(waveX,waveY));
	}

	Vector2 ConvertToWorldCoordinates(Vector2 waveCoords)
	{
		var scale = transform.localScale;
		var position = transform.position - (scale / 2f);

		return new Vector2((waveCoords.x * scale.x) + position.x,(waveCoords.y * scale.y) + position.y);

		//return new Vector2(Mathf.LerpUnclamped(position.x - (scale.x / 2f), position.x + (scale.x / 2f),waveCoords.x), Mathf.LerpUnclamped(position.y - (scale.y / 2f), position.y + (scale.y / 2f), waveCoords.y + baseHeight + 0.5f));
	}

	Vector2 ConvertToWaveCoordinates(float worldX, float worldY)
	{
		return ConvertToWaveCoordinates(new Vector2(worldX,worldY));
	}

	Vector2 ConvertToWaveCoordinates(Vector2 worldCoords)
	{
		var scale = transform.localScale;
		var position = transform.position - (scale / 2f);

		return new Vector2((worldCoords.x - position.x) / scale.x, (worldCoords.y - position.y) / scale.y);

		//return new Vector2(UnclampedInverseLerp(position.x - (scale.x / 2f), position.x + (scale.x / 2f), worldCoords.x), UnclampedInverseLerp(position.y - (scale.y / 2f), position.y + (scale.y / 2f), worldCoords.y) - baseHeight - 0.5f);
	}

	//Rounds a wave x position to the nearest vertex
	float RoundWaveXToNearestVertex(float waveX)
	{
		return Mathf.RoundToInt(waveX * (wavePoints - 1f)) / (wavePoints - 1f);
	}

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

		//If the new split is being shared with another split
		if (sharedSplit != null)
		{
			//Set it to use the same vertex points as the shared one
			split.VertexPoint = sharedSplit.VertexPoint;
			split.BaseVertexPoint = sharedSplit.BaseVertexPoint;
		}

		//Debug.Log("WAVE X = " + waveX);
		//Debug.Log("OUT OF BOUNDS WAVE = " + outOfBounds);

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


			for (int i = 0; i < splits.Count; i++)
			{
				if (!splits[i].OutOfBounds && splits[i].WaveX > waveX)
				{
					splits[i].VertexPoint += 2;
				}
			}

			for (int i = 0; i < blankers.Count; i++)
			{
				if (blankers[i].WaveX <= 1f && blankers[i].WaveX >= 0f && blankers[i].Vertex > vertexPosition)
				{
					blankers[i].Vertex += 2;
				}
			}

			var bottomVertex = meshVerticies[vertexPosition];
			var topVertex = meshVerticies[vertexPosition + 1];

			meshVerticies.Insert(vertexPosition + 2, topVertex);
			meshVerticies.Insert(vertexPosition + 2, bottomVertex);

			var uvBottom = meshUVs[vertexPosition];
			var uvTop = meshUVs[vertexPosition + 1];

			meshUVs.Insert(vertexPosition + 2, uvTop);
			meshUVs.Insert(vertexPosition + 2,uvBottom);

			colliderPoints.Insert((vertexPosition / 2) + 1,colliderPoints[vertexPosition / 2]);

			var trianglePosition = baseVertexPosition * 3;

			for (int i = trianglePosition; i < meshTriangles.Count; i++)
			{
				meshTriangles[i] += 2;
			}
		}

		splits.Add(split);
		splits.Sort(splitSorter);
	}

	void RemoveSplit(SplitPoint split)
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

		splits.Remove(split);
	}

	void Internal_AddBlankerLine(float waveX, float acceleration, float terminalVelocity, float deacceleration, float startingIntensity, float startingWaitTime, float spread, float decayRate)
	{
		//Debug.Log("___ADDING BLANKER");
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


	int GetVertexAtWaveX(float waveX)
	{
		int b;
		return GetVertexAtWaveX(waveX, out b);
	}

	int GetVertexAtWaveX(float waveX, out int baseVertexPosition)
	{
		var vertexPosition = Mathf.RoundToInt(waveX * (wavePoints - 1)) * 2;
		baseVertexPosition = vertexPosition;

		for (int i = 0; i < splits.Count; i++)
		{
			if (!splits[i].OutOfBounds && vertexPosition > splits[i].VertexPoint)
			{
				vertexPosition += 2;
			}
		}

		return vertexPosition;
	}

	/*float GetWaveXAtVertex(int vertexPosition)
	{
		return meshVerticies[vertexPosition].x;
	}*/

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

	float CalculateWave(float x)
	{
		x += WaveWidth / 2f;
		float value = 0f;
		for (int i = 0; i < generators.Count; i++)
		{
			value = generators[i].Calculate(x, value);
		}
		return value;
	}

	public void AddGenerator(IWaveGenerator generator)
	{
		generators.Add(generator);
		generators.Sort(generatorSorter);
		generator.OnWaveStart(this);
	}

	public void RemoveGenerator(IWaveGenerator generator)
	{
		generator.OnWaveEnd(this);
		generators.Remove(generator);
		generators.Sort(generatorSorter);
	}

	public void AddBlanker(float position, float acceleration, float terminalVelocity, float deacceleration, float startingIntensity, float startingWaitTime, float spread, float decayRate)
	{
		var wavePosition = WorldToWaveX(position);
		var waveAcceleration = acceleration / WaveWidth;
		var waveTerminalVelocity = terminalVelocity / WaveWidth;
		var waveDeacceleration = deacceleration / WaveWidth;
		var waveSpread = spread / WaveWidth;


		Internal_AddBlankerLine(wavePosition,waveAcceleration,waveTerminalVelocity,waveDeacceleration,startingIntensity,startingWaitTime,waveSpread,decayRate);
	}

	public void AddSplit(float position, int splitAmount, float splitTime)
	{
		var waveX = WorldToWaveX(position);

		Internal_AddSplitPoint(waveX, splitAmount, splitTime);
	}
}
