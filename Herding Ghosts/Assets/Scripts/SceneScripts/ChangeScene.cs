using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneByString()
    {
        if(SceneManager.GetSceneByName(_sceneName) != null)
        {
            SceneManager.LoadScene(_sceneName); 
        }
    }
}
