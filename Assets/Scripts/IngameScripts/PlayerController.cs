using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController; //ĳ���� �ݸ��� ����

    public float Speed = 8.0f;  //ĳ���� ������ �ӵ�
    public Sprite[] sprites = new Sprite[3]; //ĳ���� ������ �ִϸ��̼�
    public SpriteRenderer spriteRenderer; //ĳ���� ������
    public Stage_Data stage;    //ĳ���Ͱ� ȭ�� ������ ������ �ʱ� ���� ����
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

        MovingAnim(xInput); //�÷��̾� �ִϸ��̼�
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
