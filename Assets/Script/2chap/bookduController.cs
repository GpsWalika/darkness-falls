using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookduController : MonoBehaviour {

	public GameObject[] bookdu;
	int index = 0;
	float time = 0;
	bool isFade = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (index < bookdu.Length)
		{
			time += Time.deltaTime;
			if (time > 0.1f)
			{
				bookdu[index].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 0.1f);
				//bookdu[index].SetActive(true);
				if (time > 0.2f)
				{
					if (!isFade)
					{
						StartCoroutine(fadeOutCoroutine());
						index++;
						time = 0;
					}
				}
			}
		}
	}

	IEnumerator fadeOutCoroutine()
	{
		isFade = true;
		float atime = 0.4f;
		int temp = index;

		while (atime > 0)
		{
			atime -= Time.deltaTime;
			bookdu[temp].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, atime / 0.6f);
			yield return null;
		}
		bookdu[temp].SetActive(false);
		isFade = false;
	}
}


