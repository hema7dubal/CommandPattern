using UnityEngine;
using System.Collections;

public class RightCommand : Command
{
    GameObject OldParent;
    GameObject NewParent;

    InputManager InputManagerScriptObject;

    int beforeX, beforeY;
    int afterX, afterY;

    GameObject Player;

    public RightCommand(GameObject PlayerObject)
    {
        this.Player = PlayerObject;
        OldParent = PlayerObject.GetComponentInParent<BoxBehaviour>().gameObject;
        InputManagerScriptObject = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        beforeX = OldParent.GetComponent<BoxBehaviour>().boxID.rowID;
        beforeY = OldParent.GetComponent<BoxBehaviour>().boxID.colID;
        afterX = beforeX;
        afterY = beforeY + 1;
        Debug.Log(beforeX + " , " + beforeY + " , " + afterX + " , " + afterY);
    }

    public void Execute()
    {
        if (beforeY < 9)
        {
            NewParent = InputManagerScriptObject.row[afterX].coloumn[afterY];
            Player.transform.SetParent(NewParent.transform, false);
            Player.transform.localPosition = Vector3.zero;
        }
    }
    
    public void ReverseMove()
    {
        Player.transform.SetParent(OldParent.transform);
        Player.transform.localPosition = Vector3.zero;
    }
}
