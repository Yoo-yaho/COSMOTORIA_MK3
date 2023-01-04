using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController; //캐릭터 콜리더 설정

    public float Speed = 8.0f;  //캐릭터 움직임 속도
    public Sprite[] sprites = new Sprite[3]; //캐릭터 움직임 애니메이션
    public SpriteRenderer spriteRenderer; //캐릭터 움직임
    public Stage_Data stage;    //캐릭터가 화면 밖으로 나가지 않기 위한 제한
    public BulletShot bulletShot;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        bulletShot = GetComponent<BulletShot>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        float xSpeed = xInput * Speed * Time.deltaTime;
        float ySpeed = yInput * Speed * Time.deltaTime;

        Vector2 dir = new Vector2(xSpeed, ySpeed);

        characterController.Move(dir);

        MovingAnim(xInput); //플레이어 애니메이션
        bulletShot.Fire();
        bulletShot.Reload();
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,stage.LimitMin.x,stage.LimitMax.x),
                                         Mathf.Clamp(transform.position.y,stage.LimitMin.y,stage.LimitMax.y));
    }

    void MovingAnim(float Xdir)
    {
        if (Xdir >= 0.5)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (Xdir <= -0.5)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

    }

}
