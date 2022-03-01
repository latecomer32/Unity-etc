using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour {

	Tile[] Tiles = new Tile[16];

	Tile tile1;
	Tile tile2;
	Tile tile3;
	Tile tile4;
	Tile tile5;
	Tile tile6;
	Tile tile7;
	Tile tile8;
	Tile tile9;
	Tile tile10;
	Tile tile11;
	Tile tile12;
	Tile tile13;
	Tile tile14;
	Tile tile15;
	Tile tile16;

	Tile MainTile;


	public	GameObject GetlandBuyPannel;


	public void AllVcheck()
	{
		Debug.Log ("AllVcheck");
		MainTile.Vcheck();

	}

	public void AllXcheck()
	{
		Debug.Log ("AllXcheck");
		MainTile.Xcheck();

	}



	void Start () {

		tile1 = GameObject.Find("Tile 1").GetComponent<Tile>();
		tile2 = GameObject.Find("Tile 2").GetComponent<Tile>();
		tile3 = GameObject.Find("Tile 3").GetComponent<Tile>();
		tile4 = GameObject.Find("Tile 4").GetComponent<Tile>();
		tile5 = GameObject.Find("Tile 5").GetComponent<Tile>();
		tile6 = GameObject.Find("Tile 6").GetComponent<Tile>();
		tile7 = GameObject.Find("Tile 7").GetComponent<Tile>();
		tile8 = GameObject.Find("Tile 8").GetComponent<Tile>();
		tile9 = GameObject.Find("Tile 9").GetComponent<Tile>();
		tile10 = GameObject.Find("Tile 10").GetComponent<Tile>();
		tile11 = GameObject.Find("Tile 11").GetComponent<Tile>();
		tile12 = GameObject.Find("Tile 12").GetComponent<Tile>();
		tile13 = GameObject.Find("Tile 13").GetComponent<Tile>();
		tile14 = GameObject.Find("Tile 14").GetComponent<Tile>();
		tile15 = GameObject.Find("Tile 15").GetComponent<Tile>();
		tile16 = GameObject.Find("Tile 16").GetComponent<Tile>();

		Tiles[0] = tile1;
		Tiles[1] = tile2;
		Tiles[2] = tile3;
		Tiles[3] = tile4;
		Tiles[4] = tile5;
		Tiles[5] = tile6;
		Tiles[6] = tile7;
		Tiles[7] = tile8;
		Tiles[8] = tile9;
		Tiles[9] = tile10;
		Tiles[10] = tile11;
		Tiles[11] = tile12;
		Tiles[12] = tile13;
		Tiles[13] = tile14;
		Tiles[14] = tile15;
		Tiles[15] = tile16;


		GetlandBuyPannel = GameObject.Find("Landbuypannel");
		GetlandBuyPannel.SetActive(false);

		MainTile = tile1;             //임의로 MainTile =tile1넣음 없으면 에러뜸
	}



	void Update () 
	{


		for(int i = 0; i < 16; i++)
		{
			if( Tiles[i].landing == true )
			{
				Debug.Log ("landing" );


				MainTile = Tiles [i];

					Debug.Log ("MainTile:"+MainTile.name );


				GetlandBuyPannel.SetActive(true);

				Debug.Log ("MainTile~:"+MainTile.name );
				//Tiles [i].landing = false;
			
			}
		}

	
		if (MainTile.landBuy == true || MainTile.landDontBuy == true) 
		{
			Debug.Log ("landBuy");

			GetlandBuyPannel.SetActive (false);
			
			Debug.Log ("Tiles[i].landBuy" + MainTile.landBuy);
			Debug.Log ("Tiles[i].landDontBuy" + MainTile.landDontBuy);


		}
	

//		if (GetlandBuyPannel.activeSelf == false) 
//		{
//			for (int i = 0; i < 16; i++) 
//			{
//				Tiles [i].landBuy = false;
//				Tiles [i].landDontBuy = false;
//			}
//		}

	
	}
}
