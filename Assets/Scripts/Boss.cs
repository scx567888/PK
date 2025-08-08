using DefaultNamespace;
using Enums;
using UnityEngine;

public class Boss
{
    // 最大 HP
    private static int MAX_HP = 100;

    // 当前 HP
    public int hp;

    // 所属阵营
    public Camp camp;

    public GameObject view;
    public bool isDead;

    public Boss(Camp camp,Game game)
    {
        this.camp = camp;
        this.hp = MAX_HP;
        if (camp == Camp.BLUE)
        {
            this.view = ViewFactory.getBlueBoss();
        }
        else
        {
            this.view = ViewFactory.getRedBoss();
        }

        this.view.transform.position = Utils.getBossInitPosition(game.ground,camp);
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
        if (camp == Camp.BLUE)
        {
            ViewFactory.destroyBlueBoss(view);
        }
        else
        {
            ViewFactory.destroyRedBoss(view);
        }
        this.isDead = true;
    }

    public void Update()
    {
        // Boss 目前没有可调用的方法
    }
    
    
}