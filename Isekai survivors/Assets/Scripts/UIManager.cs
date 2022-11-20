using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private TextMeshProUGUI exp;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject BGObj;
    int lvl; 
    private int kills;
    public void UpdateScore()
    {
        kills++;
        score.text = $"Kills: {kills}";
    }
    public void UpdateLevel(int lvl)
    {
        level.text += lvl;
        this.lvl = lvl;
    }
    public void UpdateExp(float cur, float req)
    {
        exp.text = $"Exp: {cur}/{req}";
    }
    public void Setup()
    {
        BGObj.SetActive(true);
        text.text = $"{kills} enemies killed, reached {lvl} level";
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
