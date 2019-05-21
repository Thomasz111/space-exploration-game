using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCoordMoving : MonoBehaviour {

    private CellCoordPosition cellCoordPosition;

    void Start () {
        cellCoordPosition = (CellCoordPosition)gameObject.GetComponent(typeof(CellCoordPosition));
    }
	
	void Update () {
        cellCoordPosition.SetLocalPosition(transform.position.x, transform.position.y, transform.position.z);
        if (cellCoordPosition.OutOfCell())
        {
        //    cellCoordPosition.UpdateGlobalPos();
        //    cellCoordPosition.SnapCoordsBackToCell();
        }
    }
}
