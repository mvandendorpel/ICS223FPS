using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsPopup : BasePopup
{
    [SerializeField] SettingsPopup settingsPopup;
    public override void Open()
    {
        //gameObject.SetActive(true);
        base.Open();
    }

    public override void Close()
    {
        //gameObject.SetActive(false);
        base.Close();
    }

    public override bool isActive()
    {
        //return gameObject.activeSelf;
        return base.isActive();
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
        //controller.SetGameActive(true);
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
