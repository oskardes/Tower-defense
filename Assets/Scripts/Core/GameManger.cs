using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject chooseOption;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject endStatistic;

    public void StartGame()
    {
        mainMenu.SetActive(false);
        chooseOption.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit game!");
    }

    public void MuteSound()
    {

    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene("PrototypeScene");
    }

    public void ReturnToMenu()
    {
        chooseOption.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ReturnToMenuFromSettings()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ReturnToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TurnPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ReturnGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;   
    }

    public void ReturnToMenuAfterWinGame()
    {
        endStatistic.SetActive(false);
        credits.SetActive(true);
        Invoke("ReturnToMenuScene", 10f);
    }
}
