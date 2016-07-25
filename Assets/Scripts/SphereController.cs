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
    public GameOverManager gameObjectManeger;
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
            if (foodObjectController.FoodObjectList.Count == 0)
                gameObjectManeger.SphereCollided = true;
           
        }

		if (other.CompareTag("food"))
        {
            // place colored images on food board
            Texture texture = other.GetComponentInChildren<Renderer>().material.mainTexture;
            GameObject foodboard = GameObject.Find("Canvas_FoodBoard");
            /*Image[] images;
            images = foodboard.GetComponentInChildren<Image>().GetComponentsInChildren<Image>();
            for (int i = 0; i < images.Length; i++)
                if (texture.name + "_sw" == images[i].name)
                {
                    StartCoroutine(moveAndeChange(other, images[i]));
                }
                */
            Button[] buttons = foodboard.GetComponentInChildren<Image>().GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
                if (texture.name + "_sw" == buttons[i].GetComponent<Image>().sprite.name)
                {
                    StartCoroutine(moveAndeChange(other, buttons[i]));
                }

            particleSystem.Play();
            foodObjectController.FoodItemCount--;
            collectSound.GetComponent<AudioSource>().Play();


         }

	}



    private IEnumerator moveAndeChange(Collider other, Button btn)
    {
        iTween.RotateTo(other.gameObject, new Vector3(90,180,0),5);
        yield return new WaitForSeconds(0.2f);
        Vector3 target = new Vector3(btn.GetComponentInChildren<ChangeSprite>().XNumber, 8, btn.GetComponentInChildren<ChangeSprite>().ZNumber);
        iTween.MoveTo(other.gameObject, iTween.Hash(
                     "position", target,
                     "speed", 20,
                     "oncomplete", "onCompleteFromiTween",
                     "easetype", iTween.EaseType.linear
                     ));
        yield return new WaitForSeconds(0.7f);
        btn.GetComponentInChildren<ChangeSprite>().changeSprite();
        foodObjectController.FoodObjectList.Remove(other.gameObject);
        Destroy(other.gameObject);

        //foodObjectController.FoodItemCount--;


        // yield return new WaitForSeconds(1f);
        //foodObjectController.FoodItemCount--;


    }


}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         