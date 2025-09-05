using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Enums;
using UnityEngine;

public class Soldier
{
    // 空间信息
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    // 基本信息
    public long id;
    public Camp camp;
    public SoldierType soldierType;

    // 血量
    public int hp;

    // 攻击力
    public int attackPower;

    //移动速度
    public float speed;

    // 攻击范围
    public float attackRange;

    // 世界对象
    public readonly Game game;

    // 状态机相关
    public SoldierState state;

    // 当前帧
    public int currentFrame;

    public Boss targetBoss;

    public Soldier(long id, Camp camp, SoldierType soldierType, Game game)
    {
        // 设置基本信息
        this.id = id;
        this.camp = camp;
        this.soldierType = soldierType;
        this.game = game;

        // 这里应该根据 soldierType 读取
        this.hp = 1000;
        this.attackPower = 1000;
        this.speed = 3f;
        this.attackRange = 1.5f;

        // 设置空间信息
        
        this.position = Utils.getSoilderInitPosition(game.ground, camp);
        
        this.rotation = Quaternion.identity;
        this.scale = new Vector3(0.2f,0.2f,0.2f);

        // 默认状态
        this.state = SoldierState.MOVING_TO_BOSS;

        // 默认第一帧
        this.currentFrame = 0;
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
        Vector3 currentPos = this.position;

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
            this.position += dir * moveDist;
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

    public Matrix4x4 GetMatrix()
    {
        return Matrix4x4.TRS(this.position, this.rotation, this.scale);
    }
    
}