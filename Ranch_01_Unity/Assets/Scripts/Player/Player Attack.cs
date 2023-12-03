using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
    public float attackRange = 1.0f;
    public LayerMask enemyLayer;
    public int attackDamage = 1;

    void Update()
    {
        if (Input.GetButtonDown("e")) // You can use the appropriate input method for attacking
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            DefaultEnemyAI enemyAI = enemy.GetComponent<DefaultEnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(attackDamage);
            }
        }
    }
}
