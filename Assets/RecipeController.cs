using UnityEngine;
using System.Collections;

public class RecipeController : MonoBehaviour {

	public Animator recipe;

	// Use this for initialization
	void Start () {
		recipe.SetBool ("isHidden", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
