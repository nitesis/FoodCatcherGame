using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public FoodObjectController foodObjectController;
	public float restartDelay = 8f;

    private bool sphereCollided;
	private string recipe;
	private Image image;
	private Sprite newSprite;

    public bool SphereCollided
    {
        get { return SphereCollided;}
        set { sphereCollided = value; }
    }

	Animator anim;
	float restartTimer;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}


    void Start()
    {
        sphereCollided = false;
		LoadSpritesInGameOverScreen ();
    }
		
	// Update is called once per frame
	void Update () 
	{
        //if ((foodObjectController.FoodItemCount <= 0) )
        if ((foodObjectController.FoodObjectList.Count==0)&& (sphereCollided==true))
            {
			
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                anim.SetTrigger("GameOver");
            }

			restartTimer += Time.deltaTime;
		    }
			if (restartTimer >= 4*restartDelay) 
		    {
			SceneManager.LoadScene ("menu");
		    }
	}

	public void LoadSpritesInGameOverScreen()
	{
		Debug.Log("LoadSpritesInGameOverScreen() started");
		Debug.Log("From FoodobjectController: " + PlayerPrefs.GetString("ChoosedReciep"));
		recipe = PlayerPrefs.GetString ("ChoosedReciep");
		newSprite = Resources.Load<Sprite> (recipe);
		Debug.Log("GetComponent<Image>().sprite = " + recipe);
		Image[] images = GetComponentsInChildren<Image>();
		Text[] texts = GetComponentsInChildren<Text> ();
		Debug.Log("Laenge des Image Arrays: " + texts.Length);
		images[2].GetComponent<Image>().sprite = newSprite;
		texts [0].GetComponent<Text> ().text = recipe;


	}
}
