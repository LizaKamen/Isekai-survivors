using System.Collections;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{
    [SerializeField] float viewRange;
    [SerializeField] float range;
    [SerializeField] private float attackWidth;
    [SerializeField] private float attackHeight;
    [SerializeField] private float damage;
    [SerializeField] private float attackDelay;
    [SerializeField] private LayerMask enemyLayers;
    bool switcher;
    int lvl;
    private Vector2 atk;
    private GameObject player;
    float sqrClosestDistance = Mathf.Infinity;
    [SerializeField] GameObject enemyToAttack;
    [SerializeField] private Collider2D[] enemiesHit;
    BoxCollider2D attack;
    [SerializeField] float angle;

    private void Start()
    {
        switcher = true;
        player = GameObject.Find("Player");
        atk = new Vector2(attackHeight, attackWidth);
        attack = gameObject.GetComponent<BoxCollider2D>();
        attack.size = atk;
        attack.offset = new Vector2 (0,2 + attackWidth / 2);
        StartCoroutine(DoAttack());
    }
    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(player.transform.position, viewRange, enemyLayers);
        foreach (var item in enemiesHit)
        {
            var dist = Vector2.Distance(player.transform.position, item.transform.position);
            if(dist < sqrClosestDistance)
            {
                sqrClosestDistance = dist;
                enemyToAttack = item.gameObject;
            }
        }
        if (enemyToAttack != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, (enemyToAttack.transform.position - transform.position));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Mathf.Infinity);
        }
    }
    IEnumerator DoAttack()
    {
        while (switcher)
        {
            attack.enabled = false;
            yield return new WaitForSeconds(attackDelay);
            attack.enabled = true;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            enemyToAttack = null;
            sqrClosestDistance = Mathf.Infinity;
        }
    }
}
