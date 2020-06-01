using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;

public class InfiniteNames : MonoBehaviour {




	static string GeneratePronounceableName(int length)
			{

		//char[] vowels = "aeiou".ToCharArray (); = You don't need to ToCharArray these because strings are already arrays. You can just define two constants.
		//char[] consonants = "bcdfghjklmnpqrstvwxyz".ToCharArray (); = You don't need to ToCharArray these because strings are already arrays. You can just define two constants.


		//List<char> chosenVowels = new List<char> (); = You don't need two lists that you join later. You can use the StringBuilder and create the name right away.
		//List<char> chosenConsonants = new List<char> (); = You don't need two lists that you join later. You can use the StringBuilder and create the name right away.

				const string vowels = "aeiou";
				const string consonants = "bcdfghjklmnpqrstvwxyz";

				var rnd = new System.Random();

				length = length % 2 == 0 ? length : length + 1;

		var name = new char [length];


		for (var i = 0; i < length; i += 2)
				{
			name [i] = vowels [rnd.Next (vowels.Length)];
			name [i+1] = consonants [rnd.Next (consonants.Length)];
				}

				return name.ToString();
			}
}