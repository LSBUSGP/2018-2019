using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    
    private Text winText;

    private float delay = 0.1f;

    [TextArea]
    public string fullText;
    private string currentText = "";
    
    void Start()
    {
        //winText = GetComponent<Text>();
    }

    public void SendText()
    {
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}