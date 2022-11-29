using UnityEngine;

public class ExpController : MonoBehaviour
{
    [SerializeField] private float exp = 10;
    private UIManager manager;
    PlayerProgression player;
    private void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        player = GameObject.Find("Player").GetComponent<PlayerProgression>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            player.currentExp += exp;
            manager.UpdateExp(player.currentExp, player.expToNextLvl);
            Destroy(gameObject);
        }
    }
}
