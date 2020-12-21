using UnityEngine;
using UnityEngine.UI;

public class MenuSetting : MonoBehaviour
{
	public enum MenuSettingType
	{
		Resolution = 10,
		FullScreen = 11,
		VSync = 12,
		MonitorSelect = 14,
		FrameCap = 15,
		ParticleLevel = 16,
		ShaderQuality = 17,
		GameLanguage = 33,
		GameBackerCredits = 34,
		NativeAchievements = 35,
		NativeInput = 36,
		ControllerRumble = 37,
	}

	public MenuSettingType settingType;
	public MenuOptionHorizontal optionList;
}
