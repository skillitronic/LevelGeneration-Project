using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DungeonGenerator : MonoBehaviour
{
    public Tilemap shitMap;
    public TileBase[] tileBase;
    public Vector3Int currentTile;
    public void Start()
    {
        currentTile = new Vector3Int(0, 0, 0);
        Spawn();
    }
    public void Spawn()
    {
        shitMap.SetTile(new Vector3Int(0, 0, 0), tileBase[0]);
        shitMap.SetTile(new Vector3Int(1, 0, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(-1, 0, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(0, 1, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(0, -1, 0), tileBase[1]);
    }

    /*    public void MoveUp() {
            currentTile += Vector3Int.up;
            shiet.SetTile(currentTile, tileBase[0]);
            shiet.SetTile(currentTile + Vector3Int.right, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.left, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.up, tileBase[1]);
        }

        public void MoveDown() {
            currentTile += Vector3Int.down;
            shiet.SetTile(currentTile, tileBase[0]);
            shiet.SetTile(currentTile + Vector3Int.right, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.left, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.down, tileBase[1]);
        }

        public void MoveLeft() {
            currentTile += Vector3Int.left;
            shiet.SetTile(currentTile, tileBase[0]);
            shiet.SetTile(currentTile + Vector3Int.down, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.left, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.up, tileBase[1]);
        }

        public void MoveRight() {
            currentTile += Vector3Int.right;
            shiet.SetTile(currentTile, tileBase[0]);
            shiet.SetTile(currentTile + Vector3Int.right, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.down, tileBase[1]);
            shiet.SetTile(currentTile + Vector3Int.up, tileBase[1]);
        }*/

    public void GeneratePath(string path)
    {
        switch (path)
        {
            case "up":

                currentTile += Vector3Int.up;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    shitMap.SetTile(currentTile, tileBase[0]);
                    if (shitMap.GetTile(currentTile + Vector3Int.up) == tileBase[0])
                    {
                        return;
                    } else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                    }

                    Debug.Log("Created at " + path);

                } else if (shitMap.GetTile(currentTile) == tileBase[0])
                {
                    Debug.Log("Moved " + path);
                    break;

                }
                
                if (shitMap.HasTile(currentTile + Vector3Int.left) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.left, tileBase[1]);
                } /*else if (shitMap.GetTile(currentTile + Vector3Int.left) == tileBase[0])
                {
                    return;
                }*/

                if (shitMap.HasTile(currentTile + Vector3Int.right) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.right, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.right) == tileBase[0])
                {
                    return;
                }*/

                break;
            case "down":

                currentTile += Vector3Int.down;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    shitMap.SetTile(currentTile, tileBase[0]);
                    if (shitMap.GetTile(currentTile + Vector3Int.down) == tileBase[0])
                    {
                        return;
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.down, tileBase[1]);
                    }
                    Debug.Log("Created at " + path);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0])
                {
                    Debug.Log("Moved " + path);
                    break;

                }

                if (shitMap.HasTile(currentTile + Vector3Int.left) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.left, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.left) == tileBase[0])
                {
                    return;
                }*/

                if (shitMap.HasTile(currentTile + Vector3Int.right) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.right, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.right) == tileBase[0])
                {
                    return;
                }*/

                break;
            case "left":

                currentTile += Vector3Int.left;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    shitMap.SetTile(currentTile, tileBase[0]);
                    if (shitMap.GetTile(currentTile + Vector3Int.left) == tileBase[0])
                    {
                        return;
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.left, tileBase[1]);
                    }
                    Debug.Log("Created at " + path);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0])
                {
                    Debug.Log("Moved " + path);
                    break;

                }

                if (shitMap.HasTile(currentTile + Vector3Int.up) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.up) == tileBase[0])
                {
                    return;
                }*/

                if (shitMap.HasTile(currentTile + Vector3Int.down) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.down, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.down) == tileBase[0])
                {
                    return;
                }*/

                break;
            case "right":

                currentTile += Vector3Int.right;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    shitMap.SetTile(currentTile, tileBase[0]);
                    if (shitMap.GetTile(currentTile + Vector3Int.right) == tileBase[0])
                    {
                        return;
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.right, tileBase[1]);
                    }
                    Debug.Log("Created at " + path);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0])
                {
                    Debug.Log("Moved " + path);
                    break;
                }

                if (shitMap.HasTile(currentTile + Vector3Int.up) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.up) == tileBase[0])
                {
                    return;
                }*/

                if (shitMap.HasTile(currentTile + Vector3Int.down) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.down, tileBase[1]);
                }
/*                else if (shitMap.GetTile(currentTile + Vector3Int.down) == tileBase[0])
                {
                    return;
                }*/

                break;
        }


    }
}
