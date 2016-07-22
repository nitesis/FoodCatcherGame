using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public FoodObjectController foodObjectController;
	public float restartDelay = 8f;

    private bool sphereCollided;

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
}
