using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour {
    private Animator ani;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        StartCoroutine("CheckAnimationState");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EventTrig1")) {
            Debug.Log("Samjok5 Ani Scripts Trigger Excute!!");
            ani.SetBool("Landing", true);
        }
    }
    IEnumerator CheckAnimationState()
    {

        while (!ani.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
        {
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }

        //애니메이션 완료 후 실행되는 부분
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
    public void EndFlying()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        GetComponent<ParabolaController>().ParabolaRoot = GameObject.Find("ParabolaRoot2");
        ani.SetBool("Landing", false);
        ani.Play("Flying");
    }
}
