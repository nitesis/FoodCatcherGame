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
        StartCoroutine(doAnimationSteps(btn));
    }

    private IEnumerator doAnimationSteps(Button btn)
    {
        Color c;
        if (pressed == false)
        {
            GetComponentInChildren<Button>().GetComponent<Image>().sprite = btn.GetComponent<Image>().sprite;
            Text[] texts = GetComponentsInChildren<Text>();
            texts[1].text = btn.GetComponentInChildren<Text>().text;
            c = reciepName.color;
            c.a = 0f;
            if (firstRun)
            {
                anim.SetTrigger("Ingredient");
                firstRun = false;
                yield return new WaitForSeconds(0.45f);
                reciepName.color = c;
            }
            else {
                anim.SetTrigger("IngredientIn");
                yield return new WaitForSeconds(0.45f);

                reciepName.color = c;
                 }
            pressed = true;

        }
        else
        {
            anim.ResetTrigger("Ingredient");
            anim.SetTrigger("IngredientOut");
            pressed = false;
            yield return new WaitForSeconds(0.6f);
            c = reciepName.color;
            c.a = 1f;
            reciepName.color = c;
        }
    }

}

