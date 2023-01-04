using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float h, v;

    // 수평 Move 체크
    bool isHorizonMove;
    public float speed;
    public InGameManager manager;

    Rigidbody2D rigidBody;
    Animator animator;
    GameObject scanObject;

    Vector3 dirVec;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        // 버튼 다운 체크
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        // 수평 Move인가?
        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        // 애니메이션
        if (animator.GetInteger("hAxisRaw") != h)
        {          
            animator.SetInteger("hAxisRaw", (int)h);
            animator.SetBool("isChange", true);
        }
        else if (animator.GetInteger("vAxisRaw") != v)
        {
            animator.SetInteger("vAxisRaw", (int)v);
            animator.SetBool("isChange", true);
        }
        else
            animator.SetBool("isChange", false);

        // Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown && h == -1)
            dirVec = Vector3.left;

        // ScanObject
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Scan(scanObject);
    }

    private void FixedUpdate()
    {
        // Move
        Vector2 moveVector = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);

        rigidBody.velocity = moveVector * speed;


        // Ray
        Debug.DrawRay(rigidBody.position, dirVec * 0.8f, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigidBody.position, dirVec, 0.7f, 
            LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;
    }
}
