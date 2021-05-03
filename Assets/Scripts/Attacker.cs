using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField]
    GameObject deathVFX;

    [SerializeField]
    int health = 20;

    [SerializeField]
    private bool vulnerable = false;

    [SerializeField]
    int enemyID;

    private LevelLoader levelLoad;

    GameObject currentTarget;

    float movementSpeed = 1f;

    Animator animator;

    DefenderSpawner defenderSpawner;

    // Start is called before the first frame update
    void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        levelLoad = FindObjectOfType<LevelLoader>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void Movement()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    private void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    private void SetVulnerability()
    {
        vulnerable = true;
    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);
    }

    private void StrikeTarget()
    {
        DefenderResource health = currentTarget.GetComponent<DefenderResource>();

        if(health)
        {
            health.DamageHealth(GetComponent<DamageDealer>().GetDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGameobject = other.gameObject;
        DamageDealer damage = otherGameobject.GetComponent<DamageDealer>();
        DefenderResource defender = otherGameobject.GetComponent<DefenderResource>();


        if (damage && vulnerable)
        {
            health -= damage.GetDamage();

            if (health <= 0)
            {
                GameObject newVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
                newVFX.transform.parent = levelLoad.GetCleanUpContainer();
                Destroy(newVFX, 1f);
                Destroy(this.gameObject);
            }
        }

        if(otherGameobject.CompareTag("GraveStone") && enemyID == 1)
        {
            animator.SetTrigger("JumpTrigger");
        }
        else if (defender)
        {
            currentTarget = otherGameobject;
            Attack();
        }
    }
}
