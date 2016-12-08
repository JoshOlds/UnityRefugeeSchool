using UnityEngine;
public class ViveControllerManager : MonoBehaviour
{
    public enum Controller { LeftViveController, RightViveController};

    public GameObject LeftViveControllerObject;
    public GameObject RightViveControllerObject;
    public bool LeftControllerEnabled; //Uncheck this in editor if not using this controller
    public bool RightControllerEnabled;//Uncheck this in editor if not using this controller

    private SteamVR_Controller.Device leftController;
    private SteamVR_Controller.Device rightController;
    private SteamVR_TrackedObject.EIndex leftControllerIndex;
    private SteamVR_TrackedObject.EIndex rightControllerIndex;

    [SerializeField]
    private bool Ready; //Are both controllers found?

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    void Awake()
    {
        //Grab the controller indexes. This may happen too fast, so update will check for new values
        leftControllerIndex = LeftViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
        rightControllerIndex = RightViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
    }

    void Update()
    {
        if ((int)rightControllerIndex != -1 && (int)leftControllerIndex != -1) return; //Short circuit if indexes are found


        if (LeftControllerEnabled)
        {
            leftControllerIndex = LeftViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
        }
        if (RightControllerEnabled)
        {
            rightControllerIndex = RightViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
        }

        if ((int)rightControllerIndex != -1 && (int)leftControllerIndex != -1) //Found both controllers
        {
            Debug.Log("Left controller index: " + (int)leftControllerIndex);
            Debug.Log("Right controller index: " + (int)rightControllerIndex);
            leftController = SteamVR_Controller.Input((int)leftControllerIndex);
            rightController = SteamVR_Controller.Input((int)rightControllerIndex);
            Ready = true;
        }     
    }

    public bool IsReady()
    {
        return Ready;
    }

    public bool GetPress(Valve.VR.EVRButtonId buttonId, ViveControllerManager.Controller controller)
    {
        SteamVR_Controller.Device currentController;
        if (controller == ViveControllerManager.Controller.LeftViveController) currentController = leftController;
        else currentController = rightController;

        return currentController.GetPress(buttonId);
    }

    public Vector2 GetTouchCoords(ViveControllerManager.Controller controller)
    {
        SteamVR_Controller.Device currentController;
        if (controller == ViveControllerManager.Controller.LeftViveController) currentController = leftController;
        else currentController = rightController;

        return currentController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
    }

    public float GetTriggerAnalog(ViveControllerManager.Controller controller)
    {
        SteamVR_Controller.Device currentController;
        if (controller == ViveControllerManager.Controller.LeftViveController) currentController = leftController;
        else currentController = rightController;

        return currentController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis1).x;
    }

    public bool GetTouchPadPress(Valve.VR.EVRButtonId buttonId, ViveControllerManager.Controller controller, float sensitivity)
    {
        sensitivity = Mathf.Clamp(sensitivity, 0.0f, 1.0f);
        SteamVR_Controller.Device currentController;
        if (controller == ViveControllerManager.Controller.LeftViveController) currentController = leftController;
        else currentController = rightController;

        if (!GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad, controller)) return false; //No button pressed!

        if (buttonId == Valve.VR.EVRButtonId.k_EButton_DPad_Down)
        {
            if (GetTouchCoords(controller).y < -sensitivity) return true;
        }
        if (buttonId == Valve.VR.EVRButtonId.k_EButton_DPad_Up)
        {
            if (GetTouchCoords(controller).y > sensitivity) return true;
        }
        if (buttonId == Valve.VR.EVRButtonId.k_EButton_DPad_Left)
        {
            if (GetTouchCoords(controller).x < -sensitivity) return true;
        }
        if (buttonId == Valve.VR.EVRButtonId.k_EButton_DPad_Right)
        {
            if (GetTouchCoords(controller).x > sensitivity) return true;
        }

        return false;
    }

}