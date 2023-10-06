using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    //Singleton
    //public static EnemyManager EnemyManagerSGLTN { get; private set; }

    [SerializeField]
    private List<Ghost> ghosts = new List<Ghost>();

    [SerializeField]
    private int MaxGhosts;

    private void Awake()
    {
        //Singleton Constructor (unnecesary, we can just use global search on Awak and store ref in a local var)
        //if (EnemyManagerSGLTN != null && EnemyManagerSGLTN != this)
        //{
        //    Destroy(this);
        //    return;
        //}
        //EnemyManagerSGLTN = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        FetchExistingGhosts();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FetchExistingGhosts()
    {
        foreach (Ghost e in FindObjectsOfType<Ghost>())
        {
            ghosts.Add(e);
        }
    }

    public void AddGhost(Ghost ghost)
    {
        ghosts.Add(ghost);
         
    }

    public void RemoveGhost(Ghost ghost)
    {
        ghosts.Remove(ghost);
    }

    public System.Collections.ObjectModel.ReadOnlyCollection<Ghost> GetConstListOfGhosts()
    {
        return ghosts.AsReadOnly();
    }


    public bool CheckMax()
    {
        return ghosts.Count < MaxGhosts;
    }



}
