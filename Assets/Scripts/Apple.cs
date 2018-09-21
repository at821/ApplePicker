using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    [Header("Set in Inspector")]
    public static float bottomY = -20f;

    void Update ()    {
        if (transform.position.y < bottomY)        {
            Destroy(this.gameObject);

            //get a refernce to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();

            //call the public appledestroyed() method of apScript
            apScript.AppleDestroyed();
        }
    }
}
