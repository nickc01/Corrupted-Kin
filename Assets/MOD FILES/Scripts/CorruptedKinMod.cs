using Modding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WeaverCore;
using WeaverCore.Attributes;

namespace Kin
{
	public class CorruptedKin : WeaverMod
	{
		[OnInit]
		static void Init()
		{
			//WeaverLog.Log("Hooks getting added!");
			ModHooks.Instance.GetPlayerBoolHook += Instance_GetPlayerBoolHook;
			//ModHooks.Instance.GetPlayerFloatHook += Instance_GetPlayerFloatHook;
			//ModHooks.Instance.GetPlayerIntHook += Instance_GetPlayerIntHook;
			//ModHooks.Instance.GetPlayerStringHook += Instance_GetPlayerStringHook;
		}

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
			if (originalSet == "infectedKnightDreamDefeated")
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
			return "0.0.0.1 alpha";
		}
	}
}

