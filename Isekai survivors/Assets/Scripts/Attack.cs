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
    private BoxCollider2D collider2D;
    private void Start()
    {
        collider2D.enabled = false;
        collider2D = gameObject.GetComponent<BoxCollider2D>();
        collider2D.size = new Vector2(attackWidth, attackHeight);
        StartCoroutine(DoAttack());
    }
    IEnumerator DoAttack()
    {
        while (true)
        {
            collider2D.enabled = true;
            Debug.Log(collider2D.enabled.ToString());
            yield return new WaitForEndOfFrame();
            collider2D.enabled = false;
            Debug.Log(collider2D.enabled.ToString());
            yield return new WaitForSeconds(attackDelay);
        }
    }
    private void OnTriggerEnter2D()
    {
        Debug.Log("hit!");
    }
}
