﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CellCoordPosition))]
public class CellCoordCameraMovement : MonoBehaviour 
{
	public float flySpeed = 1.0f;
	public Vector2 flySpeedLimit = new Vector2(0, 10);
	public float rotationSpeed = 120.0f;
    public float speedH = 5.0f;
    public float speedV = 5.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
	private Vector2	mouseDelta;
	private Vector2 mouseAbsolute;
	private Vector2 smoothMouse;
    private CellCoordPosition cellCoordPosition;
    private double cellSize;

    void Start()
    {
        cellCoordPosition = (CellCoordPosition) gameObject.GetComponent(typeof(CellCoordPosition));
        cellSize = CellCoordPosition.CellSize;
    }

    void Update()
    {
        ManageRotation();

        // Camera keyboard movement
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
            flySpeed = Mathf.Clamp(flySpeed + ((flySpeedLimit.y - flySpeedLimit.x) / 10.0f) * Input.GetAxis("Mouse ScrollWheel"), flySpeedLimit.x, flySpeedLimit.y);

        transform.Translate(transform.forward * flySpeed, Space.World);
        cellCoordPosition.SetLocalPosition(transform.position.x, transform.position.y, transform.position.z);
        if (cellCoordPosition.OutOfCell())
        {
            cellCoordPosition.SnapCoordsBackToCell();
            transform.position = cellCoordPosition.GetLocalPos();
        }
	}

    private void ManageRotation() {
        // Camera Mouse rotation (XY)
        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = -speedV * Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(pitch, yaw, 0.0f));

        // Camera Keyboard rotation (Z)
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
}
