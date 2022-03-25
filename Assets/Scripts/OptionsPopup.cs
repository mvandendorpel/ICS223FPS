using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsPopup : MonoBehaviour
{
    [SerializeField] UIController controller;
    [SerializeField] SettingsPopup settingsPopup;
    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public bool isActive()
    {
        return gameObject.activeSelf;
    }

    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        Close();
        settingsPopup.Open();
    }

    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }

    public void OnReturnToGameButton()
    {
        Debug.Log("Return to game");
        Close();
        controller.SetGameActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
