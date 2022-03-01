using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	
	public bool Ready;
	public bool Ready1;
	public bool Ready2;
	public bool isoveraped;

	public bool GameOver = false;

	public DiceManager  DMBD1;

	Tile startingTile;
	Tile currentTile;

	Tile finalTile;


	PlayerMover player1;
	PlayerMover player2;

	void Start()
	{

		player1 = GameObject.Find("Player1").GetComponent<PlayerMover> ();
		player2 = GameObject.Find("Player2").GetComponent<PlayerMover> ();

		 DMBD1 = GameObject.Find("DiceManager").GetComponent<DiceManager>();

		Ready = false;

	}
		










	void Update()
	{
				StartCoroutine ("Play");
	}

	IEnumerator Play()
	{

		isoveraped = false;

		DMBD1.run1 = true;
		DMBD1.run2 = true;

		if (Ready == false) 
		{
			
			if (Input.GetMouseButtonUp (0)) 
			{

				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) 
				{

					if (this.transform.position != new Vector3 (hit.transform.position.x, 5, hit.transform.position.z)) 
					{
						this.GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f, 0.3f);
						this.transform.position = new Vector3 (hit.transform.position.x, 5, hit.transform.position.z);
					}
				
					else if (this.transform.position == new Vector3 (hit.transform.position.x, 5, hit.transform.position.z)) 
					{
						this.GetComponent<Renderer> ().material.color = new Color (1f, 1f, 1f, 1f);
						startingTile = hit.collider.GetComponent<Tile> ();
					
						Ready = true;

						Ready1 = true;
						Ready2 = true;
					}

				}
			}
		}
			

		else if ( DMBD1.run == true)
        {
			int spacesToMove = DMBD1.bluesum;

			DMBD1.run = false;
		
			finalTile = currentTile;

			for (int i = 0; i < spacesToMove; i++) 
			{
				if (finalTile == null) 
				{
					finalTile = startingTile.NextTiles [0];
				} 
				else 
				{
					finalTile = finalTile.NextTiles [0];
				}
			
			
				yield return new WaitForSeconds(0.5f);

				this.transform.position = finalTile.transform.position;

			}
			currentTile = finalTile;


			DMBD1.run1 = false;
			DMBD1.run2 = false;
        }
    }
}




//18.12.02 충돌감지 포기
//void OnTriggerStay(Collider col)
//{
//	if (col.tag == "Tile") 
//	{
//		isoveraped = true;
//	}
//}