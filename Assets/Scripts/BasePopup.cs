using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    public virtual void Open()
    {
        if (!isActive())
        {
            this.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);
        }
        else
        {
            Debug.Log(this + ".Open() - trying to open a popup that is active!");
        }

    }

    public virtual void Close()
    {
        if (isActive())
        {
            this.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
        else
        {
            Debug.Log(this + ".Close() - trying to close a popup that is inactive!");
        }
    }

    public virtual bool isActive()
    {
        return gameObject.activeSelf;
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
