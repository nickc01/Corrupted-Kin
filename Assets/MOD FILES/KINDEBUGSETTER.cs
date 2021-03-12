using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;

[ExecuteInEditMode]
public class KINDEBUGSETTER : MonoBehaviour 
{
	void Start()
	{
		WeaverLog.Log("START");


		var kin = GetComponent<CorruptedKin>();

		var components = GetComponents<MonoBehaviour>();

		foreach (var field in typeof(CorruptedKin).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
		{
			foreach (var component in components)
			{
				if (!(component is CorruptedKin))
				{
					var type = component.GetType();
					var otherField = type.GetField(field.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
					if (otherField != null)
					{
						otherField.SetValue(component, field.GetValue(kin));
					}
				}
			}
		}

	}

}
