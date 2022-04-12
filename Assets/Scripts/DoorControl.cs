using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private bool doorIsOpen = false;
    private Vector3 homePos;
    private Vector3 closeOffset = new Vector3(0, 0, -15);
    private float moveTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        homePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        if (doorIsOpen)
        {
            iTween.MoveTo(this.gameObject, homePos, moveTime);
        }
        else
        {
            iTween.MoveTo(this.gameObject, homePos + closeOffset, moveTime);
        }
        doorIsOpen = !doorIsOpen;
    }
}
