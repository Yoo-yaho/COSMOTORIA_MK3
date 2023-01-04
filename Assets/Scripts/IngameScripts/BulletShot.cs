using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    // Start is called before the first frame update
    public int Power;

    public GameObject bullet1;

    [SerializeField] float ShootDelay;
    public float MaxDelay;


    public void Fire()
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

                Destroy(Bullet, 1.0f);
            }
            else if (Power == 2)
            {
                GameObject BulletL = Instantiate(bullet1, transform.position + Vector3.left * 0.5f, transform.rotation);
                GameObject BulletR = Instantiate(bullet1, transform.position + Vector3.right * 0.5f, transform.rotation);
                Rigidbody2D BrigidL = BulletL.GetComponent<Rigidbody2D>();
                Rigidbody2D BrigidR = BulletR.GetComponent<Rigidbody2D>();
                BrigidL.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                BrigidR.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

                Destroy(BulletL, 1.0f);
                Destroy(BulletR, 1.0f);
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

                Destroy(BulletL, 1.0f);
                Destroy(BulletR, 1.0f);
                Destroy(BulletCR, 0.5f);
                Destroy(BulletCL, 0.5f);
            }

            ShootDelay = 0;
        }
    }

    public void Reload()
    {
        ShootDelay += Time.deltaTime;
    }
}