using System.Collections;
using UnityEngine;

public class RectAttack : MonoBehaviour
{
    [SerializeField] bool switcher;
    [SerializeField] int lvl;
    [SerializeField] private float attackWidth;
    [SerializeField] private float attackHeight;
    [SerializeField] private Vector2 atkOffset;
    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask enemyLayers;
    private Collider2D[] enemiesHit;
    private Transform playerPos;
    private PlayerMovement pMov;

    private void Start()
    {
        switcher = true;
        playerPos = player.GetComponent<Transform>();
        pMov = player.GetComponent<PlayerMovement>();
        StartCoroutine(DoAttack());
        StartCoroutine(AttackAnim());
    }
    IEnumerator DoAttack()
    {
        Vector2 pointA;
        Vector2 pointB;
        while (switcher)
        {
            if (pMov.facingRight == false)
            {
                pointA = new Vector2(playerPos.position.x - atkOffset.x, playerPos.position.y + atkOffset.y);
                pointB = pointA + new Vector2(- attackWidth, attackHeight);
            }
            else
            {
                pointA = new Vector2(playerPos.position.x, playerPos.position.y) + atkOffset;
                pointB = pointA + new Vector2(attackWidth, attackHeight);
            }
            enemiesHit = Physics2D.OverlapAreaAll(pointA, pointB, enemyLayers);
            foreach (var item in enemiesHit)
            {
                item.GetComponent<EnemyController>().TakeDamage(damage);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
    IEnumerator AttackAnim()
    {
        while (switcher)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(attackDelay - 0.05f);
        }

    }

}
