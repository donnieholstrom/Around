using Pixelplacement;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public GameObject burstParticles;

    private Vector2 initialForce;

    public Color darkRed = new Color(0.5f, 0, 0, 0);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        initialForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        Tween.LocalScale(transform, new Vector3(2f, 2f, 2f), Vector3.one, 0.5f, 0f, Tween.EaseIn);
        Tween.Color(spriteRenderer, Color.clear, darkRed, 0.5f, 0f, Tween.EaseIn);

        Tween.Color(spriteRenderer, darkRed, Color.red, 0.25f, 1f);
    }

    private void Start()
    {
        rb.AddForce(initialForce, ForceMode2D.Impulse);
    }

    public void Burst()
    {
        Destroy(Instantiate(burstParticles, transform.position, Quaternion.identity), 1f);
        Destroy(gameObject);
    }
}