﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {

	[Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	void Start () {
        basketList = new List<GameObject>();

        for (int i=0; i<numBaskets; i++)        {
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
	}

    public void AppleDestroyed()    {
        //destory all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }

        //Destroy one of the baskets
        //get the index of the last basket in basketlist
        int basketIndex = basketList.Count-1;

        //get a reference to that Basket GameObject
        GameObject tBasketGo = basketList[basketIndex];

        //remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGo);

        if (basketList.Count == 0)      {
            SceneManager.LoadScene("picked_0");
        }

    }
	
	
}
