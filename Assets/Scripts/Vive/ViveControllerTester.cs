using UnityEngine;
using System.Collections;

public class ViveControllerTester : MonoBehaviour {

    public ViveControllerManager ControllerManager;

    public bool VerboseConsole; //Flag for verbose console logging. Not yet implemented
    public Vector2 LeftTouchPadCoords;
    public Vector2 RightTouchPadCoords;
    public float LeftTriggerAnalog;
    public float RightTriggerAnalog;
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
    public bool LeftControllerMenu;
    public bool RightControllerMenu;

    private float touchSensitivity = 0.5f;

    // Use this for initialization
    void Start () {
	    if(ControllerManager == null)
        {
            Debug.LogError("Missing Controller Manager! Will not be able to access Vive Controllers!");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!ControllerManager.IsReady()) return; //Short circuit if not ready

        LeftTouchPadCoords = ControllerManager.GetTouchCoords(ViveControllerManager.Controller.LeftViveController);
        RightTouchPadCoords = ControllerManager.GetTouchCoords(ViveControllerManager.Controller.RightViveController);

        LeftTriggerAnalog = ControllerManager.GetTriggerAnalog(ViveControllerManager.Controller.LeftViveController);
        RightTriggerAnalog = ControllerManager.GetTriggerAnalog(ViveControllerManager.Controller.RightViveController);

        LeftControllerTriggerDown = ControllerManager.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, ViveControllerManager.Controller.LeftViveController);
        RightControllerTriggerDown = ControllerManager.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger, ViveControllerManager.Controller.RightViveController);

        LeftControllerGripDown = ControllerManager.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip, ViveControllerManager.Controller.LeftViveController);
        RightControllerGripDown = ControllerManager.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip, ViveControllerManager.Controller.RightViveController);

        LeftControllerPadDown = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Down, ViveControllerManager.Controller.LeftViveController, touchSensitivity);
        RightControllerPadDown = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Down, ViveControllerManager.Controller.RightViveController, touchSensitivity);

        LeftControllerPadUp = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Up, ViveControllerManager.Controller.LeftViveController, touchSensitivity);
        RightControllerPadUp = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Up, ViveControllerManager.Controller.RightViveController, touchSensitivity);

        LeftControllerPadLeft = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Left, ViveControllerManager.Controller.LeftViveController, touchSensitivity);
        RightControllerPadLeft = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Left, ViveControllerManager.Controller.RightViveController, touchSensitivity);

        LeftControllerPadRight = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Right, ViveControllerManager.Controller.LeftViveController, touchSensitivity);
        RightControllerPadRight = ControllerManager.GetTouchPadPress(Valve.VR.EVRButtonId.k_EButton_DPad_Right, ViveControllerManager.Controller.RightViveController, touchSensitivity);

        LeftControllerMenu = ControllerManager.GetPress(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu, ViveControllerManager.Controller.LeftViveController);
        RightControllerMenu = ControllerManager.GetPress(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu, ViveControllerManager.Controller.RightViveController);
    }

}
