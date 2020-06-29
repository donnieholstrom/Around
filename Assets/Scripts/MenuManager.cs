using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PushButton(string buttonType)
    {
        switch (buttonType)
        {
            case "start":
                SceneManager.LoadScene(1);
                break;

            case "quit":
                Application.Quit();
                break;
        }
    }
}