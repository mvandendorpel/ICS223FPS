using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // enum to set values by name instead of number. 
    // makes code more readable! 
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHoriz = 9.0f;
    public float sensitivityVert = 9.0f;
    public float minVert = -45.0f;
    public float maxVert = 45.0f;
    private bool isActive = true;

    private float rotationX = 0.0f;
    void Update()
    {

        if (isActive)
        {

            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivityHoriz);

            }
            else if (axes == RotationAxes.MouseY)
            {
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
                transform.localEulerAngles = new Vector3(rotationX, 0, 0);

            }
            else
            {
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
                float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
                float rotationY = transform.localEulerAngles.y + deltaHoriz;



                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }
        }
        
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnChangeGameState);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnChangeGameState);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnChangeGameState);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnChangeGameState);
    }

    private void OnChangeGameState()
    {
        isActive = !isActive;
    }


}
