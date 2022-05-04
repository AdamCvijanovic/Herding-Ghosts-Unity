using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        FetchExistingEnemies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FetchExistingEnemies()
    {
        foreach (Enemy e in FindObjectsOfType<Enemy>())
        {
            enemies.Add(e);
        }
    }

    public void AddEnemy()
    {

    }
}
