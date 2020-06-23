using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    [Header("Gravity")]
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float gravityScale = -9.81f;
    [SerializeField] float gravityAcceleration = 1f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.5f;
    [SerializeField] LayerMask groundLayerMask;

    CharacterController characterController;
    float gravity;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputForward = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float inputRight = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 moveDirection; // = transform.forward * inputForward + transform.right * inputRight;
        moveDirection = transform.forward * inputForward;
        moveDirection += transform.right * inputRight;

        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayerMask);
        if (isGrounded)
        {
            if (gravity < 0)
            {
                gravity = gravityScale;
            }
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpHeight;
            }
            //else if (gravity < 0)
            //{
            //    gravity = gravityScale;
            //}
        }
        else
        {
            gravity += gravityScale * Time.deltaTime; 
        }


        moveDirection.y = gravity * Time.deltaTime + (gravityScale * Time.deltaTime * Time.deltaTime) / 2;

        characterController.Move(moveDirection);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
