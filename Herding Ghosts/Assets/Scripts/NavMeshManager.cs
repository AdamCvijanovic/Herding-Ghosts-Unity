using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    //BEst not have a singleton actually
    //public static NavMeshManager Instance { get; private set; }


    public NavMeshSurface2d navMeshSurface;

    private void Awake()
    {
        //Singleton Constructor
        //if (Instance != null && Instance != this)
        //{
        //    Destroy(this);
        //}
        //else
        //{
        //    Instance = this;
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface2d>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNavMesh()
    {
        Debug.Log("REbuild");
        navMeshSurface.BuildNavMesh();
    }

    
}

