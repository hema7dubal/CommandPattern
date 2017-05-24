using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum ButtonType
{
    Right,
    Left,
    Up,
    Down
}

public class ButtonConfigurationWindowBehaviour : MonoBehaviour
{
    public GameObject ExitButton;
    public ButtonBehaviour RightButton, LeftButton, UpButton, DownButton;

    void Start()
    {
        StartCoroutine(MyUpdate());
    }

    public void ToggleVisibilityOfExitButton()
    {
        ExitButton.SetActive(!ExitButton.activeSelf);
    }

    public void ToggleOwnVisibility()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    IEnumerator MyUpdate()
    {

        while (true)
        {
            if (RightButton.GetState() && LeftButton.GetState() && UpButton.GetState() && DownButton.GetState())
            {
                ToggleVisibilityOfExitButton();
                StopAllCoroutines();
            }
            yield return new WaitForEndOfFrame(); 
        }
    }
}
