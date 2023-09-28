using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{   
    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    private float turnSmoothVelocity;

    private Animator animator;

    // Update is called once per frame

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {

            animator.SetBool("IsMoving", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;// calcula o quanto o personagem deve ser rotacionado para acompanhar o movimento lateral do personagem
            float angle =Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //faz o personagem rotacionar suavemente entre os ângulos
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
