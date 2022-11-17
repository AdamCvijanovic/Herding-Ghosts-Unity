using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ghost : MonoBehaviour
{
    [SerializeField]
    GhostLogic ghostLogic;

    [SerializeField]
    Pickup ghostPickup;

    protected GhostManager _ghostMngr;

    // Start is called before the first frame update
    void Awake()
    {
        _ghostMngr = FindObjectOfType<GhostManager>();

        if (ghostLogic == null)
            ghostLogic = GetComponent<GhostLogic>();

        if (ghostPickup == null)
            ghostPickup = GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Pickup GetGhostPickup()
    {
        return ghostPickup;
    }

    public void PossessObject(Possessable possessable)
    {
       
    }



}
