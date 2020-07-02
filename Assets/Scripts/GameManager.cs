﻿using Pixelplacement;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variables

    private HighscoreManager highscoreManager;

    private int cyclesCompleted;
    private int coinsCollected;
    private int totalScore;

    public CanvasGroup overlay;

    public GameObject countdownObject;
    private TextMeshProUGUI countdownLabel;

    public TextMeshProUGUI cyclesLabel;
    public TextMeshProUGUI coinsLabel;
    public GameObject scoreObject;
    private TextMeshProUGUI scoreLabel;

    public Pivot pivot;

    public GameObject spike;
    public GameObject coin;

    private float timer = 0;
    private float scoreFrequency = 0.1f;

    public AudioSource cycleSource;
    public AudioSource coinSource;
    public AudioSource damageSource;
    public AudioClip cycleSound;
    public AudioClip coinSound;
    public AudioClip damageSound;

    public GameObject cycleText;

    private bool playing;

    #endregion

    private void Awake()
    {
        overlay.alpha = 1f;

        Time.timeScale = 0f;

        highscoreManager = GameObject.FindGameObjectWithTag("HighscoreManager").GetComponent<HighscoreManager>();

        countdownLabel = countdownObject.GetComponent<TextMeshProUGUI>();
        scoreLabel = scoreObject.GetComponent<TextMeshProUGUI>();

        cyclesCompleted = 0;
        coinsCollected = 0;
        totalScore = 0;

        SpawnSpike(2);
        SpawnCoin(1);

        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (timer >= scoreFrequency && playing)
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

            Instantiate(cycleText, Vector3.up, Quaternion.identity);

            cycleSource.pitch = 0.2f + (0.1f * cyclesCompleted);
            cycleSource.PlayOneShot(cycleSound, 0.63f);

            totalScore += 75;

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
        coinSource.PlayOneShot(coinSound, 0.75f);

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

    private IEnumerator StartGame()
    {
        Tween.CanvasGroupAlpha(overlay, 1f, 0.25f, 0.75f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, false);
        yield return new WaitForSecondsRealtime(0.75f);

        countdownLabel.text = "3";
        countdownObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.75f);
        countdownObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.25f);

        countdownLabel.text = "2";
        countdownObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.75f);
        countdownObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.25f);

        countdownLabel.text = "1";
        countdownObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.75f);
        countdownObject.SetActive(false);
        Tween.CanvasGroupAlpha(overlay, 0.25f, 0f, 0.25f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, false);
        yield return new WaitForSecondsRealtime(0.25f);

        Time.timeScale = 1f;
        playing = true;

        countdownLabel.text = "GO";
        countdownObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.25f);
        countdownObject.SetActive(false);
    }

    public void Lose()
    {
        playing = false;

        damageSource.PlayOneShot(damageSound, 0.6f);

        if (totalScore > highscoreManager.highscore)
        {
            highscoreManager.highscore = totalScore;
        }

        StartCoroutine(EndGame());
    }

    public IEnumerator EndGame()
    {
        Tween.CanvasGroupAlpha(overlay, 0f, 1f, 2f, 1f, null, Tween.LoopType.None, null, null, false);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);
    }
}