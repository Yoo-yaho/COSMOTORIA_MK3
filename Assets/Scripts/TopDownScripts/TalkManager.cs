using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    Dictionary<int, Sprite> fleryPortraitData;

    public Sprite[] portraitArr;
    public Sprite[] FleryportraitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        fleryPortraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    private void GenerateData()
    {

        //talkData.Add(100, new string[] { "아무도 사용하지 않는 책상이다."});
        talkData.Add(4000, new string[] { "알아볼 수 없는 글씨로 쓰여져있다." });
        talkData.Add(2000, new string[] { "(자고있다...):1" });

        // Quest Talk
        talkData.Add(10 + 2000, new string[] { "Zzz...:1", "어... 왔니...:0", "쿨쿨....:1" });
        talkData.Add(11 + 2000, new string[] { "엇...:0", "아... 일단 사보텐한테 가봐...:0", "쿨쿨....:1" });

        talkData.Add(20 + 2000, new string[] { "(일어날 기미가 보이지 않는다...):0" });
        talkData.Add(20 + 1000, new string[] { "여왕님이?:0", "그렇구만...:0", "일단 그 전에 부탁 좀 들어주겠나?:0" });
        talkData.Add(21 + 1000, new string[] { "소인이 물건 하나를 잃어버려서 말일세...:0", "상자 하나만 찾아주시게나:0" });
        talkData.Add(21 + 5000, new string[] { "상자를 찾았다!" });
        talkData.Add(22 + 1000, new string[] { "오오 고맙네!:0" });
        //talkData.Add(11 + 2000, new string[] { "음....:0", "무슨 일이지?:1" });
        //talkData.Add(12 + 2000, new string[] { "여왕님이 보내셨나?:0", "음... 그렇구만:1",
        //                                        "일단 저기 있는 상자 좀 갖다주겠나?:0"});

        //talkData.Add(20 + 5000, new string[] { "상자를 주었다" });

        //talkData.Add(21 + 2000, new string[] { "고맙네:0", "자 근데 뭐 때문에 날 찾아왔더라?:1" });

        portraitData.Add(1000 + 0, portraitArr[2]);

        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);

        fleryPortraitData.Add(2000 + 0, fleryPortraitData[0]);

        //portraitData.Add(2000 + 0, portraitArr[2]);
        //portraitData.Add(2000 + 1, portraitArr[2]);
        //portraitData.Add(2000 + 2, portraitArr[2]);

        talkData.Add(1000, new string[] { "안녕하시오:0", "오랜만이구려:0" });

        talkData.Add(2000, new string[] { "Zzz...:1" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            // 퀘스트 맨 처음 대사마저 없을 때
            // 기본 대사를 출력  
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex); // Get First Talk
            // 해당 퀘스트 진행 순서 대사가 없을 때
            // 퀘스트 맨 처음 대사를 가지고 옴
            else
                return GetTalk(id - id % 100, talkIndex); // Get First Quest Talk
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
