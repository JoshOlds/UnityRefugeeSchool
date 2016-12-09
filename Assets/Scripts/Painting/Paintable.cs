using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paintable : MonoBehaviour, IPaintable
{

    public Color SelectedColor;
    private MeshRenderer MyMeshRenderer;

    // Use this for initialization
    void Start()
    {
        MyMeshRenderer = GetComponent<MeshRenderer>();
        if (MyMeshRenderer == null) Debug.LogError("No Mesh Renderer on Object! Cannot be paintable!");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Paint()
    {
        MyMeshRenderer.material.color = SelectedColor;
    }

    public void Paint(Color color)
    {
        MyMeshRenderer.material.color = color;
    }

    

}
