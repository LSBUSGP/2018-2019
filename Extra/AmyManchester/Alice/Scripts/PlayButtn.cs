﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtn : MonoBehaviour {

	// Use this for initialization
	public void PlayGame () 
	{
		SceneManager.LoadScene ("Level 1");
	}


	public void QuitGame ()
	{
		Application.Quit();
	}
}
