using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour {
    private Vector3 mousePos;
    public RaycastHit2D hit;
    [SerializeField]
    private PlayerMovement playermove;
    [SerializeField]
    private ZoomControl zoomCon;
    public bool isTalk = false;
    public bool isFly = false;
    public bool isMGame1 = false;
    public bool isGame = false;
    public bool isStart = false;
    public bool isMStart = false;
    public bool isMGameEnd = false;


    public GameObject miniGame;
    private Camera camera;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Ray2D ray = new Ray2D(mousePos, Vector2.zero);
                hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit != false)
                {
                    if (hit.collider.tag == "hopae" && isGame)
                    {
                        Debug.Log("hopae");
                        isMStart = true;
                        zoomCon.ZoomIn();
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                isTalk = false;
            }
        }
    }
    

}
