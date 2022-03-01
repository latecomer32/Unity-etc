using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{ 



    protected Joystick joystick;




	public float moveSpeed = 5f;
	public float turnSpeed = 540f;
	Rigidbody rb;
    Vector3 movement;
	public float jumpPower = 5f;

	public Image jump_Skill;
	public Image touch_Skill;

	public Text coolTimeCounter;
	public float coolTime;
	float currentCoolTime;
	bool jumpdelay;
	bool touchdelay;

	void Start() {
		rb = GetComponent<Rigidbody> ();

      
        joystick = FindObjectOfType<Joystick>();

    }
	





void Update() 
{









        float h = SimpleInput.GetAxis ("Horizontal");
		float v = SimpleInput.GetAxis ("Vertical");


       // movement.Set(h, 0, v);
      //  movement = movement.normalized * moveSpeed * Time.deltaTime;

       // rb.MovePosition(transform.position + movement);

         

          transform.Translate(h * moveSpeed * Time.deltaTime, 0f, v * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, joystick.Horizontal*turnSpeed * Time.deltaTime, 0f);


        // transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);









        


	}



	




    
}

