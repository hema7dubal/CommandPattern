using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using System;

public struct BoxID
{
    public int rowID, colID;
};

public class InputManager : MonoBehaviour
{
    public GameObject CurrentObject;
    public GameObject Player;
    Command currentCommand;
    List<Command> StackOfMoves;
    List<Command> UndoList;

    public void Start()
    {
        StackOfMoves = new List<Command>();
        UndoList = new List<Command>();
    }

    [System.Serializable]
    public class BoardTiles
    {
        public GameObject[] coloumn;
    }

    public BoardTiles[] row;

    public void MoveCommand()
    {
        StackOfMoves.Add(currentCommand);
        StackOfMoves[StackOfMoves.Count - 1].Execute();
        UndoList.Clear();
        print("StackOfMoves " + StackOfMoves.Count + "UndoList " + UndoList.Count);
    }

    public void UndoCommand()
    {
        if(StackOfMoves.Count > 0)
        {
            UndoList.Add(StackOfMoves[StackOfMoves.Count - 1]);
            StackOfMoves.RemoveAt(StackOfMoves.Count - 1);
            UndoList[UndoList.Count - 1].ReverseMove();
            print("StackOfMoves " + StackOfMoves.Count + "UndoList " + UndoList.Count);
        }
    }

    public void RedoCommand()
    {
        if (UndoList.Count > 0)
        {
            StackOfMoves.Add(UndoList[UndoList.Count - 1]);
            UndoList.RemoveAt(UndoList.Count - 1);
            StackOfMoves[StackOfMoves.Count - 1].Execute();
            print("StackOfMoves " + StackOfMoves.Count + "UndoList " + UndoList.Count);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(ButtonConfigurationManager.LeftButtonKey))
            {
                currentCommand = new LeftCommand(Player);
                MoveCommand();
            }
            else if (Input.GetKeyDown(ButtonConfigurationManager.RightButtonKey))
            {
                currentCommand = new RightCommand(Player);
                MoveCommand();
            }
            else if (Input.GetKeyDown(ButtonConfigurationManager.UpButtonKey))
            {
                currentCommand = new UpCommand(Player);
                MoveCommand();
            }
            else if (Input.GetKeyDown(ButtonConfigurationManager.DownButtonKey))
            {
                currentCommand = new DownCommand(Player);
                MoveCommand();
            }
        }
    }
}


