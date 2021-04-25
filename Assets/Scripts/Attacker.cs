using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }
}
