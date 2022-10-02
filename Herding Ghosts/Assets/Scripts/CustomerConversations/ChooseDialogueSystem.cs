using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDialogueSystem : MonoBehaviour
{
    private GameObject cManager;
    private GameObject dManager;

    private DialogueManager dM;
    private ConversationManager cM;

    public bool nextDial = false;
    public bool nextConve = false;

    void Update()
    {
        /* cManager = GameObject.Find("ConversationManager");
        cM = cManager.GetComponent<ConversationManager>(); */
    }

    public void JudgeNext()
    {
        //Get the DialogueManager
        dManager = GameObject.Find("DialogueManager");
        dM = dManager.GetComponent<DialogueManager>();

        if(nextDial == true)
        {
            Debug.Log("CDS One");
            dM.DisplayNextSentence();
            Debug.Log("CDS Two");
        }else if(nextConve == true)
        {
            Debug.Log("CDS Three");
            //Get the ConversationManager
            cManager = GameObject.Find("ConversationManager");
            Debug.Log("CDS Four");
            cM = cManager.GetComponent<ConversationManager>();
            Debug.Log("CDS Five"); 
            cM.DisplayNextConversationSentence();
            Debug.Log("CDS Six");
        }
    }

    public void NDTrue()
    {
        nextDial = true;
        nextConve = false;
    }

    public void NCTrue()
    {
        nextConve = true;
        nextDial = false;
    }
    public void NCOff()
    {
        nextConve = false;
        nextDial = false;
    }
}
