using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

    public GameObject EnemyPrefab;
    private List<GameObject> groupEnemys;

    private MainPlayer player;
    private GameObject GameOverSp;
    private Button BtnObj;
    void Awake()
    {
        Debug.Log("Awake");
        EventManager.Add2(EventEnum.GameOver, OnGameOver);
        EventManager.Add2(EventEnum.RemoveEnemyGroup, OnGameOver);
        EventManager.Add2(EventEnum.TEST1, OnTestHandler);
        GameOverSp = GameObject.Find("GameOverSp");
        GameOverSp.SetActive(false);

        BtnObj = GameOverSp.GetComponentInChildren<Button>();
        Debug.Log(BtnObj);
        BtnObj.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        GameOverSp.SetActive(false);
        for(int i = 0; i < groupEnemys.Count; i++)
        {
            DestroyEnemyGroups(groupEnemys[i]);
        }
        Debug.Log("重新开始游戏");
        player.IsDead = false;
        player.Hp = MainPlayer.MaxHP;
        InvokeRepeating("CreateEnemyGroup", 1, 2);
    }

    void Start () {
        Debug.Log("Start");
        groupEnemys = new List<GameObject>();
        InvokeRepeating("CreateEnemyGroup", 1, 2);
        player = GameObject.Find("Player").GetComponent("MainPlayer") as MainPlayer;
        //EventManager.DispatchEvent(EventEnum.TEST1);
    }

    private void OnGameOver()
    {
        Debug.Log("GameOver!!");
        GameOverSp.SetActive(true);
        CancelInvoke();
    }

    public void OnTestHandler()
    {
        Debug.Log("触发事件");
        Invoke("Remove", 3);
    }

    public void Remove()
    {
        Debug.Log("移除事件");
        EventManager.Remove(EventEnum.TEST1, OnTestHandler);
    }

    private void CreateEnemyGroup()
    {
        if (player.IsDead)
        {
            return;
        }
        GameObject group = new GameObject("EnemyGroup");
        group.tag = "EnemyGroup";
        //group.AddComponent<BoxCollider>();
        //group.AddComponent<Rigidbody>();
        EnemyGroup groupCls = group.AddComponent<EnemyGroup>();
        groupCls.EnemyPrefab = EnemyPrefab;

        groupEnemys.Add(group);

        //Instantiate(EnemyPrefab);
    }

    private void DestroyEnemyGroups(GameObject group)
    {
        if(groupEnemys.Contains(group)) groupEnemys.Remove(group);
        if(group.gameObject) Destroy(group.gameObject);
        
    }

    void FixedUpdate () {
        
	}
}
