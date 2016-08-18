using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public FoodObjectController foodObjectController;
    public Text reciepText;
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


	void Update () 
	{
        if ((foodObjectController.FoodObjectList.Count==0)&& (sphereCollided==true))
            {
			
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                anim.SetTrigger("GameOver");
                Color c;
                c = reciepText.color;
                c.a = 0f;
                reciepText.color = c;
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
		recipe = PlayerPrefs.GetString ("ChoosedReciep");
		newSprite = Resources.Load<Sprite> (recipe);
		Image[] images = GetComponentsInChildren<Image>();
		images[2].GetComponent<Image>().sprite = newSprite;
        Text[] texts = GetComponentsInChildren<Text>();
        texts[0].text= PlayerPrefs.GetString("reciepDE");
        texts[1].text = "Gratulation!\n Sie haben alle Zutaten für "+ PlayerPrefs.GetString("reciepDE")+ " gesammelt.";
        texts[1].text.Replace("\\n", "\n");

    }
}
