using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    float time;
    private void OnEnable()
    {
        time = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (time < 3f)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, time / 3);
        }
        time += Time.deltaTime;
    }
}
