﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        public Moving movement;      

        // Update is called once per frame
        void Update()
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
            movement.Rotate(inputH);
            
        }
    }
}