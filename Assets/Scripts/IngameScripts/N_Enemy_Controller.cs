using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_Enemy_Controller : MonoBehaviour
{
    public float Speed = 8.0f;
    public int HP = 3;
    public EnemyHitEffect EnemyHitEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP -= 1;
            Destroy(collision.gameObject);
            EnemyHitEffect.recent_Delay = 0;
            
            if(HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
