using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll : MonoBehaviour
{
    private Renderer BGrend;
    private float offset;

    public float Speed = 0.5f; //배경 속도


    // Start is called before the first frame update
    void Start()
    {
        BGrend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime;
        BGrend.material.SetTextureOffset("_MainTex", new Vector2(0, offset * Speed)); //배경 스크롤링
        
    }
}
