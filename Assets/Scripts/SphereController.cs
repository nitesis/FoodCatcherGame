using UnityEngine;
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
