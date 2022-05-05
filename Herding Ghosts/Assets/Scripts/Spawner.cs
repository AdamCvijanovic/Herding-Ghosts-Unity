using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;

    public float _spawnTime;
    public float countdown;



    // Start is called before the first frame update
    void Start()
    {
        countdown = _spawnTime;
    }

    // Update is called once per frame
    void Update()
    {

        SpawnCountDown(_spawnTime);



    }

 

    private void SpawnCountDown(float time)
    {

        
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = time;
            SpawnRandomEnemy();
        }

        

    }

    public void SpawnRandomEnemy()
    {
        int i = Random.Range(0, enemyPrefabs.Count);

        SpawnEnemy(enemyPrefabs[i]);



    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyManager.EnemyManagerSGLTN.AddEnemy(newEnemy.GetComponent<Enemy>());

    }

}
