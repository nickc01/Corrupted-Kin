using System;
using UnityEngine;
using GlobalEnums;

[Serializable]
public class ControllerImage
{
	[SerializeField]
	public string name;
	[SerializeField]
	public GamepadType gamepadType;
	[SerializeField]
	public Sprite sprite;
	[SerializeField]
	public ControllerButtonPositions buttonPositions;
	public float displayScale;
	public float offsetY;
	public bool canRemap;
}
