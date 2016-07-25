using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BoardController : MonoBehaviour {

    public ReciepCSVReader reciepCSVReader;
	void Start () {
        LoadSpritesInBoard();       
    }
	
	public void LoadSpritesInBoard()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        int i = 0;
        int j = 0;
        while (i < reciepCSVReader.ReciepList.Count)
        {
            buttons[j].GetComponent<Image>().sprite = Resources.Load<Sprite>(reciepCSVReader.ReciepList[i]);
            buttons[j + 1].GetComponent<Image>().sprite = Resources.Load<Sprite>(reciepCSVReader.ReciepList[i] + "_sw");
            i++;
            j += 2;
        }

    }
    void Update () {
	
	}
}
