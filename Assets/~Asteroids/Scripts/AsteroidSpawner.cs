using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public float spawnRate = 1f;
        private float spwntimer = 0f;
        public GameObject[] prefabs;
        //public float seperation;
        //private Rigidbody rigid;
        private Bounds camBounds;
        private float camwidth;
        private float camHeight;

       /* void OnTriggerEnter2D(Collider2D col)
        {
            if(col.name.Contains("player"))
            {
                Vector2 direction =transform.position - col.transform.position;
                rigid.AddForce(direction.normalized * seperation);
            }
        }
        */
        public void Spawn()
        {
            #region Generate randowm postion
            Vector3 position = Vector3.zero;
            float halfwidth = camwidth * 0.5f;
            float halfHight = camHeight * 0.5f;
            if (Random.Range(0, 2) > 0)
            {
                position.x = Random.Range(-halfwidth, halfwidth);
                if (Random.Range(0, 2) > 0)
                {
                    position.y = halfHight;
                }
                else
                {
                    position.y = -halfHight;
                }
            }
            else
            {
                position.y = Random.Range(-halfHight, halfHight);
                if (Random.Range(0, 2) > 0)
                {
                    position.x = halfwidth;
                }
                else
                {
                    position.x = -halfwidth;
                }
                #endregion
                SpawnAtPostion(position);
            }
        }
        // Use this for initialization
        void Start()
        {
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camwidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camwidth, camHeight));
        }

        // Update is called once per frame
        void Update()
        {
            spwntimer += Time.deltaTime;
            if(spwntimer > spawnRate)
            {
                Spawn();
                spwntimer = 0;
            }
        }
        public void SpawnAtPostion(Vector3 position)
        {
            Instantiate(prefabs[6], position, Quaternion.identity);
        }
    }
    
}
