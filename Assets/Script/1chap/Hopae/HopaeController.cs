using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopaeController : MonoBehaviour {
    [SerializeField]
    private GameObject particle;
    private CircleCollider2D hopCol;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private MouseEvent msEvent;
    [SerializeField]
    private BoxCollider2D sBCol;
    [SerializeField]
    private GameObject realHopae;
	// Use this for initialization
	void Start () {
        hopCol = gameObject.GetComponent<CircleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("map"))
        {
            StartCoroutine(delayCoroutine());
        }
    }

    public void hopaeMove()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        msEvent.isMGame1 = false;
        StartCoroutine(moveCoroutine());
    }

    IEnumerator moveCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        float count = 0;
        while (count < 100)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
            yield return null;
            count++;
        }
        //particle.SetActive(false);
        //Destroy(particle);
        msEvent.isMStart = false;
        msEvent.isGame = false;
        msEvent.isMGameEnd = true;
        sBCol.enabled = true;
        realHopae.SetActive(true);
        Destroy(this.gameObject);
    }

    IEnumerator delayCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        hopCol.isTrigger = false;
        particle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

}
