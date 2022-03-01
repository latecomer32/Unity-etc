using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0 : MonoBehaviour {

    // Use this for initialization

    protected Joystick joystick;

    void Start () {
    rb = GetComponent<Rigidbody>();


    joystick = FindObjectOfType<Joystick>();
}
public float moveSpeed = 5f;
public float turnSpeed = 540f;
Rigidbody rb;
Vector3 movement;
public float jumpPower = 5f;



public float coolTime;
float currentCoolTime;
bool jumpdelay;
bool touchdelay;

// Update is called once per frame
void Update () {



   // float h = SimpleInput.GetAxis("Horizontal");
  //  float v = SimpleInput.GetAxis("Vertical");


    // movement.Set(h, 0, v);
    //  movement = movement.normalized * moveSpeed * Time.deltaTime;

    // rb.MovePosition(transform.position + movement);



 //   transform.Translate(h * moveSpeed * Time.deltaTime, 0f, v * moveSpeed * Time.deltaTime);
    transform.Rotate(0f, joystick.Horizontal * turnSpeed * Time.deltaTime, 0f);

}
}
