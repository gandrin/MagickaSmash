using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayScript : MonoBehaviour {
	// Use this for initialization
	private Text me;
	private GameObject[] players;


	void Start () {
		this.me = this.GetComponent<Text>();
		players = GameObject.FindGameObjectsWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		this.me.text = "";
		foreach(GameObject player in players){
		int life =	player.GetComponent<HealthScript>().hp;
		this.me.text += player.name + " : " + life +"\n";
		}
	}
}
