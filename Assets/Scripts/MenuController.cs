using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	public void ExitGame() {
        PlayerPrefs.SetFloat("gameOption", 1f);
		Application.Quit ();
	}
	public void MainMenu() {
        PlayerPrefs.SetFloat("gameOption", 1f);
        LoadScene("menu");
	}

	public void MenuRecipeEasy() {
		LoadScene ("menuRecipeEasy");
	}

	public void MenuRecipeMedium() {
		LoadScene ("menuRecipeMedium");
	}

	public void MenuRecipeHard() {
		LoadScene ("menuRecipeHard");
	}

	public void MenuTest() {
		LoadScene ("menuTest");
	}

    // EasyMaze Menues
    public void EasyMazeFondue()
    {
        PlayerPrefs.SetString("ChoosedReciep", "fondue");
        PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Fondü");
        LoadScene("easyMaze");
    }

	public void EasyMazeEldersirup()
    {
		PlayerPrefs.SetString("ChoosedReciep", "eldersirup");
        PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Holundersirup");
        LoadScene("easyMaze");
    }
    public void EasyMazeRoesti()
    {
        PlayerPrefs.SetString("ChoosedReciep", "roesti");
        PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Rösti");
        LoadScene("easyMaze");
    }

    public void EasyMazeRaclette()
    {
        PlayerPrefs.SetString("ChoosedReciep", "raclette");
        PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Raclette");
        LoadScene("easyMaze");
    }

    public void EasyMazeMeringue()
    {
        PlayerPrefs.SetString("ChoosedReciep", "meringue");
        PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Meringues");
        LoadScene("easyMaze");
    }


    // Menues MediumMaze
   
    public void MediumMaze() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        PlayerPrefs.SetString("reciepDE", "Älplermagronen");
        LoadScene("mediumMaze");
	}
	public void MediumMazeLaubfroesche() {
		PlayerPrefs.SetString("ChoosedReciep", "laubfroesche");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Laubfrösche");
		LoadScene("mediumMaze");
	}
	public void MediumMazeBirchermuesli() {
		PlayerPrefs.SetString("ChoosedReciep", "birchermuesli");
		PlayerPrefs.SetInt("IngredientsCount", 8);
		PlayerPrefs.SetString("reciepDE", "Bircher Müsli");
		LoadScene("mediumMaze");
	}
	public void MediumMazeFischknusperli() {
		PlayerPrefs.SetString("ChoosedReciep", "fischknusperli");
		PlayerPrefs.SetInt("IngredientsCount", 8);
		PlayerPrefs.SetString("reciepDE", "Fischknusperli");
		LoadScene("mediumMaze");
	}
	public void MediumMazeAelplermagronen() {
		PlayerPrefs.SetString("ChoosedReciep", "aelplermagronen");
		PlayerPrefs.SetInt("IngredientsCount", 8);
		PlayerPrefs.SetString("reciepDE", "Älplermagronen");
		LoadScene("mediumMaze");
	}
	public void MediumMazeVermicelles() {
		PlayerPrefs.SetString("ChoosedReciep", "vermicelles");
		PlayerPrefs.SetInt("IngredientsCount", 6);
		PlayerPrefs.SetString("reciepDE", "Vermicelles");
		LoadScene("mediumMaze");
	}
	public void MediumMazeFotzelschnitte() {
		PlayerPrefs.SetString("ChoosedReciep", "fotzelschnitte");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Fotzelschnitte");
		LoadScene("mediumMaze");
	}
	public void MediumMazeZuerchergeschnetzeltes() {
		PlayerPrefs.SetString("ChoosedReciep", "zuerchergeschnetzeltes");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Zürcher Geschnetzeltes");
		LoadScene("mediumMaze");
	}


    // Menues for hardMaze
	public void HardMaze() {
        PlayerPrefs.SetString("ChoosedReciep", "capuns");
        PlayerPrefs.SetInt("IngredientsCount", 9);
        PlayerPrefs.SetString("reciepDE", "Capuns");
        LoadScene("hardMaze");
	}
	public void HardMazeCapuns() {
		PlayerPrefs.SetString("ChoosedReciep", "capuns");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Capuns");
		LoadScene("hardMaze");
	}
	public void HardMazeKuerbissuppe() {
		PlayerPrefs.SetString("ChoosedReciep", "kuerbissuppe");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Kürbissuppe");
		LoadScene("hardMaze");
	}
	public void HardMazeSpinatwaehe() {
		PlayerPrefs.SetString("ChoosedReciep", "spinatwaehe");
		PlayerPrefs.SetInt("IngredientsCount", 10);
		PlayerPrefs.SetString("reciepDE", "Spinatwähe");
		LoadScene("hardMaze");
	}
	public void HardMazeSuuremocke() {
		PlayerPrefs.SetString("ChoosedReciep", "suuremocke");
		PlayerPrefs.SetInt("IngredientsCount", 11);
		PlayerPrefs.SetString("reciepDE", "Suure Mocke");
		LoadScene("hardMaze");
	}
	public void HardMazeFlammkuchen() {
		PlayerPrefs.SetString("ChoosedReciep", "flammkuchen");
		PlayerPrefs.SetInt("IngredientsCount", 11);
		PlayerPrefs.SetString("reciepDE", "Flammkuchen");
		LoadScene("hardMaze");
	}
	public void HardMazeBernerplatte() {
		PlayerPrefs.SetString("ChoosedReciep", "bernerplatte");
		PlayerPrefs.SetInt("IngredientsCount", 10);
		PlayerPrefs.SetString("reciepDE", "Berner Platte");
		LoadScene("hardMaze");
	}
	public void HardMazeApfelwaehe() {
		PlayerPrefs.SetString("ChoosedReciep", "apfelwaehe");
		PlayerPrefs.SetInt("IngredientsCount", 11);
		PlayerPrefs.SetString("reciepDE", "Apfelwähe");
		LoadScene("hardMaze");
	}
	public void HardMazeLauchquiche() {
		PlayerPrefs.SetString("ChoosedReciep", "lauchquiche");
		PlayerPrefs.SetInt("IngredientsCount", 10);
		PlayerPrefs.SetString("reciepDE", "Lauchquiche");
		LoadScene("hardMaze");
	}

    public void HardMazeLachscanape()
    {
        PlayerPrefs.SetString("ChoosedReciep", "lachscanape");
        PlayerPrefs.SetInt("IngredientsCount",10);
        PlayerPrefs.SetString("reciepDE", "Lachscanapé");
        LoadScene("hardMaze");
    }

    private void LoadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
		Debug.Log ("Loading " + sceneName);
		Scene mazeScene = SceneManager.GetSceneByName (sceneName);
		SceneManager.SetActiveScene(mazeScene);
	}


    public void GameOptions(Slider slider)
    {
        PlayerPrefs.SetFloat("gameOption", slider.value);
    }
}
