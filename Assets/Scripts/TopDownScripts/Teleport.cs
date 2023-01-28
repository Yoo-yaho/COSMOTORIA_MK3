using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetPoint;
    public GameObject toPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            targetPoint = collision.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(TeleportRoutine());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        targetPoint = null;
    }

    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetPoint.transform.position = toPoint.transform.position;
    }
}
