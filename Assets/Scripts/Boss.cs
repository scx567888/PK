using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private static int MAX_HP = 100;
    private int hp;

    void Awake()
    {
        hp = MAX_HP;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Boss 生成了");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
