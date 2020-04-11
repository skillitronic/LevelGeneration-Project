using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DungeonGeneration3 : MonoBehaviour
{
    public Tilemap shitMap;
    public TileBase[] tileBase;
    public Vector3Int currentTile;
    public int pathDirecion;
    public int maxGeneratableTiles;
    public int tileCounter;
    public void Start()
    {
        currentTile = new Vector3Int(0, 0, 0);
        Spawn();
        pathDirecion = Random.Range(0, 4);
        StartCoroutine("GenerateIntitator");

    }
    public void Spawn()
    {
        shitMap.SetTile(new Vector3Int(0, 0, 0), tileBase[0]);
        shitMap.SetTile(new Vector3Int(1, 0, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(-1, 0, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(0, 1, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(0, -1, 0), tileBase[1]);
    }
    private IEnumerator GenerateIntitator()
    {
        while (tileCounter < maxGeneratableTiles)
        {
            yield return new WaitForSeconds(.1f);
            if (pathDirecion == 0)
            {
                GeneratePath("up");
                tileCounter++;
                pathDirecion = Random.Range(0, 4);
                if (pathDirecion == 2)
                {
                    pathDirecion = Random.Range(0, 4);
                }
            }
            else if (pathDirecion == 1)
            {
                GeneratePath("right");
                tileCounter++;
                pathDirecion = Random.Range(0, 4);
                if (pathDirecion == 3)
                {
                    pathDirecion = Random.Range(0, 4);
                }

            }
            else if (pathDirecion == 2)
            {
                GeneratePath("down");
                tileCounter++;
                pathDirecion = Random.Range(0, 4);
                if (pathDirecion == 0)
                {
                    pathDirecion = Random.Range(0, 4);
                }

            }
            else if (pathDirecion == 3)
            {
                GeneratePath("left");
                tileCounter++;
                pathDirecion = Random.Range(0, 4);
                if (pathDirecion == 1)
                {
                    pathDirecion = Random.Range(0, 4);
                }
            }


        }

    }

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
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                    }

                    Debug.Log("Created at " + path);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0])
                {
                    currentTile -= Vector3Int.up;
                    tileCounter--;
                }

                if (shitMap.HasTile(currentTile + Vector3Int.left) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.left, tileBase[1]);
                }

                if (shitMap.HasTile(currentTile + Vector3Int.right) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.right, tileBase[1]);
                }

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
                    currentTile -= Vector3Int.down;
                    tileCounter--;
                }

                if (shitMap.HasTile(currentTile + Vector3Int.left) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.left, tileBase[1]);
                }

                if (shitMap.HasTile(currentTile + Vector3Int.right) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.right, tileBase[1]);
                }

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
                    currentTile -= Vector3Int.left;
                    tileCounter--;
                }

                if (shitMap.HasTile(currentTile + Vector3Int.up) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                }

                if (shitMap.HasTile(currentTile + Vector3Int.down) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.down, tileBase[1]);
                }

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
                    currentTile -= Vector3Int.right;
                    tileCounter--;
                }

                if (shitMap.HasTile(currentTile + Vector3Int.up) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                }

                if (shitMap.HasTile(currentTile + Vector3Int.down) == false)
                {
                    shitMap.SetTile(currentTile + Vector3Int.down, tileBase[1]);
                }

                break;
        }


    }
}
