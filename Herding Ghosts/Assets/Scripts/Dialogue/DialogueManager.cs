using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public bool isTherePlayer = true;
    public bool isThereCustomer = true;

    public bool playerImageColored = false;
    public bool customerImageColored = false;

    public int imgChangeCounter = 0;
    public int maxSentSize = 8;

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
        customerNameplate.SetActive(false);
        playerNameplate.SetActive(false);
        
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
        Debug.Log("Number: " + num);
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

    public void StartDialogue(Dialogue convisation)
    {

        imgChangeCounter = 0;
        //customerIMG.sprite = grandmaImg;
        //Debug.Log("Starting conversation between "+ player.name + "and " + customer.name);
        animator.SetBool("IsOpen", true);
        
        if(isTherePlayer == true){playerAnimator.SetBool("PlayerActive", true);}
        if(isThereCustomer == true){customerAnimator.SetBool("CustomerActive", true);}

        sentenceCounter = 0;
        //player name
        playerNameText.text = convisation.playerName;
        //customer name
        customerNameText.text = convisation.customerName;

        sentences.Clear();
        foreach (string sentence in convisation.sentences)
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
        Debug.Log(imgChangeCounter);
        if(imgChangeCounter <= maxSentSize)
        {
            Debug.Log("imgChangeCounter");
            ChangeCustomerImageSprite(imagePlacement[imgChangeCounter]);
            imgChangeCounter++;
        }
        
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
                if(isThereCustomer == true){customerNameplate.SetActive(true);}
                if(playerImageColored == true){playerIMG.color = colorChange;}
                customerIMG.color = Color.white;
           }  
        }

        for(int j = 0; j < customerTalking.Length + 1; j++)
        {
           if(sentenceCounter == playerTalking[j])
           {
                Debug.Log("Player");
                if(isTherePlayer == true){playerNameplate.SetActive(true);}
                customerNameplate.SetActive(false);
                if(customerImageColored == true){customerIMG.color = colorChange;}
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