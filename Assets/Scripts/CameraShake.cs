using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private Transform cameraTransform;

	private float shakeDuration = 0f;
	private float shakeAmount = 0.7f;

	public float shakeRatio;

	private Vector3 originalPos;

	private void Awake()
	{
		cameraTransform = GetComponent<Transform>();
		originalPos = cameraTransform.localPosition;
	}

	private void Update()
	{
		if (shakeDuration > 0)
		{
			shakeAmount = shakeDuration / shakeRatio;

			cameraTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime;
		}
		else
		{
			shakeDuration = 0f;
			shakeAmount = 0f;

			cameraTransform.localPosition = originalPos;
		}
	}

	public void Shake(float seconds)
	{
		shakeDuration += seconds;
	}
}