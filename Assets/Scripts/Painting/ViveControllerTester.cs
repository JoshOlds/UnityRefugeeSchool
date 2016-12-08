using UnityEngine;
using System.Collections;

public class ViveControllerTester : MonoBehaviour {

    public ViveControllerManager ControllerManager;

    public bool VerboseConsole; //Flag for verbose console logging. Not yet implemented
    public bool RightControllerTriggerDown;
    public bool LeftControllerTriggerDown;
    public bool RightControllerGripDown;
    public bool LeftControllerGripDown;
    public bool RightControllerPadDown;
    public bool LeftControllerPadDown;
    public bool RightControllerPadUp;
    public bool LeftControllerPadUp;
    public bool RightControllerPadLeft;
    public bool LeftControllerPadLeft;
    public bool RightControllerPadRight;
    public bool LeftControllerPadRight;

    // Use this for initialization
    void Start () {
	    if(ControllerManager == null)
        {
            Debug.LogError("Missing Controller Manager! Will not be able to access Vive Controllers!");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!ControllerManager.isReady()) return; //Short circuit if not ready

        LeftControllerTriggerDown = ControllerManager.getButtonDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, ViveControllerManager.Controller.LeftViveController);
        RightControllerTriggerDown = ControllerManager.getButtonDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, ViveControllerManager.Controller.RightViveController);

        LeftControllerGripDown = ControllerManager.getButtonDown(Valve.VR.EVRButtonId.k_EButton_Grip, ViveControllerManager.Controller.LeftViveController);
        RightControllerGripDown = ControllerManager.getButtonDown(Valve.VR.EVRButtonId.k_EButton_Grip, ViveControllerManager.Controller.RightViveController);
    }

}
