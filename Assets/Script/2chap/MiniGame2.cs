using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MiniGame2 : MonoBehaviour {

	//[SerializeField]
	//private GameObject mGame2;
	public raykast ray;
	public StateManager state;
	public Text countText;
	public Vector2 targetPos;
	public int bugCount = 5;
	public GameObject fireDog;
	public PlayerMove playerScript;
	public float x, y;
	// Use this for initialization
	void Start () {
		countText.transform.gameObject.SetActive(true);
	}

	void Update()
	{
		mouseControl(); // 빈딧불이의 남은 마릿수 표시
		catchBug(); // 반딧불이 잡기
		gameEnd(); // 미니게임2가 끝났을때
	}

	void catchBug()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (ray.hit == true)
			{
				if (ray.hit.collider.tag == "key")
				{
					Destroy(ray.hit.transform.gameObject);
					bugCount -= 1;
				}
			}
		}
	}

	void mouseControl()
	{
		countText.text = bugCount.ToString();
		targetPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		countText.transform.position = new Vector2(targetPos.x + x, targetPos.y + y);
	}
	void gameEnd()
	{
		if (bugCount == 0)
		{

			playerScript.isClick = false;
			countText.transform.gameObject.SetActive(false);
			state.isMove = true;
			StateManager.isStory = false;
			fireDog.GetComponent<Animator>().SetBool("isRun", false);
			fireDog.GetComponent<DogManager>().StopAllCoroutines();
			Destroy(fireDog.GetComponent<DogManager>());
			Destroy(this);
		}
	}

}
