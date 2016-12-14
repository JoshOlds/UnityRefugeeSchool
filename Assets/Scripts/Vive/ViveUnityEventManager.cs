using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ViveUnityEventManager : MonoBehaviour {

    public ViveControllerManager VCManager;
    public UnityEvent LeftGripButtonOnPress;
    public UnityEvent RightGripButtonOnPress;
    public UnityEvent LeftMenuButtonOnPress;
    public UnityEvent RightMenuButtonOnPress;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!VCManager.IsReady()) return;
        LeftControllerUpdate();
        RightControllerUpdate();
    }

    private void LeftControllerUpdate()
    {
        ViveControllerManager.Controller cont = ViveControllerManager.Controller.LeftViveController;

        if (VCManager.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip, cont)) LeftGripButtonOnPress.Invoke();
        if (VCManager.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu, cont)) LeftMenuButtonOnPress.Invoke();
    }

    private void RightControllerUpdate()
    {
        ViveControllerManager.Controller cont = ViveControllerManager.Controller.RightViveController;

        if (VCManager.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip, cont)) RightGripButtonOnPress.Invoke();
        if (VCManager.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu, cont)) RightMenuButtonOnPress.Invoke();
    }
}
