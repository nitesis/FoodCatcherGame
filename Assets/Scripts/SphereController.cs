using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SphereController : MonoBehaviour {

	private new ParticleSystem particleSystem;
	public float thrust;
	public Rigidbody rb;
	public MazeGenerator mazeGenerator;
    public GameObject songs;
    public GameObject collectSound;
    public GameObject landingSound;
    public GameObject winSound;
    public GameOverManager gameObjectManeger;
	private FoodObjectController foodObjectController;
    AudioSource[] songList;
    private AudioSource currentSong;

    public AudioSource CurrentSong
    {
        get{ return currentSong; }
        set { currentSong = value;}
    }


    void Start(){
		particleSystem = gameObject.GetComponent<ParticleSystem> ();
		rb = GetComponent<Rigidbody>();
		foodObjectController = mazeGenerator.GetComponent<FoodObjectController> ();
        songList = songs.GetComponentsInChildren<AudioSource>();
        currentSong = songList[Random.Range(0, songList.Length)];
    }
	
	void OnTriggerEnter(Collider other) {

        if (!currentSong.GetComponent<AudioSource>().isPlaying)
            currentSong = songList[Random.Range(0, songList.Length)];
        if (other.CompareTag ("ball")) {
            particleSystem.Play();
            other.GetComponent<ParticleSystem>().Play();
            if (foodObjectController.FoodObjectList.Count == 0)
            {
                
                gameObjectManeger.SphereCollided = true;
                if (currentSong.GetComponent<AudioSource>().isPlaying)
                    currentSong.GetComponent<AudioSource>().Stop();
                if((!winSound.GetComponent<AudioSource>().isPlaying))
                    winSound.GetComponent<AudioSource>().Play();
            }
            else
                if ((!currentSong.GetComponent<AudioSource>().isPlaying)
                    && (!winSound.GetComponent<AudioSource>().isPlaying))
            {
                currentSong.GetComponent<AudioSource>().Play();
            }
        }

		if (other.CompareTag("food"))
        {
            // place colored images on food board
            Texture texture = other.GetComponentInChildren<Renderer>().material.mainTexture;
            GameObject foodboard = GameObject.Find("Canvas_FoodBoard");
            Button[] buttons = foodboard.GetComponentInChildren<Image>().GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
                if (texture.name + "_big_sw" == buttons[i].GetComponent<Image>().sprite.name)
                {
                    StartCoroutine(moveAndeChange(other, buttons[i]));
                }
            collectSound.GetComponent<AudioSource>().Play();
            particleSystem.Play();

         }

	}



    private IEnumerator moveAndeChange(Collider other, Button btn)
    {

        other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 2, other.gameObject.transform.position.z);
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
        if (!(gameObject == null && !ReferenceEquals(gameObject, null)))
            foodObjectController.FoodObjectList.Remove(other.gameObject);
        btn.GetComponentInChildren<ChangeSprite>().changeSprite();
        landingSound.GetComponent<AudioSource>().Play();
        if (!(gameObject == null && !ReferenceEquals(gameObject, null)))
            Destroy(other.gameObject);
    }

}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         