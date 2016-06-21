using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestSphereController : MonoBehaviour {

	private new ParticleSystem particleSystem;
	public float thrust;
	public Rigidbody rb;


	void Start(){
		particleSystem = gameObject.GetComponent<ParticleSystem> ();
		rb = GetComponent<Rigidbody>();
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
			rb.AddForce(0,0, thrust, ForceMode.Impulse);
            //Destroy(other.gameObject);

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
