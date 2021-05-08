using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 2f;

    float health = 1;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, -1000 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damage = other.GetComponent<DamageDealer>();

        if (damage)
        {
            health -= damage.GetDamage();

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
