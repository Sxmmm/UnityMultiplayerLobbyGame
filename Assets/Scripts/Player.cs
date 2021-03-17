using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    private void handleMovement()
    {
        if (isLocalPlayer)
        {
            float moverHorizontal = Input.GetAxis("Horizontal");
            // float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moverHorizontal * 0.05f, 0, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0) + movement;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private void Update()
    {
        handleMovement();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
            isGrounded = true;
    }
}
