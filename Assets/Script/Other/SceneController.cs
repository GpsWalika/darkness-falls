using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public bool isChapEnd;
    public static int posScene = 1;
    public GameObject fadeOut;
    public GameObject fadeIn;
    private string []list = new string[10];

    // Use this for initialization
    void Start()
    {
        isChapEnd = false;
        
        for (int n = 0; n < 10; n++) { 
            list[n] = ("ch" + (n + 1) + "COF");
        }
        if (posScene > 1)
        {
            fadeOut.SetActive(true);
            fadeOutFalseCoroutine();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isChapEnd)
        {
            fadeIn.SetActive(true);
            StartCoroutine(delayCoroutine());
            isChapEnd = false;
        }
    }

    IEnumerator delayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(list[posScene].ToString());
        posScene++;
    }
    IEnumerator fadeOutFalseCoroutine()
    {
        yield return new WaitForSeconds(3f);
        fadeOut.SetActive(false);
    }
}
