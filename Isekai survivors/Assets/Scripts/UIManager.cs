using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI winCond;
    [SerializeField] private TextMeshProUGUI level;
    float timer = 5f;
    [SerializeField] private TextMeshProUGUI exp;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject BGObj;
    float expc;
    private int kills;
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            winCond.gameObject.SetActive(false);
        }
    }
    public void UpdateScore()
    {
        kills++;
        score.text = $"Kills: {kills}";
    }
    public void UpdateLevel(int lvl)
    {
        level.text = $"Health: {lvl}";
    }
    public void UpdateExp(float cur, float req)
    {
        expc = cur;
        exp.text = $"Exp: {cur}/{req}";
    }
    public void Setup(bool win)
    {
        BGObj.SetActive(true);
        if (win)
        {
            text.text = $"YOU WIN!!! \n{kills} enemies killed";
            Time.timeScale = 0;
        }
        else
        {
            text.text = $"YOU LOSE!!! \n{kills} enemies killed, earned {expc} experiencce";
        }
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
