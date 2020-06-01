using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnClick : MonoBehaviour
{
	// this code loads the scene when buttons are pressed
	public void LoadScene(string Level1)
	{
		SceneManager.LoadScene (("Main"));
	}
	public void LoadCredits(string Credits)
	{
		SceneManager.LoadScene (("Credits")); 
	}
}

