using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePop : MonoBehaviour {

    public GameObject miniGame;
    private bool isGame = false;
	// Use this for initialization
	void Start () {
        miniGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isGame)
        {
            miniGame.SetActive(true);
            isGame = !isGame;
        }
        if (Input.GetMouseButtonDown(1))
        {
            //miniGame.SetActive(false);
        }
	}
}
