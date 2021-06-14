using Modding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Attributes;
using WeaverCore.Settings;

namespace KinMod
{
	public class CorruptedKin : WeaverMod
	{
		[OnInit]
		static void Init()
		{
			//WeaverLog.Log("Hooks getting added!");
			ModHooks.GetPlayerBoolHook += Instance_GetPlayerBoolHook;
			ModHooks.LanguageGetHook += Instance_LanguageGetHook;
			//ModHooks.Instance.GetPlayerStringHook += Instance_GetPlayerStringHook;
			//ModHooks.Instance.GetPlayerFloatHook += Instance_GetPlayerFloatHook;
			//ModHooks.Instance.GetPlayerIntHook += Instance_GetPlayerIntHook;
			//ModHooks.Instance.GetPlayerStringHook += Instance_GetPlayerStringHook;
		}

		private static string Instance_LanguageGetHook(string key, string sheetTitle)
		{
			if (key == "NAME_LOST_KIN")
			{
				return "Corrupted Kin";
			}
			else if (key == "GG_S_LOST_KIN")
			{
				return "Lost god corrupted by infection";
			}
			else
			{
				return WeaverCore.Language.GetStringInternal(key, sheetTitle);
			}

			//WeaverLog.Log("KEY = " + key);
			//WeaverLog.Log("Sheet Title = " + sheetTitle);
			//var value = WeaverCore.Language.GetStringInternal(key, sheetTitle);
			//WeaverLog.Log("Value = " + value);

			//return value;
		}

		/*private static string Instance_GetPlayerStringHook(string stringName)
		{
			WeaverCore.Language.GetString
			return PlayerData.instance.
		}*/

		/*private static string Instance_GetPlayerStringHook(string stringName)
		{
			WeaverLog.Log("String Value = " + stringName);
			var value = PlayerData.instance.GetStringInternal(stringName);
			WeaverLog.Log("Value = " + value);
			return value;
		}

		private static int Instance_GetPlayerIntHook(string intName)
		{
			WeaverLog.Log("Int Value = " + intName);
			var value = PlayerData.instance.GetIntInternal(intName);
			WeaverLog.Log("Value = " + value);
			return value;
		}

		private static float Instance_GetPlayerFloatHook(string floatName)
		{
			WeaverLog.Log("Float Value = " + floatName);
			var value = PlayerData.instance.GetFloatInternal(floatName);
			WeaverLog.Log("Value = " + value);
			return value;
		}*/

		private static bool Instance_GetPlayerBoolHook(string originalSet)
		{
			var settings = Panel.GetSettings<CorruptedKinSettings>();
			if (originalSet == "infectedKnightDreamDefeated" && settings != null /*&& settings.EnableInAbyss*/)
			{
				return false;
			}
			else
			{
				return PlayerData.instance.GetBoolInternal(originalSet);
			}
		}

		public override string GetVersion()
		{
			return "1.1.0.0";
		}
	}
}

