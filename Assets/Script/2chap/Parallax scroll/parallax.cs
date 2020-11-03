using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {
    private float startpos;
    public GameObject player;
    public float parallaxEffect; // 원근감 속도
    
	// Use this for initialization
	void Start () {
        startpos = transform.position.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float dist = (player.transform.position.x * parallaxEffect); // player와의 거리를 계산해 원근감

        transform.position = new Vector3(startpos - dist, transform.position.y, transform.position.z); // 위치 재설정
	}
}
