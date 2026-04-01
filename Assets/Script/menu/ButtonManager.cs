using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject settingsWindow;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
   
}
