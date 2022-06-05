using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WinTextUI : MonoBehaviour
{

    public TextMeshProUGUI tmpText;
    public string pickup = "Daughters Tasks: ";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText(DaughterLogic daughter)
    {
        tmpText.text = pickup + daughter._tasksCompleted + "/" + daughter._numTasksToComplete;
    }
}
