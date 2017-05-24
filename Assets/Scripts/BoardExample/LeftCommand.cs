using UnityEngine;
using System.Collections;
using System;

public class LeftCommand : Command
{
    BoxBehaviour OldParent;
    GameObject NewParent;

    InputManager InputManagerScriptObject;

    int beforeX, beforeY;
    int afterX, afterY;

    GameObject Player;

    public LeftCommand(GameObject PlayerObject)
    {
        this.Player = PlayerObject;
        OldParent = Player.GetComponentInParent<BoxBehaviour>();
        Debug.Log(OldParent);
        InputManagerScriptObject = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        beforeX = OldParent.boxID.rowID;
        beforeY = OldParent.boxID.colID;
        afterX = beforeX;
        afterY = beforeY - 1;
        Debug.Log(beforeX + "," + beforeY + "," + afterX + "," + afterY);
    }

    public void Execute()
    {
        if(beforeY > 0)
        {
            NewParent = InputManagerScriptObject.row[afterX].coloumn[afterY];
            Debug.Log(NewParent);
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
