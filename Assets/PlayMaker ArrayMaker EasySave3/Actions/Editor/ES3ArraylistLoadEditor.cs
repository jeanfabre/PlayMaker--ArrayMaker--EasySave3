using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMakerEditor;
using ES3PlayMaker;
using UnityEditor;

namespace HutongGames.PlayMaker.Actions
{

	[CustomActionEditor(typeof(ES3ArraylistLoad))]
	public class ES3ArraylistLoadEditor : SettingsEditor
	{
		public override void DrawGUI()
		{
			EditField("gameObject");
			EditField("reference");
			EditField("key");
		}
	}
}