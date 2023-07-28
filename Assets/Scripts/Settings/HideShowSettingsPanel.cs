using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowSettingsPanel : MonoBehaviour
{
    [SerializeField] public GameObject _settingsPanel;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)))
        {
            gameObject.SetActive(false);
        }
    }
    public void showSettings()
    {
        _settingsPanel.SetActive(true);
    }
    public void goBack()
    {
        _settingsPanel.SetActive(false);
    }
}

