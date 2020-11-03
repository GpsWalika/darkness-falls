using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    public float time;

    private void OnEnable()
    {
        time = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, time / 3);
            time -= Time.deltaTime;
        }
    }
}
