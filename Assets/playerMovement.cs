using UnityEngine;

public class playerMovement : MonoBehaviour
{
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
    }
}
