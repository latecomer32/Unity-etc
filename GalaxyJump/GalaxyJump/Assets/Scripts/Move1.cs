using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move1 : MonoBehaviour
{
    Move1 move1;
    bool startDelay;

    public Image start_time;

    bool jump;

    public float moveSpeed = 5f;
    public float turnSpeed = 540f;

    Vector3 movement;
    Joystick joystick;
    public float jumpPower = 5f;

    public Image jump_Skill;

    public Text coolTimeCounter;
    public float coolTime;
    float currentCoolTime;
    bool jumpdelay;
    bool touchdelay;

    Vector3 smoothMoveVelocity;

    Vector3 startposition;
    Quaternion startQuaternion;

    void Start()
    {
        startposition = transform.position;
        startQuaternion = transform.rotation;


        joystick = FindObjectOfType<Joystick>();
    //    StartCoroutine(StartDelay(2f));
    }


    void Update()
    {
            float h = SimpleInput.GetAxis("Horizontal");
            float v = SimpleInput.GetAxis("Vertical");

            transform.Translate(0f, 0f, v * moveSpeed * Time.deltaTime);
            transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);
            transform.Rotate(0f, joystick.Horizontal * turnSpeed * Time.deltaTime, 0f);
            //     Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            //    Vector3 targetMoveAmount = moveDir * moveSpeed;
            //   Vector3 moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
        }
    

   

    public void JUMP()
    {

        if (jumpdelay == true)
        {
            return;
        }
      
       
        GetComponent<Rigidbody>().AddForce(transform.up * jumpPower);
        StartCoroutine(jumpDelay(2f));
    }

    /*
    private void OnEnable()
    {
        transform.rotation = startQuaternion;
        transform.position = startposition;

      //  state = MoveState.Idle;
      // move1.enabled = false;
    }
    */

    public void MoveReset()
    {
        transform.rotation = startQuaternion;
        transform.position = startposition;
    }
       
    


    private void OnCollisionEnter(Collision col)
{
    if (col.collider.tag == "Stone" || col.collider.tag == "enemy")
    {

        if (startDelay == true)
        {
            return;
        }


        Debug.Log("YOU DIE");
         gameManager.instance.OnDestroy();

    }
}

IEnumerator StartDelay(float cool)
{
    while (cool > 1.0f)
    {
        startDelay = true;
        cool -= Time.deltaTime;
        //     start_time.fillAmount = (1.0f / cool);
        yield return new WaitForFixedUpdate();
    }

    startDelay = false;
}

IEnumerator jumpDelay(float cool)
{
    while (cool > 1.0f)
    {
        jumpdelay = true;
        cool -= Time.deltaTime;
        jump_Skill.fillAmount = (1.0f / cool);
        yield return new WaitForFixedUpdate();
    }

    jumpdelay = false;
}
        

}