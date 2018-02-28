using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{ [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenWrap : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        //Camera
        private Bounds camBounds;
        private float camwidth;
        private float camHeight;
        // Use this for initialization
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void UpdateCameraBounds()
        {  // Calculate camera bounds
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camwidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camwidth, camHeight));
        }
        // Update is called once per frame
        void LateUpdate()
        {// Update dimensions of camera bounds before checking stuff
            UpdateCameraBounds();
            // Store position and size in a shorter variable name
            Vector3 pos = transform.position;
            Vector3 size = spriteRenderer.bounds.size;
            // Calculate the sprite's half width and half height
            float halfeWidth = size.x / 2f;
            float halfeHeight = size.y / 2f;
            // Check left
            if (pos.x + halfeWidth < camBounds.min.x)
            {
                pos.x = camBounds.max.x + halfeWidth;
            }
            // Check right
            if (pos.x - halfeWidth > camBounds.max.x)
            {
                pos.x = camBounds.min.x - halfeWidth;
            }
            // Check up
            if (pos.y + halfeHeight < camBounds.min.y)
            {
                pos.y = camBounds.max.y + halfeHeight;
            }
            // Check down
            if (pos.y - halfeHeight > camBounds.max.y)
            {
                pos.y = camBounds.min.y - halfeHeight;
            }
            transform.position = pos;
        }
    }
}