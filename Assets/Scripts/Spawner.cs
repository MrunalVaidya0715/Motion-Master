using System.Collections;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array to hold different obstacle prefabs
    public Rigidbody vRRigRigidbody; // Reference to the VR Rig's Rigidbody
    public TMP_Text timerText; // Reference to the UI Text component for displaying the timer
    public float gameDuration = 180f; // Game duration in seconds
    private bool spawning = false; // Initialize the spawning variable
    private int previousRandom = -1; // Variable to store the previous random number

    void Start()
    {
        // Freeze Y position of the VR rig initially
        vRRigRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    void Update()
    {
        // Update timer text
        UpdateTimerText();

        // Check for Enter key press to start spawning
        if (Input.GetKeyDown(KeyCode.Return) && !spawning)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // Start game timer
        StartCoroutine(GameTimer());

        // Unfreeze Y position of the VR rig
        vRRigRigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;

        // Start spawning obstacles
        StartCoroutine(Spawning());
    }

    IEnumerator GameTimer()
    {
        while (gameDuration > 0)
        {
            yield return null;
            gameDuration -= Time.deltaTime;
        }
        gameDuration = 0;

        // Game end logic
        EndGame();
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Calculate minutes and seconds remaining
            int minutes = Mathf.FloorToInt(gameDuration / 60f);
            int seconds = Mathf.FloorToInt(gameDuration % 60f);

            // Update timer text
            timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
        }
    }

    void EndGame()
    {
        spawning = false;
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Score");
        foreach (GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
        // Freeze bird at current position
        vRRigRigidbody.constraints |= RigidbodyConstraints.FreezePositionY;
    }

    IEnumerator Spawning()
    {
        spawning = true; // Set spawning to true
        while (spawning)
        {
            int randomIndex = GetRandomNumber(); // Get a new random number avoiding consecutive repeats

            GameObject newObstacle = Instantiate(GetObstaclePrefab(randomIndex), transform.position, transform.rotation);
            // Instantiate the obstacle using the generated random number to get the correct prefab

            yield return new WaitForSeconds(16); // Adjust the delay time as needed
        }
    }

    private int GetRandomNumber()
    {
        int newRandom = Random.Range(0, obstaclePrefabs.Length); // Generate a new random number
        while (newRandom == previousRandom) // Check if it matches the previous random number
        {
            newRandom = Random.Range(0, obstaclePrefabs.Length); // If it matches, generate a new random number
        }
        previousRandom = newRandom; // Update the previous random number
        return newRandom; // Return the new random number
    }

    private GameObject GetObstaclePrefab(int randomIndex)
    {
        if (randomIndex >= 0 && randomIndex < obstaclePrefabs.Length)
        {
            return obstaclePrefabs[randomIndex]; // Return the prefab at the specified index
        }
        else
        {
            return obstaclePrefabs[0]; // Default to the first prefab if the index is out of range
        }
    }
}
