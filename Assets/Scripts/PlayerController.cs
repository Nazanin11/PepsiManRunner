using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;
    public float laneChangeSpeed = 10f;
    public Transform[] lanes;       // Lane positions
    private int currentLane = 1;
    private Vector3 targetPosition;

    [Header("Score Settings")]
    public TMP_Text scoreText;      // Current score UI
    public TMP_Text bestScoreText;  // Best score UI
    private float score = 0;
    private float bestScore = 0;

    [Header("Game Over UI")]
    public GameObject gameOverPanel; // Game Over panel reference

    private bool isGameOver = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        // Load best score (create if not exist)
        if (!PlayerPrefs.HasKey("BestScore"))
            PlayerPrefs.SetFloat("BestScore", 0);

        bestScore = PlayerPrefs.GetFloat("BestScore");

        // Display best score
        if (bestScoreText != null)
            bestScoreText.text = "Best: " + Mathf.FloorToInt(bestScore).ToString();

        // Set initial target position to the current lane
        targetPosition = transform.position;

        // Disable GameOver panel at start
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        // Play running animation
        if (animator != null)
            animator.SetBool("isRunning", true);
    }

    void Update()
    {
        if (isGameOver) return;

        // Move forward automatically
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Lane switching input (Keyboard arrows and A/D keys)
        if ((Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame) && currentLane > 0)
            currentLane--;

        if ((Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame) && currentLane < lanes.Length - 1)
            currentLane++;

        // Move smoothly toward selected lane
        targetPosition = new Vector3(lanes[currentLane].position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);

        // Increase score over time
        score += Time.deltaTime;
        if (scoreText != null)
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        // Update best score
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);

            if (bestScoreText != null)
                bestScoreText.text = "Best: " + Mathf.FloorToInt(bestScore).ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Trigger Game Over when touching an obstacle
        if (other.CompareTag("Obstacle"))
            GameOver();
    }

    void GameOver()
    {
        isGameOver = true;

        // Stop running animation
        if (animator != null)
            animator.SetBool("isRunning", false);

        // Enable GameOver UI
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
