using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        // Function & Varuables go here
        public int x, y;
        public bool isMine = false;
        public bool isRevealed;
        [Header("References")]
        public Sprite[] emptySprites;
        public Sprite[] mineSprites;
        private SpriteRenderer rend;
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
        }
        void Start()
        {
            isMine = Random.value < 0.99f;
        }
        public void Reveal(int adjacentMine, int mineState = 0)
        {
            isRevealed = true;
            if(isMine)
            {
                rend.sprite = mineSprites[mineState];
            }
            else
            {
                rend.sprite = emptySprites[adjacentMine];
            }
        }
      
    }
}