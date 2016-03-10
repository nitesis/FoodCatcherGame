using System;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript.Behaviors;


public class RollSphere : MonoBehaviour {

	public float attractionStrength = 1000;
	public long holdDelayTicks = TimeSpan.FromMilliseconds(1).Ticks;

	private TransformGesture transformGesture;
	private Rigidbody rb;
	private bool isActive = false;
	private long lastActive = 0;

	private void OnEnable()
	{
		rb = GetComponent<Rigidbody> ();
		transformGesture = GetComponent<TransformGesture> ();
		transformGesture.TransformStarted += HandleTransformStarted;
		transformGesture.TransformCompleted += HandleTransformCompleted;
	}

	private void OnDisable()
	{
		transformGesture.TransformStarted -= HandleTransformStarted;
		transformGesture.TransformCompleted -= HandleTransformCompleted;
	}
	
	void FixedUpdate() 
	{
		if (!transformGesture.GetTargetHitResult ()) {
			if (isActive) {
				long now = DateTime.Now.Ticks;
				// wait some time until the sphere is released
				if (lastActive == 0) {
					lastActive = now;
				} else if (now - holdDelayTicks > lastActive) {
					lastActive = 0;
					isActive = false;
				}
			}
		} else {
			lastActive = 0;
			isActive = true;
		}

		// from http://answers.unity3d.com/questions/239614/roll-a-ball-towards-the-player.html
		// HACK: Check if ScreenPosition is a valid number to get around some strange log messages.
		if (isActive && !float.IsNaN(transformGesture.ScreenPosition.x)) {
			// get the positions of this object and the target
			Vector3 targetPosition = Camera.main.ScreenToWorldPoint (new Vector3 (transformGesture.ScreenPosition.x, transformGesture.ScreenPosition.y, 9.5f));
			Vector3 myPosition = transform.position;

			// work out direction and distance
			Vector3 direction = (targetPosition - myPosition).normalized;
			float distance = Vector3.Magnitude (targetPosition - myPosition);
		
			// apply square root to distance if specified to do so in the inspector
			//if (useSqrtOfDistance) distance = Mathf.Sqrt(distance);

			Vector3 resultingForceAmount = attractionStrength * direction * distance;

			// then finally add the force to the rigidbody
			rb.AddForce (resultingForceAmount);
		}
		
	}

	void HandleTransformStarted (object sender, EventArgs e)
	{
		isActive = true;		
	}
	
	void HandleTransformCompleted (object sender, EventArgs e)
	{
		isActive = false;	
	}
	

}
