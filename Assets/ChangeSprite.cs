using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeSprite : MonoBehaviour {

	//public Image colorImg;
	public Image bwImg;

	public void changeSprite()
	{
		bwImg = GetComponent<Image>();

		Color c = bwImg.color;
		c.a = 0.1f;
		bwImg.color = c;
	}

	// Use this for initialization
	void Start () 
	{
		

		
	}



	// Update is called once per frame
	void Update () 
	{
		
	}
}
