using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject expPoint;
    [SerializeField] private UIManager manager;
    private float currentHP;
    void Start()
    {
        currentHP = maxHP;
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("Player");
    }
    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        var thisPos = new Vector3(transform.position.x, transform.position.y);
        Destroy(gameObject);
        manager.UpdateScore();
        Instantiate(expPoint, thisPos, Quaternion.identity);
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
