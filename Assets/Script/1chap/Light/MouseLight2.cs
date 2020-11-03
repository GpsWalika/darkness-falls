using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLight2 : MonoBehaviour {

    RaycastHit2D hit;
    private Vector3 mousePosition;
    private Vector3 lightPosition;
    private Vector3 rockPosition;
    [SerializeField]
    private GameObject mGame;
    [SerializeField]
    private GameObject hopae;
    [SerializeField]
    private float dis = 5f;
    [SerializeField]
    private GameObject keyRock;
    private int limit = 0;
    private int selecLayer = 5;
    private int beforeLayer = 0;
    private float gameTime = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dis);
        lightPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = lightPosition;
        Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.red);

        if (gameTime > 3)
        {
            hopae.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {

                if (limit == 2)
                {
                    Ray2D ray = new Ray2D(lightPosition, Vector2.zero);
                    hit = Physics2D.Raycast(ray.origin, ray.direction);
                    if (hit.collider.tag == "hopae")
                    {

                        mGame.SetActive(false);
                    }
                    else
                    {
                        keyRock.transform.position = rockPosition;
                        keyRock.transform.rotation = Quaternion.Euler(0, 0, 0f);
                        keyRock.transform.GetComponent<SpriteRenderer>().sortingOrder = beforeLayer;
                        limit = 0;
                    }
                }
                else if (limit == 0)
                {
                    Ray2D ray = new Ray2D(lightPosition, Vector2.zero);
                    hit = Physics2D.Raycast(ray.origin, ray.direction);
                    if (hit.collider.tag == "rock")
                    {
                        rockPosition = hit.transform.position;
                        beforeLayer = hit.transform.GetComponent<SpriteRenderer>().sortingOrder;
                        hit.transform.position = new Vector2(hit.transform.position.x - 0.9f, hit.transform.position.y + 0.9f);
                        hit.transform.rotation = Quaternion.Euler(0, 0, 5f);
                        hit.transform.GetComponent<SpriteRenderer>().sortingOrder = selecLayer;
                        limit++;
                    }
                    else if (hit.collider.tag == "keyRock")
                    {
                        rockPosition = hit.transform.position;
                        beforeLayer = hit.transform.GetComponent<SpriteRenderer>().sortingOrder;
                        hit.transform.position = new Vector2(hit.transform.position.x - 0.9f, hit.transform.position.y + 0.9f);
                        hit.transform.rotation = Quaternion.Euler(0, 0, 5f);
                        hit.transform.GetComponent<SpriteRenderer>().sortingOrder = selecLayer;
                        limit = 2;
                    }

                }
                else if (limit == 1)
                {
                    if (hit.collider.tag == "rock")
                    {
                        hit.transform.position = rockPosition;
                        hit.transform.rotation = Quaternion.Euler(0, 0, 0f);
                        hit.transform.GetComponent<SpriteRenderer>().sortingOrder = beforeLayer;
                        limit--;
                    }
                }
            }


        }
    }
}
