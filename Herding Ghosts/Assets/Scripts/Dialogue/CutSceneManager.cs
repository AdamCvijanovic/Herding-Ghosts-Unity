using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutSceneManager : MonoBehaviour
{
    public bool isTherePlayer = true;
    public bool isThereCustomer = true;

    public bool playerImageColored = false;
    public bool customerImageColored = false;

    public int imgChangeCounter = 0;
    public int maxSentSize = 8;

    public GameObject panelButton;

    public GameObject playerNameplate;
    public GameObject customerNameplate;

    //player images
    public Image playerIMG;
    public List<Sprite> playerImageList;
    
    //customer images
    public Image customerIMG;
    public List<Sprite> customerImageList; 
    public Color colorChange;

    //backgroundImages
    public Image backgroundIMG;
    public List<Sprite> backgroundImageList;

    //textmesh pro GUIs
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI customerNameText;
    public TextMeshProUGUI dialogueText;

    //Animators
    public Animator animator;
    public Animator playerAnimator;
    public Animator customerAnimator;

    [SerializeField]
    private GameObject chooseDialogue;
    [SerializeField]
    private ChooseDialogueSystem cDS;

    public Queue<Sentence> sentences;
    [SerializeField]
    private int sentenceCounter = 0;
    public int[] playerTalking;
    public int[] customerTalking;
    public int[] imagePlacement;

    public bool cutSceneActive;

    public CutSceneTrigger cutSceneTrigger;

    // Start is called before the first frame update
    void Start()
    {
        cutSceneTrigger = FindObjectOfType<CutSceneTrigger>();
        

        sentences = new Queue<Sentence>();
        colorChange.a = 1;
        chooseDialogue = GameObject.Find("CutSceneElements");
        cDS = chooseDialogue.GetComponent<ChooseDialogueSystem>();
        customerNameplate.SetActive(false);
        playerNameplate.SetActive(false);
        panelButton.SetActive(false);

        StartCoroutine(WaitOneFrame());

    }

    IEnumerator WaitOneFrame()
    {

        //returning 0 will make it wait 1 frame
        yield return new WaitForEndOfFrame();

        cutSceneTrigger.TriggerCutScene();


    }

    public void ChangePlayerImageSprite(int num)
    {
        playerIMG.sprite = playerImageList[num];

        Debug.Log("Number: " + num);
            
    }

    public void ChangePlayerImageSprite(Sprite sprite)
    {
        playerIMG.sprite = sprite;
    }

    public void ChangeCustomerImageSprite(int num)
    {

        customerIMG.sprite = customerImageList[num];

        Debug.Log("Number: " + num);
            
    }

    public void ChangeCustomerImageSprite(Sprite sprite)
    {
        customerIMG.sprite = sprite;
    }

    public void StartCutScene(CutSceneDialogue cutSceneDialogue)
    {
        cutSceneActive = true;

        imgChangeCounter = 0;
        //Debug.Log("Starting conversation between "+ player.name + "and " + customer.name);
        animator.SetBool("IsOpen", true);
        
        if(isTherePlayer == true){playerAnimator.SetBool("PlayerActive", true);}
        if(isThereCustomer == true){customerAnimator.SetBool("CustomerActive", true);}

        panelButton.SetActive(true);

        sentenceCounter = 0;
        //player name
        playerNameText.text = cutSceneDialogue.playerName;
        //customer name
        customerNameText.text = cutSceneDialogue.customerName;

        sentences.Clear();
        foreach (Sentence sentence in cutSceneDialogue.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log("THE AMOUNT OF SENTENCES IS " + sentences.Count);
        }
        
        
        DisplayNextSentence();
         
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndCutscene();
            return;
        }
        Sentence currSentence = sentences.Dequeue();
        Debug.Log("imgChangeCounter" + imgChangeCounter);
        if(imgChangeCounter <= maxSentSize)
        {
            Debug.Log("imgChangeCounter" + imgChangeCounter + "Is Less Than or Equal to maxSentSize");
            //ChangeCustomerImageSprite(imagePlacement[imgChangeCounter]);
            ChangeCustomerImageSprite(currSentence.customerImage);
            //ChangePlayerImageSprite(imagePlacement[imgChangeCounter]);
            ChangePlayerImageSprite(imagePlacement[imgChangeCounter]);
            imgChangeCounter++;
        }
        
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currSentence.sentenceText));
        
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

        for(int j = 0; j < playerTalking.Length; j++)
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

    public void EndCutscene()
    {
        Debug.Log("End of conversation.");
        cDS.NCOff();
        animator.SetBool("IsOpen", false);
        playerAnimator.SetBool("PlayerActive", false);
        customerAnimator.SetBool("CustomerActive", false);
        Time.timeScale = 1f;
        panelButton.SetActive(false);
        cutSceneActive = false;
    }

    public void ActivateStartGameButton()
    {

    }
}