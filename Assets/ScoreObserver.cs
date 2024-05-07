using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreObserver : MonoBehaviour
{
    public TMP_Text scoreText;
    public Transform scorePoint; 
    private int score = 0;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            IncreaseScore();
        }
    }

    void IncreaseScore()
    {
        score++;
        UpdateScoreUI();
    }

    public void DecreaseScore()
    {
        score--;
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pipes: " + score.ToString(); // Update the text displayed on the UI
        }
    }
}
