using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Customer _customer;

    public int randMin = 1;
    public int randMax = 8;

    private Conversation convChosen;

    public Conversation convOne;
    public Conversation convTwo;
    public Conversation convThree;
    public Conversation convFour;
    public Conversation convFive;
    public Conversation convSix;
    public Conversation convSeven;

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
            TalkConversation();
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

    public void TriggerConversation()
    {
        var cManager = FindObjectOfType<ConversationManager>();


        if (cManager.conversationActive != true)
        {
            if (!cManager.GetCustomerTalk())
                FindObjectOfType<CustomerManager>().ActivateTimerUI();

            cManager.StartConversation(convChosen);
            
            
            
            Time.timeScale = 0f;
        }
        else
        {
            ProgressDialogue();
        }
            
    }

    //private void OnTriggerEnter2D(Collider2D other) 
    //{
    //    //clear UI of other elements
    //    FindObjectOfType<CanvasManager>().DisableOtherUIElements();
    //
    //    //Debug.Log("Player entred chat area");
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        cDS.NCTrue();
    //        ConversationTrigger dt = gameObject.GetComponent<ConversationTrigger>();
    //        dt.TriggerConversation();
    //        Time.timeScale = 0f;
    //    }
    //}

    public void ActivateConversation()
    {
        if (_customer.GetCustomerLogic().currentState == CustomerLogic.CustomerState.Leaving)
        {
            Debug.Log("Customer Leaving, Cannot Talk");
        }
        else
        {
            //this shoudl really be in the logic section
            if (_customer.IsPlayerHoldingItem() && _customer.IsPlayerHoldingDesiredItem())
            {
                _customer.PickupDesiredItem();
                _customer.GetCustomerLogic().SetState(CustomerLogic.CustomerState.Leaving);
                if (FindObjectOfType<PlayerPickup>()._isHolding)
                {
                    FindObjectOfType<PlayerPickup>().Drop();
                }
            }
            else if (!_customer.IsPlayerHoldingItem())
            {
                //clear UI of other elements
                FindObjectOfType<CanvasManager>().DisableOtherUIElements();

                cDS.NCTrue();
                ConversationTrigger dt = gameObject.GetComponent<ConversationTrigger>();
                dt.TriggerConversation();
                //Time.timeScale = 0f;
            }
        }
    }

    private void TalkConversation()
    {
        ConversationTrigger bt = gameObject.GetComponent<ConversationTrigger>();
        bt.TriggerConversation();
        Time.timeScale = 0f;
    }

    public void ProgressDialogue()
    {
        FindObjectOfType<ChooseDialogueSystem>().PressEtoProgressDialogue();
    }
}