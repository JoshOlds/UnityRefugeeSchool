using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViveControlSwapper : MonoBehaviour
{

    public List<GameObject> Objects;
    public ViveControllerManager ControllerManager;
    public ViveControllerManager.Controller Controller;
    public float TimeoutTime;

    private Valve.VR.EVRButtonId ButtonId = Valve.VR.EVRButtonId.k_EButton_Grip;
    private bool timeout = false;


    void Update()
    {
        if (ControllerManager.IsReady())
        {
            if (ControllerManager.GetPress(ButtonId, Controller) && !timeout) //Pressed button, after timeout
            {
                timeout = true;
                StartCoroutine(resetTimeout(TimeoutTime));
                CycleActive();
            }
        }
    }

    IEnumerator resetTimeout(float time)
    {
        yield return new WaitForSeconds(time);

        timeout = false;
    }

    public void CycleActive()
    {
        Debug.Log("Cycling");
        for (int i = 0; i < Objects.Count; i++)
        {
            Debug.Log(Objects[i].activeSelf);
        }
        for (int i = 0; i < Objects.Count; i++)
        {
            if (Objects[i].activeSelf)
            {
                Objects[i].SetActive(false);
                if (i == Objects.Count - 1) Objects[0].SetActive(true);
                else Objects[i + 1].SetActive(true);
                return;
            }
        }
    }
}
