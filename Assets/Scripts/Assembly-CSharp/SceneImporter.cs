using UnityEngine;

public class SceneImporter : MonoBehaviour
{
	public string xml_folder;
	public string prefabs_folder;
	public string xml_doc_filename;
	public string level_name;
	public int tile_size;
	public int scene_width;
	public int scene_height;
	public int layer_count;
	public GameObject placeholder_prefab;
	public int importMode;
	public bool lookForPrefabsFirst;
	public bool debug_output;
}
