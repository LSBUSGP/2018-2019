﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TartScore : MonoBehaviour {

	public int health;
	public int numOfHearts;
	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite EmptyHeart;

	void Update (){
		if (health > numOfHearts){
			health = numOfHearts;
			
		for (int i = 0; i < hearts.Length; i++) {
			if (i < health) {
				hearts [i].sprite = fullHeart;
			} else {
				hearts [i].sprite = EmptyHeart;
			}

			if (i < numOfHearts) {
				hearts [i].enabled = true;
			}
			else {
				hearts [i].enabled = false;
			}
		}
	}
}
}



