using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*내최선이다 시부랄거 더좋은코드있으면 해주셈*/
//이거는 그냥 트렌지션만 해주는 스크립트로 다른 오브젝트 오면안됨 ex) dog
//옙
public class transitionScript : MonoBehaviour {
    public StateManager state;
    public GameObject[] fade;
    public Vector3 playerPos, cameraPos;
    public SpriteRenderer rendTitles;   //Object Renderer => Map changes
    public Sprite[] spriteTitleImages;    //sprite Image
    static private int spriteCounter = 2;
    public bool isTransition = false;
    private bool isDelay = false; 

    public float delay=0;
	// Update is called once per frame
	void Update () {
        Transition();
        Delay();
	}

    void Delay()
    {
        if (isDelay)
            delay += Time.deltaTime;
    }
    void Transition()
    {
        if (delay > 3 && isTransition)
        {
            isTransition = false;
            delay = 0;
            GameObject.Find("player").transform.position = playerPos;
            Camera.main.transform.position = cameraPos;
            fade[0].SetActive(false);
            fade[1].SetActive(true);
            GameObject.Find("player").transform.GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else if (delay > 3)
        {
            state.isMove = true;
            isDelay = false;
            delay = 0;
            fade[1].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (state.nextMap)
            {
                state.isMove = false;
                fade[0].SetActive(true);
                isDelay = true;
                isTransition = true;
                StartCoroutine(nChangeTitleImages());
            }
        }
    }

    IEnumerator nChangeTitleImages()
    {
        yield return new WaitForSeconds(2.9f);
        rendTitles.sprite = spriteTitleImages[spriteCounter++];
    }
}
