/*
 * Based on the epic post found here:
 * baraujo.net/unity3d-making-singletons-from-scriptableobjects-automatically
 * 
 */

using System.Linq;
using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject  {
	static T _instance = null;
	public static T data {
		get {
			if (!_instance)
				_instance = Resources.FindObjectsOfTypeAll<T> ().FirstOrDefault ();
			return _instance;
		}
	}
}
