using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
  
    public float speed;
    public FixedJoystick fj;
    public float horizontalInput, verticalInput,x,y;
    [SerializeField]
    private float rotationSpeed, inputMagnitude;

    void Update()
    {
        //horizontalInput = Input.GetAxisRaw("Horizontal");
        //verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = fj.Horizontal;
        verticalInput = fj.Vertical;
        /*  if (horizontalInput != 0)
          {
              if (horizontalInput > 0)
              {
                  x = 1;
              }
              if (horizontalInput < 0)
              {
                  x = -1;
              }
          }
          if (verticalInput != 0)
          {
              if (verticalInput > 0)
              {
                  y = 1;
              }
              if (verticalInput < 0)
              {
                  y = -1;
              }
          } */
     
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        
        movementDirection.Normalize();
        if (horizontalInput!=0 && verticalInput!=0)
        {
            x = horizontalInput;
            y = verticalInput;
        }
        if(horizontalInput==0 && verticalInput == 0)
        {
            inputMagnitude = 1;
            movementDirection = new Vector2(x, y);
        }
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
  

        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}