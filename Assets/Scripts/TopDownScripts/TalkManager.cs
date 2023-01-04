using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    private void GenerateData()
    {
        talkData.Add(1000, new string[] { "Zzz...:1" });

        talkData.Add(2000, new string[] { ".........:0", "반갑소:1",
                                        "뭔가 용건이라도?:2"});

        talkData.Add(100, new string[] { "아무도 사용하지 않는 책상이다."});
        talkData.Add(200, new string[] { "너무 흔해빠진 상자이다." });

        // Quest Talk
        talkData.Add(10 + 1000, new string[] { "부탁할게 있어:0", "인장이한테 가봐:1" });
        talkData.Add(11 + 1000, new string[] { "빨리가봐:0" });

        talkData.Add(11 + 2000, new string[] { "음....:0", "무슨 일이지?:1" });
        talkData.Add(12 + 2000, new string[] { "여왕님이 보내셨나?:0", "음... 그렇구만:1",
                                                "일단 저기 있는 상자 좀 갖다주겠나?:0"});

        talkData.Add(20 + 5000, new string[] { "상자를 주었다" });

        talkData.Add(21 + 2000, new string[] { "고맙네:0", "자 근데 뭐 때문에 날 찾아왔더라?:1" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);

        portraitData.Add(2000 + 0, portraitArr[2]);
        portraitData.Add(2000 + 1, portraitArr[2]);
        portraitData.Add(2000 + 2, portraitArr[2]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            // 퀘스트 맨 처음 대사마저 없을 때
            // 기본 대사를 출력  
            if (!talkData.ContainsKey(id - id % 10))             
                return GetTalk(id - id % 100, talkIndex);
            // 해당 퀘스트 진행 순서 대사가 없을 때
            // 퀘스트 맨 처음 대사를 가지고 옴
            else
                return GetTalk(id - id % 100, talkIndex);                
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
