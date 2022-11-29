using UnityEngine;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] GameObject pausebg;
    public static bool onfirstm;
    bool ondecondm;
    private void Start()
    {
        onfirstm = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true && !onfirstm )
        {
            Time.timeScale = 0;
            pausebg.SetActive(true);
            onfirstm=true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) == true && onfirstm)
        {
            Time.timeScale = 1;
            pausebg.SetActive(false);
            onfirstm = false;
        }
    }
}
