using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_MOVement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed,fspeed=10f;
    public float horizontalInput, verticalInput, x, y;
    [SerializeField]
    private float rotationSpeed, inputMagnitude;
    public Transform[] path;
    public int i = 0;

    void Update()
    {
        if (this.transform.position != path[i].position)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, path[i].position, fspeed * Time.deltaTime);
        }
        else
        {
            if (i >= path.Length-1)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }
        if (horizontalInput < 2)
        {
            horizontalInput *= 2;
            verticalInput *= 2;
        }
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();
        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);
        if (movementDirection != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
   
}