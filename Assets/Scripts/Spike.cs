using Pixelplacement;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spike : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private AudioSource source;

    public AudioClip thud;

    public GameObject burstParticles;

    private Vector2 initialForce;

    public Color darkRed = new Color(0.5f, 0, 0, 0);

    private GameManager gameManager;
    private CameraShake cameraShake;

    private bool justSpawned;

    public UnityEvent spikeHit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

        initialForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        Tween.LocalScale(transform, new Vector3(2f, 2f, 2f), Vector3.one, 0.5f, 0f, Tween.EaseIn);
        Tween.Color(spriteRenderer, Color.clear, darkRed, 0.5f, 0f, Tween.EaseIn);

        Tween.Color(spriteRenderer, darkRed, Color.red, 0.25f, 1f);

        cameraShake = Camera.main.GetComponent<CameraShake>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        StartCoroutine(JustSpawned());
    }

    private void Start()
    {
        rb.AddForce(initialForce, ForceMode2D.Impulse);
    }

    public void Die()
    {
        gameManager.spawnedSpikes.Remove(gameObject);

        Destroy(Instantiate(burstParticles, transform.position, Quaternion.identity), 1f);

        Destroy(gameObject);
    }

    public void Burst()
    {
        Destroy(Instantiate(burstParticles, transform.position, Quaternion.identity), 1f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (justSpawned)
        {
            return;
        }

        // checks if collision is on "Object Collision" layer

        if (collision.gameObject.layer == 12)
        {
            cameraShake.Shake(0.1f);
            source.PlayOneShot(thud, 0.3f);
        }
    }

    private IEnumerator JustSpawned()
    {
        justSpawned = true;

        yield return new WaitForSeconds(0.1f);

        justSpawned = false;
    }
}