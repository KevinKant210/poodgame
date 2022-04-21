using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    void Start() {
        currentScoreText.text = "Current Score: " + PlayerPrefs.GetInt("currScore");
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }
}
