using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    
    private static int MAX_HP = 100;
    private int hp;

    public float speed = 3f;
    public float attackRange = 1.5f;
    public float attackInterval = 1.0f;
    public int attackDamage = 10;

    private Transform bossTransform;
    private Boss boss; // 引用 Boss 的脚本
    private float attackTimer = 0f;

    void Awake()
    {
        hp = MAX_HP;
    }

    void Start()
    {
        GameObject bossObj = GameObject.Find("RedBoss"); // 或 BlueBoss
        if (bossObj != null)
        {
            bossTransform = bossObj.transform;
            boss = bossObj.GetComponent<Boss>();
        }
    }

    void Update()
    {
        if (bossTransform == null) return;

        float distance = Vector3.Distance(transform.position, bossTransform.position);

        if (distance > attackRange)
        {
            // 继续移动靠近Boss
            Vector3 dir = (bossTransform.position - transform.position).normalized;
            transform.position += dir * (speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(dir);
        }
        else
        {
            // 在攻击范围内，计时攻击
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackInterval)
            {
                attackTimer = 0f;
                Attack();
            }
        }
    }

    void Attack()
    {
        Debug.Log("123123");
        if (boss != null)
        {
            boss.TakeDamage(attackDamage);
            Debug.Log($"{gameObject.name} attacked {boss.gameObject.name}");
        }
    }
    
}
