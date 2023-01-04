using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public float textSpeed;
    public bool isAction;
    public int talkIndex;

    public QuestManager questManager;
    public Image portraitImage;
    public TalkManager talkManager;
    public Text talkText;
    public GameObject scanObject;
    public GameObject talkPanel;

    private void Start()
    {
        Debug.Log(questManager.CheckQuest());
    }

    public void Scan(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            ObjectData objectData = scanObject.GetComponent<ObjectData>();
            Talk(objectData.id, objectData.isNpc);
        }

        talkPanel.SetActive(isAction);     
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            talkIndex = 0;
            isAction = false;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData.Split(':')[0];

            portraitImage.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;

            portraitImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
