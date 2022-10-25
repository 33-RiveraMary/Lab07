using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rigidBody;

    //jump
    public float jumpForce;

    //gameover
    private bool isAlive;
    public GameObject gameoverTxt;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rigidBody = GetComponent<Rigidbody>();

        isAlive = true;
        gameoverTxt.SetActive(false);
    }

    void Update()
    {
        //check if game is playing
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                thisAnimation.Play();

                //jump
                rigidBody.velocity += Vector3.up * jumpForce;
            }
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
            gameoverTxt.SetActive(true);

            isAlive = false;
        }
    }

    private void OnCollisionEnter (Collision other)
    {
        //gameover when collide with obstacle
        if (other.gameObject.tag == "Obstacle")
        {
            gameoverTxt.SetActive(true);

            isAlive = false;
        }
    }
}
