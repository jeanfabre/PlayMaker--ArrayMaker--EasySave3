//	(c) Jean Fabre, 2011-2018 All rights reserved.
//	http://www.fabrejean.net

// INSTRUCTIONS
// Drop a PlayMakerArrayList script onto a GameObject, and define a unique name for reference if several PlayMakerArrayList coexists on that GameObject.
// In this Action interface, link that GameObject in "arrayListObject" and input the reference name if defined. 
// Note: You can directly reference that GameObject or store it in an Fsm variable or global Fsm variable

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ES3PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Easy Save 3")]
	[Tooltip("Loads a PlayMaker Arraylist Proxy component")]
	public class ES3ArraylistLoad : SettingsAction
	{

		[ActionSection("Arraylist Set up")]

		[RequiredField]
		[Tooltip("The Game Object to add the Hashtable Component to.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker arrayList proxy component ( necessary if several component coexists on the same GameObject")]
		public FsmString reference;

		[ActionSection("Easy Save Set Up")]

		[Tooltip("A unique key for this load. For example, the object's name if no other objects use the same name.")]
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

			_proxy.arrayList.Clear ();

			List<object> _list = ES3.Load<List<object>> (key.Value, GetSettings ());

			if (_list != null)
			{
				foreach (var x in _list)
				{
					_proxy.arrayList.Add (x);
				}
			}


		}

	}
}