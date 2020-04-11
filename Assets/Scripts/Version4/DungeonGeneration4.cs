using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class DungeonGeneration4 : MonoBehaviour
{
    private int secretSpawn;

    public Tilemap shitMap;
    public TileBase[] tileBase;
    public Vector3Int currentTile;
    public float tilePerTime;

    [Header("Randomizers")]
    public int mainDirecionRandomizer;
    public int secretDirectionRandomizer;
    public int setSecretSpawnChance;

    [Header("Counters")]
    public int maxGeneratableTiles;
    public int tileCounter;
    public int maxSecretRoom;
    public int secretRoomCounter;

    private void Start()
    {
        currentTile = new Vector3Int(0, 0, 0);
        Spawn();
        mainDirecionRandomizer = Random.Range(0, 4);
        StartCoroutine("GenerateIntitator");
    }
    private void Spawn()
    {
        shitMap.SetTile(new Vector3Int(0, 0, 0), tileBase[0]);
        shitMap.SetTile(new Vector3Int(1, 0, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(-1, 0, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(0, 1, 0), tileBase[1]);
        shitMap.SetTile(new Vector3Int(0, -1, 0), tileBase[1]);
    }
    private IEnumerator GenerateIntitator()
    {
        while (tileCounter != maxGeneratableTiles)
        {
            yield return new WaitForSeconds(tilePerTime);

            if (mainDirecionRandomizer == 0)
            {
                GeneratePath(0); // to up
                tileCounter++;
                mainDirecionRandomizer = Random.Range(0, 4);
                while (mainDirecionRandomizer == 2)
                {
                    mainDirecionRandomizer = Random.Range(0, 4);
                }
            }
            else if (mainDirecionRandomizer == 1)
            {
                GeneratePath(1); // to right
                tileCounter++;
                mainDirecionRandomizer = Random.Range(0, 4);
                while (mainDirecionRandomizer == 3)
                {
                    mainDirecionRandomizer = Random.Range(0, 4);
                }

            }
            else if (mainDirecionRandomizer == 2)
            {
                GeneratePath(2); // to down
                tileCounter++;
                mainDirecionRandomizer = Random.Range(0, 4);
                while (mainDirecionRandomizer == 0)
                {
                    mainDirecionRandomizer = Random.Range(0, 4);
                }

            }
            else if (mainDirecionRandomizer == 3)
            {
                GeneratePath(3); // to left
                tileCounter++;
                mainDirecionRandomizer = Random.Range(0, 4);
                while (mainDirecionRandomizer == 1)
                {
                    mainDirecionRandomizer = Random.Range(0, 4);
                }
            }

        }

        if (tileCounter == maxGeneratableTiles)
        {
            shitMap.SetTile(currentTile, tileBase[3]);
        }

    }

    private void CheckAndPutTile(Vector3Int vectorDirection)
    {
        if (shitMap.HasTile(currentTile + vectorDirection) == false)
        {
            shitMap.SetTile(currentTile + vectorDirection, tileBase[1]);
        }
    }

    private void CheckAndPutTile(Vector3Int vectorDirection, Vector3Int secondVectorDirection)
    {
        if (shitMap.HasTile(currentTile + vectorDirection) == false)
        {
            shitMap.SetTile(currentTile + vectorDirection, tileBase[1]);
        }
        else
        {
            return;
        }

        if (shitMap.HasTile(currentTile + secondVectorDirection) == false)
        {
            shitMap.SetTile(currentTile + secondVectorDirection, tileBase[1]);
        }
        else
        {
            return;
        }
    }

    public void GeneratePath(int direction)
    {
        if (secretRoomCounter < maxSecretRoom)
        {
            secretSpawn = Random.Range(0, setSecretSpawnChance);
        }

        switch (direction)
        {
            case 0: // up

                currentTile += Vector3Int.up;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    if (secretSpawn == setSecretSpawnChance - 1 && secretRoomCounter < maxSecretRoom)
                    {
                        shitMap.SetTile(currentTile, tileBase[2]);
                        secretRoomCounter++;
                        Debug.Log("Created when counter was: " + tileCounter);
                        Debug.Log("Created at " + direction);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile, tileBase[0]);
                    }

                    if (shitMap.GetTile(currentTile + Vector3Int.up) == tileBase[0])
                    {
                        CheckAndPutTile(Vector3Int.right, Vector3Int.left);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.up, tileBase[1]);
                    }

                    Debug.Log("Created at " + direction);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0] || shitMap.GetTile(currentTile) == tileBase[2])
                {
                    while (mainDirecionRandomizer == 0)
                    {
                        mainDirecionRandomizer = Random.Range(0, 4);
                    }
                    GeneratePath(mainDirecionRandomizer);
                }

                CheckAndPutTile(Vector3Int.left);
                CheckAndPutTile(Vector3Int.right);
                break;
            case 1: // right

                currentTile += Vector3Int.right;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    if (secretSpawn == setSecretSpawnChance - 1 && secretRoomCounter < maxSecretRoom)
                    {
                        shitMap.SetTile(currentTile, tileBase[2]);
                        secretRoomCounter++;
                        Debug.Log("Created when counter was: " + tileCounter);
                        Debug.Log("Created at " + direction);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile, tileBase[0]);
                    }

                    if (shitMap.GetTile(currentTile + Vector3Int.right) == tileBase[0])
                    {
                        CheckAndPutTile(Vector3Int.up, Vector3Int.down);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.right, tileBase[1]);
                    }
                    Debug.Log("Created at " + direction);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0] || shitMap.GetTile(currentTile) == tileBase[2])
                {
                    while (mainDirecionRandomizer == 1)
                    {
                        mainDirecionRandomizer = Random.Range(0, 4);
                    }
                    GeneratePath(mainDirecionRandomizer);
                }

                CheckAndPutTile(Vector3Int.up);
                CheckAndPutTile(Vector3Int.down);
                break;

            case 2: // down

                currentTile += Vector3Int.down;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    if (secretSpawn == setSecretSpawnChance - 1 && secretRoomCounter < maxSecretRoom)
                    {
                        shitMap.SetTile(currentTile, tileBase[2]);
                        secretRoomCounter++;
                        Debug.Log("Created when counter was: " + tileCounter);
                        Debug.Log("Created at " + direction);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile, tileBase[0]);
                    }

                    if (shitMap.GetTile(currentTile + Vector3Int.down) == tileBase[0])
                    {
                        CheckAndPutTile(Vector3Int.right, Vector3Int.left);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.down, tileBase[1]);
                    }
                    Debug.Log("Created at " + direction);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0] || shitMap.GetTile(currentTile) == tileBase[2])
                {
                    while (mainDirecionRandomizer == 2)
                    {
                        mainDirecionRandomizer = Random.Range(0, 4);
                    }
                    GeneratePath(mainDirecionRandomizer);
                }

                CheckAndPutTile(Vector3Int.left);
                CheckAndPutTile(Vector3Int.right);
                break;

            case 3: // left

                currentTile += Vector3Int.left;

                if (shitMap.HasTile(currentTile) == false || shitMap.GetTile(currentTile) == tileBase[1])
                {
                    if (secretSpawn == setSecretSpawnChance - 1 && secretRoomCounter < maxSecretRoom)
                    {
                        shitMap.SetTile(currentTile, tileBase[2]);
                        secretRoomCounter++;
                        Debug.Log("Created when counter was: " + tileCounter);
                        Debug.Log("Created at " + direction);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile, tileBase[0]);
                    }

                    if (shitMap.GetTile(currentTile + Vector3Int.left) == tileBase[0])
                    {
                        CheckAndPutTile(Vector3Int.up, Vector3Int.down);
                    }
                    else
                    {
                        shitMap.SetTile(currentTile + Vector3Int.left, tileBase[1]);
                    }
                    Debug.Log("Created at " + direction);

                }
                else if (shitMap.GetTile(currentTile) == tileBase[0] || shitMap.GetTile(currentTile) == tileBase[2])
                {
                    while (mainDirecionRandomizer == 3)
                    {
                        mainDirecionRandomizer = Random.Range(0, 4);
                    }
                    GeneratePath(mainDirecionRandomizer);
                }

                CheckAndPutTile(Vector3Int.up);
                CheckAndPutTile(Vector3Int.down);
                break;
        }
    }
}