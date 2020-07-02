using UnityEngine;
using Pixelplacement;

public class ScoreText : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 1f);
    }

    private void Start()
    {
        Tween.LocalPosition(transform, transform.position, transform.position + (Vector3.up), 1f, 0f, Tween.EaseOut, Tween.LoopType.None, null, null, false);
        Tween.LocalScale(transform, transform.localScale, Vector3.zero, 0.2f, 0.75f, Tween.EaseOut, Tween.LoopType.None, null, null, false);
    }
}