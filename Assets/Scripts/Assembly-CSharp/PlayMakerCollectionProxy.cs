using UnityEngine;
using System.Collections.Generic;

public class PlayMakerCollectionProxy : MonoBehaviour
{
	public enum VariableEnum
	{
		GameObject = 0,
		Int = 1,
		Float = 2,
		String = 3,
		Bool = 4,
		Vector3 = 5,
		Rect = 6,
		Quaternion = 7,
		Color = 8,
		Material = 9,
		Texture = 10,
		Vector2 = 11,
		AudioClip = 12,
	}

	public bool showEvents;
	public bool showContent;
	public bool TextureElementSmall;
	public bool condensedView;
	public bool liveUpdate;
	public string referenceName;
	public bool enablePlayMakerEvents;
	public string addEvent;
	public string setEvent;
	public string removeEvent;
	public int contentPreviewStartIndex;
	public int contentPreviewMaxRows;
	public VariableEnum preFillType;
	public int preFillObjectTypeIndex;
	public int preFillCount;
	public List<string> preFillKeyList;
	public List<bool> preFillBoolList;
	public List<Color> preFillColorList;
	public List<float> preFillFloatList;
	public List<GameObject> preFillGameObjectList;
	public List<int> preFillIntList;
	public List<Material> preFillMaterialList;
	public List<Object> preFillObjectList;
	public List<Quaternion> preFillQuaternionList;
	public List<Rect> preFillRectList;
	public List<string> preFillStringList;
	public List<Texture2D> preFillTextureList;
	public List<Vector2> preFillVector2List;
	public List<Vector3> preFillVector3List;
	public List<AudioClip> preFillAudioClipList;
}
