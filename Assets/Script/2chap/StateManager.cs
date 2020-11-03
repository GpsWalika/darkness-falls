using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	public bool isMove = true;
	public bool nextMap = false;
	public bool isHit = false; 
	public static bool isStory = false;
	public bool isAnime = false;
	public bool story1 = true;
	public bool story2 = false;
	public bool isCat = false;
	public bool isCatFollow = false;
	public bool fadeInOut = false;	//fadein, fadeout일때 움직임 불가하도록 만든 변수

}
