using Unity.VisualScripting;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField] private int lvl = 1;
    [SerializeField] public float expToNextLvl = 100;
    public float currentExp;
    private UIManager manager;

    private void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        manager.UpdateLevel(lvl);
        manager.UpdateExp(currentExp, expToNextLvl);
    }
    private void Update()
    {
        if (currentExp >= expToNextLvl)
        {
            manager.Setup(true);
        }
    }
}
