using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IngredientManager : MonoBehaviour {
      


    Animator anim;                          
    private bool pressed;
    private bool firstRun;


    void Start()
    {
        pressed = false;
        firstRun = true;
    }

    void Awake()
    {
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

}

