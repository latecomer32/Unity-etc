using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Tile[] NextTiles;

	GameObject[] GamePlayer = new GameObject[2];


	GameObject player1;
	GameObject player2;
	GameObject Owner;
	Vector3 distance;

	DiceManager  DMBD1;

	GameObject buildingBuyPannel;


	enum TileState
	{
		Empty, Property, Single, Double, Triple, Hotel, Market, MilitaryBase
	}


	TileState state = TileState.Empty;

//	float doublePrice = 2f;
//	float triplePrice = 3f;

	bool Move;
	bool Checking;
	public bool landBuy = false;
	public bool landDontBuy = false;
	public bool landing;

	void Start()
	{


		DMBD1 = GameObject.Find("DiceManager").GetComponent<DiceManager>();

		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");

		GamePlayer[0] = player1;
		GamePlayer[1] = player2;


	}



	public void Vcheck()
	{
		Debug.Log ("Vcheck");
		landBuy = true;

	}

	public void Xcheck()
	{
		Debug.Log ("Xcheck");
		landDontBuy = true;

	
	}


	void Update () 
	{
		StartCoroutine ("BoardTile");

	}


//	IEnumerator Wait()
//	{
//		
//		yield return new WaitForSeconds(0.3f);
//	}


	IEnumerator BoardTile()
	{

		Debug.Log ("landBuy" + landBuy);


		landing = false;


			for (int i = 0; i < 2; i++) 
			{
				distance = this.transform.position - GamePlayer [i].transform.position;

				if (distance.sqrMagnitude <= 1) 
			{
					Debug.Log ("1");

					
					//this.GetComponent<Renderer> ().material.color = new Owner.GetComponent<Renderer> ().material.color; 로 깃발 오브젝트 생성해서 색깔 연출할 것.



					if (DMBD1.run1 == false) 
					{
						this.Owner = GamePlayer [i];

						Debug.Log ("2");

						landing = true;

						Checking = true;

					while (Checking == true) 
					{
						
							Debug.Log ("3");

							switch (state) 
						{
							case TileState.Empty: 

								Debug.Log ("4");



							if ( landBuy == true) //landBuy == true 실패
								{
									state = TileState.Property;

									Debug.Log ("Vcheck-true");


									Debug.Log ("이" + this.name + "의 땅 주인은" + Owner.name + "입니다.");


									Checking = false;

									// landBuy = false;
								}

							else if (landDontBuy == true) //landDontBuy == true 실패
								{

									Debug.Log ("Xcheck-true");

							
									Checking = false;

									// landDontBuy = false;
								}

								break;

						case TileState.Property:

							break;
						}
						yield return null;
						}
					}
				}

			}
	}
}





























//18.12.02 충돌감지 방식 오류있음..플레이어 오젝트에 콜라이더 기능 활성화시 플레이무버 넥스트 타일 null오류 및 Lanbuypannel활성화 조작 불가 오류
//void OnTriggerEnter(Collider col)
//{
//	Debug.Log ("1");
//
//	if (col.tag == "EveryPlayer") 
//	{
//		Debug.Log ("2");
//
//		if (DMBD1.run1 == false) 
//		{
//
//			Debug.Log ("3");
//
//			switch(state)
//			{
//			case TileState.Empty: 
//
//				Debug.Log ("4");
//
//				//		GetlandBuyPannel.SetActive(true);
//
//				if (landBuy == true) 
//				{
//
//					for(int i = 0; i < 2; i++)
//					{
//						if( GamePlayer[i].GetComponent<PlayerMover>().isoveraped == true)
//						{
//							Owner = GamePlayer[i];
//							//this.GetComponent<Renderer> ().material.color = new Owner.GetComponent<Renderer> ().material.color; 로 깃발 오브젝트 생성해서 색깔 연출할 것.
//
//						}
//					}
//
//					Debug.Log ("이"+this.name+"의 땅 주인은"+Owner.name+"입니다.");
//					state = TileState.Property;
//
//					GetlandBuyPannel.SetActive (false);
//				}
//
//				if (landDontBuy == true) 
//				{
//					GetlandBuyPannel.SetActive (false);
//				}
//
//				break;
//
//
//			}
//		}
//
//
//
//
//	}
//}











//			case TileState.Property: 
//			this.
//				
//				{
//
//				}
//			break;
//			
//			case TileState.Single: 
//			break;
//			case TileState.Double: 
//			break;
//			case TileState.Triple: 
//			break;
//			case TileState.Hotel: 
//			break;
//			case TileState.Market: 
//			break;
//			case TileState.MilitaryBase: 
//			break;












/* 예시 

public GameObject[] GamePlayer; //여서 게임플레이어 변수에 오브젝트 연결할것

int count = 0;

for(int i = 0; i < 3; i++)
{
   if( GamePlayer[i].isoveraped(bool변수 생성할것)~~ == ~~)
   {
   count++;
   }
 }

if(count >=3)
{
 isgameover = true;
 }

 

*/


	


