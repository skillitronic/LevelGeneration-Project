using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerInputs2 : MonoBehaviour, CustomInputs.ISpawnControllerActions
{
    private CustomInputs CustonInput;
    private Vector2 InputVector;
    public DungeonGenerator2 dungeonGenerator;
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
        transform.position = dungeonGenerator.currentTile;
    }
    private void OnEnable() => CustonInput.Enable();

    private void OnDisable() => CustonInput.Disable();

    public void OnKeyBoard(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();

        if (context.performed)
        {
            if (InputVector.y > 0)
            {
                if (dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.up) == dungeonGenerator.tileBase[0]){
                    transform.position += Vector3Int.up;
                }
            }
            else if (InputVector.y < 0)
            {
                if (dungeonGenerator.shitMap.GetTile(currentPosition + Vector3Int.down) == dungeonGenerator.tileBase[0])
                {
                    transform.position += Vector3Int.down;
                }
            }

            if (InputVector.x > 0)
            {

            }
            else if (InputVector.x < 0)
            {

            }
        }
    }

}
