using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * 소스코드 조금 간소화할 필요있음.
 * 그리고 호패나 대화중 땅에 레이캐스트찍으면 호패사라지거나, 
 * 대화끝난후 그쪽으로 이동하는 버그 있어서 수정해야함
 * bool 형은 Statemanager에 다 모아두고 있음
 */
public class GameManager : MonoBehaviour {
    [SerializeField]
    private StateManager state;
    public transitionScript trans;
    public raykast ray;
    public talkScript ts;
    public GameObject playerObject;
    public PlayerMove playerScript;
    public GameObject hopae;
    public GameObject npc;
    public GameObject npc2;
    public GameObject mGame2;
    public GameObject missionText;
    public GameObject myosa;
    public GameObject bigDipper;
    public Animator npc2Anime;
    public Text nameText;
    // Use this for initialization
    void Start () {
        //ts = GameObject.Find("ScriptManager").GetComponent<talkScript>();
        //state = GameObject.Find("StateManager").GetComponent<StateManager>();
       // playerObject = GameObject.Find("player");
        //playerScript = GameObject.Find("player").GetComponent<PlayerMove>();
    }
	
	// Update is called once per frame
	void Update () {
        scriptControl(); // 스크립트 건드는곳
        storyTransition();

    }
    void storyTransition() // 트랜지션될때 story2 on -> story1 이랑 충돌되는 버그있어서 만듬
    {
        if (trans.isTransition)
        {
            StateManager.isStory = false;
            state.story2 = true;
            talkScript.talkCount = 0;
        }
    }

