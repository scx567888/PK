using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private static int MAX_HP = 100;
    private int hp;
    public Camp camp;

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
    
    public void TakeDamage(int amount)
    {
        hp -= amount;
        Debug.Log($"Boss took {amount} damage, current HP: {hp}");

        if (hp <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Boss died!");
        Destroy(gameObject);
    }
    
    void OnMouseDown()
    {
        // 点击时扣10点血
        TakeDamage(10);
    }
    
}
