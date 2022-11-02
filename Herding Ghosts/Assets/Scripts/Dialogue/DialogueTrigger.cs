using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue conversation;

    private GameObject chooseDialogue;
    private ChooseDialogueSystem cDS;

    public bool talkNow = false;


    void Start()
    {
        chooseDialogue = GameObject.Find("DialogueElements");
        cDS = chooseDialogue.GetComponent<ChooseDialogueSystem>();
    }

    void Update()
    {
        if(talkNow == true)
        {
            talkNow = false;
            Talk();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(conversation);
    }

    //private void OnTriggerEnter2D(Collider2D other) 
    //{
    //    //clear UI of other elements
    //    FindObjectOfType<CanvasManager>().DisableOtherUIElements();
    //
    //    Debug.Log("Player entred chat area");
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        cDS.NDTrue();
    //        DialogueTrigger dt = gameObject.GetComponent<DialogueTrigger>();
    //        dt.TriggerDialogue();
    //        Time.timeScale = 0f;
    //    }
    //}

    public void ActivateDialogue()
    {
        if(FindObjectOfType<DialogueManager>().dialogueActive != true)
        {
            //clear UI of other elements
            FindObjectOfType<CanvasManager>().DisableOtherUIElements();

            cDS.NDTrue();
            DialogueTrigger dt = gameObject.GetComponent<DialogueTrigger>();
            dt.TriggerDialogue();
            Time.timeScale = 0f;
        }
        else
        {
            ProgressDialogue();
        }
        
    }

    private void Talk()
    {
        DialogueTrigger bt = gameObject.GetComponent<DialogueTrigger>();
        bt.TriggerDialogue();
        Time.timeScale = 0f;
    }

    public void ProgressDialogue()
    {
        FindObjectOfType<ChooseDialogueSystem>().PressEtoProgressDialogue();
    }
}