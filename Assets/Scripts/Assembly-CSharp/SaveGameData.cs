using System;
using Modding;

[Serializable]
public class SaveGameData
{
	public PlayerData playerData;
	public SceneData sceneData;
	public ModSettingsDictionary modData;
	public SerializableStringDictionary LoadedMods;
	public string Name;
}
