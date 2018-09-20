using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    static public int score = 1000;

    void Awake() {
        //if the playerprefs highscore already exists, read it
        if (PlayerPrefs.HasKey("HighScore")) {
            score = PlayerPrefs.GetInt("HighScore");
        }
        //assign the high score to highscore
        PlayerPrefs.SetInt("HighScore", score);
    }

	void Update () {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + score;

        //update the playerprefs highscore if necessary
        if (score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
        }
	}
}
