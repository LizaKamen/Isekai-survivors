using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private float attackDelay;
    [SerializeField]
    private float attackWidth;
    [SerializeField]
    private float attackHeight;
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private Vector2 atkOffset;
    [SerializeField]
    private LayerMask enemyLayers;
    private Collider2D[] enemiesHit;
    private void Start()
    {
        playerPos = gameObject.GetComponent<Transform>();
        StartCoroutine(DoAttack());
    }
    IEnumerator DoAttack()
    {
        while (true)
        {
            Debug.Log("yy");
            var pointA = new Vector2(playerPos.position.x, playerPos.position.y) + atkOffset;
            var pointB = pointA + new Vector2(attackWidth, attackHeight);
            enemiesHit = Physics2D.OverlapAreaAll(pointA,pointB,enemyLayers);
            Debug.Log($"{pointA},{pointB}");
            foreach (var item in enemiesHit)
            {
                Debug.Log("hit!");
                item.GetComponent<EnemyController>().TakeDamage(damage);
            }
            yield return new WaitForSeconds(attackDelay);
        }
    }
    private void OnDrawGizmosSelected()
    {
        var pointA = new Vector2(playerPos.position.x, playerPos.position.y) + 2 * atkOffset;

        Gizmos.DrawCube(pointA, new Vector2(attackWidth, attackHeight));
    }
}
