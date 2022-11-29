using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject expPoint;
    [SerializeField] private UIManager manager;
    private float currentHP; 
    private Vector3 scale;
    bool facingRight = true;
    
    void Start()
    {
        currentHP = maxHP;
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("Player");
        scale = transform.localScale;
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
        if (player != null)
        {
            if (player.transform.position.x < transform.position.x && facingRight)
            {
                Flip();
                facingRight = false;
            }
            else if (player.transform.position.x > transform.position.x && !facingRight)
            {
                Flip();
                facingRight = true;
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
