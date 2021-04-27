using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 2f;

    int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, -8);
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