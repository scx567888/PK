using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private GameObject ground;
    private GameObject redBossPrefab;
    private GameObject redSoldierPrefab;
    private GameObject blueBossPrefab;
    private GameObject blueSoldierPrefab;

    void Awake()
    {
        // 初始化 4个预制体
        redBossPrefab = Resources.Load<GameObject>("Prefabs/RedBoss");
        redSoldierPrefab = Resources.Load<GameObject>("Prefabs/RedSoldier");
        blueBossPrefab = Resources.Load<GameObject>("Prefabs/BlueBoss");
        blueSoldierPrefab = Resources.Load<GameObject>("Prefabs/BlueSoldier");
        // 获取地板
        ground = GameObject.Find("Ground");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(ground.transform.position);
        Instantiate(redBossPrefab);
    }

    // Update is called once per frame
    void Update()
    {

    }

}