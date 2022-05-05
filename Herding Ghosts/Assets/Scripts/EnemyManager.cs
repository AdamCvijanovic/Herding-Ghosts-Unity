using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Singleton
    public static EnemyManager EnemyManagerSGLTN { get; private set; }

    [SerializeField]
    private List<Enemy> enemies = new List<Enemy>();

    //what have you been reading lately?

    private void Awake()
    {
        if (EnemyManagerSGLTN != null && EnemyManagerSGLTN != this)
        {
            Destroy(this);
            return;
        }
        EnemyManagerSGLTN = this;
        
    }

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

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
    }



}
