using System;
using GlobalEnums;
using InControl;

[Serializable]
public class GameSettings
{
	public SupportedLanguages gameLanguage;
	public int backerCredits;
	public int showNativeAchievementPopups;
	public bool isNativeInput;
	public bool vibrationMuted;
	public float masterVolume;
	public float musicVolume;
	public float soundVolume;
	public int fullScreen;
	public int vSync;
	public int useDisplay;
	public float overScanAdjustment;
	public float brightnessAdjustment;
	public int overscanAdjusted;
	public int brightnessAdjusted;
	public int targetFrameRate;
	public bool frameCapOn;
	public int particleEffectsLevel;
	public ShaderQualities shaderQuality;
	public ControllerMapping controllerMapping;
	public Key jumpKey;
	public Key attackKey;
	public Key dashKey;
	public Key castKey;
	public Key superDashKey;
	public Key dreamNailKey;
	public Key quickMapKey;
	public Key quickCastKey;
	public Key inventoryKey;
	public Key upKey;
	public Key downKey;
	public Key leftKey;
	public Key rightKey;
}
