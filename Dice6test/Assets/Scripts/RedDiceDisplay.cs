using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RedDiceDisplay : MonoBehaviour {

	void Start () {

		RS1 = GameObject.Find("DiceManager").GetComponent<DiceManager>();
	}

	DiceManager RS1;

	void Update () {

		GetComponent<Text>().text = "BD Total : " + RS1.Redsum;
	}
}
