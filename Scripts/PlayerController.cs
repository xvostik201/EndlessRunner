using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header(" Player Settings ")]
    [SerializeField] private float jumpForce;
    
    [Header("Other Settings")]
    [SerializeField] private float sphereRadius;
    [SerializeField] private LayerMask layerMask;
    

    private bool isGrounded;
    private float groundedDelay;
    private Rigidbody rb;
    private GameManager gameManager;
    void Start()
    {
        isGrounded = false;
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        groundedDelay += Time.deltaTime;

        if(groundedDelay > 1)
            isGrounded = Physics.CheckSphere(transform.position, sphereRadius, layerMask);

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            gameManager.GameOver();
        }
    }
}
