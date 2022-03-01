using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Move1 : NetworkBehaviour
{

    /*
    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public Slider healthSlider;

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;

    }


    void OnChangeHealth(int health)
    {
        healthSlider.value = health;
    }
    */


    JoyBUtton joybutton;


    //	public GameObject Lazerprefab;
    //	public Transform LazerSpwan;
    bool jump;

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

    void Start()
    {

        if (isLocalPlayer)
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
        }
        else
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
        }

        joybutton = GameObject.Find("JoyButton").GetComponent<JoyBUtton>();

        rb = GetComponent<Rigidbody>();
    }






    void Update()
    {
        /*
       if (!isLocalPlayer)
       {
           return;
       }




           else if (hit.collider.tag == "JUMP")
           {

               if (jumpdelay == true)
               {
                   return;
               }

               //  jump = true;

               rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
               StartCoroutine(jumpDelay(3f));
           }




        if (joybutton.Pressed == false)
        {
            jump = false;
        }
        */


        /*
        if (!jump && joybutton.Pressed)
        {

                     jump = true;

            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            StartCoroutine(jumpDelay(3f));
        }

        if (jump && !joybutton.Pressed)
        {
            jump = false;
        }
        */




        float h = SimpleInput.GetAxis("Horizontal");
        float v = SimpleInput.GetAxis("Vertical");


        //      movement.Set(h, 0, v);
        //      movement = movement.normalized * moveSpeed * Time.deltaTime;

        //     rb.MovePosition(transform.position + movement);

        transform.Translate(0f, 0f, v * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, h * turnSpeed * Time.deltaTime, 0f);






        if (Input.GetMouseButtonDown(0))
        {
            CmdFire();
        }


    }


    IEnumerator touchDelay(float cool)
    {

        Debug.Log(" jumpDelay 코루틴 실행");

        while (cool > 1.0f)
        {
            touchdelay = true;

            cool -= Time.deltaTime;
            touch_Skill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
        touchdelay = false;
        Debug.Log(" jumpDelay 코루틴 완료");

    }



    IEnumerator jumpDelay(float cool)
    {

        Debug.Log(" jumpDelay 코루틴 실행");

        while (cool > 1.0f)
        {
            jumpdelay = true;
            cool -= Time.deltaTime;
            jump_Skill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }

        jumpdelay = false;
        Debug.Log(" jumpDelay 코루틴 완료");

    }

  
  



    [Command]
    void CmdFire()
    {
      

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            //			GameObject Lazer = Instantiate (Lazerprefab,LazerSpwan.position,LazerSpwan.rotation);

            //			Lazer.GetComponent<Rigidbody> ().velocity = Lazer.transform.forward * 100;

            //			NetworkServer.Spawn (Lazer);

            //		Destroy (Lazer, 2.0f);


            Debug.Log("2");
            if (hit.collider.tag == "enemy")
            {
                Debug.Log("3");

                if (touchdelay == true)
                {
                    return;
                }
                Destroy(hit.transform.gameObject);
                StartCoroutine(touchDelay(3f));
                Debug.Log("4");

            }
           
        }

    }

   // [Command]
    public void JUMP()
    {


        if (jumpdelay == true)
        {
            return;
        }
        Debug.Log("jump!");
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        StartCoroutine(jumpDelay(3f));
    }

    public override void OnStartLocalPlayer()
    {
        this.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0.3f);
    }

}