using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//public int PeopleCount;

	public	enum PlayerState 
	{
		Ready1, Ready2, Active1, Active2, End
	}
	public PlayerState state;
	public bool GameOver;

	DiceManager  DMBD1;

	PlayerMover player1;
	PlayerMover player2;
	GameObject ButtonRollDice;

	void Start()
	{
		DMBD1 = GameObject.Find("DiceManager").GetComponent<DiceManager>();

		player1 = GameObject.Find("Player1").GetComponent<PlayerMover> ();
		player2 = GameObject.Find("Player2").GetComponent<PlayerMover> ();

		ButtonRollDice = GameObject.Find ("Button-RollDice");

		ButtonRollDice.SetActive (false);

		state = PlayerState.Ready1;


	}

		void Update()
		{


	switch(state)
	{

		case PlayerState.Ready1:


			player2.enabled = false;

			if (player1.Ready == true) 
			{
				
				player1.enabled = false;
			

				state = PlayerState.Ready2;
			}
				
		break;

		case PlayerState.Ready2:


			player2.enabled = true;

			if (player2.Ready == true)
			{
				player2.enabled = false;
			
				state = PlayerState.Active1;

				ButtonRollDice.SetActive (true);
			} 

			break;



		case PlayerState.Active1:
			
			player2.enabled = false;


			player1.enabled = true;


				if (DMBD1.run1 == false) 
				{

				state = PlayerState.Active2;

				}
				


			break;

		case PlayerState.Active2:
			player1.enabled = false;

			player2.enabled = true;

			if (DMBD1.run2 == false) 
			{	
				
				state = PlayerState.Active1;
			}


			break;

		}
	}
}










//public GameObject player1;












//	public Color color = Color.black;
//
//
//	void OnTriggerEnter(Collider col) 
//	{
//	}
//
//	//	bool gameover = false;
//
//	bool start = true;
//
//	IEnumerator WaitPleasee()
//	{
////		for(int i=0; i <100; i++)
//		yield return new WaitForSeconds(10f);
//	}
//
//
//	void Start()
//	{
//		List<GameObject> player = new List<GameObject> ();
//		player.Add(GameObject.Find ("Player1"));
//		player.Add(GameObject.Find ("Player2"));
//
//		if (start == true)
//		{
//			Debug.Log ("end1");
//
//			foreach (GameObject players in player) {
//
//				Debug.Log ("end2");
//
//				if (Input.GetMouseButtonDown (0)) {
//
//					Debug.Log ("end3");
//
//					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//					RaycastHit hit;
//					if (Physics.Raycast (ray, out hit)) 
//					{
//						if (players.transform.position != new Vector3 (hit.transform.position.x, hit.transform.position.y + players.transform.position.y / 2, hit.transform.position.z)) {
//							players.GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f, 0.5f);
//
//							players.transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y + players.transform.position.y / 2, hit.transform.position.z);				
//
//					StartCoroutine("WaitPleasee");
//
//							Debug.Log ("end4");
//							start = false;
//
//						}
//					}
//
//				}
//
//			}
//
//		}
//
//	}

//
//			if (gameover == true) 
//			{
//				all stop 기능 넣기
//			}










//	void Start()
//	{



//		StartCoroutine ("GameStart");
//	}
		//IEnumerator GamePlay()
		//{
		//	}
		

			

//		if (player != 타일 위치)
//		{


//	}

//}
