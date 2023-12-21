using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeWindowedWorkstation : MonoBehaviour
{
    public Interactable interactable;

    public WorkbenchUIPrototype workbenchUIPrototype;


    public float maxDistance;
    public float dstToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();

        if (workbenchUIPrototype == null)
        {
            workbenchUIPrototype = FindObjectOfType<WorkbenchUIPrototype>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDistanceDisableUI();
    }


    public void UseWorkbench()
    {
        Debug.Log("Using Workbench");
        workbenchUIPrototype.ActivatePanel();
    }

    public void PlayerDistanceDisableUI()
    {
        dstToPlayer = Vector3.Distance(FindObjectOfType<Player>().transform.position, transform.position);
        if (dstToPlayer >= maxDistance)
        {
            workbenchUIPrototype.DeActivatePanel();
        }
    }



}
