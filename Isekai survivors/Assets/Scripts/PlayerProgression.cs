using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField]
    private int lvl = 1;
    [SerializeField]
    public float expToNextLvl = 1000;
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
            LvlUp();
        }
        
    }
    void LvlUp()
    {
        lvl++;
        currentExp = 0;
        manager.UpdateLevel(lvl);
    }
}
