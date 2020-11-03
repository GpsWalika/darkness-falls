using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent1 : MonoBehaviour
{

    RaycastHit2D hit;
    private Vector3 mousePosition;
    private Vector3 hitPosition;
    private Vector3 rockPosition;
    [SerializeField]
    private HopaeController hCon;
    [SerializeField]
    private GameObject mGame;
    [SerializeField]
    private GameObject hopae;
    [SerializeField]
    private float dis = 5f;
    [SerializeField]
    private GameObject[] keyRock;
    private int limit = 0;
    private int selecLayer = 9;
    private int beforeLayer = 0;
    private float gameTime = 0f;
    private bool isFindH = false;
    [SerializeField]
    private GameObject player;
    string name;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (!isFindH)
        {
            mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dis);
            hitPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (gameTime > 3)
            {
                hopae.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {

                    if (limit == 2)
                    {
                        Ray2D ray = new Ray2D(hitPosition, Vector2.zero);
                        hit = Physics2D.Raycast(ray.origin, ray.direction);
                        if (hit == true)
                        {
                            if (hit.collider.tag == "key_hopae")
                            {
                                StartCoroutine("GameEscapeCoroutine");
                            }
                            else
                            {
                                hopae.GetComponent<SpriteRenderer>().sortingOrder = 0;
                                if (name == "24")
                                {
                                    keyRock[0].transform.position = rockPosition;
                                    keyRock[0].transform.rotation = Quaternion.Euler(0, 0, 0f);
                                    keyRock[0].transform.GetComponent<SpriteRenderer>().sortingOrder = beforeLayer;
                                    limit = 0;
                                }
                                else
                                {
                                    keyRock[1].transform.position = rockPosition;
                                    keyRock[1].transform.rotation = Quaternion.Euler(0, 0,  0f);
                                    keyRock[1].transform.GetComponent<SpriteRenderer>().sortingOrder = beforeLayer;
                                    limit = 0;
                                }
                            }
                        }
                    }
                    else if (limit == 0)
                    {
                        Ray2D ray = new Ray2D(hitPosition, Vector2.zero);
                        hit = Physics2D.Raycast(ray.origin, ray.direction);
                        if (hit == true)
                        {
                            if (hit.collider.tag == "rock")
                            {
                                Debug.Log(hit.transform.rotation);
                                rockPosition = hit.transform.position;
                                beforeLayer = hit.transform.GetComponent<SpriteRenderer>().sortingOrder;
                                hit.transform.position = new Vector2(hit.transform.position.x - 0.9f, hit.transform.position.y + 0.9f);
                                hit.transform.rotation = Quaternion.Euler(0, 0, 5f);
                                hit.transform.GetComponent<SpriteRenderer>().sortingOrder = selecLayer;
                                limit++;
                            }
                            else if (hit.collider.tag == "keyRock")
                            {
                                hopae.GetComponent<SpriteRenderer>().sortingOrder = 5;
                                name = hit.transform.name;
                                rockPosition = hit.transform.position;
                                beforeLayer = hit.transform.GetComponent<SpriteRenderer>().sortingOrder;
                                hit.transform.position = new Vector2(hit.transform.position.x - 0.9f, hit.transform.position.y + 0.9f);
                                hit.transform.rotation = Quaternion.Euler(0, 0, 5f);
                                hit.transform.GetComponent<SpriteRenderer>().sortingOrder = selecLayer;
                                limit = 2;
                            }
                        }
                    }
                    else if (limit == 1)
                    {
                        hit.transform.position = rockPosition;
                        hit.transform.rotation = Quaternion.Euler(0, 0, 0f);
                        hit.transform.GetComponent<SpriteRenderer>().sortingOrder = beforeLayer;
                        limit = 0;
                    }
                }

            }
        }
    }

    IEnumerator GameEscapeCoroutine() // key_hopae를 찾고 미니게임1이 종료되었을때
    {
        isFindH = true;
        hopae.transform.GetComponent<SpriteRenderer>().sortingOrder = 11;
        yield return new WaitForSeconds(1f);
        hopae.SetActive(false);
        yield return new WaitForSeconds(1f);
        hopae.transform.localPosition = new Vector3(5.11f, 0.09f, 0f);
        hopae.transform.localScale = new Vector3(1.5f, 1.5f, 0f);
        hopae.SetActive(true);
        yield return new WaitForSeconds(1f);
        mGame.SetActive(false);
        player.SetActive(true);
        hCon.hopaeMove();
    }
}
