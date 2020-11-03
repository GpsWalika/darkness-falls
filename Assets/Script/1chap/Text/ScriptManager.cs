using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour {
    private string[] samTalk = { "큰일이다. 네게 전해줄 호패를 개울에 빠뜨렸어..", "미안하지만 호패를 직접 찾아가야 할 것 같아."};
    private string samTalk1 = "다행이다. 무사히 다녀오길 바래.";

    public int cnt = 0;

    private bool tTalk = false;
    private bool ist = false;
    private bool isParticle = true;
    [SerializeField]
    private GameObject talkText;
    [SerializeField]
    private MouseEvent msEvent;
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private PlayerMovement pMove;
    public BoxCollider2D mBCol1;
    public BoxCollider2D mBCol2;
    public GameObject qText;
    public SpriteFadeOut qFadeOut;

    void Start()
    {
        
    }
    void Update()
    {
        if (msEvent.isTalk && cnt < samTalk.Length)
        {
            talkText.SetActive(true);
            if (msEvent.hit == true)
            {
                mBCol1.enabled = false;
                mBCol2.enabled = false;
                if (Input.GetMouseButtonDown(0))
                    ist = true;
                if (msEvent.hit.collider.tag == "next_button")
                {
                    if (ist)
                    {
                        cnt++;
                        if (cnt < samTalk.Length)
                        {
                            talkText.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = samTalk[cnt];
                            ist = false;
                        }
                    }
                }
            }
        }
        else if ( msEvent.isMGameEnd && msEvent.isTalk)
        {
            mBCol1.enabled = false;
            mBCol2.enabled = false;
            talkText.SetActive(true);
            talkText.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = samTalk1;
            if (msEvent.hit == true)
            {
                if (msEvent.hit.collider.tag == "next_button")
                {
                    pMove.enabled = false;
                    talkText.SetActive(false);
                    msEvent.isTalk = false;
                    pMove.enabled = true;
                    GameObject.Find("SamJok5").GetComponent<AniScript>().EndFlying();
                }
            }
        }
        else if (cnt >= samTalk.Length && !tTalk)
        {
            qText.SetActive(true);
            tTalk = true;
            StartCoroutine(delayCoroutine());
            talkText.SetActive(false);

            if (isParticle)
            {
                mBCol1.enabled = true;
                mBCol2.enabled = true;
                isParticle = false;
                particle.SetActive(true);
                
            }
        }
        
    }

    IEnumerator delayCoroutine()
    {
        
        yield return new WaitForSeconds(4f);
        qFadeOut.enabled = true;
        msEvent.isTalk = false;
        yield return new WaitForSeconds(5f);
        qText.SetActive(false);
    }
}
