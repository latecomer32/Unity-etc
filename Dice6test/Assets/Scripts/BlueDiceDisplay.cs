using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueDiceDisplay : MonoBehaviour {

	void Start () {

		BS1 = GameObject.Find("DiceManager").GetComponent<DiceManager>();
	}

	DiceManager BS1;

	void Update () {

		GetComponent<Text>().text = "BD Total : " + BS1.bluesum;
	}
}
