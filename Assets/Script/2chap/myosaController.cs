using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myosaController : MonoBehaviour {
	/*
	 * 이거 실행 제대로되려면 맵에 collider박아줘서 hit값이 항상 찍혀야함
	 * 근대 그렇게되면 hit이 맵만 찍음
	 * 시발
	 */
	public GameObject player;
	public GameObject npc2;
	public bool isFollow = false;
	private Vector2 targetPos;
	private Animator catAnim;
	public raykast ray;
	public StateManager state;
	private float time = 0;
	float dis = 0;
	// Use this for initialization
	void Start () {
		catAnim = GetComponent<Animator>();
	}

	//void LateUpdate()
	//{
	//	if (isFollow)
	//	{
	//		if (Input.GetMouseButtonDown(0))
	//		{
	//			catChangeMove();
	//		}
	//	}
	//}

	// Update is called once per frame
	void Update () {
		if (state.isCatFollow) { 
			dis = Vector3.Distance(player.transform.position, this.transform.position);
			if(dis < 1f)
			{
				Debug.Log("STOP");
				catState(true, false, false);
				Debug.Log(player.transform.position.x + " " + this.transform.position.x);
			}
			else if(player.transform.position.x > this.transform.position.x)
			{
				Debug.Log("CAT LEFT");
				catState(false, false, true);
			}
			else if(player.transform.position.x < this.transform.position.x)
			{
				Debug.Log("CAT RIGHT");
				catState(false, true, false);
			}
		}
		else
		{
			if (this.transform.position.x > 24.7)
			{
				catState(false, true, false);
			}
			else
				catState(true, false, false);
		}
	}
	void FixedUpdate()
	{
		catMove();
	}
	void catMove()
	{
		if (catAnim.GetBool("isLwalk"))
		{
			transform.position += Vector3.left * Time.deltaTime;
		}
		else if (catAnim.GetBool("isRwalk"))
		{
			transform.position += Vector3.right * Time.deltaTime;
		}
	}


	void catState(bool Idle,bool Lwalk, bool Rwalk)
	{
		catAnim.SetBool("isIdle", Idle);
		catAnim.SetBool("isLwalk", Lwalk);
		catAnim.SetBool("isRwalk", Rwalk);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
		}
	}
}
