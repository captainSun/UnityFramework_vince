using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinceFramework;

public class MotionBlurController : MonoBehaviour
{
    private Material[ ] mats; //所有需要控制的材质球
    private Vector3 lastPosition; //记录上一次的位置
    private Vector3 newPosition; //新位置
    private Vector3 direction; //移动的方向
    private float t = 0; //时间差值
    void Start()
    {
        ResManager resMgr = AppCore.Instance.GetManager<ResManager>(ManagerName.Resource);
        var renderers = transform.GetComponentsInChildren<Renderer> ();
        mats = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            //renderers[i].sharedMaterial = resMgr.LoadMaterial("Res/Material/MotionBlur.mat");
            mats[i] = renderers[i].sharedMaterial;
        }
        lastPosition = newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = transform.position;

        //如果上一帧的位置追到了当前帧的位置，则重置t
        if (newPosition == lastPosition)
        {
            t = 0;
            return;
        }
        t += Time.deltaTime;
        //上一帧的位置通过t来做插值
        lastPosition = Vector3.Lerp (lastPosition, newPosition, t/2);
        //求出移动的方向
        direction = lastPosition - newPosition;
        //遍历修改所有材质的_Direction属性
        foreach (var m in mats)
        {
            m.SetVector ("_Direction", new Vector4 (direction.x, direction.y, direction.z, m.GetVector ("_Direction").w));
        }
    }
}
