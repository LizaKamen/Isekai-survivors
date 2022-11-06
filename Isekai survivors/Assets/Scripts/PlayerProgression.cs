using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [SerializeField]
    private int lvl = 1;
    [SerializeField]
    private float expToNextLvl = 1000;
    public float currentExp;

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
    }
}
