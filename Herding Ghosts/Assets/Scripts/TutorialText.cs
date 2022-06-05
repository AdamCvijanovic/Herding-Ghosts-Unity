using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public TextMeshProUGUI tmpText;

    public string pickup = "Press E to pickup: ";
    public string use = "Press LMB to use: ";

    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void UpdateTextPickup(string text)
    {
        tmpText.text = pickup + text;
    }

    public void DisableText()
    {
        tmpText.text = " ";
    }

    public void UpdateTextUse(string text)
    {
        tmpText.text = use + text;
    }
}
