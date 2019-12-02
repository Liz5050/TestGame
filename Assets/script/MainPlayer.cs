using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour {

    public Rigidbody rb;
    public float speed = 1000f;
    public float speedX = 600;
    private bool isDead = false;
    private int hp = 50;
    public static int MaxHP = 20;
    // Use this for initialization
    private Text Txt_PlayerHp;
    void Awake()
    {
        EventManager.Add2(EventEnum.TEST1, OnTestHandler);
        GameObject gameUITxt = GameObject.Find("GameUI/Txt_PlayerHp");
        Debug.Log(gameUITxt);
        Txt_PlayerHp = gameUITxt.GetComponent<Text>();
        Txt_PlayerHp.text = "HP:" + MaxHP;
    }

    private void OnTestHandler()
    {
        Debug.Log("MainPlayer触发事件");
    }
    void Start () {
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
            if (isDead) EventManager.DispatchEvent(EventEnum.GameOver);
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (hp > MainPlayer.MaxHP)
            {
                hp = MainPlayer.MaxHP;
                return;
            }
            if (hp <= 0)
            {
                hp = 0;
                IsDead = true;
                Debug.Log("主角死亡，游戏结束");
            }
            Txt_PlayerHp.text = "HP:" + hp;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (IsDead) return;
        //rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 600 * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -600 * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(speedX * Time.deltaTime, 0, 0);
        }
        
    }
}
