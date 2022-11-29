using System.Collections;
using UnityEngine;

public class CircleAttack : MonoBehaviour
{
    [SerializeField] bool switcher;
    [SerializeField] int lvl;
    [SerializeField] private float damage;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDelay;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Transform playerPos;
    private Collider2D[] enemiesHit;
    void Start()
    {
        switcher = true;
        StartCoroutine(DoAttack());
    }
    private IEnumerator DoAttack()
    {
        while (switcher)
        {
            enemiesHit = Physics2D.OverlapCircleAll(playerPos.position, attackRadius, enemyLayers);
            foreach (var item in enemiesHit)
            {
                item.GetComponent<EnemyController>().TakeDamage(damage);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(playerPos.position, attackRadius);
    }
}
