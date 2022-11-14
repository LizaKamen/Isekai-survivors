using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI level;
    [SerializeField]
    private TextMeshProUGUI exp;
    private int kills;
    public void UpdateScore()
    {
        kills++;
        score.text = $"Kills: {kills}";
    }
    public void UpdateLevel(int lvl)
    {
        level.text += lvl;
    }
    public void UpdateExp(float cur, float req)
    {
        exp.text = $"Exp: {cur}/{req}";
    }
}
