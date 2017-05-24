using UnityEngine;
using System.Collections;

public class DownCommand : Command
{
    BoxBehaviour OldParent;
    GameObject NewParent;

    InputManager InputManagerScriptObject;

    int beforeX, beforeY;
    int afterX, afterY;

    GameObject Player;

    public DownCommand(GameObject PlayerObject)
    {
        this.Player = PlayerObject;
        OldParent = Player.GetComponentInParent<BoxBehaviour>();
        InputManagerScriptObject = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        beforeX = OldParent.boxID.rowID;
        beforeY = OldParent.boxID.colID;
        afterX = beforeX + 1;
        afterY = beforeY;
    }

    public void Execute()
    {
        if (beforeX < 9)
        {
            NewParent = InputManagerScriptObject.row[afterX].coloumn[afterY];
            Player.transform.SetParent(NewParent.transform);
            Player.transform.localPosition = Vector3.zero;
        }
    }

    public void ReverseMove()
    {
        Player.transform.SetParent(OldParent.transform);
        Player.transform.localPosition = Vector3.zero;
    }
}
