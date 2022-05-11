using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyLogic enemyLogic;

    EnemyManager _enemyMngr;

    // Start is called before the first frame update
    void Start()
    {
        _enemyMngr = FindObjectOfType<EnemyManager>();

        if (enemyLogic == null)
            enemyLogic = GetComponent<EnemyLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
