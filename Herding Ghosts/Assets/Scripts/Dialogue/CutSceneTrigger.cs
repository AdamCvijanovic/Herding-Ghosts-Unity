using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    public CutSceneDialogue cutSceneConvo;

    [SerializeField]
    private GameObject chooseCutScene;
    [SerializeField]
    private ChooseDialogueSystem cDS;

    public bool talkNow = false;


    void Start()
    {
        //chooseCutScene = GameObject.Find("CutSceneElements");
        cDS = chooseCutScene.GetComponent<ChooseDialogueSystem>();
    }

    void Update()
    {
        if (talkNow == true)
        {
            talkNow = false;
            Talk();
        }
    }

    public void TriggerCutScene()
    {
        FindObjectOfType<CutSceneManager>().StartCutScene(cutSceneConvo);
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
        if (FindObjectOfType<DialogueManager>().dialogueActive != true)
        {
            //clear UI of other elements
            FindObjectOfType<CanvasManager>().DisableOtherUIElements();

            cDS.NDTrue();
            DialogueTrigger dt = gameObject.GetComponent<DialogueTrigger>();
            dt.TriggerDialogue();
            //Time.timeScale = 0f;
        }
        else
        {
            ProgressDialogue();
        }

    }

    private void Talk()
    {
        CutSceneTrigger cSct = gameObject.GetComponent<CutSceneTrigger>();
        cSct.TriggerCutScene();
        Time.timeScale = 0f;
    }

    public void ProgressDialogue()
    {
        FindObjectOfType<ChooseDialogueSystem>().PressEtoProgressDialogue();
    }
}