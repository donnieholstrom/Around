using Pixelplacement;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private HighscoreManager highscoreManager;

    public TextMeshProUGUI highscoreLabel;

    public CanvasGroup overlay;

    private bool starting;

    private void Awake()
    {
        highscoreManager = GameObject.FindGameObjectWithTag("HighscoreManager").GetComponent<HighscoreManager>();
    }

    private void Start()
    {
        highscoreLabel.text = highscoreManager.highscore.ToString();
    }

    public void PushButton(string buttonType)
    {
        if (starting)
        {
            return;
        }

        switch (buttonType)
        {
            case "start":
                StartCoroutine(StartGame());
                break;

            case "quit":
                Application.Quit();
                break;
        }
    }

    private IEnumerator StartGame()
    {
        Tween.CanvasGroupAlpha(overlay, 0f, 1f, 0.5f, 0f, null, Tween.LoopType.None, null, null, false);

        starting = true;
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(2);
    }
}