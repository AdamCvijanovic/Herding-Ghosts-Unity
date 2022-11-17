using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>Static reference to the instance of our DataManager</summary>
    public static GameManager instance;

    public int satisfiedCustomers;
    public int disastisfiedCustomers;
    public int points;
    public int dayNumber;

    /// <summary>Awake is called when the script instance is being loaded.</summary>
    void Awake()
    {
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateCustomerCounter(int i)
    {
        satisfiedCustomers = i;
    }

    public void UpdateDisatisfiedCustomerCounter(int i)
    {
        disastisfiedCustomers = i;
    }

    public void UpdatePoints(int i)
    {
        satisfiedCustomers = i;
    }

    public void IncrementDay()
    {
        ++dayNumber;
    }

    public void ClearAllFields()
    {
        satisfiedCustomers = 0;
        disastisfiedCustomers = 0;
        points = 0;
        dayNumber = 0;
}

}
