using UnityEngine;

public class LVR_CanvasWorldCamera : MonoBehaviour {
    /// <summary>if used within the main UI canvas, match the layer on instantiate</summary>
    public bool matchParentLayer;
    public bool matchParentLayerForAllChildren;
    // Use this for initialization
#if UNITY_ENGAGE
    void Start ()
    {
        CheckWorldCamera();
	}
	
	// Update is called once per frame
	void OnEnable()
    {
        CheckWorldCamera();
	}

    void CheckWorldCamera()
    {

        if (matchParentLayer)
        {
            if (transform.parent != null)
            {
                int layer = transform.parent.gameObject.layer;
                gameObject.layer = layer;

                foreach (CanvasRenderer ren in GetComponentsInChildren<CanvasRenderer>())
                    ren.gameObject.layer = layer;
            }
        }

        if (ENG_TrackedMotionControllers.instance.uiCamera != null)
        {
            if (GetComponent<Canvas>())
            {
                GetComponent<Canvas>().worldCamera = ENG_TrackedMotionControllers.instance.uiCamera;
#if UNITY_ANDROID && !UNITY_EDITOR
                foreach (UnityEngine.UI.InputField ifd in GetComponentsInChildren<UnityEngine.UI.InputField>(true))
                    ifd.interactable = false;
#endif
            }

            foreach (Canvas can in GetComponentsInChildren<Canvas>())
            {
                can.worldCamera = ENG_TrackedMotionControllers.instance.uiCamera;
            }
        }
    }
#endif
}
