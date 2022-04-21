using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timeStart;
    public TextMeshProUGUI textBox_CurrentTime;
    public TextMeshProUGUI textBox_BestTime;
    bool timerActive = false;
    int scene;
    [SerializeField]float bestTime;
    [SerializeField]public static float _bestTimetoUGUI;

   
    void Start()
    {
        
        int numTimers = FindObjectsOfType<Timer>().Length;
        if (numTimers != 1)
        {
            Destroy(this.gameObject);
            
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            
        }
        scene = SceneManager.GetActiveScene().buildIndex;
        
        textBox_CurrentTime.text = timeStart.ToString("F2");
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timeStart += Time.deltaTime;
            textBox_CurrentTime.text = timeStart.ToString("F2");
        }
        if (FindObjectOfType<Door>() == null) return;
        StopTimer();
    }

    private void StopTimer()
    {
        if (FindObjectOfType<Door>().isDoorOpened() && timerActive ==true && timeStart >1)
        {
            FindObjectOfType<CanvasHandler>().ShowWindowDoor();
            timerActive = false;
            Debug.Log("disabled timer");
            if (bestTime > timeStart || bestTime == 0)
            {
                bestTime = timeStart;
                textBox_BestTime.text = bestTime.ToString("F2");
                _bestTimetoUGUI = bestTime;
            }
            
        }
    }

    public void RestartScene()
    {
        FindObjectOfType<CanvasHandler>().CloseWindowDoor();
        SceneManager.LoadScene(scene);
        timeStart = 0;
        textBox_CurrentTime.text = timeStart.ToString("F2");
        timerActive = true;
        
    }
}
