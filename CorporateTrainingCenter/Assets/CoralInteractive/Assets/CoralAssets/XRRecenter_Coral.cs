using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRecenter_Coral : MonoBehaviour
{
    public bool MoveToRoomScaleAfterRecenter = false;

    private bool needRoom = true;
    private bool needRecenter = true;

	private void Start ()
    {
        needRoom = MoveToRoomScaleAfterRecenter;
        UnityEngine.XR.XRDevice.SetTrackingSpaceType(UnityEngine.XR.TrackingSpaceType.Stationary);

		Application.targetFrameRate = 24;
		QualitySettings.vSyncCount = 0;
	}
	
	private void LateUpdate ()
    {
		//Debug.Log ("VsyncCount = " + QualitySettings.vSyncCount);
    }

    private void Update()
    {
        if (needRecenter && UnityEngine.XR.XRDevice.GetTrackingSpaceType() == UnityEngine.XR.TrackingSpaceType.Stationary)
        {
            needRecenter = false;
            UnityEngine.XR.InputTracking.Recenter();
        }
        else if (needRoom && MoveToRoomScaleAfterRecenter && !needRecenter)
        {
            if(UnityEngine.XR.XRDevice.GetTrackingSpaceType() != UnityEngine.XR.TrackingSpaceType.RoomScale)
                UnityEngine.XR.XRDevice.SetTrackingSpaceType(UnityEngine.XR.TrackingSpaceType.RoomScale);
        }
    }
}
