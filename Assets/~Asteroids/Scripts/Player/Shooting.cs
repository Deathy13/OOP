using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPreFab;
        public Transform[] spawnPoint;
        public float bulletSpeed = 5f;
   
       // method in charge of fireing a bullet
       public void Fire(Vector3 Direction)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                //spawn bullet
                Spawn(Direction, spawnPoint[i].position);
            }
        }
        void Spawn(Vector3 Direction,Vector3 point)
        {

            // make a clone of bulletPrefabs
            GameObject clone = Instantiate(bulletPreFab);
            // set clone 's position
            clone.transform.position = point;
            // rotate the Bullet clone
            float angle = Mathf.Atan2(Direction.y, Direction.x);
            float degrees = angle * Mathf.Rad2Deg;

            clone.transform.rotation = Quaternion.AngleAxis(degrees, Vector3.forward);
            // tell its rigidbody 2d to fly in direction
            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
            rigid.AddForce(Direction * bulletSpeed, ForceMode2D.Impulse);

        }
    }
}