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

    public bool Ready; //Are both controllers found?

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    void Awake()
    {
        //Grab the controller indexes. This may happen too fast, so while loops...
        leftControllerIndex = LeftViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
        rightControllerIndex = RightViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;

        if (LeftControllerEnabled)
        {
            while((int)leftControllerIndex == -1)
            {
                leftControllerIndex = LeftViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
            }
        }
        if (RightControllerEnabled)
        {
            while ((int)rightControllerIndex == -1)
            {
                rightControllerIndex = RightViveControllerObject.GetComponent<SteamVR_TrackedObject>().index;
            }
        }

        Debug.Log("Left controller index: " + (int)leftControllerIndex);
        Debug.Log("Right controller index: " + (int)rightControllerIndex);
        leftController = SteamVR_Controller.Input((int)leftControllerIndex);
        rightController = SteamVR_Controller.Input((int)rightControllerIndex);
        Ready = true;
    }

    public bool isReady()
    {
        return Ready;
    }

    public bool getButtonDown(Valve.VR.EVRButtonId buttonId, ViveControllerManager.Controller controller)
    {
        if(controller == ViveControllerManager.Controller.LeftViveController && LeftControllerEnabled)
        {
            return leftController.GetPressDown(buttonId);
        }
        if(controller == ViveControllerManager.Controller.RightViveController && RightControllerEnabled)
        {
            return rightController.GetPressDown(buttonId);
        }
        return false;
    }

}