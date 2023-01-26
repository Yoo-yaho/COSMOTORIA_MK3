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
    public Animator portraitAnim;
    public Image FleryImage;
    public TalkManager talkManager;
    public GameObject scanObject;
    public Animator talkPanel;
    public Sprite previousSprite;
    public TypeEfffect talk;

    private void Start()
    {
         Debug.Log(questManager.CheckQuest());
    }

    public void Scan(GameObject scanObj)
    {
        //if (isAction)
        //{
        //    isAction = false;
        //}
        //else
        //{
        //    isAction = true;
        //    scanObject = scanObj;
        //    ObjectData objectData = scanObject.GetComponent<ObjectData>();
        //    Talk(objectData.id, objectData.isNpc);
        //}

        //talkPanel.SetActive(isAction);

        scanObject = scanObj;
        ObjectData objectData = scanObject.GetComponent<ObjectData>();
        Talk(objectData.id, objectData.isNpc);


        talkPanel.SetBool("isShow", isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";

        if (talk.isTexting)
        {
            talk.SetMsg("");
            return;
        }        
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }      

        if (talkData == null)
        {
            talkIndex = 0;
            isAction = false;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            portraitImage.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImage.color = new Color(1, 1, 1, 1);

            if (previousSprite != portraitImage.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                previousSprite = portraitImage.sprite;
            }
               

            FleryImage.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talk.SetMsg(talkData);

            portraitImage.color = new Color(1, 1, 1, 0);
            FleryImage.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}
