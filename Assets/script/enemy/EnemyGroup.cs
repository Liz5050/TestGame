using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {

    // Use this for initialization
    private GameObject prefab;
    private List<GameObject> enemys;
    private MainPlayer player;

    public float speed = 20;
    public float endPosZ = -90;
    public int m_count;
    private Vector3 pos;

    private bool isInit;
    void Start() {

        player = GameObject.Find("Player").GetComponent("MainPlayer") as MainPlayer;
        pos = new Vector3(0, 0, 100);
        UpdatePosition();
    }

    public GameObject EnemyPrefab
    {
        get
        {
            return prefab;
        }
        set
        {
            prefab = value;
            InitEnemy();
        }
    }

    void InitEnemy()
    {
        enemys = new List<GameObject>();
        m_count = Mathf.FloorToInt(Random.Range(1, 4));
        //Debug.Log("随机创建数量：" + count);
        for (int i = 0; i < m_count; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab,gameObject.transform);
            float randomX = Random.Range(-20, 20);
            enemy.transform.position = new Vector3(randomX, 0, 0);

        }
        isInit = true;
    }

    void UpdatePosition()
    {
        if (!isInit || player.IsDead) return;

        pos.z -= speed * Time.deltaTime;
        this.transform.position = pos;
        if (endPosZ > pos.z)
        {
            int childCount = gameObject.transform.childCount;
            player.Hp -= childCount;

            Debug.Log("移动到终点,敌人数量" + m_count + ",主角生命值-" + childCount + "，当前生命值：" + player.Hp);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        UpdatePosition();
    }
}
