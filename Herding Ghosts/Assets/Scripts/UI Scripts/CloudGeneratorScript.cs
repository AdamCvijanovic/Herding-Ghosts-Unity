using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGeneratorScript : MonoBehaviour
{
    [SerializeField]
    public GameObject [] clouds;

    [SerializeField]
    public float spawnInterval;

    [SerializeField]
    public GameObject endPoint;

    public Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        Prewarm();

        Invoke("AttemptSpawn", spawnInterval); //could be replaced with coroutine/delegate
    }

    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = UnityEngine.Random.Range(0, clouds.Length);
        GameObject cloud = Instantiate(clouds[randomIndex],Vector3.zero,Quaternion.identity);
        cloud.GetComponent<CloudScript>().StartFloating(2, endPoint.transform.position.x);

        float startY = UnityEngine.Random.Range(startPos.y - 1.5f, startPos.y + 1.5f);
        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        //float scale = UnityEngine.Random.Range(0.8f, 1f);
        //cloud.transform.localScale = new Vector2(scale, scale);

        //float speed = UnityEngine.Random.Range(0.8f, 0.9f);
        //cloud.GetComponent<CloudScript>().StartFloating(speed, endPoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        SpawnCloud(startPos);
        Invoke("AttemptSpawn", spawnInterval);  //loops function
        //SpawnCloud(startPos);
    }

    void Prewarm()
    {
        for (int i = 0; i < 1; i++)
        {
            Vector3 spawnPos = startPos - (Vector3.right) * (i * 7);
            SpawnCloud(spawnPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
