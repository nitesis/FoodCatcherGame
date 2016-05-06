using UnityEngine;
using System.Collections;

public class AddPictureToObject : MonoBehaviour {

	public Renderer rend;
	public Texture[] textures;
	private Shader shad;
	private GameObject foodObject; //Das Objekt an dem du die Textur ändern willst
	private Material material;
	private Texture2D oldTexture;
	private Texture2D newTexture;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.mainTexture = Resources.Load("spiegelei") as Texture;
		var texture = rend.material.mainTexture;
		Shader.EnableKeyword("_ALPHATEST_ON");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
