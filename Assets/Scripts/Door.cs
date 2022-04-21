using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool isKeyFound;
    bool doorOpened = false;
    private void Start()
    {
        isKeyFound = false;
    }
    private void Update()
    {
        if (FindObjectOfType<Chest>() == null) return;
       isKeyFound = FindObjectOfType<Chest>().isKeyTaken;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if( isKeyFound== false)
        {
            Debug.Log("you dont have a key");
            FindObjectOfType<CanvasHandler>().ShowWindowDoorClosed();
        }
        else
        {
            Debug.Log("you have a key!");
            doorOpened = true;
        }
    }
    public bool isDoorOpened()
    {
        return doorOpened;
    }
}
