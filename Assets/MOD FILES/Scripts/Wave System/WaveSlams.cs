using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;

[CreateAssetMenu(fileName = "Wave Slams", menuName = "Wave Slams")]
public class WaveSlams : ScriptableObject
{
	public BurrowWave BurrowWave;
	public AmbientWave AmbientWave;
	public SlamWave LeftOffscreenWave;
	public SlamWave RightOffscreenWave;
	public SlamWave LeftWave;
	public SlamWave RightWave;


	public AmbientWave SpawnAmbientWave(WaveSystem system)
	{
		var wave = Pooling.Instantiate(AmbientWave, system.transform.position, Quaternion.identity);
		system.AddGenerator(wave);
		return wave;
	}

	public void SpawnSlam(WaveSystem system, Vector3 position, float spacing = 2.8f)
	{
		SlamWave left, right;
		SpawnSlam(system, position, out left, out right, spacing);
	}

	public void SpawnSlam(WaveSystem system, Vector3 position, out SlamWave leftWave, out SlamWave rightWave, float spacing = 2.8f)
	{
		leftWave = Pooling.Instantiate(LeftWave, new Vector3(position.x - spacing, position.y, position.z), Quaternion.identity);
		system.AddGenerator(leftWave);
		leftWave.SpawnBlanker(position.x);

		rightWave = Pooling.Instantiate(RightWave, new Vector3(position.x + spacing, position.y, position.z), Quaternion.identity);
		system.AddGenerator(rightWave);
		rightWave.SpawnBlanker(position.x);
	}

	public void SpawnSlam(WaveSystem system, float x_position, float spacing = 2.8f)
	{
		SlamWave left, right;
		SpawnSlam(system, new Vector3(x_position,system.transform.position.y,system.transform.position.z), out left, out right,spacing);
	}

	public void SpawnSlam(WaveSystem system, float x_position, out SlamWave leftWave, out SlamWave rightWave, float spacing = 2.8f)
	{
		SpawnSlam(system, new Vector3(x_position, system.transform.position.y, system.transform.position.z), out leftWave, out rightWave,spacing);
	}

	public SlamWave SpawnOffScreenWave(WaveSystem system, Vector3 position)
	{
		if (position.x > system.transform.position.x)
		{
			var instance = Pooling.Instantiate(LeftOffscreenWave, position, Quaternion.identity);
			system.AddGenerator(instance);
			return instance;
		}
		else
		{
			var instance = Pooling.Instantiate(RightOffscreenWave, position, Quaternion.identity);
			system.AddGenerator(instance);
			return instance;
		}
	}

	public SlamWave SpawnOffScreenWave(WaveSystem system, float x_position)
	{
		return SpawnOffScreenWave(system, new Vector3(x_position, system.transform.position.y, system.transform.position.z));
	}
}

