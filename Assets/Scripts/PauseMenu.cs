using Pixelplacement;
using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused;
    private bool pausing;

    public CanvasGroup overlay;

    private void Update()
    {
        if (pausing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
                Time.timeScale = 0f;
                paused = true;
            }

            else
            {
                Unpause();
                Time.timeScale = 1f;
                paused = false;
            }
        }
    }

    private void Pause()
    {
        Tween.CanvasGroupAlpha(overlay, 0, 1f, 0.2f, 0f, Tween.EaseIn, Tween.LoopType.None, null, null, false);

        StartCoroutine(Pausing());
    }

    private void Unpause()
    {
        Tween.CanvasGroupAlpha(overlay, 1f, 0, 0.2f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, false);

        StartCoroutine(Pausing());
    }

    private IEnumerator Pausing()
    {
        pausing = true;
        yield return new WaitForSecondsRealtime(0.2f);
        pausing = false;
    }
}