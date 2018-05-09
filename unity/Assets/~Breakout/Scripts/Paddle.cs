using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakOut
{
    public class Paddle : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public Ball currentBall;
        //directions array defaults to two values
        public Vector2[] directions = new Vector2[]
        {
            new Vector2(-0.5f,0.5f),
            new Vector2(0.5f,0.5f)

        };
        // Use this for initialization
        void Start()
        {
            // Grabs currentBall from children of paddle
            currentBall = GetComponentInChildren<Ball>();

        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            CheckInput();
        }

        void Fire()
        {
            // Detach as child
            currentBall.transform.SetParent(null);
            // generate random dir from list of direction
            Vector3 randomDir = directions[Random.Range(0, directions.Length)];
            //fire off ball in randomDirection
            currentBall.Fire(randomDir);
        }
        void CheckInput()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
        void Movement()
        {
            //get input on the horizontal axis
            float inputH = Input.GetAxis("Horizontal");
            // set force to direction ( inputH to decide wgich Direction)
            Vector3 force = transform.right * inputH;
            //apply movement speed to force
            force *= movementSpeed;
            //apply delta time to force
            force *=Time.deltaTime;
            //add force to posion
            transform.position  += force;
        }
    }
}