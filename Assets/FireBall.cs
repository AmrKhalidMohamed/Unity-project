using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(speed* -1, 0);
    }

    private void Update()
    {
        
    }
}
