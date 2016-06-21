using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TestSphereController : MonoBehaviour {

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
