using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraPos : MonoBehaviour {

    [SerializeField]
    private GuideManager GManger;
    [SerializeField]
    private GameObject menu;
    public float speed;
    public float time = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(StartCameraCoroutine());
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}
    IEnumerator StartCameraCoroutine()
    {
        if (transform.position.y > -0.5f)
        {
            while (gameObject.transform.position.y >= -0.5f)
            {
                if (time > 6.5f)
                {
                    speed -= Time.deltaTime * 1.1f;
                }
                else if (time > 2)
                {
                    speed += Time.deltaTime * 1.1f;
                }
                //speed -= Time.deltaTime * 1.1f;
                transform.position += Vector3.down * speed * Time.deltaTime;

                yield return null;
            }
        }
        transform.position = new Vector3(-4.59f, -0.58f, -10);
        menu.SetActive(true);
        GManger.isGuide = true;
    }
}
