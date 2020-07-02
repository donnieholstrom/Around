using Pixelplacement;
using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private SpriteRenderer spriteRenderer;
    private bool justSpawned;

    public GameObject coinParticles;
    public GameObject scoreText;

    private GameManager gameManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        Tween.LocalScale(transform, new Vector3(2f, 2f, 2f), Vector3.one, 0.5f, 0f, Tween.EaseIn);
        Tween.Color(spriteRenderer, Color.clear, Color.yellow, 0.5f, 0f, Tween.EaseIn);

        StartCoroutine(JustSpawned());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (justSpawned)
        {
            return;
        }

        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Line"))
        {
            Collect(value);
        }
    }

    public void Collect(int amount)
    {
        gameManager.CollectCoins(amount);

        Destroy(Instantiate(coinParticles, transform.position, Quaternion.identity), 1f);
        Instantiate(scoreText, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private IEnumerator JustSpawned()
    {
        justSpawned = true;

        yield return new WaitForSeconds(0.5f);

        justSpawned = false;
    }
}