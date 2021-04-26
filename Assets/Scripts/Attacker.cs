using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    int health = 20;

    [SerializeField]
    GameObject deathVFX;

    float movementSpeed = 1f;

    private LevelLoader levelLoad;

    // Start is called before the first frame update
    void Start()
    {
        levelLoad = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    private void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damage = other.GetComponent<DamageDealer>();

        if(damage)
        {
            health -= damage.GetDamage();

            if(health <= 0)
            {
                GameObject newVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
                newVFX.transform.parent = levelLoad.GetCleanUpContainer();
                Destroy(newVFX, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}
