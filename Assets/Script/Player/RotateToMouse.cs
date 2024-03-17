using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    private float rotCamXAxisSpeed = 3;
    private float rotCamYAxisSpeed = 2;

    private float limixMinX = -80;
    private float limixMaxX = 85;
    private float eulerAngleX;
    private float eulerAngleY;
    public float mouseX;
    public float mouseY;
    public float mouseYplus;

    private PlayerMove playerMove;
    private void Awake()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;
        eulerAngleX -= mouseY * rotCamXAxisSpeed;

        eulerAngleX = ClampAngle(eulerAngleX, limixMinX, limixMaxX);

        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
        transform.root.rotation = Quaternion.Euler(0, eulerAngleY, 0);
    }
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
    void Update()
    {
        if (playerMove.isPlayerMove)
        {

             mouseX = Input.GetAxis("Mouse X");
             mouseY = Input.GetAxis("Mouse Y");
            
            UpdateRotate(mouseX, mouseY);
        }
    }
}