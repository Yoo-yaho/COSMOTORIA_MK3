using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI m_TextMeshProUGUI;
    private int Game_Score = 0;

    public float Score_Delay = 0.1f;
    public float Score_Duration;
    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        Score_Duration += Time.deltaTime;

        if (Score_Duration >= Score_Delay)
        {
            Game_Score += 1;
            Score_Duration = 0;
        }

        m_TextMeshProUGUI.text = Game_Score.ToString();
    }
}
