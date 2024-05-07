using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDescreaser : MonoBehaviour
{
    public TMP_Text CollidedText;

    private int collided = 0;
    public AudioClip pointSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pointSound;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreArea"))
        {
            IncreaseCollidedScore();
            audioSource.Play();
        }
    }

    void IncreaseCollidedScore()
    {
        collided++;
        UpdateCollidedScoreUI();
    }
    void UpdateCollidedScoreUI()
    {
        if (CollidedText != null)
        {
            CollidedText.text = "Score: " + collided.ToString(); // Update the text displayed on the UI
        }
    }
}
