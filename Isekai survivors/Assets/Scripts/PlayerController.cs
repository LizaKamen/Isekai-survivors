using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private UIManager manager;
    [SerializeField] private float currentHP;

    private void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        currentHP = maxHP;
        manager.UpdateLevel((int)currentHP);
    }
    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        manager.UpdateLevel((int)currentHP);
        if (currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        manager.Setup(false);
        Destroy(gameObject);
    }
}
