using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour {
    public GameObject player;
    private GameObject Target;
    public float CameraZ = -10;
    
    void FixedUpdate()
    {
        Vector3 TargetPos = new Vector3(
            Mathf.Clamp(player.transform.position.x, -5.88f, 5.88f), 
            Mathf.Clamp(player.transform.position.y, -1.27f, 1.27f), 
            CameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * 1f);
    }
}
