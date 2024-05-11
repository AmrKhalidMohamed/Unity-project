using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class playerMovement : MonoBehaviour
{
    public Text scoreText;
    private static int score = 0;


    public float moveSpeed = 5f;
    public float jumpForce = 16f;
    private Rigidbody2D rb;
    public GameObject deathScreen;
    public GameObject winScreen;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        scoreText.text = "Score: " + score;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            Win();
        }
    }

    void Die()
    {

        deathScreen.SetActive(true);

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Win()
    {
        winScreen.SetActive(true);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        score++;


        // Restart the current scene after a delay
        Invoke("RestartGame", 2f); // 2 seconds delay
    }

    void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
