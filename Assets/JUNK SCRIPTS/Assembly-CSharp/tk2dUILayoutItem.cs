using System;
using UnityEngine;

[Serializable]
public class tk2dUILayoutItem
{
	public tk2dBaseSprite sprite;
	public tk2dUIMask UIMask;
	public tk2dUILayout layout;
	public GameObject gameObj;
	public bool snapLeft;
	public bool snapRight;
	public bool snapTop;
	public bool snapBottom;
	public bool fixedSize;
	public float fillPercentage;
	public float sizeProportion;
	public bool inLayoutList;
	public int childDepth;
	public Vector3 oldPos;
}
