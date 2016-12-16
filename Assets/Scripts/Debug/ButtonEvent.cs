using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ButtonEvent : MonoBehaviour {

    public UnityEvent Qpress;
    public UnityEvent Wpress;
    public UnityEvent Epress;
    public UnityEvent Rpress;
    public UnityEvent Tpress;
    public UnityEvent Ypress;
    public UnityEvent Upress;
    public UnityEvent Ipress;
    public UnityEvent Opress;
    public UnityEvent Ppress;
    public UnityEvent LeftBracketPress;
    public UnityEvent RightBracketPress;
    public UnityEvent BackslashPress;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Q)) Qpress.Invoke();
        if (Input.GetKeyDown(KeyCode.W)) Wpress.Invoke();
        if (Input.GetKeyDown(KeyCode.E)) Epress.Invoke();
        if (Input.GetKeyDown(KeyCode.R)) Rpress.Invoke();
        if (Input.GetKeyDown(KeyCode.T)) Tpress.Invoke();
        if (Input.GetKeyDown(KeyCode.Y)) Ypress.Invoke();
        if (Input.GetKeyDown(KeyCode.U)) Upress.Invoke();
        if (Input.GetKeyDown(KeyCode.I)) Ipress.Invoke();
        if (Input.GetKeyDown(KeyCode.O)) Opress.Invoke();
        if (Input.GetKeyDown(KeyCode.P)) Ppress.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftBracket)) LeftBracketPress.Invoke();
        if (Input.GetKeyDown(KeyCode.RightBracket)) RightBracketPress.Invoke();
        if (Input.GetKeyDown(KeyCode.Backslash)) BackslashPress.Invoke();

    }
}
