using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ColorMeForTime : MonoBehaviour {

    public Color Color;
    public float SecondsToWait;

    private MeshRenderer mesh;
    private Color originalColor;

	void Start () {
        mesh = GetComponent<MeshRenderer>();
        originalColor = mesh.material.color;
	}
	
    public void ColorMe()
    {
        mesh.material.color = Color;
        StartCoroutine(resetColor(SecondsToWait));
    }

    IEnumerator resetColor(float time)
    {
        yield return new WaitForSeconds(time);
        mesh.material.color = originalColor;
    }
}
