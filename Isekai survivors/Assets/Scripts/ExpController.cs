using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    [SerializeField]
    private float exp = 10;
    private UIManager manager;
    private void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerProgression>();
        player.currentExp += exp;
        manager.UpdateExp(player.currentExp, player.expToNextLvl);
        Destroy(gameObject);
    }
}
