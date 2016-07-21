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

	public void EasyMaze() {
        PlayerPrefs.SetString("ChoosedReciep", "Capuns");
        PlayerPrefs.SetInt("IngredientsCount", 5);
		LoadScene("easyMaze");

    }

    public void MediumMaze() {
		LoadScene("mediumMaze");
	}

	public void HardMaze() {
		LoadScene("hardMaze");
	}

	private void LoadScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
		Debug.Log ("Loading " + sceneName);
		Scene mazeScene = SceneManager.GetSceneByName (sceneName);
		SceneManager.SetActiveScene(mazeScene);
	}
}
