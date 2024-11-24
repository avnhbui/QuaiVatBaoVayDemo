using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopUI, SettingUI;
    public ItemInfoDisplay itemInfoDisplay;
    void Start()
    {
        string gunnamaa = PlayerPrefs.GetString("GunName");
        Debug.Log(gunnamaa);
    }
   
    public void ChangeScene()
    {
        SceneManager.LoadScene("PlayGame");
        Time.timeScale = 1.0f;
    }
    public void GoToSceneLobby()
    {
        SceneManager.LoadScene("Lobby");
        Time.timeScale = 1.0f;
    }
    public void Resume()
    {
        SettingUI.SetActive(false);
        Time.timeScale = 1.0f;

    }
    public void Setting()
    {
        SettingUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void GoToTrangChu()
    {
        SceneManager.LoadScene("Welcome");
        Time.timeScale = 1.0f;
    }
    public void OpenShop()
    {
        shopUI.SetActive(true);
    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
}
