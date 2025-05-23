using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlocker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject); // BulletTag のオブジェクトを削除
        }
    }
}
