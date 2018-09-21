using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start ()   {
        //find a refernce to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        //get the Text component of that GameObject
        scoreGT = scoreGO.GetComponent<Text>();

        //set the starting number of points to 0
        scoreGT.text = "0";
    }
	
	void Update () {
        //get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //the cammera's z position sets how far to push the mouse into 3d
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Move the x posiition of this Basket to the zPosition of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
	}

    void OnCollisionEnter(Collision coll) {
        //find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);

            //Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);

            //add points for catching the apple
            score += 100;

            //convert the score back to a string and display it
            scoreGT.text = score.ToString();

            //track the high score
            if (score > HighScore.score)            {
                HighScore.score = score;
            }
        }
        
        
    }
}
