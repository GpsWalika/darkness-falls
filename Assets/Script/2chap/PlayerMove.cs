using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField]
    private StateManager state;
    public bool isClick = false;
    public Vector2 playPos;
    private Vector2 tarPos;
    public raykast ray;
    public Animator ani;
    public bool isAnime = false;
    public GameObject talkDialog;
    private Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        ray = GameObject.Find("RayCastObject").GetComponent<raykast>();
        ani = gameObject.GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isClick && state.isMove) {
            isClick = false;
            if (!talkDialog.activeSelf) { 
                tarPos = ray.targetPos;
            
                StopAllCoroutines();
                StartCoroutine(Movement());
            }
        }

    }

    IEnumerator Movement()
    {
        float distance = 0f;

        playPos = transform.position;
        if (gameObject.transform.position.x < tarPos.x)
        {
            aniState(false, false, true);
            while (gameObject.transform.position.x <= tarPos.x)
            {
                transform.position += Vector3.right * 2f * Time.deltaTime;
                if (ray.hit == true && (ray.hit.collider.tag == "npc" || ray.hit.collider.tag == "cat"))
                    distance = Vector3.Distance(transform.position, ray.hit.transform.position);
                if (gameObject.transform.position.x >= tarPos.x)
                {
                    if (ray.hit)    // hit Null Object 가 아니면
                        if ((ray.hit.collider.tag == "npc" || ray.hit.collider.tag == "cat")&& distance <= 1.2f)   //hit한 오브젝트의 이름이 npc이고 둘의 거리가 1 이하이면
                        {
                            Debug.Log(ray.hit.collider.tag);
                            isAnime = true; //애니메 true
                        }
                    aniState(false, true, false);
                }

                yield return null;
            }
        }
        else if (gameObject.transform.position.x > tarPos.x)
        {
            aniState(true, false, false);
            while (gameObject.transform.position.x >= tarPos.x)
            {
                transform.position += Vector3.left * 2f * Time.deltaTime;
                if (ray.hit == true && (ray.hit.collider.tag == "npc" || ray.hit.collider.tag == "cat"))
                    distance = Vector3.Distance(transform.position, ray.hit.transform.position);
                if (gameObject.transform.position.x <= tarPos.x)
                {
                    if (ray.hit)    // hit Null Object 가 아니면
                        if ((ray.hit.collider.tag == "npc" || ray.hit.collider.tag == "cat ") && distance <= 1.2f)   //hit한 오브젝트의 이름이 npc이고 둘의 거리가 1 이하이면
                        {
                            isAnime = true; //애니메 true
                        }
                    aniState(false, true, false);
                }
                yield return null;
            }
        }
    }
    public void aniState(bool lWalk, bool Idle, bool rWalk)
    {
        ani.SetBool("LeftWalk", lWalk);
        ani.SetBool("Idle", Idle);
        ani.SetBool("RightWalk", rWalk);
    }
}
