using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // Reference to the Text element on the UI Canvas displaying the score
    private int score = 0;
    public AudioClip pointSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pointSound;

        UpdateScoreUI(); // Display the initial score on UI
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            IncreaseScore();
            audioSource.Play();
        }
    }

    void IncreaseScore()
    {
        score++; // Increase the score by 1
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score " + score.ToString(); // Update the text displayed on the UI
        }
    }
}
