using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanging : MonoBehaviour {

	public static SceneChanging instance;

	void Awake () {
		instance = this;
	}

	public void ChangeSceneNoSync (int newScene){
		SceneManager.LoadScene (newScene);
	}

	public void ChangeSceneASync (int newScene){
		SceneManager.LoadSceneAsync (newScene);
	}

	public void NextSceneNoSync () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void NextSceneAsync () {
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void PreviousSceneNoSync () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);

	}

	public void PreviousSceneASync () {
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex - 1);

	}
}
