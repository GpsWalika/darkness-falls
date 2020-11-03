using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour {

    public float zoomSize = 5.4f;
    public GameObject target;
    private Vector3 TargetPos;
    public float limitX;
    public float limitY;
    public float speedX;
    public float speedY;
    public float zoomSpeed;
    private bool isZoom = false;
    private Vector3 originCamera;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == true)
        {
            TargetPos = new Vector3(
                    Mathf.Clamp(target.transform.position.x, zoomSize - limitX, 5.88f),
                    Mathf.Clamp(target.transform.position.y, zoomSize - limitY, 1.27f),
                    -10f);
        }
        GetComponent<Camera>().orthographicSize = zoomSize;

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("123");
            originCamera = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(ZoomInCoroutine());
        }
        if (Input.GetKeyDown("2"))
        {
            StopAllCoroutines();
            this.transform.position = originCamera;
            zoomSize = 5.4f;
        }
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
        int count = 0;

        while (count < 350)
        {
            if (zoomSize > 3.5)
            {
                transform.position = new Vector3(TargetPos.x, TargetPos.y, -10);
            }
            else
            {
                transform.position = new Vector3(Mathf.Lerp(transform.position.x,
                    TargetPos.x - 1.6f, speedX), TargetPos.y, -10);
            }

            if (zoomSize > 1)
            {
                zoomSize -= (Time.deltaTime * zoomSpeed);
            }
            count += 1;
            yield return null;
        }
        this.transform.position = originCamera;
        zoomSize = 5.4f;
    }
}
