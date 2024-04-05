
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float RotSpeed;

    private Vector2 Move;

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        MovePlayer();
    }




    private void MovePlayer()
    {
        Vector3 Movement = new(Move.x, 0f, Move.y);
        if (Movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Movement),RotSpeed);
        transform.Translate( Speed * Time.deltaTime * Movement, Space.World); 
    }
}
