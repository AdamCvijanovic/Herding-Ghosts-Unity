using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public bool isTherePlayer = true;
    public bool isTherecustomer = true;

    public GameObject playerNameplate;
    public GameObject customerNameplate;

    //player images
    public Image playerIMG;
    public Sprite playerIMGOne;
    public Sprite playerIMGTwo;
    public Sprite playerIMGThree;
    public Sprite playerIMGFour;
    
    //customer images
    public Image customerIMG;
    public Sprite customerIMGOne;
    public Sprite customerIMGTwo;
    public Sprite customerIMGThree;
    public Sprite grandmaImg;
    public Color colorChange;

    //textmesh pro GUIs
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI customerNameText;
    public TextMeshProUGUI dialogueText;

    //Animators
    public Animator animator;
    public Animator playerAnimator;
    public Animator customerAnimator;

    private GameObject chooseDialogue;
    private ChooseDialogueSystem cDS;

    public Queue<string> sentences;
    private int sentenceCounter = 0;
    public int[] playerTalking;
    public int[] customerTalking;
    public int[] imagePlacement;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        colorChange.a = 1;
        chooseDialogue = GameObject.Find("DialogueElements");
        cDS = chooseDialogue.GetComponent<ChooseDialogueSystem>();

        //retrieve customer image from Canvas
        customerIMG = FindObjectOfType<CanvasManager>().customerIMG;
        playerIMG = FindObjectOfType<CanvasManager>().playerIMG;
        
    }

    public void ChangePlayerImageSprite(int num)
    {
        if(num == 1)
        {
            playerIMG.sprite = playerIMGOne;
        }else if(num == 2)
        {
            playerIMG.sprite = playerIMGTwo;
        }else if(num == 3)
        {
            playerIMG.sprite = playerIMGThree;
        }else if(num == 4)
        {
            playerIMG.sprite = playerIMGFour;
        }
            
    }

    public void ChangeCustomerImageSprite(int num)
    {
        if(num == 1)
        {
            customerIMG.sprite = customerIMGOne;
        }else if(num == 2)
        {
            customerIMG.sprite = customerIMGTwo;
        }else if(num == 3)
        {
            customerIMG.sprite = customerIMGThree;
        }
            
    }

    public void StartDialogue(Dialogue conversation)
    {
        
        customerIMG.sprite = grandmaImg;
        //Debug.Log("Starting conversation between "+ player.name + "and " + customer.name);
        animator.SetBool("IsOpen", true);
        
        if(isTherePlayer == true){playerAnimator.SetBool("PlayerActive", true);}
        if(isTherecustomer == true){customerAnimator.SetBool("CustomerActive", true);}

        sentenceCounter = 0;
        //player name
        playerNameText.text = conversation.playerName;
        //customer name
        customerNameText.text = conversation.customerName;

        sentences.Clear();
        foreach (string sentence in conversation.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
         
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //sentence = sentence.Replace("greenhouse","<b><color=#4AB055>Greenhouse</color></b>"); // has glitch during text output
        
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
      for(int i = 0; i < customerTalking.Length; i++)
        {
           if(sentenceCounter == customerTalking[i])
           {
                Debug.Log("Customer");
                playerNameplate.SetActive(false);
                customerNameplate.SetActive(true);
                playerIMG.color = colorChange;
                customerIMG.color = Color.white;
           }  
        }

        for(int j = 0; j < customerTalking.Length + 1; j++)
        {
           if(sentenceCounter == playerTalking[j])
           {
                Debug.Log("Player");
                playerNameplate.SetActive(true);
                customerNameplate.SetActive(false);
                customerIMG.color = colorChange;
                playerIMG.color = Color.white;
           }
              
        }
       
        sentenceCounter++; 
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
        cDS.NCOff();
        animator.SetBool("IsOpen", false);
        playerAnimator.SetBool("PlayerActive", false);
        customerAnimator.SetBool("CustomerActive", false);
        Time.timeScale = 1f;
    }
}