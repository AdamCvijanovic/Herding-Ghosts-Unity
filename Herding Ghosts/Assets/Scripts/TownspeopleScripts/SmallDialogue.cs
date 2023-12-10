using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmallDialogue : MonoBehaviour
{

    public Canvas dialogueCanvas;
    public TextMeshProUGUI dialogueText;

    public List<string> phraseList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        AssignVarRefs();


    }

    private void AssignVarRefs()
    {
        if (dialogueCanvas == null)
        {
            dialogueCanvas = GetComponentInChildren<Canvas>();
        }

        if (dialogueText == null)
        {
            dialogueText = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerPickup>())
            ActivateCanvas();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        DeActivateCanvas();

    }

    private void ActivateCanvas()
    {
        dialogueCanvas.enabled = true;
        SelectPhrase();
    }

    private void DeActivateCanvas()
    {
        dialogueCanvas.enabled = false;
    }

    private void SelectPhrase()
    {
        dialogueText.text = phraseList[Random.Range(0, phraseList.Count)];
    }


}
