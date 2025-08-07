using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

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

    private void InitBoss()
    {
        // 1. 获取地板的位置
        Vector3 groundPos = ground.transform.position;

        // 2. 获取地板的宽度（假设宽度是 x 轴方向）
        Renderer groundRenderer = ground.GetComponent<Renderer>();
        float groundWidth = groundRenderer.bounds.size.x;

        // 3. 计算左右两侧的位置（以地板中心为基准）
        // 这里偏移量可以根据需要调整，比如偏离地板边缘一点
        float offset = groundWidth / 2 - 2f; // 2f是额外距离

        Vector3 leftPos = new Vector3(groundPos.x - offset, groundPos.y, groundPos.z);
        Vector3 rightPos = new Vector3(groundPos.x + offset, groundPos.y, groundPos.z);

        // 4. 生成红色Boss在左边，蓝色Boss在右边
        var redBoss = Instantiate(redBossPrefab, leftPos, Quaternion.identity);
        var blueBoss = Instantiate(blueBossPrefab, rightPos, Quaternion.identity);
        // 5. 设置名字和阵营
        redBoss.name = "RedBoss";
        redBoss.GetComponent<Boss>().camp = Camp.RED;
        blueBoss.name = "BlueBoss";
        blueBoss.GetComponent<Boss>().camp = Camp.BLUE;
    }

    private void InitSoldiers()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-3f, 3f),  // x 方向随机偏移
                0f,                     // y 不偏移（保持在地面上）
                Random.Range(-3f, 3f)   // z 方向随机偏移
            );

            Vector3 spawnPos = Vector3.zero + randomOffset;
            Instantiate(blueSoldierPrefab, spawnPos, Quaternion.identity);    
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitBoss();
        InitSoldiers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}