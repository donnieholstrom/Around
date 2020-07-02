using UnityEngine;

public class Pivot : MonoBehaviour
{
    public float rotationSpeed;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        float modifier = Vector3.Distance(transform.position, player.transform.position);

        transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime * (1 / modifier)));
    }
}