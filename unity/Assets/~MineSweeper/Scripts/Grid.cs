using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper
{
    public class Grid : MonoBehaviour
    {
        // functions & Variables go here
        public GameObject tilePrefabs;
        public int width = 10, height = 10;
        public float spacing = 0.155f;
        public Ray mouseRay;
        private Tile hitTile;
        public RaycastHit2D hit;
        private Tile[,] tiles;

        Tile SpawnTile(Vector3 pos)
        {
            GameObject clone = Instantiate(tilePrefabs);
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            return currentTile;
        }
        void GenerateTiles()
        {
            tiles = new Tile[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 halfSize = new Vector2(width * 0.5f, height * 0.5f);
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);
                    Vector2 offset = new Vector2(0.5f, 0.5f);
                    pos += offset;
                    pos *= spacing;
                    Tile tile = SpawnTile(pos);
                    tile.transform.SetParent(transform);
                    tile.x = x;
                    tile.y = y;
                    tiles[x, y] = tile;
                }
            }
        }
        void Start()
        {
            GenerateTiles();
        }
        public int GetAdjacentMineCount(Tile tile)
        {
            int count = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;
                    if (desiredX < 0 || desiredX >= width ||
                        desiredY < 0 || desiredY >= height)
                    {
                        continue;
                    }

                    Tile CurrentTile = tiles[desiredX, desiredY];
                    if (CurrentTile.isMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        void SelectATile()
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (hit.collider != null)
            {
                hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile != null)
                {
                    SelectTile(hitTile);
                }
            }
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectATile();
            }

        }
        void FFuncover(int x, int y, bool[,] visited)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                if (visited[x, y])
                    return;
                Tile tile = tiles[x, y];
                int adjacentMine = GetAdjacentMineCount(tile);
                tile.Reveal(adjacentMine);
                if (adjacentMine == 0)
                {
                    visited[x, y] = true;
                    FFuncover(x - 1, y, visited);
                    FFuncover(x + 1, y, visited);
                    FFuncover(x, y - 1, visited);
                    FFuncover(x, y + 1, visited);

                }
            }
        }
        void UncoverMines(int mineState = 0)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    if (tile.isMine)
                    {
                        int adjacentMine = GetAdjacentMineCount(tile);
                        tile.Reveal(adjacentMine, mineState);
                    }

                }
            }
        }
        bool NoMoreEmptyTile()
        {
            int emptyTileCount = 0;




            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Tile tile = tiles[x, y];
                    if (!tile.isRevealed && !tile.isMine)
                    {
                        emptyTileCount += 1;
                    }
                }
            }
            return emptyTileCount == 0;
        }
        void SelectTile(Tile selected)
        {
            int adjacentMine = GetAdjacentMineCount(selected);
            selected.Reveal(adjacentMine);
            if(selected.isMine)
            {
                UncoverMines();
            }
            else if (adjacentMine == 0)
            {
                int x = selected.x;
                int y = selected.y;
                FFuncover(x, y, new bool[width, height]);
            }
            if(NoMoreEmptyTile())
            {
                UncoverMines(1);
            }
        }
    }
}
