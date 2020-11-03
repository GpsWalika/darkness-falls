using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopaeZoom : MonoBehaviour {

    [SerializeField]
    private ZoomController zoomCon;
    RaycastHit2D hit;
    Vector2 mousePos;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Ray2D ray = new Ray2D(mousePos, Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit == true)
            {
                if (hit.collider.tag == "hopae")
                {
                    zoomCon.ZoomIn();
                }
            }
        }
    }
}
