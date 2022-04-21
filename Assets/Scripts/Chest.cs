using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    [SerializeField]float range = 1f;
    [SerializeField]public bool isKeyTaken = false;
    
    Vector3 playerPosition;

    private void Awake()
    {
        isKeyTaken = false;
    }

    private void Update()
    {
        
        if (FindObjectOfType<Player>() == null) return;
        playerPosition = FindObjectOfType<Player>().transform.position;
        if (Vector3.Distance(transform.position, playerPosition) < range && !isKeyTaken)
        {    
            FindObjectOfType<CanvasHandler>().ShowWindowChest();
            isKeyTaken = true;
        }
        
    }

    public void TakeTheKey()
    {
        isKeyTaken = true;
        Debug.Log("I got the key" + isKeyTaken);
        FindObjectOfType<CanvasHandler>().CloseWindowChest();
        
    }
   
    
}
