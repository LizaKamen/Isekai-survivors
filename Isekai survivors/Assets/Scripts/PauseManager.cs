using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1;
        MenuOpener.onfirstm = false;
        gameObject.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
