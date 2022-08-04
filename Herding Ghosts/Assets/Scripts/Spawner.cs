using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    GhostManager _enemyMngr;

    public List<GameObject> enemyPrefabs;


    public Transform _spawnPosition;
    public float _spawnTime;
    public float countdown;



    // Start is called before the first frame update
    void Start()
    {
        _enemyMngr = FindObjectOfType<GhostManager>();

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
            if(_enemyMngr.CheckMax())
            {
                SpawnRandomEnemy();
            }
            else
            {
                //Debug.Log("Exceeds Max Count");
            }
        }

        

    }

    public void SpawnRandomEnemy()
    {


        int i = Random.Range(0, enemyPrefabs.Count);

        SpawnEnemy(enemyPrefabs[i]);



    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        if(_spawnPosition != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, _spawnPosition.position, Quaternion.identity, _enemyMngr.transform);
            _enemyMngr.AddGhost(newEnemy.GetComponent<Ghost>());

        }
        else
        {
            GameObject newEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity, _enemyMngr.transform);
            _enemyMngr.AddGhost(newEnemy.GetComponent<Ghost>());

        }

    }

}
