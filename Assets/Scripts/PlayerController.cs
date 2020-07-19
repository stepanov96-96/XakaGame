using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public float rotateZ;

    public Transform weaponPose;
    
    void FixedUpdate()
    {
        //Передвижение игрока
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        Vector2 velocity = new Vector2(moveHorizontal, moveVertical);
        rigidBody.velocity = velocity * speed;


        //Вращение игрока
        float inputHorizontal = joystick.Horizontal;
        float inputVertical = joystick.Vertical;
        
        if (joystick.Horizontal > 0 )
        {
            rotateZ = Mathf.Atan2(inputVertical, inputHorizontal) * Mathf.Rad2Deg;
            weaponPose.rotation = Quaternion.Euler(0, 0, rotateZ);
        }
        else if (joystick.Horizontal < 0 )
        {
            rotateZ = Mathf.Atan2(inputVertical, -inputHorizontal) * Mathf.Rad2Deg;
            weaponPose.rotation = Quaternion.Euler(0, 0, rotateZ);
        }
        
        else if (inputVertical > 0)
        {
            rotateZ = Mathf.Atan2(inputVertical, inputHorizontal) * Mathf.Rad2Deg;
            weaponPose.rotation = Quaternion.Euler(0, 0, rotateZ);
        }

        else if (inputVertical < 0)
        {
            rotateZ = Mathf.Atan2(-inputVertical, inputHorizontal) * Mathf.Rad2Deg;
            weaponPose.rotation = Quaternion.Euler(0, 0, rotateZ);
        }
        //Переход в  исходные координаты
        if (joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            weaponPose.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

}
