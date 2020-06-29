using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedInput;
    private float speed;

    private void Awake()
    {
        speed = speedInput / 1000;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && transform.localPosition.y < 0.9f)
        {
            transform.Translate(0, speed, 0);
        }

        if (Input.GetKey(KeyCode.Mouse1) && transform.localPosition.y > -0.84f)
        {
            transform.Translate(0, -speed, 0);
        }
    }
}