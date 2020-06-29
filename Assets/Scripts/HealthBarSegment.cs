using UnityEngine;
using Pixelplacement;

public class HealthBarSegment : MonoBehaviour
{
    private CanvasGroup canvas;

    private void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    public void Deplete()
    {
        Tween.LocalScale(transform, Vector3.one, new Vector3(2, 2, 2), 0.25f, 0f, Tween.EaseOut);
        Tween.CanvasGroupAlpha(canvas, 1f, 0f, 0.25f, 0f, Tween.EaseOut);
    }
}