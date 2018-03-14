using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        public Moving movement;
        public Shooting shoot;
        // Update is called once per frame
        void Update()
        {
            Movememnt();
            Shoot();
        }
        void Movememnt()
        {
            float inputV = Input.GetAxis("Vertical");
            float inputH = Input.GetAxis("Horizontal");
            // Check if up arrow is pressed
            if (inputV > 0)
            {
                // Accelerate player
                movement.Accelerate(transform.up);
            }


            // Rotate in correct direction
            //movement.Rotate(inputH);
            if (inputH > 0)
            {
                movement.RotateLeft();
            }
            if (inputH < 0)
            {
                movement.RotateRight();
            }
        }
        void Shoot()
        {

            // if Space is pressed
            if(Input.GetKeyDown(KeyCode.Space))
            {
                shoot.Fire(transform.up);
            }

        }
    }
}
