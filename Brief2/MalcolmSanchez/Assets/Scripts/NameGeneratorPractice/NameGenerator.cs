using System.Collections;

// Gives access to lists.
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour {

	// List<string> = What data type will it be expecting, this is a string data type list.
	public List<string> names;

	// What stores every line that are in the list from programs such as .txt files.
	public string[] lines;


	// Use this for initialization
	void Start ()
	{
		// The "=" needs to reference a folder.
		// Reources.Load<--What you want to load--> 
		// ("--Name of file--"); = Whatever file you called it.
		TextAsset nameText = Resources.Load<TextAsset>("Names");

		// 
		lines = nameText.text.Split("\n"[0]);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(50,50,50,50), "generate name"))
			{
				Debug.Log (lines[Random.Range(0,lines.Length)]);
			}
	}
}
