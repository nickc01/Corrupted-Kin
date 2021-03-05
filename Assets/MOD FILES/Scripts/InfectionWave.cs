using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Utilities;

/*public abstract class WaveGenerator
{
	public InfectionWave Wave { get; set; }

	public abstract float Calculate(float x);
}*/

public class InfectionWave : MonoBehaviour 
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



	struct SplitPoint
	{
		public float WaveX; //The x position of where the split is located
		public int VertexPoint; //The vertex the split is occuring at
		public int BaseVertexPoint; //Same as VertexPoint, but with all previous splits not accounted for. Used for removing the split later
		public int SplitAmount; //How much of a split
		public float SplitTime; //How long the split will occur
		public bool OutOfBounds; //Whether the split is on the wave, or out of bounds. Out of bounds waves are easier to calculate

		public float _timer; //The internal timer of the split
		//public float _extraUVOffset; //Any extra UV offset if any. Used internally
	}

	struct BlankerLine
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
	[Range(50,500)]
	[Tooltip("Determines how many verticies the wave will have. The more points, the higher quality the wave will be, but it can get laggier with high values")]
	int wavePoints = 50;
	[SerializeField]
	[Tooltip("The base height of the wave. Use this to adjust the overall height")]
	float baseHeight = 0.5f;
	[SerializeField]
	[Range(0f,1f)]
	[Tooltip("How squished the contents of the wave can get")]
	float squashFactor = 0f;
	[SerializeField]
	[Tooltip("An offset to the polygon collider")]
	Vector2 colliderOffset;
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

	List<Vector3> verticies;
	List<int> triangles;
	List<Vector3> uv;
	List<Vector2> colliderPoints;
	Mesh mesh;

	Material waveMaterial;
	new MeshRenderer renderer;
	MeshFilter filter;
	PolygonCollider2D polyCollider;

	//int xTileID;
	//int yTileID;

	SplitSorter splitSorter = new SplitSorter();
	List<SplitPoint> splits = new List<SplitPoint>();
	HashSet<int> splitVerticies = new HashSet<int>();
	List<BlankerLine> blankers = new List<BlankerLine>();

	//MeshCollider meshCollider;

	public float WaveWidth
	{
		get
		{
			return transform.localScale.x;
		}
	}

	void Awake()
	{
		mesh = GenerateWaveMesh(out verticies,out triangles,out uv);
		renderer = GetComponent<MeshRenderer>();
		filter = GetComponent<MeshFilter>();
		polyCollider = GetComponent<PolygonCollider2D>();
		colliderPoints = GenerateColliderPoints(verticies);
		UpdatePolygonCollider(colliderPoints);
		filter.mesh = mesh;

		//xTileID = Shader.PropertyToID("_TilingX");
		//yTileID = Shader.PropertyToID("_TilingY");
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

		AddSplitPoint(0f, SplitAmount, SplitTime);
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
		AddSplitPoint(1f, SplitAmount, SplitTime);

		for (int i = 0; i < splits.Count; i++)
		{
			Debug.Log("FINAL SPLIT = " + splits[i].VertexPoint);
		}

		for (int i = 0; i < verticies.Count; i += 2)
		{
			if (i - 2 >= 0 && Mathf.Abs(verticies[i].x - verticies[i - 2].x) < 0.00110102f)
			{
				Debug.Log("SPLIT FOUND: Left = " + (i - 2) + " Right = " + i);
			}
		}


		//AddBlankerLine(test_waveX, test_acceleration, test_terminalVelocity, test_deacceleration, 1 + (blankingColorDecay * SplitTime), test_startingWaitTime, test_spread, test_decayRate);
		//AddBlankerLine(test_waveX, -test_acceleration, -test_terminalVelocity, -test_deacceleration, 1 + (blankingColorDecay * SplitTime), test_startingWaitTime, test_spread, test_decayRate);

	}

	void Update()
	{
		CalculateSplits();
		CalculateBlankerLines();
		DecayBlankers();

		RunWaveCalculation();
	}

	private void DecayBlankers()
	{
		var decay = blankingColorDecay * Time.deltaTime;
		for (int i = 0; i < uv.Count; i++)
		{
			var uvTemp = uv[i];
			uvTemp.z -= decay;
			uvTemp.x -= ambientMovement * Time.deltaTime;
			//TODO : FIGURE OUT METHOD TO HAVE UV RESET
			//if (splits.Count == 0)
			//{

				/*if (uvTemp.x < 0f)
				{
					uvTemp.x += 1f;
				}
				if (uvTemp.x > 1f)
				{
					uvTemp.x -= 1f;
				}*/
			//}
			if (uvTemp.z < 0f)
			{
				uvTemp.z = 0f;
			}
			uv[i] = uvTemp;

			if (i - 1 >= 0)
			{
				//0.01010102
				var diff = (uv[i].x - uv[i - 1].x);
				if (diff > 0.02010102f)
				{
					Debug.Log("ERROR: DIFF = " + diff);
					Debug.Log("LEFT V = " + (i - 1));
					Debug.Log("RIGHT V = " + (i - 1));
				}
				//Debug.Log("UV DIFF WITH PREVIOUS = " + (uv[i].x - uv[i - 1].x));
			}
		}
	}

	private void CalculateBlankerLines()
	{
		//for (int i = 0; i < blankers.Count; i++)
		for (int i = blankers.Count - 1; i >= 0; i--)
		{
			//Debug.Log("RUNNING BLANKER");
			var blanker = blankers[i];

			if (blanker._intensity <= 0f)
			{
				blankers.RemoveAt(i);
				continue;
			}

			float intensity = 0;
			if (blanker.StartingWaitTime > 0f && blanker._waitTime > 0f)
			{
				intensity = ((blanker.StartingWaitTime - blanker._waitTime) / blanker.StartingWaitTime) * blanker._intensity;
			}
			else
			{
				intensity = blanker._intensity;
			}

			//Debug.Log("INTENSITY = " + intensity);

			if (blanker._waitTime == 0f)
			{
				//Do movement
				if (blanker._reachedTerminalVelocity)
				{
					var signBefore = Mathf.Sign(blanker._velocity);
					//var previous = blanker._velocity;
					blanker._velocity -= blanker.Deacceleration * Time.deltaTime;
					var signAfter = Mathf.Sign(blanker._velocity);
					if (signBefore != signAfter)
					{
						//Debug.Log("SIGN FLIP");
						//Debug.Log("PREVIOUS VALUE = " + previous);
						//Debug.Log("Current Value = " + blanker._velocity);
						blanker._velocity = 0f;
						blanker.Deacceleration = 0f;
					}
				}
				else
				{
					blanker._velocity += blanker.Acceleration * Time.deltaTime;
					if ((blanker.TerminalVelocity >= 0f && blanker._velocity >= blanker.TerminalVelocity) || (blanker.TerminalVelocity < 0f && blanker._velocity <= blanker.TerminalVelocity))
					{
						blanker._reachedTerminalVelocity = true;
						blanker._velocity = blanker.TerminalVelocity;
					}
				}

				var oldVertex = blanker.Vertex;

				blanker.WaveX += blanker._velocity * Time.deltaTime;
				blanker.Vertex = GetVertexAtWaveX(blanker.WaveX);

				if (blanker.Vertex >= oldVertex)
				{
					for (int b = oldVertex; b < blanker.Vertex; b++)
					{
						SetBlankIntensity(b, intensity);
					}
				}
				else
				{
					for (int b = blanker.Vertex - 1; b >= oldVertex; b--)
					{
						SetBlankIntensity(b, intensity);
					}
				}

				var worldPos = ConvertToWorldCoordinates(blanker.WaveX, 1f);
				Debug.DrawLine(worldPos, (Vector3)worldPos + new Vector3(0f, 10f, 0f), Color.magenta);

				blanker._intensity -= blanker.DecayRate * Time.deltaTime;
			}
			else
			{
				//Decrease the timer
				blanker._waitTime -= Time.deltaTime;
				if (blanker._waitTime < 0f)
				{
					blanker._waitTime = 0f;
				}
			}

			SetBlankIntensity(blanker.Vertex, intensity);
			SetBlankIntensity(blanker.Vertex + 1, intensity);

			if (splitVerticies.Contains(blanker.Vertex))
			{
				SetBlankIntensity(blanker.Vertex + 2, intensity);
				SetBlankIntensity(blanker.Vertex + 3, intensity);
			}

			if (splitVerticies.Contains(blanker.Vertex - 2))
			{
				SetBlankIntensity(blanker.Vertex - 2, intensity);
				SetBlankIntensity(blanker.Vertex - 1, intensity);
			}

			int spreadVertexCounter = blanker.Vertex;
			for (int z = 0; z < blanker.Spread; z++)
			{
				if (spreadVertexCounter >= 0)
				{
					SetBlankIntensity(spreadVertexCounter, Mathf.Min(intensity,1f) * (1 - (z / (float)blanker.Spread)));
					SetBlankIntensity(spreadVertexCounter + 1, Mathf.Min(intensity, 1f) * (1 - (z / (float)blanker.Spread)));

					if (splitVerticies.Contains(spreadVertexCounter - 2))
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
				if (spreadVertexCounter < verticies.Count)
				{
					SetBlankIntensity(spreadVertexCounter,  Mathf.Min(intensity, 1f) * (1 - (z / (float)blanker.Spread)));
					SetBlankIntensity(spreadVertexCounter + 1, Mathf.Min(intensity, 1f) * (1 - (z / (float)blanker.Spread)));

					if (splitVerticies.Contains(spreadVertexCounter))
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

			blankers[i] = blanker;
		}
	}

	private void CalculateSplits()
	{
		var textureScale = waveMaterial.mainTextureScale;
		for (int s = 0; s < splits.Count; s++)
		{
			var split = splits[s];

			var worldPos = ConvertToWorldCoordinates(split.WaveX, 0f);
			Debug.DrawLine(worldPos, worldPos + new Vector2(0f, 10f), Color.green);

			if (split._timer >= split.SplitTime)
			{
				//Debug.Log("Out of Bounds = " + split.OutOfBounds);
				//Debug.Log("Split Vertex = " + split.VertexPoint);
				//Debug.Log("Splits At Vertex = " + GetSplitsOnVertex(split.VertexPoint));
				if (!split.OutOfBounds && GetSplitsOnVertex(split.VertexPoint) == 1)
				{
					Debug.Log("REMOVING SPLIT At Position = " + split.WaveX);
					RemoveSplit(split);
					splitVerticies.Remove(split.VertexPoint);
					//TODO : TAKE INTO ACCOUNT ALL THE UV SUBTRACTIONS OF ALL THE SPLITS
				}
				/*else
				{
					for (int z = 0; z < splits.Count; z++)
					{
						if (z != s && splits[z].VertexPoint == split.VertexPoint)
						{
							//var uvDifference = uv[split.VertexPoint].x - uv[split.VertexPoint + 4].x;
							//var zTemp = splits[z];
							//zTemp._extraUVOffset += uvDifference;
							//splits[z] = zTemp;
						}
					}
				}*/

				splits.RemoveAt(s);
				continue;
			}

			var previousValue = splitCurve.Evaluate(split._timer / split.SplitTime);
			split._timer += Time.deltaTime;
			if (split._timer >= split.SplitTime)
			{
				split._timer = split.SplitTime;
			}
			splits[s] = split;
			var nextValue = splitCurve.Evaluate(split._timer / split.SplitTime);

			var difference = ((nextValue - previousValue) * split.SplitAmount) / textureScale.x;

			if (split.OutOfBounds)
			{
				if (split.WaveX >= 1f)
				{
					for (int i = 0; i < uv.Count; i++)
					{
						uv[i] = uv[i] + new Vector3(difference / 2f, 0f, 0f);
					}
				}
				else if (split.WaveX <= 0f)
				{
					for (int i = 0; i < uv.Count; i++)
					{
						uv[i] = uv[i] - new Vector3(difference / 2f, 0f, 0f);
					}
				}
			}
			else
			{
				for (int i = 0; i < uv.Count; i++)
				{
					if (i <= (split.VertexPoint + 1))
					{
						uv[i] = uv[i] + new Vector3(difference / 2f, 0f, 0f);
					}
					else
					{
						uv[i] = uv[i] - new Vector3(difference / 2f, 0f, 0f);
					}
				}
			}
		}
	}

	void RunWaveCalculation()
	{
		//for (int i = 0; i < wavePoints; i++)

		for (int i = 0; i < verticies.Count; i += 2)
		{
			var waveX = verticies[i].x;

			var heightValue = baseHeight - 0.5f + CalculateWave(waveX);
			/*if (heightValue <= 0.1f)
			{
				Debug.Log("Height Value = " + heightValue);
			}*/

			//heightValue + 0.5f

			verticies[1 + i] = new Vector3(waveX, heightValue, 0f);
			uv[1 + i] = new Vector3(uv[1 + i].x, Mathf.Lerp(heightValue + 0.5f,1f,squashFactor), uv[1 + i].z);

			/*var bottomUV = uv[i];
			bottomUV.z = blankingTest;
			uv[i] = bottomUV;*/
		}
		mesh.Clear();
		mesh.SetVertices(verticies);
		mesh.SetTriangles(triangles, 0);
		//mesh.vertices = verticies;
		mesh.SetUVs(0, uv);
		//mesh.uv = uv;

		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		UpdateColliderPoints(colliderPoints, verticies);
		UpdatePolygonCollider(colliderPoints);

		//waveMaterial.SetFloat(xTileID, transform.localScale.x);
		//waveMaterial.SetFloat(yTileID, transform.localScale.y);
	}

	Mesh GenerateWaveMesh(out List<Vector3> verticies, out List<int> triangles, out List<Vector3> uv)
	{
		var mesh = new Mesh();

		mesh.MarkDynamic();

		//verticies = new Vector3[wavePoints * 2];
		//triangles = new int[(wavePoints - 1) * 6];
		verticies = new List<Vector3>(wavePoints * 2);
		triangles = new List<int>((wavePoints - 1) * 6);
		//uv = new Vector3[wavePoints * 2];
		uv = new List<Vector3>(wavePoints * 2);

		for (int i = 0; i < wavePoints; i++)
		{
			//verticies[i * 2] = new Vector3(-0.5f + (i / (wavePoints - 1f)), -0.5f, 0f);
			//verticies[(i * 2) + 1] = new Vector3(-0.5f + (i / (wavePoints - 1f)), 0.5f, 0f);

			verticies.Add(new Vector3(-0.5f + (i / (wavePoints - 1f)), -0.5f, 0f));
			verticies.Add(new Vector3(-0.5f + (i / (wavePoints - 1f)), 0.5f, 0f));

			uv.Add(new Vector3(i / (wavePoints - 1f), 0f, 0f));
			uv.Add(new Vector3(i / (wavePoints - 1f), 1f, 0f));
			//uv[i * 2] = new Vector3(i / (wavePoints - 1f), 0f,0f);
			//uv[(i * 2) + 1] = new Vector3(i / (wavePoints - 1f), 1f,0f);
		}

		for (int i = 0; i < (wavePoints - 1); i++)
		{
			/*triangles[0 + (i * 6)] = 0 + (i * 2);
			triangles[1 + (i * 6)] = 1 + (i * 2);
			triangles[2 + (i * 6)] = 2 + (i * 2);

			triangles[3 + (i * 6)] = 1 + (i * 2);
			triangles[4 + (i * 6)] = 3 + (i * 2);
			triangles[5 + (i * 6)] = 2 + (i * 2);*/
			triangles.Add(0 + (i * 2));
			triangles.Add(1 + (i * 2));
			triangles.Add(2 + (i * 2));

			triangles.Add(1 + (i * 2));
			triangles.Add(3 + (i * 2));
			triangles.Add(2 + (i * 2));
		}

		//mesh.vertices = verticies;
		//mesh.triangles = triangles;
		mesh.SetVertices(verticies);
		mesh.SetTriangles(triangles, 0);
		mesh.SetUVs(0, uv);
		//mesh.uv = uv;
		mesh.RecalculateNormals();



		return mesh;
	}

	List<Vector2> GenerateColliderPoints(List<Vector3> verticies)
	{
		var length = verticies.Count;
		//Vector2[] colliderPoints = new Vector2[(length / 2) + 2];
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
		if (tempArray == null || tempArray.GetLength(0) != colliderPoints.Count)
		{
			tempArray = new Vector2[colliderPoints.Count];
		}

		for (int i = 0; i < colliderPoints.Count; i++)
		{
			tempArray[i] = colliderPoints[i];
		}

		polyCollider.points = tempArray;
	}



	float CalculateWave(float x)
	{
		return 1f + Mathf.Sin((x + Time.time) * Mathf.PI * 2f);
	}

	Vector2 ConvertToWorldCoordinates(float waveX, float waveY)
	{
		return ConvertToWorldCoordinates(new Vector2(waveX,waveY));
	}

	Vector2 ConvertToWorldCoordinates(Vector2 waveCoords)
	{
		var scale = transform.localScale;
		var position = transform.position;

		return new Vector2(Mathf.LerpUnclamped(position.x - (scale.x / 2f), position.x + (scale.x / 2f),waveCoords.x), Mathf.LerpUnclamped(position.y - (scale.y / 2f), position.y + (scale.y / 2f), waveCoords.y + baseHeight + 0.5f));
	}

	Vector2 ConvertToWaveCoordinates(float worldX, float worldY)
	{
		return ConvertToWaveCoordinates(new Vector2(worldX,worldY));
	}

	Vector2 ConvertToWaveCoordinates(Vector2 worldCoords)
	{
		var scale = transform.localScale;
		var position = transform.position;

		return new Vector2(UnclampedInverseLerp(position.x - (scale.x / 2f), position.x + (scale.x / 2f), worldCoords.x), UnclampedInverseLerp(position.y - (scale.y / 2f), position.y + (scale.y / 2f), worldCoords.y) - baseHeight - 0.5f);
	}

	static void UpdateUV(List<Vector3> list, int index, float x = float.NaN, float y = float.NaN, float z = float.NaN)
	{
		var oldValue = list[index];
		list[index] = new Vector3(x == float.NaN ? oldValue.x : x, y == float.NaN ? oldValue.y : y, z == float.NaN ? oldValue.z : z);
	}

	float UnclampedInverseLerp(float a, float b, float value)
	{
		return (value - a) / (b - a);
	}

	void AddSplitPoint(float waveX, int splitAmount, float splitTime)
	{
		float roundedPosition = Mathf.RoundToInt(waveX * (wavePoints - 1f)) / (wavePoints - 1f);


		bool splitAlreadyExists = false;
		SplitPoint sharedSplit = default(SplitPoint);

		for (int i = 0; i < splits.Count; i++)
		{
			if (splits[i].WaveX == roundedPosition)
			{
				//Debug.Log("Split Already Exists");
				splitAlreadyExists = true;
				sharedSplit = splits[i];
				break;
			}
		}

		bool outOfBounds = roundedPosition <= 0f || roundedPosition >= 1f;

		var split = new SplitPoint
		{
			WaveX = roundedPosition,
			SplitAmount = splitAmount,
			SplitTime = splitTime,
			OutOfBounds = outOfBounds,
			_timer = 0
		};

		if (splitAlreadyExists)
		{
			split.VertexPoint = sharedSplit.VertexPoint;
			split.BaseVertexPoint = sharedSplit.BaseVertexPoint;
		}

		Debug.Log("WAVE X = " + roundedPosition);
		//Debug.Log("OUT OF BOUNDS WAVE = " + outOfBounds);


		if (!outOfBounds && !splitAlreadyExists)
		{
			int baseVertexPosition = 0;
			int vertexPosition = GetVertexAtWaveX(roundedPosition, out baseVertexPosition);
			//var baseVertexPosition = Mathf.RoundToInt((roundedPosition * (wavePoints - 1)) * 2f);
			//var vertexPosition = baseVertexPosition;


			/*for (int i = 0; i < splits.Count; i++)
			{
				if (splits[i].WaveX < waveX)
				{
					vertexPosition += 2;
				}
			}*/

			split.VertexPoint = vertexPosition;
			split.BaseVertexPoint = baseVertexPosition;

			Debug.Log("VERTEX POINT = " + split.VertexPoint);

			splitVerticies.Add(split.VertexPoint);

			for (int i = 0; i < splits.Count; i++)
			{
				if (!splits[i].OutOfBounds && splits[i].WaveX > roundedPosition)
				{
					var splitTemp = splits[i];
					//splitDictionary.Remove(splitTemp.VertexPoint);
					splitTemp.VertexPoint += 2;
					splitTemp.WaveX = GetWaveXAtVertex(splitTemp.VertexPoint);
					//splitDictionary.Add(splitTemp.VertexPoint, splitTemp);
					splits[i] = splitTemp;
				}
			}

			for (int i = 0; i < blankers.Count; i++)
			{
				if (blankers[i].WaveX <= 1f && blankers[i].WaveX >= 0f && blankers[i].Vertex > vertexPosition)
				{
					var blankerTemp = blankers[i];
					blankerTemp.Vertex += 2;
					blankerTemp.WaveX = GetWaveXAtVertex(blankerTemp.Vertex);
					blankers[i] = blankerTemp;
				}
			}

			/*Debug.Log("SPLIT COUNT = " + splits.Count);

			if (splits.Count == 1)
			{
				var worldPos = ConvertToWorldCoordinates(split.WaveX, 0f);
				Debug.Log("WORLD POS = " + worldPos);
				Debug.DrawLine(worldPos,worldPos + new Vector2(0f,20f),Color.cyan,10f);
			}*/

			var bottomVertex = verticies[vertexPosition];
			var topVertex = verticies[vertexPosition + 1];

			//Debug.Log("Split Left" + vertexPosition);
			//Debug.Log("Split Right" + (vertexPosition + 2));

			verticies.Insert(vertexPosition + 2, topVertex);
			verticies.Insert(vertexPosition + 2, bottomVertex);

			var uvBottom = uv[vertexPosition];
			var uvTop = uv[vertexPosition + 1];

			/*var temp = uv[vertexPosition];
			temp.z = 1f;
			uv[vertexPosition] = temp;*/

			/*var temp = uv[vertexPosition];
			temp.z = 10f;
			uv[vertexPosition] = temp;

			temp = uv[vertexPosition + 1];
			temp.z = 10f;
			uv[vertexPosition + 1] = temp;*/

			//uvBottom.z = 1f;
			//uvTop.z = 1f;

			uv.Insert(vertexPosition + 2, uvTop);
			uv.Insert(vertexPosition + 2,uvBottom);

			//Debug.Log("Split Left Value = " + uv[vertexPosition]);
			//Debug.Log("Split Right Value = " + uv[vertexPosition + 2]);

			colliderPoints.Insert((vertexPosition / 2) + 1,colliderPoints[vertexPosition / 2]);

			var trianglePosition = baseVertexPosition * 3;

			for (int i = trianglePosition; i < triangles.Count; i++)
			{
				triangles[i] += 2;
			}
		}

		splits.Add(split);
		//splitDictionary.Add(split.VertexPoint, split);
		splits.Sort(splitSorter);
	}

	void RemoveSplit(SplitPoint split)
	{
		Debug.Log("Removing with Vertex Point = " + split.VertexPoint);
		//Debug.Log("Left UV = " + uv[split.VertexPoint].x);
		//Debug.Log("Right UV = " + uv[split.VertexPoint + 2].x);

		var uvDifference = uv[split.VertexPoint].x - uv[split.VertexPoint + 2].x;// + split._extraUVOffset;
		//Debug.Log("________________Removing With Difference = " + uvDifference);

		for (int i = 0; i < splits.Count; i++)
		{
			if (!splits[i].OutOfBounds && splits[i].VertexPoint > split.VertexPoint)
			{
				var splitTemp = splits[i];
				splitTemp.VertexPoint -= 2;
				splits[i] = splitTemp;
			}
		}

		if (Mathf.Abs(verticies[split.VertexPoint].x - verticies[split.VertexPoint + 2].x) < 0.00110102f)
		{
			Debug.Log("Vertex at " + split.VertexPoint + " is a valid split!");
		}
		else
		{
			Debug.Log("Vertex at " + split.VertexPoint + " is NOT a valid split!");

			for (int i = 0; i < verticies.Count; i += 2)
			{
				if (i - 2 >= 0 && Mathf.Abs(verticies[i - 2].x - verticies[i].x) < 0.00110102f)
				{
					Debug.Log("But the vertex at " + (i - 2) + "is a valid split!");
					break;
				}
			}
		}

		verticies.RemoveAt(split.VertexPoint + 3);
		verticies.RemoveAt(split.VertexPoint + 2);

		uv.RemoveAt(split.VertexPoint + 3);
		uv.RemoveAt(split.VertexPoint + 2);

		colliderPoints.RemoveAt((split.VertexPoint / 2) + 1);

		for (int i = split.VertexPoint + 2; i < uv.Count; i++)
		{
			var currentUV = uv[i];
			currentUV.x += uvDifference;// + split._extraUVOffset;
			uv[i] = currentUV;
		}

		var trianglePosition = split.BaseVertexPoint * 3;

		for (int i = trianglePosition; i < triangles.Count; i++)
		{
			triangles[i] -= 2;
		}

		//Debug.Log("UV DIFFERENCE = " + uvDifference);
		//Debug.Log("UV Difference After = " + (uv[split.VertexPoint].x - uv[split.VertexPoint + 2].x));
	}

	void AddBlankerLine(float waveX, float acceleration, float terminalVelocity, float deacceleration, float startingIntensity, float startingWaitTime, float spread, float decayRate)
	{
		Debug.Log("___ADDING BLANKER");
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

	static float SmoothEval(float t)
	{
		return (6 * Mathf.Pow(t, 5f)) - (15 * Mathf.Pow(t, 4f)) + (10 * Mathf.Pow(t,3f));
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

	float GetWaveXAtVertex(int vertexPosition)
	{
		for (int i = splits.Count - 1; i >= 0; i--)
		{
			if (vertexPosition > splits[i].VertexPoint)
			{
				vertexPosition -= 2;
			}
		}
		return (vertexPosition / 2) / (wavePoints - 1f);
	}

	void SetBlankIntensity(int uvPoint, float intensity)
	{
		var point = uv[uvPoint];
		uv[uvPoint] = point.With(z: Math.Max(point.z,intensity));
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
}
