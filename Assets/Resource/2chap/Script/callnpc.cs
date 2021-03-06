﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callnpc : MonoBehaviour {
    public bool isNPC = false;
    public PlayerMove pMove;
    public CameraShake cs;

    public GameObject npc;
    private Animator ani;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        cs.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isNPC) {
            npc.SetActive(true);
            
        }
        pMove.StopAllCoroutines();
        StartCoroutine(CheckAnimationState());
    }

    IEnumerator CheckAnimationState()
    {
        
        while (!ani.GetCurrentAnimatorStateInfo(0)
        .IsName("2muk"))
        {
            //전환 중일 때 실행되는 부분
            yield return null;
        }

        while (ani.GetCurrentAnimatorStateInfo(0)
        .normalizedTime < 1f)
        {
            //애니메이션 재생 중 실행되는 부분
            yield return null;
        }

        //애니메이션 완료 후 실행되는 부분
        Destroy(gameObject);
    }
}
