using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyBUtton : MonoBehaviour
{ 
    //, IPointerUpHandler, IPointerDownHandler{

    //   [HideInInspector]

    public bool Pressed;


    void Start() {


    }

    // Update is called once per frame
    void Update()
    {

        Pressed = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
           

            Debug.Log("2");
            if (hit.collider.tag == "JUMP")
            {
                Pressed = true;
/*
                Debug.Log("3");

                if (touchdelay == true)
                {
                    return;
                }
                Destroy(hit.transform.gameObject);
                StartCoroutine(touchDelay(3f));
                Debug.Log("4");

            */

            }
        }
    }

/*
        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
        }

        // public void ButtonON()
        //  {
        //      Pressed = true;
        // }
        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }

    */
    
}






