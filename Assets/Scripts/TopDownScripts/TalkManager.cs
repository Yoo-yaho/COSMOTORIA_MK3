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

        talkData.Add(2000, new string[] { ".........:0", "�ݰ���:1",
                                        "���� ����̶�?:2"});

        talkData.Add(100, new string[] { "�ƹ��� ������� �ʴ� å���̴�."});
        talkData.Add(200, new string[] { "�ʹ� ���غ��� �����̴�." });

        // Quest Talk
        talkData.Add(10 + 1000, new string[] { "��Ź�Ұ� �־�:0", "���������� ����:1" });
        talkData.Add(11 + 1000, new string[] { "��������:0" });

        talkData.Add(11 + 2000, new string[] { "��....:0", "���� ������?:1" });
        talkData.Add(12 + 2000, new string[] { "���մ��� �����̳�?:0", "��... �׷�����:1",
                                                "�ϴ� ���� �ִ� ���� �� �����ְڳ�?:0"});

        talkData.Add(20 + 5000, new string[] { "���ڸ� �־���" });

        talkData.Add(21 + 2000, new string[] { "����:0", "�� �ٵ� �� ������ �� ã�ƿԴ���?:1" });

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
            // ����Ʈ �� ó�� ��縶�� ���� ��
            // �⺻ ��縦 ���  
            if (!talkData.ContainsKey(id - id % 10))             
                return GetTalk(id - id % 100, talkIndex);
            // �ش� ����Ʈ ���� ���� ��簡 ���� ��
            // ����Ʈ �� ó�� ��縦 ������ ��
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
