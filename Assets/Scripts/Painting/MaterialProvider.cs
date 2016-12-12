using UnityEngine;
using System.Collections;

public class MaterialProvider : MonoBehaviour, IMaterialProvider
{

    public Material MyMaterial;
    public bool OverrideMyMaterial;

    private MeshRenderer MyMeshRenderer;

    // Use this for initialization
    void Start()
    {
        if (OverrideMyMaterial)
        {
            MyMeshRenderer = GetComponent<MeshRenderer>();
            MyMeshRenderer.material = MyMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Material GetMaterial()
    {
        return MyMaterial;
    }
}
