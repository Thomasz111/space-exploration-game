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
        Vector3 localCoordDiff = (cellCoordPosition.GetGlobalPos() - playerPosition.GetGlobalPos()) * Universe.CellSize;
        Vector3 localPosition = new Vector3(transform.position.x - localCoordDiff.x, transform.position.y - localCoordDiff.y, transform.position.z - localCoordDiff.z);
        cellCoordPosition.SetLocalPosition(localPosition.x, localPosition.y, localPosition.z);
        if (cellCoordPosition.OutOfCell())
        {
            cellCoordPosition.UpdateGlobalPos();
            cellCoordPosition.SnapCoordsBackToCell();
        }
    }
}
