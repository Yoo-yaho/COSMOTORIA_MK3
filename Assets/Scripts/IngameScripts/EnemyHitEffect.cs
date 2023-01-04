using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitEffect : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float Effect_Delay = 0.05f;
    public float recent_Delay;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        recent_Delay += Time.deltaTime;
        Effect();
    }

    public void Effect()
    {
        Color hitAlpha = sprite.GetComponent<SpriteRenderer>().color;
        hitAlpha = Color.red;
        if(recent_Delay < Effect_Delay)
        {
            sprite.color = hitAlpha;
        }

        else
        {
            hitAlpha = new Color(255.0f, 255.0f, 255.0f);
            sprite.color = hitAlpha;
        }
    }
}
