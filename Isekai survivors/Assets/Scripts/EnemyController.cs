using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    private float currentHP;
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject expPoint;
    [SerializeField]
    private UIManager manager;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

}
