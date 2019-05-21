using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCoordMoving : MonoBehaviour {

    private CellCoordPosition cellCoordPosition;
    private CellCoordPosition playerPosition;

    void Start () {
        cellCoordPosition = (CellCoordPosition)gameObject.GetComponent(typeof(CellCoordPosition));
        playerPosition = (CellCoordPosition)GameObject.Find("Player").GetComponent(typeof(CellCoordPosition));
    }
	
	void Update () {
        cellCoordPosition.SetLocalPosition(transform.position.x, transform.position.y, transform.position.z);
        if (cellCoordPosition.RelativelyOutOfCell(playerPosition.GetGlobalPos()))
        {
            //cellCoordPosition.RelativelyUpdateGlobalPos(playerPosition.GetGlobalPos());
            //cellCoordPosition.SnapCoordsBackToCell();
        }
    }
}
