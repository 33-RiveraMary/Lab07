using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    //jump
    public float jumpForce;

    //gameover
    public GameManager managerScript;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();

            //jump
            rigidBody.velocity += Vector3.up * jumpForce;
            audioSource.Play();
        }

        //ensure cannot fly above screen
        if (transform.position.y > 3.55f)
        {
            transform.position = new Vector3(0f, 3.55f, 0f);
        }

        //gameover when fall under screen
        if (transform.position.y < -3.7f)
        {
            //gameover
            managerScript.GameOver();
        }
    }

    private void OnCollisionEnter (Collision other)
    {
        //gameover when collide with obstacle
        if (other.gameObject.tag == "Obstacle")
        {
            managerScript.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //increase score after passing obstacle
        if (other.gameObject.tag == "ObstTrigger")
        {
            managerScript.UpdateScore(1);
        }
    }
}
