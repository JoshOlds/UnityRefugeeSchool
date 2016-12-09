using UnityEngine;
using System.Collections;

public class PaintCollider : MonoBehaviour
{

    //Attach me to a sphere to paint with me!

    public Color MyColor;

    private MeshRenderer MyMeshRenderer;
    private Rigidbody MyRigidBody;

    // Use this for initialization
    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody>();
        if (MyRigidBody == null) Debug.LogError("PaintCollider does not have a rigidbody. It will not be able to collide!");
        MyMeshRenderer = GetComponent<MeshRenderer>();
        if(MyMeshRenderer != null) MyMeshRenderer.material.color = MyColor;
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

            if (mb is IColorProvider)
            {
                IColorProvider colorProvider = (IColorProvider)mb;
                MyColor = colorProvider.GetColor();
                MyMeshRenderer.material.color = MyColor;
            }
        }
    }
}
