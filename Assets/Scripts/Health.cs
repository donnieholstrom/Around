using Pixelplacement;
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int value = 1;

    private SpriteRenderer spriteRenderer;
    private bool justSpawned;

    public GameObject healthParticles;
    public GameObject healthText;

    private Player player;

    [SerializeField]
    private float rotateRatio = 1f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

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
        if (justSpawned || player.GetHealth() == 3)
        {
            return;
        }

        if (collision.transform.CompareTag("Line") || collision.transform.CompareTag("Player"))
        {
            Collect(value);
        }
    }

    public void Collect(int amount)
    {
        player.GainHealth(amount);

        Destroy(Instantiate(healthParticles, transform.position, Quaternion.identity), 1f);
        Instantiate(healthText, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private IEnumerator JustSpawned()
    {
        justSpawned = true;

        yield return new WaitForSeconds(0.5f);

        justSpawned = false;
    }
}