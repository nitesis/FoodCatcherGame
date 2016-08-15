using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IngredientManager : MonoBehaviour {

    public float restartDelay = 5f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level
    private Button pressedbutton;
    private bool pressed;
    private bool firstRun;


    void Start()
    {
        pressed = false;
        firstRun = true;
    }
    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    public void buttonPressed(Button btn)
    {
        if (pressed == false)
        {
            GetComponentInChildren<Button>().GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            if (firstRun)
            {
                anim.SetTrigger("Ingredient");
                firstRun = false;
            }
            else
                anim.SetTrigger("IngredientIn");
            pressed = true;

        }
        else
        {
            anim.ResetTrigger("Ingredient");
            anim.SetTrigger("IngredientOut");
            pressed = false;
        }
    }

    public void ClickToClose()
    {
        gameObject.SetActive(false);

    }

    private IEnumerator doProcess(Button btn)
    {
        GetComponentInChildren<Button>().GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
        anim.SetTrigger("Ingredient");
        yield return new WaitForSeconds(3f);
       // gameObject.SetActive(false);



    }

    void Update()
    {
           // anim.SetTrigger("Ingredient");
       
    }
}

