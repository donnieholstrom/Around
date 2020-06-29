using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 initialForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(initialForce, ForceMode2D.Impulse);
    }
}