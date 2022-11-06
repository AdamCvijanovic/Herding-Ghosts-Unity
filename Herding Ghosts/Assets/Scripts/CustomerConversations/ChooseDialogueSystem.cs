using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseDialogueSystem : MonoBehaviour
{
    private GameObject cManager;
    private GameObject dManager;

    [SerializeField]
    private DialogueManager dM;
    [SerializeField]
    private ConversationManager cM;

    public bool nextDial = false;
    public bool nextConve = false;

    void Update()
    {
         //cManager = GameObject.Find("ConversationManager");
        cM = FindObjectOfType<ConversationManager>();
        dM = FindObjectOfType<DialogueManager>();
    }

    public void PressEtoProgressDialogue()
    {
        JudgeNext();
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

    public void EndAllDialogue()
    {
        if(nextDial == true)
        {
            Debug.Log("End Dialogue");
            dM.EndDialogue();
        }
        else if(nextConve == true)
        {
            Debug.Log("End Conversation");
            cM.EndConversation();
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