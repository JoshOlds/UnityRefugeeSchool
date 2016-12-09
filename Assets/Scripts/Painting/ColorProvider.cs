using UnityEngine;
using System.Collections;

public class ColorProvider : MonoBehaviour, IColorProvider {

    public Color MyColor;
    public bool SetMyMaterialColorToMyColor;

    private MeshRenderer MyMeshRenderer;

    // Use this for initialization
    void Start () {
        if (SetMyMaterialColorToMyColor)
        {
            MyMeshRenderer = GetComponent<MeshRenderer>();
            MyMeshRenderer.material.color = MyColor;
        }
    }
	
	// Update is called once per frame
	void Update () {

	}

    public Color GetColor()
    {
        return MyColor;
    }
}
