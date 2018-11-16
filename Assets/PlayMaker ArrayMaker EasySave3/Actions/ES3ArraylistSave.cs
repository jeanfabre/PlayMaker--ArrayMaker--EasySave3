//	(c) Jean Fabre, 2011-2018 All rights reserved.
//	http://www.fabrejean.net

// INSTRUCTIONS
// Drop a PlayMakerArrayList script onto a GameObject, and define a unique name for reference if several PlayMakerArrayList coexists on that GameObject.
// In this Action interface, link that GameObject in "arrayListObject" and input the reference name if defined. 
// Note: You can directly reference that GameObject or store it in an Fsm variable or global Fsm variable

using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ES3PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Easy Save 3")]
	[Tooltip("Saves a PlayMaker Array List Proxy component")]
	public class ES3ArraylistSave : SettingsAction
	{
		
		[ActionSection("Arraylist Set up")]
		
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker ArrayList Proxy component")]
		[CheckForComponent(typeof(PlayMakerArrayListProxy))]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Author defined Reference of the PlayMaker ArrayList Proxy component (necessary if several component coexists on the same GameObject)")]
		public FsmString reference;
		
		[ActionSection("Easy Save Set Up")]
		
		[Tooltip("A unique key for this save. For example, the object's name if no other objects use the same name.")]
		public FsmString key = "";

		PlayMakerArrayListProxy _proxy;

		public override void OnReset()
		{
			gameObject = null;
			reference = null;

			key = new FsmString(){UseVariable=true};
		}
		
		public override void Enter()
		{
			_proxy =  CollectionsActions.GetArrayListProxyPointer (Fsm.GetOwnerDefaultTarget (gameObject), reference.Value,false);
			if (_proxy != null)
			{
				Execute();
			}

		}

		public void Execute()
		{

			string _key = key.Value;
			if (string.IsNullOrEmpty(_key))
			{
				_key = Fsm.GameObjectName+"/"+Fsm.Name+"/Arraylist/"+reference;
			}

			var _list = new List<object>();

			foreach(object item in _proxy.arrayList)
			{
				_list.Add(item);
			}
			
		
			ES3.Save<List<object>>(_key,_list, GetSettings());
		
			Finish();
		}
	
	}
}