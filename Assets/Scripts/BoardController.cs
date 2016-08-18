using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class BoardController : MonoBehaviour {

    public ReciepCSVReader reciepCSVReader;
    public IngredientsCSVReader ingredientsCSVReader;
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
            buttons[j].GetComponent<Image>().sprite = Resources.Load<Sprite>(reciepCSVReader.ReciepList[i]+"_big");
            buttons[j+1].GetComponent<Image>().sprite = Resources.Load<Sprite>(reciepCSVReader.ReciepList[i]+"_big_sw");
            buttons[j].GetComponentInChildren<Text>().text = ingredientsCSVReader.Find_NameEn(reciepCSVReader.ReciepList[i]).NameDe.ToString();
            buttons[j+1].GetComponentInChildren<Text>().text = ingredientsCSVReader.Find_NameEn(reciepCSVReader.ReciepList[i]).NameDe.ToString();
            i++;
            j += 2;
        }

        for(int k=j-1; j<buttons.Length; j++)
        {

            Color c=buttons[j].image.color;
            c.a = 0.0f;
            buttons[j].image.color = c;
        }

    }
    void Update () {
	
	}
}
