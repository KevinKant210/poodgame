using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public void playGame() {
        PlayerPrefs.SetInt("currScore", 0);
        PlayerPrefs.SetInt("currLevel", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void loadGame(){
        string sceneName = "Level " + PlayerPrefs.GetInt("savedLevel");
        
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()  {
        Application.Quit();
    }
}
