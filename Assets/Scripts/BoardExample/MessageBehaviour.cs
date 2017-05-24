using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class MessageBehaviour : MonoBehaviour
{
    private GameObject SelectedButton;
    private KeyCode selectedKeyCode;
    public GameObject ConfigurationWindow;

    public void ToggleVisibility()
    {
        SelectedButton = EventSystem.current.currentSelectedGameObject;
        gameObject.SetActive(!gameObject.activeSelf);
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                selectedKeyCode = KeyCode.LeftArrow;
                AssignKeyCodes();
                return;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedKeyCode = KeyCode.DownArrow;
                AssignKeyCodes();
                return;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedKeyCode = KeyCode.UpArrow;
                AssignKeyCodes();
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectedKeyCode = KeyCode.RightArrow;
                AssignKeyCodes();
                return;
            }

            string input = Input.inputString;
            selectedKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), input, true);
            AssignKeyCodes();
        }
    }

    private void AssignKeyCodes()
    {
        SelectedButton.GetComponent<ButtonBehaviour>().selectedButtonText.text = selectedKeyCode.ToString();
        SelectedButton.GetComponent<ButtonBehaviour>().SetState(true);

        switch (SelectedButton.GetComponent<ButtonBehaviour>().buttonType)
        {
            case ButtonType.Right:
                ButtonConfigurationManager.RightButtonKey = selectedKeyCode;
                break;
            case ButtonType.Left:
                ButtonConfigurationManager.LeftButtonKey = selectedKeyCode;
                break;
            case ButtonType.Up:
                ButtonConfigurationManager.UpButtonKey = selectedKeyCode;
                break;
            case ButtonType.Down:
                ButtonConfigurationManager.DownButtonKey = selectedKeyCode;
                break;
        }

        gameObject.SetActive(false);
    }
}
