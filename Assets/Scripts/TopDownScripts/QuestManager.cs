using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;

    Dictionary<int, QuestData> questList;

    private void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    public void GenerateData()
    {
        questList.Add(10, new QuestData("여왕 첫 대화", new int[] { 1000 , 2000, 2000 }));

        questList.Add(20, new QuestData("부탁 듣기", new int[] { 5000, 2000 }));

        questList.Add(30, new QuestData("부탁 완료", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {      
        // 다음 대화 상대
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        // Control Quest Object
        ControlObject();

        // 대화 완료 & 다음 퀘스트
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        // 퀘스트 이름
        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        // 퀘스트 이름
        return questList[questId].questName;
    }

    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}
