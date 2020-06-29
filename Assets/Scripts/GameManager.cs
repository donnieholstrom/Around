using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private HighscoreManager highscoreManager;

    private int cyclesCompleted;
    private int coinsCollected;
    private int totalScore;

    public TextMeshProUGUI cyclesLabel;
    public TextMeshProUGUI coinsLabel;
    public TextMeshProUGUI scoreLabel;

    public Pivot pivot;

    public GameObject spike;
    public GameObject coin;

    private float timer = 0;
    private float scoreFrequency = 0.1f;

    private void Awake()
    {
        highscoreManager = GameObject.FindGameObjectWithTag("HighscoreManager").GetComponent<HighscoreManager>();

        cyclesCompleted = 0;
        coinsCollected = 0;
        totalScore = 0;

        SpawnSpike(2);
        SpawnCoin(1);
    }

    private void Update()
    {
        if (timer >= scoreFrequency)
        {
            totalScore++;
            timer = 0;
        }

        scoreLabel.text = totalScore.ToString();

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Line"))
        {
            cyclesCompleted++;
            cyclesLabel.text = cyclesCompleted.ToString();

            totalScore += 50;

            pivot.rotationSpeed *= 1.1f;

            SpawnCoin(1);

            if (cyclesCompleted % 2 == 0)
            {
                SpawnSpike(1);

                if (cyclesCompleted >= 5)
                {
                    SpawnSpike(1);
                }
            }
        }
    }

    public void CollectCoins(int amount)
    {
        coinsCollected += amount;
        totalScore += amount * 50;

        coinsLabel.text = coinsCollected.ToString();
    }

    public void SpawnSpike(int amountToSpawn)
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle ;
            Instantiate(spike, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
        }
    }

    public void SpawnCoin(int amountToSpawn)
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle;
            Instantiate(coin, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
        }
    }

    public void Lose()
    {
        if (totalScore > highscoreManager.highscore)
        {
            highscoreManager.highscore = totalScore;
        }

        SceneManager.LoadScene(1);
    }
}