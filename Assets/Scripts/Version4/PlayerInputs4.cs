using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerInputs4 : MonoBehaviour, CustomInputs.ISpawnControllerActions
{
    private CustomInputs CustonInput;
    private Vector2 InputVector;
    public DungeonGeneration4 dungeonGenerator;
    public Vector3Int currentPosition;

    private void Awake()
    {
        CustonInput = new CustomInputs();
        CustonInput.SpawnController.SetCallbacks(this);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.ClearDeveloperConsole();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnEnable() => CustonInput.Enable();

    private void OnDisable() => CustonInput.Disable();

    public void OnKeyBoard(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();

        if (InputVector.y > 0)
        {
            if (dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.up) == dungeonGenerator.tileBase[0] || dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.up) == dungeonGenerator.tileBase[3])
            {
                currentPosition += Vector3Int.up;
                transform.position = currentPosition;
            }
        }
        else if (InputVector.y < 0)
        {
            if (dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.down) == dungeonGenerator.tileBase[0] || dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.up) == dungeonGenerator.tileBase[3])
            {
                currentPosition += Vector3Int.down;
                transform.position = currentPosition;
            }
        }

        if (InputVector.x > 0)
        {
            if (dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.right) == dungeonGenerator.tileBase[0] || dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.up) == dungeonGenerator.tileBase[3])
            {
                currentPosition += Vector3Int.right;
                transform.position = currentPosition;
            }
        }
        else if (InputVector.x < 0)
        {
            if (dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.left) == dungeonGenerator.tileBase[0] || dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.up) == dungeonGenerator.tileBase[3])
            {
                currentPosition += Vector3Int.left;
                transform.position = currentPosition;
            }
        }
    }

}
