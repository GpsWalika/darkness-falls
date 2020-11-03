using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    private Vector3 initPos;
    private GameObject cam;
    public float shakeTime;
    public float shakeAmount;
    private Vector3 ran;
	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera");
        initPos = new Vector3(0, 0, -10f);	
        
	}
	
	// Update is called once per frame
	void Update () {
		if(shakeTime > 0)
        {
            ran = Random.insideUnitSphere;
            
            cam.transform.position =  new Vector3(ran.x, Mathf.Clamp(ran.y, 0, 4f), ran.z) * shakeAmount + initPos;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0;
            cam.transform.position = initPos;
        }
	}
}
