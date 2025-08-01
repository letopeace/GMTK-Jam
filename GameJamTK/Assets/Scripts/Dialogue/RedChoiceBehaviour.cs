using UnityEngine;
using UnityEngine.UI;

public class RedChoiceBehaviour : MonoBehaviour
{
	public Button button;
	
	public Vector2 movementLimits = Vector2.one;   // Насколько далеко можно отклоняться
	public Vector2 proximityThreshold = Vector2.one; // На каком расстоянии мышка считается "близко"
	public float softness = 0.6f;                   // Насколько мягко двигается

	private Vector3 startPosition;
	private Vector3 targetPosition;

	private void OnEnable()
	{
		startPosition = transform.position;
		button.enabled = false;
	}

	void Update()
	{
		Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorld.z = startPosition.z;

		Vector2 offset = mouseWorld - startPosition;

		targetPosition = startPosition;

		if (Mathf.Abs(offset.x) < proximityThreshold.x && Mathf.Abs(offset.y) < proximityThreshold.y)
		{
			Vector2 clampedOffset = Vector2.Scale(offset.normalized, movementLimits);
			targetPosition = startPosition - (Vector3)clampedOffset;
		}

		// Плавное движение
		if ((targetPosition - transform.position).sqrMagnitude > 0.0001f)
		{
			transform.position = Vector3.Lerp(transform.position, targetPosition, softness);
		}
		else
		{
			transform.position = targetPosition;
		}
	}

	public void SetActive(bool active = true)
	{
		button.enabled = active;
	}
}