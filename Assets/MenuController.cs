using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void MainMenu() {
		LoadScene ("menu");
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
	public void MediumMaze_BrownStoneFlowerOrange() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_BrownStoneFlowerOrange");
	}

	public void MediumMaze_BrownStoneFlowerYellow() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_BrownStoneFlowerYellow");

	}

	public void MediumMaze_BrownStoneGrass() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_BrownStoneGrass");
	}

	public void MediumMaze_BrownStoneWater() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_BrownStoneWater");
	}

	public void MediumMaze_GreyStoneFlowerRed() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_GreyStoneFlowerRed");
	}

	public void MediumMaze_waterBrownStone() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterBrownStone");
	}

	public void MediumMaze_waterBrownStoneLight() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterBrownStoneLight");
	}

	public void MediumMaze_waterFlowerOrange() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterFlowerOrange");
	}

	public void MediumMaze_waterFlowerRed() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterFlowerRed");
	}

	public void MediumMaze_waterFlowerWhite() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterFlowerWhite");
	}

	public void MediumMaze_waterFlowerYellow() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterFlowerYellow");
	}

	public void MediumMaze_waterGreyStone() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene ("mediumMaze_waterGreyStone");
	}
	public void EasyMazeFondue() {
        PlayerPrefs.SetString("ChoosedReciep", "fondue");
        PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Fondü");
        LoadScene("easyMaze");
    }
	public void EasyMazeRoesti() {
		PlayerPrefs.SetString("ChoosedReciep", "roesti");
		PlayerPrefs.SetInt("IngredientsCount", 5);
        PlayerPrefs.SetString("reciepDE", "Rösti");
        LoadScene("easyMaze");
	}
    public void MediumMaze() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        PlayerPrefs.SetString("reciepDE", "Älplermagronen");
        LoadScene("mediumMaze");
	}
	public void MediumMazeLaubfroesche() {
		PlayerPrefs.SetString("ChoosedReciep", "laubfroesche");
		PlayerPrefs.SetInt("IngredientsCount", 8);
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
		PlayerPrefs.SetInt("IngredientsCount", 8);
		PlayerPrefs.SetString("reciepDE", "Vermicelles");
		LoadScene("mediumMaze");
	}
	public void MediumMazeFotzelschnitte() {
		PlayerPrefs.SetString("ChoosedReciep", "fotzelschnitte");
		PlayerPrefs.SetInt("IngredientsCount", 8);
		PlayerPrefs.SetString("reciepDE", "Fotzelschnitte");
		LoadScene("mediumMaze");
	}
	public void MediumMazeZuerchergeschnetzeltes() {
		PlayerPrefs.SetString("ChoosedReciep", "zuerchergeschnetzeltes");
		PlayerPrefs.SetInt("IngredientsCount", 8);
		PlayerPrefs.SetString("reciepDE", "Zürcher Geschnetzeltes");
		LoadScene("mediumMaze");
	}

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
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Spinatwähe");
		LoadScene("hardMaze");
	}
	public void HardMazeSuuremocke() {
		PlayerPrefs.SetString("ChoosedReciep", "suuremocke");
		PlayerPrefs.SetInt("IngredientsCount", 9);
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
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Berner Platte");
		LoadScene("hardMaze");
	}
	public void HardMazeApfelwaehe() {
		PlayerPrefs.SetString("ChoosedReciep", "apfelwaehe");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Apfelwähe");
		LoadScene("hardMaze");
	}
	public void HardMazeLauchquiche() {
		PlayerPrefs.SetString("ChoosedReciep", "lauchquiche");
		PlayerPrefs.SetInt("IngredientsCount", 9);
		PlayerPrefs.SetString("reciepDE", "Lauchquiche");
		LoadScene("hardMaze");
	}
	private void LoadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
		Debug.Log ("Loading " + sceneName);
		Scene mazeScene = SceneManager.GetSceneByName (sceneName);
		SceneManager.SetActiveScene(mazeScene);
	}
}
