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

    public Boss(Camp camp)
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
    }
}