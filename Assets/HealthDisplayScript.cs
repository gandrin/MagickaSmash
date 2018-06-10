using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayScript : MonoBehaviour {
	// Use this for initialization
	private Text me;

	void Start () {
		this.me = this.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		this.me.text = "";
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

		foreach(GameObject player in players){
			int life =	player.GetComponent<HealthScript>().hp;
			this.me.text += player.name + " : " + life +"\n";
		}
	}
}
