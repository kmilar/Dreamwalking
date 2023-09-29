using UnityEngine;
using UnityEngine.InputSystem;

public class MobileThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;
    private Animator animator;
    private Vector2 moveInput;

    private PlayerMovement controls;

    private void Awake()
    {
        controls = new PlayerMovement();
        controls.Enable();
        controls.Player.Move.performed += ctx => OnMove(ctx);
        controls.Player.Move.canceled += ctx => OnMove(ctx);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * moveInput.y + right * moveInput.x;

        if (desiredMoveDirection.magnitude >= 0.1f)
        {
            animator.SetBool("IsMoving", true);

            float targetAngle = Mathf.Atan2(desiredMoveDirection.x, desiredMoveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void OnDestroy()
    {
        controls.Disable();
        controls.Player.Move.performed -= ctx => OnMove(ctx);
        controls.Player.Move.canceled -= ctx => OnMove(ctx);
    }
}
