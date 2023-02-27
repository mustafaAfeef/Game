using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredlane = 1;// 0 left 1 orta 2 sag.
    public float laneDistance =4 ; // the distance between two lane

    public float jumpForce;
    public float Gravity = -20;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;


        //if (controller.isGrounded)
        // {
        //direction.y = 1;
        direction.y = Gravity * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           jump();
        }
           // else
           // {
               // direction.y = Gravity * Time.deltaTime;
          //  }

       // }

        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredlane++;
            if (desiredlane == 3)
                desiredlane = 2;

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredlane--;
            if (desiredlane == -1)
                desiredlane = 0;

        }
        Vector3 taregetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredlane == 0)
        {
            taregetPosition = Vector3.left * laneDistance;
        }else if (desiredlane == 2)
        {
            taregetPosition = Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, taregetPosition, 80 * Time.deltaTime);


    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

    }
    private void jump()
    {
        direction.y = jumpForce;
    }

}
