using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Utilities;

public abstract class WaveGenerator
{
	public InfectionWave Wave { get; set; }

	public abstract float Calculate(float x);
}


public struct SplitPoint
{
	public float WaveX;
	public float SplitSpeed;
}



public class InfectionWave : MonoBehaviour 
{
	[SerializeField]
	[Range(50,500)]
	int wavePoints = 50;
	[SerializeField]
	float baseHeight = 0.5f;
	[SerializeField]
	[Range(0f,1f)]
	float squashFactor = 0f;

	[Range(0f,1f)]
	public float blankingTest = 0f;

	Vector3[] verticies;
	int[] triangles;
	List<Vector3> uv;
	Vector2[] colliderPoints;
	Mesh mesh;

	Material waveMaterial;
	new MeshRenderer renderer;
	MeshFilter filter;
	PolygonCollider2D polyCollider;

	int xTileID;
	int yTileID;

	List<SplitPoint> splits = new List<SplitPoint>();

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

		xTileID = Shader.PropertyToID("_TilingX");
		yTileID = Shader.PropertyToID("_TilingY");
		waveMaterial = renderer.sharedMaterial;

		RunWaveCalculation();

		AddSplitPoint(0.5f, 0.01f);
	}

	void Update()
	{

		foreach (var split in splits)
		{
			var worldPos = ConvertToWorldCoordinates(split.WaveX, 0f);
			Debug.DrawLine(worldPos, worldPos + new Vector2(0f, 10f), Color.green);

			var uvCount = uv.Count / 2;
			for (int i = 0; i < uvCount; i++)
			{
				var position = i / (uvCount - 1f);

				if (position < split.WaveX)
				{
					//Debug.Log("UV Before = " + uv[i * 2]);
					//Debug.Log("UV After = " + uv[i * 2].x + (split.SplitSpeed * Time.deltaTime));

					var oldUV = uv[i * 2];
					uv[i * 2] = new Vector3(oldUV.x + (split.SplitSpeed * Time.deltaTime),oldUV.y,oldUV.z);
					oldUV = uv[(i * 2) + 1];
					uv[(i * 2) + 1] = new Vector3(oldUV.x + (split.SplitSpeed * Time.deltaTime), oldUV.y, oldUV.z);

					//UpdateUV(uv, i * 2, uv[i * 2].x + (split.SplitSpeed * Time.deltaTime));
					//UpdateUV(uv, (i * 2) + 1, uv[(i * 2) + 1].x + (split.SplitSpeed * Time.deltaTime));
				}
				else if (position > split.WaveX)
				{
					var oldUV = uv[i * 2];
					uv[i * 2] = new Vector3(oldUV.x - (split.SplitSpeed * Time.deltaTime), oldUV.y, oldUV.z);
					oldUV = uv[(i * 2) + 1];
					uv[(i * 2) + 1] = new Vector3(oldUV.x - (split.SplitSpeed * Time.deltaTime), oldUV.y, oldUV.z);
					//UpdateUV(uv, i * 2, uv[i * 2].x - (split.SplitSpeed * Time.deltaTime));
					//UpdateUV(uv, (i * 2) + 1, uv[(i * 2) + 1].x - (split.SplitSpeed * Time.deltaTime));
				}
			}
		}

		RunWaveCalculation();
	}


	void RunWaveCalculation()
	{
		for (int i = 0; i < wavePoints; i++)
		{
			var heightValue = baseHeight - 0.5f + CalculateWave(i / (float)wavePoints);
			/*if (heightValue <= 0.1f)
			{
				Debug.Log("Height Value = " + heightValue);
			}*/

			//heightValue + 0.5f

			verticies[1 + (i * 2)] = new Vector3(-0.5f + i / (wavePoints - 1f), heightValue, 0f);
			uv[1 + (i * 2)] = new Vector3(uv[1 + (i * 2)].x, Mathf.Lerp(heightValue + 0.5f,1f,squashFactor), blankingTest);

			var bottomUV = uv[i * 2];
			bottomUV.z = blankingTest;
			uv[i * 2] = bottomUV;
		}
		mesh.vertices = verticies;
		mesh.SetUVs(0, uv);
		//mesh.uv = uv;

		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		UpdateColliderPoints(colliderPoints, verticies);
		UpdatePolygonCollider(colliderPoints);

		//waveMaterial.SetFloat(xTileID, transform.localScale.x);
		//waveMaterial.SetFloat(yTileID, transform.localScale.y);
	}

	Mesh GenerateWaveMesh(out Vector3[] verticies, out int[] triangles, out List<Vector3> uv)
	{
		var mesh = new Mesh();

		mesh.MarkDynamic();

		verticies = new Vector3[wavePoints * 2];
		triangles = new int[(wavePoints - 1) * 6];
		//uv = new Vector3[wavePoints * 2];
		uv = new List<Vector3>(wavePoints * 2);

		for (int i = 0; i < wavePoints; i++)
		{
			verticies[i * 2] = new Vector3(-0.5f + (i / (wavePoints - 1f)), -0.5f, 0f);
			verticies[(i * 2) + 1] = new Vector3(-0.5f + (i / (wavePoints - 1f)), 0.5f, 0f);

			uv.Add(new Vector3(i / (wavePoints - 1f), 0f, blankingTest));
			uv.Add(new Vector3(i / (wavePoints - 1f), 1f, blankingTest));
			//uv[i * 2] = new Vector3(i / (wavePoints - 1f), 0f,0f);
			//uv[(i * 2) + 1] = new Vector3(i / (wavePoints - 1f), 1f,0f);
		}

		for (int i = 0; i < (wavePoints - 1); i++)
		{
			triangles[0 + (i * 6)] = 0 + (i * 2);
			triangles[1 + (i * 6)] = 1 + (i * 2);
			triangles[2 + (i * 6)] = 2 + (i * 2);

			triangles[3 + (i * 6)] = 1 + (i * 2);
			triangles[4 + (i * 6)] = 3 + (i * 2);
			triangles[5 + (i * 6)] = 2 + (i * 2);
		}

		mesh.vertices = verticies;
		mesh.triangles = triangles;
		mesh.SetUVs(0, uv);
		//mesh.uv = uv;
		mesh.RecalculateNormals();



		return mesh;
	}

	Vector2[] GenerateColliderPoints(Vector3[] verticies)
	{
		var length = verticies.GetLength(0);
		Vector2[] colliderPoints = new Vector2[(length / 2) + 2];
		UpdateColliderPoints(colliderPoints,verticies);
		return colliderPoints;
	}

	void UpdateColliderPoints(Vector2[] colliderPoints, Vector3[] verticies)
	{
		var length = verticies.GetLength(0);
		for (int i = 0; i < (length / 2); i++)
		{
			colliderPoints[i] = verticies[1 + (i * 2)];
		}
		colliderPoints[length / 2] = new Vector2(0.5f, -0.5f);
		colliderPoints[(length / 2) + 1] = new Vector2(-0.5f, -0.5f);
	}

	void UpdatePolygonCollider(Vector2[] colliderPoints)
	{
		polyCollider.points = colliderPoints;
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

	public void AddSplitPoint(float waveX, float splitSpeed)
	{
		splits.Add(new SplitPoint
		{
			WaveX = Mathf.RoundToInt(waveX * (wavePoints - 1f)) / (wavePoints - 1f),
			SplitSpeed = splitSpeed
		});
	}
}
