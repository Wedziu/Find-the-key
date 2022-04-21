using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BestTime : MonoBehaviour
{
    public TextMeshProUGUI bestscoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GetBestScore()
    {
        float receivedBestScore = Timer._bestTimetoUGUI;
        bestscoreText.text = receivedBestScore.ToString("F2");
    }
    private void Update()
    {
        GetBestScore();
    }
}