    void scriptControl()
    {
        if (ray.hit == true)
        {

            if (state.story1) // 첫번째 스토리
            {
                nameText.text = "연년무곡성";
                if (ray.hit.collider.tag == "npc" && !StateManager.isStory)
                {
                    if (playerObject.transform.position.x <= ray.hit.transform.position.x - 1.2f &&
                        playerObject.transform.position.x >= ray.hit.transform.position.x + 1.2f) { }
                    //ts.storyObj.SetActive(true);
                    else
                    {
                        playerScript.isClick = true;
                    }
                }
                else if (ray.hit.collider.tag == "next_button" && !StateManager.isStory)   //나중에 미션2를 위해 수정해야 할듯
                {
                    state.isHit = true;
                    ts.storyObj.SetActive(false);
                    StateManager.isStory = true;

                    if (talkScript.talkCount < talkScript.storyTalk1.Length)
                        (ts.storyObj.transform.GetChild(2).GetChild(0).
                                        GetComponent<Text>().text) = talkScript.storyTalk1[talkScript.talkCount++];
                    else
                    {
                        npc.GetComponent<BoxCollider2D>().enabled = false;
                        state.nextMap = true;
                        state.story1 = false;
                        npc.tag = "Untagged";
                        StartCoroutine(MoveNpc());
                    }
                }
                if (ray.hit.collider.tag == "hopae" && StateManager.isStory)
                {
                    //ray.targetPos = new Vector2(0, 0);
                    state.isHit = false;
                    state.isMove = false;
                    StartCoroutine(FadewaitTime());
                }
            }

            else if (state.story2) // 두번째 스토리
            {
                nameText.text = "오귀염정성";
                if (ray.hit.collider.tag == "npc" && !StateManager.isStory)
                {
                    //ts.storyObj.SetActive(true);
                    if (playerObject.transform.position.x <= ray.hit.transform.position.x - 2f &&
                        playerObject.transform.position.x >= ray.hit.transform.position.x + 2f)
                    {
                        Debug.Log("2");
                        //ts.storyObj.SetActive(true);
                    }
                    else
                    {
                        playerScript.isClick = true;
                    }

                    (ts.storyObj.transform.GetChild(2).GetChild(0).
                                    GetComponent<Text>().text) = talkScript.storyTalk2[talkScript.talkCount];
                }

                else if (ray.hit.collider.tag == "next_button")   //나중에 미션2를 위해 수정해야 할듯
                {
                    Debug.Log(talkScript.talkCount);
                    state.isHit = true;
                    StateManager.isStory = true;

                    if (talkScript.talkCount == 0)
                    {
                        (ts.storyObj.transform.GetChild(2).GetChild(0).
                                        GetComponent<Text>().text) = talkScript.storyTalk2[talkScript.talkCount++];
                        ts.storyObj.SetActive(false);
                        StartCoroutine(MissionCoroutine());
                    }
                    else if (talkScript.talkCount < talkScript.storyTalk2.Length)
                    {
                        //talkScript.talkCount++;
                           (ts.storyObj.transform.GetChild(2).GetChild(0).
                                        GetComponent<Text>().text) = talkScript.storyTalk2[talkScript.talkCount++];

                    }
                    else// if (talkScript.talkCount > 3)
                    {
                        npc2.GetComponent<BoxCollider2D>().enabled = false;
                        npc2.tag = "Untagged";
                        //state.nextMap = true;
                        StateManager.isStory = false;
                        state.story2 = false;
                        ts.storyObj.SetActive(false);
                        myosa.SetActive(true);
                        state.isCat = true;
                        talkScript.talkCount = 0;
                    }
                }
            }
            else if (state.isCat)
            {
                nameText.text = "묘사";
                Debug.Log("isanim : "+playerScript.isAnime);
                Debug.Log("isstory:" + StateManager.isStory);
                if (ray.hit.collider.tag == "cat" && !StateManager.isStory)
                {
                    //ts.storyObj.SetActive(true);
                    if (playerObject.transform.position.x <= ray.hit.transform.position.x - 2f &&
                        playerObject.transform.position.x >= ray.hit.transform.position.x + 2f)
                    {
                        Debug.Log("2");
                        //ts.storyObj.SetActive(true);
                    }
                    else
                    {
                        playerScript.isClick = true;
                    }

                    (ts.storyObj.transform.GetChild(2).GetChild(0).
                                    GetComponent<Text>().text) = talkScript.story2CatTalk[talkScript.talkCount];
                }

                else if (ray.hit.collider.tag == "next_button")   //나중에 미션2를 위해 수정해야 할듯
                {
                    Debug.Log(talkScript.talkCount);
                    state.isHit = true;
                    StateManager.isStory = true;

                    if (talkScript.talkCount == 0)
                    {
                        state.nextMap = true;
                        state.story2 = false;
                        ts.storyObj.SetActive(false);
                        //myosa.SetActive(true);
                        //state.isCat = true;
                    }
                }
            }
        }
        if (state.story2 && talkScript.talkCount == 2)
        {
            if (bigDipper != null)
            {
                bigDipper.SetActive(true);
                StartCoroutine(bigDipperWaitTime());
            }
        }
        else if (state.story2 && talkScript.talkCount == 3 && !(state.isAnime))
        {
            state.isAnime = true;
            StartCoroutine(bookscrap());
        }
        //else if(state.story2 && talkScript.talkCount == 4)
        //{
        //    myosa.SetActive(true);
        //    StartCoroutine(MoveCat());
        //    state.story2 = false;
        //}
        if (playerScript.isAnime && !StateManager.isStory)
        {
            Debug.Log("2" + StateManager.isStory);
            npc.GetComponent<BoxCollider2D>().enabled = false;
            ts.storyObj.SetActive(true);
            playerScript.isAnime = false;
        }
    }
    IEnumerator FadewaitTime()
    {
        state.fadeInOut = true;
        //호패를 부모에게서 떼어냄
        hopae.transform.parent = null;
        // 플레이어가 호패클릭했을때 멈추고 정면보기
        playerScript.StopAllCoroutines();
        playerScript.aniState(false, true, false);
        hopae.SetActive(false);
        hopae.transform.position = new Vector3(0, 0, 0);
        hopae.transform.localScale = new Vector3(2, 2, 1);
        hopae.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        hopae.SetActive(true);
        hopae.GetComponent<SpriteFadeIn>().enabled = true;
        yield return new WaitForSeconds(3f);
        hopae.GetComponent<SpriteFadeIn>().enabled = false;
        yield return new WaitForSeconds(1f);
        hopae.GetComponent<SpriteFadeOut>().enabled = true;
        yield return new WaitForSeconds(3f);
        StateManager.isStory = false;
        Debug.Log("2" + StateManager.isStory);
        //Destroy(hopae);
        hopae.SetActive(false);
        state.isMove = true;
        npc.GetComponent<BoxCollider2D>().enabled = true;
        state.fadeInOut = false;
    }
    //npc 움직이는거
    IEnumerator MoveNpc()
    {
        while (npc.transform.position.x < 3.723)
        {
            npc.transform.position += Vector3.right * 1f * Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator MoveCat()
    {
        yield return new WaitForSeconds(3f);
    }
    IEnumerator MissionCoroutine() // 미니게임 실행순서
    {
        state.isMove = false;
        missionText.SetActive(true);
        yield return new WaitForSeconds(3.2f);
        missionText.GetComponent<SpriteFadeIn>().enabled = false;
        missionText.GetComponent<SpriteFadeOut>().enabled = true;
        yield return new WaitForSeconds(3.2f);
        missionText.SetActive(false);
        //state.isHit = true;
        mGame2.SetActive(true);
    }

    IEnumerator bigDipperWaitTime()
    {
        state.story2 = false;
        //ts.storyObj.SetActive(false);
        yield return new WaitForSeconds(3f);
        Destroy(bigDipper);
        state.story2 = true;
        //Debug.Log(talkScript.talkCount);
        //ts.storyObj.SetActive(true);
    }

    IEnumerator bookscrap()
    {
        state.story2 = false;
        npc2Anime.SetBool("isBookScrap", true);
        //ts.storyObj.SetActive(false);
        yield return new WaitForSeconds(3f);
        //ts.storyObj.SetActive(true);
        state.story2 = true;
        npc2Anime.SetBool("isBookScrap", false);
        
    }
}
