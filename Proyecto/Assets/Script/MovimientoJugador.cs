using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float Speed = 1.0f;
    public float RotationSpeed = 1.0f;
    public float JumpForce = 1.0f;

    private Rigidbody Physics;

    public Transform CameraTransform; 
    public float VerticalLookLimit = 80.0f; 
    private float verticalRotation = 0.0f; 
  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Physics = GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * Time.deltaTime * Speed);

        
        float rotationY = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * RotationSpeed, 0));

       
        if (Input.GetMouseButton(1)) 
        {
            float rotationX = -Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;

           
            verticalRotation = Mathf.Clamp(verticalRotation + rotationX, -VerticalLookLimit, VerticalLookLimit);

            
            CameraTransform.localEulerAngles = new Vector3(verticalRotation, 0, 0);
        }

       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Physics.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }
}
