using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkScript : MonoBehaviour { 
    public static int talkNum = 1;
    public static int myosaTalkCnt = 0;
    public static string[] storyTalk1;
    public static string[] storyTalk2;
    public static string[] story2CatTalk;
    public static byte talkCount = 1;
    //public static byte talkCount = 0;
    public GameObject storyObj;
    void Start()
    {
        storyTalk1 = new string[2] { "호패를 보여라.", "상급 신선의 호패군. 들어가도 좋다." };
        storyTalk2 = new string[] { "불개가 날뛰는 탓에 아무 것도 집중할 수가 없소. 저 개만 조용하면 좋을텐데!", 
                                        "고맙소. 드디어 저 져석이 조용해졌군! 어떻게 보답하면 좋을지... 흠.", 
                                        "북두 칠성이 자네의 앞길을 내다 보라고 하는군.",
                                        "자네의 여정은 저승까지 이어지네. 가는 길이 쉽지 않겠어. 도와줄 길잡이를 소개해주겠소."};
        story2CatTalk = new string[] { "나는 묘사. 곧 13지신 중 하나가 될 몸이지. 너를 돕는 것도 수련의 일부니 너무 감동 받지는 않아도 된다." };
    }
}