using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaEdge : MonoBehaviour {

	public ParabolaController[] paraCon;
	private int i = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!paraCon[i].Animation)
		{
			paraCon[i].enabled = false;
			paraCon[i].Animation = true;
			paraCon[i].Autostart = true;
			paraCon[i++].animationTime = 0; // 

			if (i == 4)
				i = 0;
			
			paraCon[i].enabled = true;

		}
	}
}