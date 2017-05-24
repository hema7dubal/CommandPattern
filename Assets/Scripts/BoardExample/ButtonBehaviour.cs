using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public ButtonType buttonType;
    public Text selectedButtonText;
    private bool isAssigned = false;

    public void SetState(bool value)
    {
        isAssigned = value;
    }

    public bool GetState()
    {
        return isAssigned;
    }
}
