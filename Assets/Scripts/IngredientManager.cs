using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IngredientManager : MonoBehaviour {

    public Text reciepName;
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
        Color c;
        if (pressed == false)
        {
            GetComponentInChildren<Button>().GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            Text[] texts = GetComponentsInChildren<Text>();
            texts[1].text= btn.GetComponentInChildren<Text>().text;
            c = reciepName.color;
            c.a = 0f;
            reciepName.color = c;
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
            c = reciepName.color;
            c.a = 1f;
            reciepName.color = c;
            anim.ResetTrigger("Ingredient");
            anim.SetTrigger("IngredientOut");
            pressed = false;
        }
    }

}

