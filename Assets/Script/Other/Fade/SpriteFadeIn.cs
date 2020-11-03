using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFadeIn : MonoBehaviour {
    public float time;
    // Update is called once per frame
    private void Start()
    {
        time = 0;
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void FixedUpdate()
    {
        if (time < 3f)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);
        }
        time += Time.deltaTime;

    }
}
