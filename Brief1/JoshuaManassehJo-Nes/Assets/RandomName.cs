using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    
    public List<string> consonants = new List<string>();
    public List<string> vowels = new List<string>();

    public string firstName = null;
    public string secondName = null;

    string lastLetter;
    char secondLastLetter;
    public List<string> existingNames = new List<string>();

    public string newRandomName = null;

    public List<string> obscenities = new List<string>();

    public void NewName()
    {
        NewFirstName(true);
        NewFirstName(false);
        
        if (!existingNames.Contains(firstName + " " + secondName)
            && !obscenities.Contains(firstName) 
            && !obscenities.Contains(secondName))
        {
            existingNames.Add(firstName + " " + secondName);
            Debug.Log(firstName + " " + secondName);
        } else
        {        
            NewName();
        }
        firstName = null;
        secondName = null;
    }

    public void NewFirstName(bool firstOrSecondName)
    {

        int firstNameLength = Random.Range(3,10);
        int consonantOrVowel = Random.Range(1, 3);

        if (consonantOrVowel == 1)
        {
            string firstLetter = consonants[Random.Range(0, consonants.Count)];
            newRandomName += firstLetter;
            lastLetter = firstLetter;
        }
        else if (consonantOrVowel == 2)
        {
            string firstLetter = vowels[Random.Range(0, vowels.Count)];
            newRandomName += firstLetter;
            lastLetter = firstLetter;
        }

        for (int i = 0; i <= firstNameLength - 1; i++)
        {
            consonantOrVowel = Random.Range(1, 3);
            
            if (newRandomName.Length > 2)
            {
                char secondLastLetter = newRandomName[newRandomName.Length - 1];
            }

            if (consonantOrVowel == 1 && !consonants.Contains(secondLastLetter.ToString()) && lastLetter != "q")
            {                
                string randomConsonant = consonants[Random.Range(0, consonants.Count)];
                newRandomName += randomConsonant;
                lastLetter = randomConsonant;

            } else if (!vowels.Contains(secondLastLetter.ToString()))
            {
                if (lastLetter == "q")
                {
                    newRandomName += "u";
                    lastLetter = "u";
                } else
                {
                    string randomVowel = vowels[Random.Range(0, vowels.Count)];
                    newRandomName += randomVowel;
                    lastLetter = randomVowel;

                }

            }

            
        }

        if (firstOrSecondName == true)
        {
            firstName = newRandomName;
        } else if (firstOrSecondName == false)
        {
            secondName = newRandomName;
        }
        newRandomName = null;



    }

}
