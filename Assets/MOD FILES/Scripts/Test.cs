using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Components;

public class Test : MonoBehaviour 
{
	WeaverAnimationPlayer animPlayer;
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
	}
}
