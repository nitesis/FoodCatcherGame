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
		LoadScene ("mediumMaze_BrownStoneFlowerOrange");
	}

	public void MediumMaze_BrownStoneFlowerYellow() {
		LoadScene ("mediumMaze_BrownStoneFlowerYellow");
	}

	public void MediumMaze_BrownStoneGrass() {
		LoadScene ("mediumMaze_BrownStoneGrass");
	}

	public void MediumMaze_BrownStoneWater() {
		LoadScene ("mediumMaze_BrownStoneWater");
	}

	public void MediumMaze_GreyStoneFlowerRed() {
		LoadScene ("mediumMaze_GreyStoneFlowerRed");
	}

	public void MediumMaze_waterBrownStone() {
		LoadScene ("mediumMaze_waterBrownStone");
	}

	public void MediumMaze_waterBrownStoneLight() {
		LoadScene ("mediumMaze_waterBrownStoneLight");
	}

	public void MediumMaze_waterFlowerOrange() {
		LoadScene ("mediumMaze_waterFlowerOrange");
	}

	public void MediumMaze_waterFlowerRed() {
		LoadScene ("mediumMaze_waterFlowerRed");
	}

	public void MediumMaze_waterFlowerWhite() {
		LoadScene ("mediumMaze_waterFlowerWhite");
	}

	public void MediumMaze_waterFlowerYellow() {
		LoadScene ("mediumMaze_waterFlowerYellow");
	}

	public void MediumMaze_waterGreyStone() {
		LoadScene ("mediumMaze_waterGreyStone");
	}
	public void EasyMazeFondue() {
        PlayerPrefs.SetString("ChoosedReciep", "Fondue");
        PlayerPrefs.SetInt("IngredientsCount", 5);
		LoadScene("easyMaze");
    }
	public void EasyMazeRoesti() {
		PlayerPrefs.SetString("ChoosedReciep", "Roesti");
		PlayerPrefs.SetInt("IngredientsCount", 5);
		LoadScene("easyMaze");
	}
    public void MediumMaze() {
        PlayerPrefs.SetString("ChoosedReciep", "Aelplermagronen");
        PlayerPrefs.SetInt("IngredientsCount", 8);
        LoadScene("mediumMaze");
	}

	public void HardMaze() {
        PlayerPrefs.SetString("ChoosedReciep", "Capuns");
        PlayerPrefs.SetInt("IngredientsCount", 9);
        LoadScene("hardMaze");
	}

	private void LoadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
		Debug.Log ("Loading " + sceneName);
		Scene mazeScene = SceneManager.GetSceneByName (sceneName);
		SceneManager.SetActiveScene(mazeScene);
	}
}
