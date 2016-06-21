using UnityEngine;
using System.Collections;

public class AddForceToObject : MonoBehaviour {

	Rigidbody rb; 
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		
		rb.AddForce(-transform.forward * 20, ForceMode.Impulse);
		//rb.useGravity = true;
	}
}
