using UnityEngine;
using System.Collections;

public class AddPictureToObject : MonoBehaviour {

	//public ArrayList spawnObjects;
	public Renderer rend;
	public Texture[] textures;
	private Shader shad;
	private GameObject foodObject; //Das Objekt an dem du die Textur ändern willst
	private Material material;
	private Texture2D oldTexture;
	private Texture2D newTexture;

	// Use this for initialization
	void Start () {
//		var go = GameObject.FindGameObjectWithTag("food");
//		var rend = go.GetComponent<Renderer>();
		rend = GetComponent<Renderer>();
		rend.material.mainTexture = Resources.Load("spiegelei") as Texture;
		var texture = rend.material.mainTexture;
//		rend.material.EnableKeyword ("_ALPHATEST_ON");
		Shader.EnableKeyword("_ALPHATEST_ON");
//		Shader.DisableKeyword("KEYWORD_OFF");

//		material = foodObject.GetComponent<Renderer>().GetComponent<Material> ();
//		newTexture = material.mainTexture;

	}
	
	// Update is called once per frame
	void Update () {
//		rend.material.mainTexture = textures[0];
//		material.mainTexture = newTexture;
	}
}
