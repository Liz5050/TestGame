using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    // Use this for initialization
    private MainPlayer player;
	void Start () {
        player = gameObject.GetComponent("MainPlayer") as MainPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.CompareTag("Enemy"))
        {
            //player.IsDead = true;
            player.Hp++;
            Debug.Log("发生碰撞，移除目标，主角生命+1，当前生命值：" + player.Hp);
            Destroy(obj);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
