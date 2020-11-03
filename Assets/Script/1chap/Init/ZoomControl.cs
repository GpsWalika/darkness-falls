using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour {

    public float zoomSize = 5.4f;
    [SerializeField]
    private GameObject miniGame;
    public GameObject player;
    public GameObject particle;
    public CircleCollider2D hCCol;
    public GameObject target;
    private Vector3 TargetPos;
    public float limitX;
    public float limitY;
    public float speedX;
    public float speedY;
    private bool isZoom = false;
    private Vector3 originCamera;

    //public Camera camera;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (target == true)
        {
            TargetPos = new Vector3(
                    Mathf.Clamp(target.transform.position.x, zoomSize - limitX, 5.88f),
                    Mathf.Clamp(target.transform.position.y, zoomSize - limitY, 1.27f),
                    -10f);
        }
        if (Input.GetKeyDown("1"))
        {
            originCamera = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(ZoomInCoroutine());
        }
        if (Input.GetKeyDown("2"))
        {
            StopAllCoroutines();
            this.transform.position = originCamera;
            zoomSize = 5.4f;
        }
        GetComponent<Camera>().orthographicSize = zoomSize;
        
        
    }

    public void ZoomIn()
    {
        if (!isZoom)
        {
            isZoom = !isZoom;
            originCamera = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(ZoomInCoroutine());
        }
    }

    IEnumerator ZoomInCoroutine()
    {
        //int count=0;

        //while (count <350)
        //{/*
        //    if (count < 100)
        //    { transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime / 3f); }
        //    else if (count < 200)
        //    { transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime / 2f); }
        //    else
        //    { transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime); }
        //    */
        // //transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * speed);
        // //transform.position = new Vector3(Mathf.Lerp(transform.position.x, TargetPos.x, Time.deltaTime * speedX), Mathf.Lerp(transform.position.y, TargetPos.y, Time.deltaTime * speedY), -10);
        //    if (zoomSize > 3.5)
        //    {
        //        transform.position = new Vector3(TargetPos.x, TargetPos.y, -10);
        //    }
        //    else
        //    {
        //        transform.position = new Vector3(Mathf.Lerp(transform.position.x,
        //            TargetPos.x -1.6f, speedX), TargetPos.y, -10);
        //    }

        //    if (zoomSize > 2)
        //    {
        //        zoomSize -= Time.deltaTime;
        //    }
        //    count += 1;
        //    yield return null;
        //}
        yield return null;
        player.SetActive(false);
        miniGame.SetActive(true);
        this.transform.position = originCamera;
        zoomSize = 5.4f;
        hCCol.enabled = false;
        //particle.transform.parent = null;
        particle.SetActive(false);
    }
}
