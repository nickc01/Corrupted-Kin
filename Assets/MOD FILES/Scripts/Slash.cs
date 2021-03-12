using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Components;
using WeaverCore.Utilities;

public class Slash : MonoBehaviour 
{
	public float ActivationDelay = 0f;
	public bool Unparent = false;
	[SerializeField]
	bool autoFlipPosition = false;

	SpriteRenderer spriteRenderer;

	Vector3 localPosition;
	Vector3 localRotation;
	Transform oldParent;

	void OnEnable()
	{
		GetComponent<WeaverAnimationPlayer>().OnClipFinish = WeaverCore.Enums.OnDoneBehaviour.Disable;


		spriteRenderer = GetComponent<SpriteRenderer>();

		StartCoroutine(MainRoutine());
	}

	IEnumerator MainRoutine()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).gameObject.SetActive(true);
		}
		if (ActivationDelay > 0f)
		{
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(ActivationDelay);
		}

		spriteRenderer.enabled = true;

		localPosition = transform.localPosition;
		localRotation = transform.localRotation.eulerAngles;

		if (Unparent)
		{
			oldParent = transform.parent;
			var oldScale = transform.localScale;
			transform.SetParent(null, true);
			transform.localScale = oldScale;
		}

	}

	void OnDisable()
	{
		if (Unparent && transform.parent == null)
		{
			UnboundCoroutine.Start(SetParent());
			//transform.parent = oldParent;
			//transform.localPosition = localPosition;
			//transform.localRotation = Quaternion.Euler(localRotation);
		}
		else
		{
			transform.localPosition = localPosition;
			transform.localRotation = Quaternion.Euler(localRotation);
		}
		StopAllCoroutines();
	}

	IEnumerator SetParent()
	{
		if (Application.isPlaying)
		{
			Debug.LogError("SETTING PARENT");
			transform.SetParent(oldParent, true);
			transform.localPosition = localPosition;
			transform.localRotation = Quaternion.Euler(localRotation);
		}
		yield break;
	}
}
