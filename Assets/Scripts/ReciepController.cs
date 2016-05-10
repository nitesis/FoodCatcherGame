using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReciepController : MonoBehaviour {

    public List<string> reciepList = new List<string>();

    public ReciepController()
    {
        reciepList.Add("potato");
        reciepList.Add("onion");
        reciepList.Add("gralic");
        reciepList.Add("stock");
        reciepList.Add("pasta");
        reciepList.Add("cheese");
        reciepList.Add("ham");
    }


	void Start () {
    }

    // Update is called once per frame
    void Update () {
	
	}
}
