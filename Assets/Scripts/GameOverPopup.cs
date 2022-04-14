using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : BasePopup
{

    public void OnExitGameButton()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }

    public void OnStartAgainButton()
    {
        Close();
        Messenger.Broadcast(GameEvent.RESTART_GAME);
    }

}
