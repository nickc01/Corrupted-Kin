using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class MapMarkerMenu : MonoBehaviour
{
	public float xPos_start;
	public float xPos_interval;
	public float markerY;
	public float markerZ;
	public float uiPause;
	public FadeGroup fadeGroup;
	public AudioSource audioSource;
	public AudioClip placeClip;
	public AudioClip removeClip;
	public AudioClip cursorClip;
	public AudioClip failureClip;
	public VibrationData placementVibration;
	public GameObject cursor;
	public PlayMakerFSM cursorTweenFSM;
	public GameObject placementCursor;
	public GameObject placementBox;
	public GameObject changeButton;
	public GameObject cancelButton;
	public TextMeshPro actionText;
	public GameObject marker_b;
	public GameObject marker_r;
	public GameObject marker_w;
	public GameObject marker_y;
	public TextMeshPro amount_b;
	public TextMeshPro amount_r;
	public TextMeshPro amount_w;
	public TextMeshPro amount_y;
	public Vector3 placementCursorOrigin;
	public float panSpeed;
	public float placementCursorMinX;
	public float placementCursorMaxX;
	public float placementCursorMinY;
	public float placementCursorMaxY;
	public List<GameObject> collidingMarkers;
	public GameObject placeEffectPrefab;
	public GameObject removeEffectPrefab;
	public Sprite spriteBlue;
	public Sprite spriteRed;
	public Sprite spriteYellow;
	public Sprite spriteWhite;
}
