using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public int randMin = 1;
    public int randMax = 8;

    private Conversations convChosen;

    public Conversations convOne;
    public Conversations convTwo;
    public Conversations convThree;
    public Conversations convFour;
    public Conversations convFive;
    public Conversations convSix;
    public Conversations convSeven;

    private GameObject chooseDialogue;
    private ChooseDialogueSystem cDS;

    public bool talkNow = false;

    void Start()
    {
        ConversationRandomizer();
        chooseDialogue = GameObject.Find("DialogueElements");
        cDS = chooseDialogue.GetComponent<ChooseDialogueSystem>();
    }

    void Update()
    {
        if(talkNow == true)
        {
            talkNow = false;
            TalkConvisation();
        }
    }
    
    public void ConversationRandomizer()
    {
        var result = Random.Range(randMin, randMax);
        Debug.Log(result); // lets us now which one was chosen
        switch (result)
        {
        case 1:
            convChosen = convOne;
            break;
        case 2:
            convChosen = convTwo;
            break;
        case 3:
            convChosen = convThree;
            break;
        case 4:
            convChosen = convFour;
            break;
        case 5:
            convChosen = convFive;
            break;
        case 6:
            convChosen = convSix;
            break;
        case 7:
            convChosen = convSeven;
            break;
        default:
            print ("Error in ConversationTrigger.cs");
            break;
        }
    }

    public void TriggerConvisation()
    {
        FindObjectOfType<ConversationManager>().StartConvisation(convChosen);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //Debug.Log("Player entred chat area");
        if(other.gameObject.CompareTag("Player"))
        {
            cDS.NCTrue();
            ConversationTrigger dt = gameObject.GetComponent<ConversationTrigger>();
            dt.TriggerConvisation();
            Time.timeScale = 0f;
        }
    }

    private void TalkConvisation()
    {
        ConversationTrigger bt = gameObject.GetComponent<ConversationTrigger>();
        bt.TriggerConvisation();
        Time.timeScale = 0f;
    }
}