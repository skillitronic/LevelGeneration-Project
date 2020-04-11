using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputs : MonoBehaviour, CustomInputs.ISpawnControllerActions
{
    private CustomInputs CustonInput;
    private Vector2 InputVector;
    public DungeonGenerator dungeonGenerator;

    private void Awake()
    {
        CustonInput = new CustomInputs();
        CustonInput.SpawnController.SetCallbacks(this);
    }

    private void OnEnable() => CustonInput.Enable();

    private void OnDisable() => CustonInput.Disable();

    public void OnKeyBoard(InputAction.CallbackContext context)
    {
        InputVector = context.ReadValue<Vector2>();

        if (context.performed)
        {
            transform.position = dungeonGenerator.currentTile;
            if (InputVector.y > 0)
            {
                dungeonGenerator.GeneratePath("up");
            } else if (InputVector.y < 0)
            {
                dungeonGenerator.GeneratePath("down");
            }

            if (InputVector.x > 0)
            {
                dungeonGenerator.GeneratePath("right");
            } else if (InputVector.x < 0)
            {
                dungeonGenerator.GeneratePath("left");
            }
        }
    }
}
