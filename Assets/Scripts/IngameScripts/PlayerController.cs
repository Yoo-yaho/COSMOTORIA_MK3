using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 8.0f;
    private CharacterController characterController;
    public Sprite[] sprites = new Sprite[3];
    public SpriteRenderer spriteRenderer;

    public int Power;
    public GameObject bullet1;

    [SerializeField] float ShootDelay;
    public float MaxDelay;
    public float DestroyBullet;

    public Stage_Data sd;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
        Fire();
        Reload();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, sd.LimitMin.x, sd.LimitMax.x),
            Mathf.Clamp(transform.position.y, sd.LimitMin.y, sd.LimitMax.y),transform.position.z);
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
    void Fire()
    {

        if (ShootDelay < MaxDelay)
            return;

        if (Input.GetButton("Fire1"))
        {
            if (Power == 1)
            {
                GameObject Bullet = Instantiate(bullet1, transform.position, transform.rotation);
                Rigidbody2D Brigid = Bullet.GetComponent<Rigidbody2D>();
                Brigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                Destroy(Bullet, DestroyBullet);
            }
            else if (Power == 2)
            {
                GameObject BulletL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject BulletR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D BrigidL = BulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidR = BulletR.GetComponent<Rigidbody2D>();
                BrigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                Destroy(BulletL, DestroyBullet);
                Destroy(BulletR, DestroyBullet);
            }
            else if (Power == 3)
            {
                GameObject BulletL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject BulletR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, transform.rotation);
                GameObject BulletCR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, Quaternion.Euler(new Vector3(0, 0, -45)));
                GameObject BulletCL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, Quaternion.Euler(new Vector3(0, 0, 45)));
                Rigidbody2D BrigidL = BulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidR = BulletR.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidCR = BulletCR.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidCL = BulletCL.GetComponent<Rigidbody2D>();
                BrigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidCR.AddForce(Vector2.one * 10, ForceMode2D.Impulse);
                BrigidCL.AddForce((Vector2.up + Vector2.left) * 10, ForceMode2D.Impulse);

                Destroy(BulletL, DestroyBullet);
                Destroy(BulletR, DestroyBullet);
                Destroy(BulletCR, DestroyBullet - 0.5f);
                Destroy(BulletCL, DestroyBullet - 0.5f);
            }

            ShootDelay = 0;
        }
    }

    void Reload()
    {
        ShootDelay += Time.deltaTime;
    }
}