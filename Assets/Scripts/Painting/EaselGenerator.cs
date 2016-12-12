using UnityEngine;
using System.Collections;

/*
 * Alright, here's the idea. Rather than messing with render cameras and instantiating objects between a camera,
 * We are gonna make an easel out of a bunch of really small planes (think pixels)
 * Hopefully, we can check the collider on all of them, and set the color if they collide
 * Probably a REALLY stupid way to do this, but I can't figure out a better way right now!
 * 
 * The 'pixels' will be facing the same direction as the Z axis of the parent points (transform.forward)
 * 
 * - Josh
 * */

public class EaselGenerator : MonoBehaviour {

    public Transform ParentTransform; //For positioning of the easel
    public float PixelSize; //Size of every pixel
    public float Width; //Pixels wide to generate
    public float Height; //Pixels high to generate
    public Material DefaultMaterial;

    private Vector3 PlanePixelScale;
    private float PlaneScale = 0.1f; //Planes are inherently 10x larger

    // Use this for initialization
    void Start () {
        PlanePixelScale = new Vector3(PixelSize * PlaneScale, PixelSize * PlaneScale, PixelSize * PlaneScale);
        generatePlaneEasel();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void generatePlaneEasel()
    {
        for(int x = 0; x < Width; x++)
        {
            for(int y = 0; y < Height; y++)
            {
                GameObject pixelPlane = GameObject.CreatePrimitive(PrimitiveType.Plane); //Create new plane
                Vector3 positionVector = new Vector3((PixelSize * x), (PixelSize * y), 0); //Size
                pixelPlane.transform.localScale = PlanePixelScale;
                pixelPlane.transform.SetParent(this.transform);
                pixelPlane.transform.position = ParentTransform.position;
                pixelPlane.transform.Translate(positionVector);
                pixelPlane.transform.localRotation = Quaternion.Euler(90, 0, 0);

                pixelPlane.AddComponent<MaterialPaintable>();
                MeshRenderer MyRenderer = pixelPlane.GetComponent<MeshRenderer>();
                MyRenderer.material = DefaultMaterial;
                MyRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                MyRenderer.receiveShadows = true;
                MyRenderer.lightProbeUsage = UnityEngine.Rendering.LightProbeUsage.Off;
                MyRenderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
                MyRenderer.motionVectors = false;
            }
        }
    }
}
