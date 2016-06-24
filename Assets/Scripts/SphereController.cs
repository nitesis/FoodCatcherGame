using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SphereController : MonoBehaviour {

	private new ParticleSystem particleSystem;
	public float thrust;
	public Rigidbody rb;
	public MazeGenerator mazeGenerator;
    public GameObject song;
    public GameObject collectSound;
	private FoodObjectController foodObjectController;



	void Start(){
		particleSystem = gameObject.GetComponent<ParticleSystem> ();
		rb = GetComponent<Rigidbody>();
		foodObjectController = mazeGenerator.GetComponent<FoodObjectController> ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("ball")) {
            particleSystem.Play();
            other.GetComponent<ParticleSystem>().Play();
            song.GetComponent<AudioSource>().Play();
            /*if (gameObject.GetComponent<AudioSource> ()) {
				gameObject.GetComponent<AudioSource> ().Play ();
			} else {
				other.gameObject.GetComponent<AudioSource>().Play();
			}*/
        }

		if (other.CompareTag("food"))
        {
            // place colored images on food board
            Texture texture = other.GetComponentInChildren<Renderer>().material.mainTexture;
            GameObject foodboard = GameObject.Find("Canvas_FoodBoard");
            Image[] images;
            images = foodboard.GetComponentInChildren<Image>().GetComponentsInChildren<Image>();
            // images[2].GetComponentInChildren<ChangeSprite>().changeSprite();
            for (int i = 0; i < images.Length; i++)
                if (texture.name + "_sw" == images[i].name)
                    images[i].GetComponentInChildren<ChangeSprite>().changeSprite();

            /*Transform ImageTr = foodboard.GetComponentInChildren<Image>().transform.Find("apple");
            Image image = ImageTr.GetComponent<Image>();
            GetComponentInChildren<Renderer>().material.mainTexture;*/

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

            //Implement your Faller game object into this variable in the inspector
            //var FallerObject : GameObject;
            //monsterfall=Animation
            //FallerObject.animation.Play("monstersfall");
            //rb.AddForce(0,0, thrust, ForceMode.Impulse);
            //foodObjectController.rearrangeObjects = false;
            particleSystem.Play();
            foodObjectController.FoodItemCount--;
            Destroy(other.gameObject);
            collectSound.GetComponent<AudioSource>().Play();
            Debug.Log("SpherControler Counter");


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
