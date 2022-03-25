using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private OptionsPopup optionsPopup;
   
    public void Open()
    {
        gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public bool isActive()
    {
        return gameObject.activeSelf;
    }

    public void OnOkButton()
    {
        Close();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        optionsPopup.Open();
        
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopup.Open();
        
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " + ((int)difficulty).ToString();
    }

    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
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
