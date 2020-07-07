using Pixelplacement;
using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool justSpawned;

    public GameObject boomParticles;
    public GameObject boomText;

    private Player player;
    private GameManager gameManager;

    [SerializeField]
    private float rotateRatio = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Tween.LocalScale(transform, new Vector3(2f, 2f, 2f), Vector3.one, 0.5f, 0f, Tween.EaseIn);
        Tween.Color(spriteRenderer, Color.clear, spriteRenderer.color, 0.5f, 0f, Tween.EaseIn);

        StartCoroutine(JustSpawned());
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f) * rotateRatio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (justSpawned)
        {
            return;
        }

        if (collision.transform.CompareTag("Line") || collision.transform.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {
        gameManager.Boom();

        Destroy(Instantiate(boomParticles, transform.position, Quaternion.identity), 1f);
        Instantiate(boomText, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private IEnumerator JustSpawned()
    {
        justSpawned = true;

        yield return new WaitForSeconds(0.5f);

        justSpawned = false;
    }
}