using UnityEngine;
using System.Collections;

public class BoxBehaviour : MonoBehaviour
{
    public int rowNo, colNo;
    public BoxID boxID;

    public void Start()
    {
        boxID.rowID = rowNo;
        boxID.colID = colNo;
    }

}
