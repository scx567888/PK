using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Enums;
using UnityEngine;

public class Soldier
{
    private static int MAX_HP = 100;


    public SoldierState state;
    private int hp;

    public float speed = 3f;
    public float attackRange = 1.5f;
    public float attackInterval = 1.0f;
    public int attackDamage = 10;

    public Camp camp;

    private readonly GameObject view;
    private readonly Game game;
    private Boss targetBoss;

    public Soldier(Camp camp, Game game)
    {
        this.camp = camp;
        this.game = game;
        this.hp = MAX_HP;
        this.state = SoldierState.MOVING_TO_BOSS;
        if (camp == Camp.BLUE)
        {
            this.view = ViewFactory.getBlueSoldier();
        }
        else
        {
            this.view = ViewFactory.getRedSoldier();
        }
        this.view.transform.position = Utils.getSoilderInitPosition(game.ground, camp);
    }

    public void Update()
    {
        if (this.state == SoldierState.MOVING_TO_BOSS)
        {
            movingToBoss();
        }
    }

    // 向 敌方 Boss 移动
    private void movingToBoss()
    {
        if (targetBoss == null)
        {
            targetBoss = findTargetBoss();
        }

        if (targetBoss == null || targetBoss.isDead)
        {
            this.state = SoldierState.WAITING;
            return;
        }
        
        // 移动?
        
        // 目标位置
        Vector3 targetPos = targetBoss.view.transform.position; // 假设Boss类有个Position属性

        // 当前位置
        Vector3 currentPos = view.transform.position;

        // 计算与目标距离
        float distance = Vector3.Distance(currentPos, targetPos);

        if (distance <= attackRange)
        {
            state = SoldierState.ATTACKING;
            Attack();
        }
        else
        {
            // 移动方向
            Vector3 dir = (targetPos - currentPos).normalized;
            // 移动距离 = 速度 * 时间间隔
            float moveDist = speed * Time.deltaTime;
            view.transform.position += dir * moveDist;
        }
        
    }

    void Attack()
    {
        
    }


    public Boss findTargetBoss()
    {
        var bossList = camp == Camp.RED ? game.blueBossList : game.redBossList;
        return Utils.RandomGet(bossList);
    }
    
}