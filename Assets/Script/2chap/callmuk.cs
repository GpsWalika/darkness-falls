using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callmuk : MonoBehaviour {
    public GameObject muk;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player")) {
            muk.SetActive(true);
            Destroy(gameObject);
        }
    }
}
