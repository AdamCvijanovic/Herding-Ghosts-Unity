using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject playerNameplate;
    public GameObject customerNameplate;

    public Image playerIMG;
    public Image customerIMG;
    public Color colorChange;

    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI customerNameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;
    public Animator playerAnimator;
    public Animator customerAnimator;


    private Queue<string> sentences;
    public int sentenceCounter = 0;
    public int[] playerTalking;
    public int[] customerTalking;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        colorChange.a = 1;
    }

    public void StartDialogue(Dialogue convisation)
    {
        //Debug.Log("Starting conversation between "+ player.name + "and " + customer.name);
        animator.SetBool("IsOpen", true);
        playerAnimator.SetBool("PlayerActive", true);
        customerAnimator.SetBool("CustomerActive", true);

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
        animator.SetBool("IsOpen", false);
        playerAnimator.SetBool("PlayerActive", false);
        customerAnimator.SetBool("CustomerActive", false);
        Time.timeScale = 1f;
    }
}

