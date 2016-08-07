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

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    public void buttonPressed()
    {
        anim.SetTrigger("Ingredient");
    }

    void Update()
    {
           // anim.SetTrigger("Ingredient");
       
    }
}

