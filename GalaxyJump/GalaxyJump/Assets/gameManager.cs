using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;

    public Text Enemy_Dis;

    public Text Exit_Dis;

    public Text messageText;

    public bool isRoundActive = false;

    public Enemy enemySc;

   public Move1 moveCharacter;

    public exit exitSc;

    public  GameObject readyPannel;

    public SpawnGenerator spawngenerator;
   

    Transform ExitTr;
    Transform EnemyTr;
    Transform PlayerTr;

    float enemy_Dis;
    float exit_Dis;

    void Awake()
    {
        instance = this;  
    }

    void Start()
    {
        StartCoroutine("RoundRoutine");

        ExitTr = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
        EnemyTr = GameObject.FindGameObjectWithTag("enemy").GetComponent<Transform>();
        PlayerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }




    void Update()
    {
 
        enemy_Dis = Mathf.Ceil(Vector3.Distance(PlayerTr.position, EnemyTr.position));
       exit_Dis = Mathf.Ceil(Vector3.Distance(ExitTr.position, PlayerTr.position));
    }

    void UpdateUI()
    {
        Enemy_Dis.text = "Enemy Distance:" + enemy_Dis;
        Exit_Dis.text = "Exit Distance:" + exit_Dis;
    }


    public void OnDestroy()
    {
        UpdateUI();
        isRoundActive = false;
    }

    public void WinTheGame()
    {
        UpdateUI();
        isRoundActive = false;
    }


    void Reset()
    {
        StartCoroutine("RoundRoutine");
        UpdateUI();
        spawngenerator.SpawnReset();
        exitSc.ExitReset();
        moveCharacter.MoveReset();
        enemySc.enemyReset();
    }

    IEnumerator RoundRoutine()
    {
        //ready
        readyPannel.SetActive(true);
        moveCharacter.enabled = false;

        isRoundActive = false;

        messageText.text = "Ready...";

        yield return new WaitForSeconds(3f);

        //play

        isRoundActive = true;
        readyPannel.SetActive(false);
        moveCharacter.enabled = true;

        while (isRoundActive == true)
        {

            UpdateUI();
            yield return null;
            
        }


        //end
        readyPannel.SetActive(true);
        moveCharacter.enabled = false;

        if( exitSc.YOUWIN == true)
        {
            messageText.text = " W I N !!! wait a seconds";
        }

        else
        {
            messageText.text = "YOU DIE..Wait..";
        }
       

        yield return new WaitForSeconds(3f);
        Reset();
           
    }
}
