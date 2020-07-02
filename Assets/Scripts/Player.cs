using UnityEngine;
using Pixelplacement;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private CameraShake cameraShake;

    public float speed;

    private int health;
    private SpriteRenderer playerRenderer;

    public HealthBarSegment healthBarSegment1;
    public HealthBarSegment healthBarSegment2;
    public HealthBarSegment healthBarSegment3;

    private Color startColor;
    public Color damageColor;

    private AudioSource source;

    public AudioClip damageSound;

    public GameObject deathParticles;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cameraShake = Camera.main.gameObject.GetComponent<CameraShake>();

        playerRenderer = GetComponent<SpriteRenderer>();

        startColor = playerRenderer.color;

        source = GetComponent<AudioSource>();
        
        health = 3;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && transform.localPosition.y < 0.9f)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Mouse1) && transform.localPosition.y > -0.77f)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    public void Damage(int damage)
    {
        DamageEffect(damage);

        if (damage >= health)
        {
            healthBarSegment1.Deplete();

            source.PlayOneShot(damageSound, 0.3f);

            gameManager.Lose();

            Destroy(Instantiate(deathParticles, transform.position, Quaternion.identity), 2.9f);
            Destroy(gameObject);

            return;
        }

        source.PlayOneShot(damageSound, 0.2f);

        switch (damage)
        {
            case 1:

                switch (health)
                {
                    case 3:

                        healthBarSegment3.Deplete();

                        break;

                    case 2:

                        healthBarSegment2.Deplete();

                        break;
                }

                health--;

                break;

            case 2:

                healthBarSegment3.Deplete();
                healthBarSegment2.Deplete();

                health -= damage;

                break;
        }
    }

    public void DamageEffect(int damage)
    {
        cameraShake.Shake(0.25f * damage);

        Tween.Color(playerRenderer, damageColor, 0.07f, 0f, Tween.EaseIn);
        Tween.Color(playerRenderer, startColor, 0.07f, 0.07f, Tween.EaseOut);
    }
}