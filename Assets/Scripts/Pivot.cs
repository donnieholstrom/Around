using UnityEngine;

public class Pivot : MonoBehaviour
{
    public float rotationSpeed;
    
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, -rotationSpeed / 100));
    }
}