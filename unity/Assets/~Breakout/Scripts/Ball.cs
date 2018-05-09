using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakOut
{
    public class Ball : MonoBehaviour
    {
        public float speed = 5f; // sped that the ball travels
        private Vector3 velocity;// velocity of the ball (direction x speed)
        // Use this for initialization
        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {
            // move ball using velocity & deltaTime
            transform.position += velocity * Time.deltaTime;
        }
        // fire off ball in given direction
        public void Fire(Vector3 direction)
        {// calculate velocity
            velocity = direction * speed;
        }
        //detact collisions
        void OnCollisionEnter2D(Collision2D other)
        {//grab contact point of collision
            ContactPoint2D contact = other.contacts[0];
            // calculate the reflection point of the ball using velocity & contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // calculate new velocity from reflection multiply by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
        }




    }

}