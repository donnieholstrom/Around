using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private HighscoreManager highscoreManager;

    public TextMeshProUGUI highscoreLabel;

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
        switch (buttonType)
        {
            case "start":
                SceneManager.LoadScene(2);
                break;

            case "quit":
                Application.Quit();
                break;
        }
    }
}