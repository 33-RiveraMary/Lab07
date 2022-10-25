using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rigidBody;

    public float jumpForce;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();

            //jump
            rigidBody.velocity += Vector3.up * jumpForce;
        }

        //ensure cannot fly above screen
        if (transform.position.y > 3.55f)
        {
            transform.position = new Vector3(0f, 3.55f, 0f);
        }
    }
}
