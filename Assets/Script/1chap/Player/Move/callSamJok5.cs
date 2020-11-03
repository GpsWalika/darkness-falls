using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callSamJok5 : MonoBehaviour {
    public GameObject samjok5;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EventTrig1"))
        {
            samjok5.SetActive(true);
        }
    }
    
}
