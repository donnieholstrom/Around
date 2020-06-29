using Pixelplacement;
using System.Collections;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damage = 1;

    private Spike spike;

    private Player player;

    private bool justSpawned;
    private bool didDamage;

    private void Awake()
    {
        spike = transform.parent.gameObject.GetComponent<Spike>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        StartCoroutine(JustSpawned());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (justSpawned || didDamage)
        {
            return;
        }

        if (collision.CompareTag("Player"))
        {
            player.Damage(damage);
            didDamage = true;

            spike.Burst();
        }
    }

    private IEnumerator JustSpawned()
    {
        justSpawned = true;

        yield return new WaitForSeconds(1.5f);

        justSpawned = false;
    }
}