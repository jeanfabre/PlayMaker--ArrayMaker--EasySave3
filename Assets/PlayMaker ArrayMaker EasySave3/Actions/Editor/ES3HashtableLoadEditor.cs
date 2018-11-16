using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMakerEditor;
using ES3PlayMaker;
using UnityEditor;

namespace HutongGames.PlayMaker.Actions
{

	[CustomActionEditor(typeof(ES3HashtableLoad))]
	public class ES3HashtableLoadEditor : SettingsEditor
	{
		public override void DrawGUI()
		{
			EditField("gameObject");
			EditField("reference");
			EditField("key");
		}
	}
}