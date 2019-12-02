using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform playerTf;
    public Vector3 offset;
	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        if(player)
        {
            this.playerTf = player.transform;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position = this.playerTf.position + offset;
    }
}
