using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 5f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Animator animator;
    public float boostedSpeed = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            speed *= boostedSpeed; // Aumenta a velocidade temporariamente
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Booster"))
        {
            speed /= boostedSpeed; // Restaura a velocidade original
        }
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;



        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsMoving", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            speed *= 0; // Aumenta a velocidade temporariamente
        }

    }
}
