using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possessable : MonoBehaviour
{

    public Ghost _possessedBy;
    public bool _isPossessed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PossessObject(Ghost ghost)
    {
        _possessedBy = ghost;
        _isPossessed = true;
        ghost.gameObject.SetActive(false);
    }

    public void UnPossessObject()
    {
        _possessedBy.gameObject.SetActive(true);
        _possessedBy = null;
        _isPossessed = false;
    }
}
