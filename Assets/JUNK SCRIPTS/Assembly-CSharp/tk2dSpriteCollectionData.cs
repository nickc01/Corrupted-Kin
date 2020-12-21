using UnityEngine;

public class tk2dSpriteCollectionData : MonoBehaviour
{
	public int version;
	public bool materialIdsValid;
	public bool needMaterialInstance;
	public tk2dSpriteDefinition[] spriteDefinitions;
	public bool premultipliedAlpha;
	public Material material;
	public Material[] materials;
	public Texture[] textures;
	public TextAsset[] pngTextures;
	public int[] materialPngTextureId;
	public FilterMode textureFilterMode;
	public bool textureMipMaps;
	public bool allowMultipleAtlases;
	public string spriteCollectionGUID;
	public string spriteCollectionName;
	public string assetName;
	public bool loadable;
	public float invOrthoSize;
	public float halfTargetHeight;
	public int buildKey;
	public string dataGuid;
	public bool managedSpriteCollection;
	public bool hasPlatformData;
	public string[] spriteCollectionPlatforms;
	public string[] spriteCollectionPlatformGUIDs;
}
