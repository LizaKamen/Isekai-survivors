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
    }
    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        Debug.Log(currentHP);
        if (currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        manager.Setup();
        Destroy(gameObject);
    }
}
