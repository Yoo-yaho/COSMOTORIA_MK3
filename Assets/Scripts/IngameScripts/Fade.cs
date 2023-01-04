using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour

{
    public float animTime = 1.5f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  
    private Image fadeImage;            // UGUI�� Image������Ʈ ���� ����.  

    private float start = 1f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 0f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��.  


    public bool stopIn = true; //false�϶� ����Ǵ°ǵ�, �ʱⰪ�� false�� �� ������ ���� �����Ҷ� ���̵������� ������...�װ� ������ true�� �ϸ��.
    public bool stopOut = true;

    void Awake()
    {
        // Image ������Ʈ�� �˻��ؼ� ���� ���� �� ����.  
        fadeImage = GetComponent<Image>();
    }

    void Update()
    {
        
        // ���������� = FadeIn �ִϸ��̼� ���.  
        if (stopIn == false && time <= 2)
        {
            PlayFadeIn();
        }
        if (stopOut == false && time <= 2)
        {
            PlayFadeOut();
        }
        
        if (time >= 2 && stopIn == false)
        {
            stopIn = true;
            time = 0;
            Debug.Log("StopIn");
        }
        if (time >= 2 && stopOut == false)
        {
            stopIn = false; //�Ͼ�� ��ȯ�ǰ� ���� �� ��ȯ �� �ٽ� Ǯ�Ŷ� �־���. �׳� ���� �����Ÿ� ���� �ʿ� ����.
            stopOut = true;
            time = 0;
            Debug.Log("StopOut");
        }
   

    }

    // ���->����
    public void PlayFadeIn()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start, end, time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
        // Debug.Log(time);
    }

    // ����->���
    public void PlayFadeOut()
    {
        Debug.Log("����Ϸ�");
        stopOut = false;
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(end, start, time);  //FadeIn���� �޸� start, end�� �ݴ��.
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
    }

}
