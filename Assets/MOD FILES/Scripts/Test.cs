using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Audio;
using WeaverCore.Components;

public class Test : MonoBehaviour 
{
	void Start()
	{
		var source = GetComponent<AudioSource>();

		source.outputAudioMixerGroup = Music.MainGroup;
	}


	/*WeaverAnimationPlayer animPlayer;
	// Use this for initialization
	void Start () 
	{
		animPlayer = GetComponent<WeaverAnimationPlayer>();
		StartCoroutine(AnimationTester());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}



	IEnumerator AnimationTester()
	{
		while (true)
		{
			foreach (var clipName in animPlayer.AnimationData.ClipNames)
			{
				yield return animPlayer.PlayAnimationTillDone(clipName,true);
				//animPlayer.PlayAnimation(clipName);

				//yield return new WaitForSeconds(2f);
			}
		}
	}*/
}
