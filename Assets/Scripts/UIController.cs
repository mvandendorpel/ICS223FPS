using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    //private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopup settingsPopup;
    private int popupsOpen = 0;


    public void UpdateScore(int newScore)
    {
        scoreValue.text = newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if(active)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            crossHair.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
        }
        else
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crossHair.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore(0);
        UpdateHealth(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && popupsOpen == 0)
        {
            //SetGameActive(false);
            optionsPopup.Open();
        }
    }

    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, this.OnHealthChanged);
        Messenger.AddListener(GameEvent.POPUP_CLOSED, this.OnPopupClosed);
        Messenger.AddListener(GameEvent.POPUP_OPENED, this.OnPopupOpened);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.HEALTH_CHANGED, this.OnHealthChanged);
        Messenger.RemoveListener(GameEvent.POPUP_CLOSED, this.OnPopupClosed);
        Messenger.RemoveListener(GameEvent.POPUP_OPENED, this.OnPopupOpened);
    }

    private void OnHealthChanged(float newHealth)
    {
        UpdateHealth(newHealth);
    }

    private void UpdateHealth(float newHealth)
    {
        Debug.Log((float)newHealth);
        healthBar.fillAmount = newHealth;
        healthBar.color = Color.Lerp(Color.red, Color.green, newHealth);
    }

    private void OnPopupOpened()
    {
        if (popupsOpen == 0)
        {
            SetGameActive(false);
        }
        popupsOpen++;
    }

    private void OnPopupClosed()
    {
        popupsOpen--;
        if (popupsOpen == 0)
        {
            SetGameActive(true);
        }
    }
}
