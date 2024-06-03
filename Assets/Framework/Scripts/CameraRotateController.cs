using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 摄影机围绕目标物体旋转控制（可拖拽）
/// </summary>
public class CameraRotateController : MonoBehaviour
{
    public Transform target;//获取旋转目标
    [Tooltip("是否自动旋转")]
    public bool isAutoRot = false;//是否自动旋转
    [Tooltip("自动旋转速度")]
    public int rotSpeed = 5;//自动旋转速度
    
    [Tooltip("拖拽移动速度")]
    public float dragMoveSpeed = 10f; //拖拽移动速度
    [Tooltip("拖拽旋转速度")]
    public float dragRotSpeed = 1f;//拖拽旋转速度
    [Tooltip("滚轮缩放")]
    public float zoomSpeed = 2.5f;//滚轮缩放

    void Start()
    {
        if (target == null)
        {
            return;
        }
        transform.LookAt(target.transform);
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        cameraRotate();
        cameraZoom();
    }
    private void cameraRotate() //摄像机围绕目标旋转操作
    {
        if (isAutoRot)
        {
            transform.RotateAround(target.position, Vector3.up, rotSpeed * Time.deltaTime); //摄像机围绕目标旋转
        }
        else
        {
            var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
            var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
            //右键拖拽 相机平滑移动
            if (Input.GetKey(KeyCode.Mouse1))
            {
                transform.Translate(Vector3.left * (mouse_x * dragMoveSpeed) * Time.deltaTime);
                transform.Translate(Vector3.up * (mouse_y * dragMoveSpeed) * Time.deltaTime);
            }
            //左键拖拽 相机旋转调整角度
            if (Input.GetKey(KeyCode.Mouse0))
            {
                transform.RotateAround(target.transform.position, Vector3.up, mouse_x * dragRotSpeed);
                transform.RotateAround(target.transform.position, transform.right, mouse_y * dragRotSpeed);
            }
        }
    }

    private void cameraZoom() //摄像机滚轮缩放
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward * zoomSpeed);


        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward * -zoomSpeed);
    }
}
