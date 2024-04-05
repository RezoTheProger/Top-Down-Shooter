
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float RotSpeed;
    [SerializeField] private bool isPc;

    private Vector2 Move, mouseLook, joystickLook;
    private Vector3 _RotTarget;
    private void Start()
    {
        if (Application.platform == (RuntimePlatform.WindowsPlayer | RuntimePlatform.OSXPlayer | RuntimePlatform.LinuxPlayer)) isPc = true;
        else isPc=false;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }
    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }
    public void OnJoystickLook(InputAction.CallbackContext context)
    {
        joystickLook = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (isPc)
        {
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);
            if (Physics.Raycast(ray, out RaycastHit hit)) _RotTarget = hit.point;
            MovePlayerWithAim();

        }
        else {
            if (joystickLook.x == 0 && joystickLook.y == 0) MovePlayer();
            else MovePlayerWithAim();
        }
    }




    private void MovePlayer()
    {
        Vector3 Movement = new(Move.x, 0f, Move.y);
        if (Movement != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Movement),RotSpeed);
        transform.Translate( Speed * Time.deltaTime * Movement, Space.World); 
    }

    private void MovePlayerWithAim()
    {
        if (isPc)
        {
            var lookPos = _RotTarget - transform.position;
            lookPos.y = 0;
            var rot = Quaternion.LookRotation(lookPos);
            Vector3 aimDir = new(_RotTarget.x, 0f, _RotTarget.y);
            if (aimDir != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, rot, RotSpeed);
        }
        else
        {
            Vector3 aimDir = new(joystickLook.x, 0f, joystickLook.y);
            if (aimDir != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDir), RotSpeed);

        }
        Vector3 movement = new(Move.x, 0f, Move.y);
        transform.Translate(Speed * Time.deltaTime * movement, Space.World);
    }


}
