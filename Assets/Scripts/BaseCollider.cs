using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    LivesDisplay lives;

    private void Start()
    {
        lives = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives.ReduceLive();
        Destroy(collision.gameObject);
        FindObjectOfType<LevelController>().RemoveAttackers(collision.gameObject);
    }
}
