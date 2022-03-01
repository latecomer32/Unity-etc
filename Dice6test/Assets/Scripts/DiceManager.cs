using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

	void Start() {
		DicebD1 = GameObject.Find("BlueDice1").GetComponent<Dice>();
		DicebD2 = GameObject.Find("BlueDice2").GetComponent<Dice>();
		DicerD1 = GameObject.Find("RedDice1").GetComponent<Dice>();

		run = false;
	}

	Dice DicebD1;
	Dice DicebD2;
	Dice DicerD1;
	public bool bDisPlay = false;
	public bool rDisPlay = false;
	public bool run;
	public bool run1;
	public bool run2;
	public int bluesum;
	public int Redsum;


	void Update()
	{
		if (DicebD1.isRolling == true && DicebD2.isRolling == true && DicerD1.isRolling == true) 
		{
			
			DicebD1.isRolling = false;
			DicebD2.isRolling = false;
			DicerD1.isRolling = false;
	
			bluesum = DicebD1.diceValue + DicebD2.diceValue;
			Redsum = DicerD1.diceValue;

				bDisPlay = true;
				rDisPlay = true;

				run = true;


		}
	}
}

