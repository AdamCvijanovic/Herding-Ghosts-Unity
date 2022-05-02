using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

  //public Manager manager;

 public void PlayGame ()
 {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Brackeys is God
    //MobileGameManager.instance
    Time.timeScale = 1f;
 }

 public void QuitGame ()
 {
   Debug.Log ("QUIT!");
   Application.Quit();
 }
}
