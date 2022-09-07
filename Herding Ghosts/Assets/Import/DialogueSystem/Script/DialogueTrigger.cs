using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue convisation;
    public bool talkNow = false;


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
        FindObjectOfType<DialogueManager>().StartDialogue(convisation);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        Debug.Log("Player entred chat area");
        if(other.gameObject.CompareTag("Player"))
        {
            
            DialogueTrigger dt = gameObject.GetComponent<DialogueTrigger>();
            dt.TriggerDialogue();
            Time.timeScale = 0f;
        }
    }

    private void Talk()
    {
        DialogueTrigger bt = gameObject.GetComponent<DialogueTrigger>();
        bt.TriggerDialogue();
        Time.timeScale = 0f;
    }
}