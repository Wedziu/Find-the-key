using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class CanvasHandler : MonoBehaviour
{
    public Canvas chestPopUp;
    public Canvas doorOpenedPopUp;
    public Canvas doorClosedPopUp;
    public TextMeshProUGUI currentTimeUGUI;
    public TextMeshProUGUI bestTimeUGUI;
    Player player;
    // Start is called before the first frame update
    void Awake()
    {
        chestPopUp.enabled = false;
        doorOpenedPopUp.enabled = false;
        doorClosedPopUp.enabled = false;
        player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        currentTimeUGUI.text = FindObjectOfType<Timer>().textBox_CurrentTime.text;
        bestTimeUGUI.text = FindObjectOfType<Timer>().textBox_BestTime.text;

    }

    public void ShowWindowChest()
    {
        chestPopUp.enabled = true;
        player.GetComponent<NavMeshAgent>().isStopped = true;
    }
    public void CloseWindowChest()
    {
        chestPopUp.enabled = false;
        player.GetComponent<NavMeshAgent>().isStopped = false;
    }
    public void ShowWindowDoor()
    {
        doorOpenedPopUp.enabled = true;
        player.GetComponent<NavMeshAgent>().isStopped = true;
    }
    public void CloseWindowDoor()
    {
        doorOpenedPopUp.enabled = false;
        player.GetComponent<NavMeshAgent>().isStopped = false;
    }
    public void CloseWindowDoorClosed()
    {
        doorClosedPopUp.enabled = false;
        player.GetComponent<NavMeshAgent>().isStopped = false;
    }
    public void ShowWindowDoorClosed()
    {
        doorClosedPopUp.enabled = true;
        player.GetComponent<NavMeshAgent>().isStopped = false;
    }
}
