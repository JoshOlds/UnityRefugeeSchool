using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightToggler : MonoBehaviour {

    public List<Light> Lights = new List<Light>();
    public bool DisableAllLightsOnStart;

	// Use this for initialization
	void Start () {
	    if(DisableAllLightsOnStart)
        {
            foreach(Light light in Lights)
            {
                light.enabled = false;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Turns all lights on or off
    /// </summary>
    /// <param name="OnStatus">True for lights on / False for off</param>
    public void ToggleAll(bool OnStatus)
    {
        foreach(Light light in Lights)
        {
            if (OnStatus) light.enabled = true;
            else light.enabled = false;
        }
    }

    /// <summary>
    /// Toggles all lights in the list
    /// </summary>
    public void ToggleAll()
    {
        foreach (Light light in Lights)
        {
            if (light.enabled) light.enabled = false;
            else light.enabled = true;
        }
    }
}
