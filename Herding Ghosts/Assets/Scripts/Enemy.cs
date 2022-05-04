using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyLogic enemyLogic;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyLogic == null)
            enemyLogic = GetComponent<EnemyLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
