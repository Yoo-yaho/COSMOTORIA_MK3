using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEfffect : MonoBehaviour
{
    private string targetMsg;
    public int textPerSecond;

    int index;
    float interval;
    public bool isTexting;

    public GameObject endCursor;
    Text msgText;
    AudioSource audioSource;

    private void Start()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isTexting)
        {
            msgText.text = targetMsg;
            CancelInvoke();         
            EffectEnd();
        } 
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        endCursor.SetActive(false);
        

        interval = 1.0f / textPerSecond;
        Debug.Log(interval);

        isTexting = true;
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        // 텍스트 효과음
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isTexting = false;
        endCursor.SetActive(true);
    }
}
