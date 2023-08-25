using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    #region SingleTon
    public static GameInput instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Vector2 MoveInput;
    public bool FireInput;
    public Ray ray;
    public void OnMoveEvent(InputAction.CallbackContext context)
        => MoveInput = context.ReadValue<Vector2>();

    public void OnFireEvent(InputAction.CallbackContext context)
    {
        if (GameManeger.Instance.isStart)
        {
            FireInput = context.performed;
        }
    }

    public Ray GetMousePos() => Camera.main.ScreenPointToRay(Input.mousePosition);
}
