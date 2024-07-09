using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public float rotCamXAxisSpeed = 0;
    public float rotCamYAxisSpeed = 0;

    public float limitMinX = -80;
    public float limitMaxX = 80;
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleX -= mouseY * rotCamYAxisSpeed;
        eulerAngleY += mouseX * rotCamXAxisSpeed;
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        // 상체 or 고개 회전;
        this.transform.rotation = Quaternion.Euler(0, eulerAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f) { angle += 360.0f; }
        if (angle > 360.0f) { angle -= 360.0f; ; }

        return Mathf.Clamp(angle, min, max);
    }
}
