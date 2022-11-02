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
            dM.DisplayNextSentence();
        }else if(nextConve == true)
        {
            //Get the ConversationManager
            cManager = GameObject.Find("ConversationManager");
            cM = cManager.GetComponent<ConversationManager>();
            cM.DisplayNextConversationSentence();
        }
    }

    public void PressEtoProgressDialogue()
    {
        JudgeNext();
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
