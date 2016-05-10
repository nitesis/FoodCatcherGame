using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SphereController : MonoBehaviour {

	private new ParticleSystem particleSystem;


	void Start(){
		particleSystem = gameObject.GetComponent<ParticleSystem> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("ball")) {
			if (!particleSystem.isPlaying) {
				particleSystem.Play ();
			}

			if (gameObject.GetComponent<AudioSource> ()) {
				gameObject.GetComponent<AudioSource> ().Play ();
			} else {
				other.gameObject.GetComponent<AudioSource>().Play();
			}
		}

		if (other.CompareTag("food"))
        {
			GameObject foodboard = GameObject.Find("Canvas_FoodBoard");
			foodboard.GetComponentInChildren<Image> ().GetComponentInChildren<Image> ().GetComponentInChildren<ChangeSprite> ().changeSprite ();

           /* Vector3 myPosition = other.transform.position;
            Vector3 targetPosition = new Vector3(myPosition.x, 5f, myPosition.z);
            Vector3 direction = (targetPosition - myPosition).normalized;
            float distance = Vector3.Magnitude(targetPosition - myPosition);

            Vector3 resultingForceAmount = 50 * direction * distance;
            other.GetComponent<Rigidbody>().AddForce(resultingForceAmount);

            targetPosition = new Vector3(10f, 0f, 8f);
            myPosition = other.transform.position;
            direction = (targetPosition - myPosition).normalized;
            distance = Vector3.Magnitude(targetPosition - myPosition);

            resultingForceAmount = 10 * direction * distance;
            other.GetComponent<Rigidbody>().AddForce(resultingForceAmount);

            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;*/

            Destroy(other.gameObject);

        }

	}

	
/*	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag ("ball"))
		{
			if (!particleSystem)
			{
				Application.LoadLevel("maze");
			}
		}
	}*/
}
