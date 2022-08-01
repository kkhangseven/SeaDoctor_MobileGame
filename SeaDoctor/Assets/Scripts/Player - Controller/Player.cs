using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Camera camera; 
    public JoystickController joystickController;

    public float speed = 10f;

    private Rigidbody rbody;
    private float defaultHeight;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        defaultHeight = transform.position.y;
    }

    void Update()
    {
        if(joystickController.Velocity.magnitude > 0f){
            float angle = -Vector2.SignedAngle( Vector2.left,joystickController.Velocity);
            if(angle<0) angle = 360 + angle;
            transform.localRotation = Quaternion.Euler(0,angle,0);
        }
        rbody.velocity = new Vector3(-joystickController.Velocity.x*speed, 0 ,-joystickController.Velocity.y*speed);

        camera.transform.position = transform.position + new Vector3(0,30,25);
    }
}