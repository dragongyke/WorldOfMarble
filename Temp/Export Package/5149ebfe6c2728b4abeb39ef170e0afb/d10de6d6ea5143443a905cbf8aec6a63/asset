using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;


/// <summary>
/// 头部跟踪
/// </summary>
public class PicoVRHeadTrack : MonoBehaviour
{
    /// <summary>
    /// 是否跟踪Rotation 
    /// </summary>
    public bool trackRotation = true;

    /// <summary>
    /// 是否跟踪Position
    /// </summary>
    public bool trackPosition = true;

    public Transform target;  // 设定位置

    public bool updateEarly = false;   //在哪处更新 Update  或者LateUpdate

    private bool updated = false;  // 是否更新完成标志

    private Vector3 startPosition;

    private Quaternion startQuaternion;

    public void Awake()
    {
        if (target == null)
        {
            startPosition = transform.localPosition;
            startQuaternion = transform.localRotation;
        }
        else
        {
            startPosition = transform.position;
            startQuaternion = transform.rotation;
        }

    }

    public Ray Gaze
    {
        get
        {
            UpdateHead();
            return new Ray(transform.position, transform.forward);
        }
    }

    void Update()
    {
        updated = false;  // OK to recompute head pose.
        if (updateEarly)
        {
            UpdateHead();
        }
    }

    void LateUpdate()
    {
        if (!updateEarly)
            UpdateHead();
    }

    private void UpdateHead()
    {
        if (updated)
        {
           return;
        }
        updated = true;
        if (PicoVRManager.SDK ==null)
        {
            return;
        }
        if (trackRotation)
        {
            var rot = PicoVRManager.SDK.headPose.Orientation;
            if (target == null)
            {
                transform.localRotation = rot;
            }
            else
            {
                transform.rotation = rot * target.rotation;
            }
        }

        else
        {
            var rot = PicoVRManager.SDK.headPose.Orientation;
            if (target == null)
            {
                transform.localRotation = Quaternion.identity;
            }
            else
            {
                transform.rotation = rot * target.rotation;
            }
        }
        if (trackPosition)
        {
            Vector3 pos = PicoVRManager.SDK.headPose.Position;
            if (target == null)
            {
                transform.localPosition = pos;
            }
            else
            {
                transform.position = target.position + target.rotation * pos;
            }
        }
    }
}
