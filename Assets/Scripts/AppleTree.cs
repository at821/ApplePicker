using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

    [Header("Set in Inspector")]
    //Prefab for instantiation apples
    public GameObject applePrefab;

    //speed at which the Apple tree moves
    public float speed = 1f;

    //Distance where AppleTress turns around
    public float leftAndRightEdge = 10f;
    
    //Chance that the Appletree will change directions
    public float chanceToChangeDirections = 0.1f;

        //rate at which apples will be instantiated
        public float secondsBetweenAppleDrops = 1f;

    void Start ()    {
        //Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    void Update() {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //changing direction
        if ( pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); //Move right
        }
        else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Moves left
        }
     }   
    
    void FixedUpdate() {

     //changing direction rendomly is now time-based because of FixedUpdate ()
        if (Random.value < chanceToChangeDirections) {

            speed *= -1; //change direction
        }

    }
   
    

}
