using UnityEngine;
using System.Collections;

public class PaintCollider : MonoBehaviour
{

    //This component will allow you to paint any object that is 
    //paintable with colors, or materials

    public Color MyColor;
    public Material MyMaterial;

    private MeshRenderer MyMeshRenderer;
    private Rigidbody MyRigidBody;

    // Use this for initialization
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody>();
        if (MyRigidBody == null) Debug.LogError("PaintCollider does not have a rigidbody. It will not be able to collide!");
        MyMeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerEnter(Collider other)
    {
        MonoBehaviour[] list = other.gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mb in list)
        {
            if (mb is IPaintable)
            {
                IPaintable paintable = (IPaintable)mb;
                paintable.Paint(MyColor);
            }

            if (mb is IMaterialPaintable)
            {
                IMaterialPaintable paintable = (IMaterialPaintable)mb;
                paintable.Paint(MyMaterial);
            }

            if (mb is IColorProvider)
            {
                IColorProvider provider = (IColorProvider)mb;
                MyColor = provider.GetColor();
                MyMeshRenderer.material.color = MyColor;
            }

            if (mb is IMaterialProvider)
            {
                IMaterialProvider provider = (IMaterialProvider)mb;
                MyMaterial = provider.GetMaterial();
                MyMeshRenderer.material = MyMaterial;
            }
        }
    }
}
