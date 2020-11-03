using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAutoMove : MonoBehaviour {

	public GameObject missionMap;
	GameObject star;
	bool isClone = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * 0.1f * Time.deltaTime;
		if (transform.position.x < 12.12f && !isClone) // 일정위치가 되었을때, GameObejct당 한번만
		{
			isClone = true;
			star = Instantiate(gameObject); //gameObject 객체 복사 생성
			star.transform.parent = missionMap.transform; // missionMap에 종속시킴
			star.transform.position = new Vector2(49.06f, transform.position.y); // 시작위치
		}
		if (transform.position.x < -6.72f)
			Destroy(gameObject); // 끝까지간 객체는 삭제
	}
}
