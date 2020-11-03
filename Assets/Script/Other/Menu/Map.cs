using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    bool isOpen = false;
    [SerializeField]
    GameObject map;
	void OpenMap()
    {
        isOpen = true;
        map.SetActive(true);
    }
}
