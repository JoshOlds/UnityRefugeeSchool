using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public float XRotationAmount;
    public float YRotationAmount;
    public float ZRotationAmount;
    public float VariationAmount;

    private float randomVariation;

	// Use this for initialization
	void Start () {
        randomVariation = Random.Range(0.0f, VariationAmount);
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        float x = XRotationAmount;
        float y = YRotationAmount;
        float z = ZRotationAmount;
        if (XRotationAmount != 0.0f)
        {
            x += randomVariation;
        }
        if (YRotationAmount != 0.0f)
        {
            y += randomVariation;
        }
        if (ZRotationAmount != 0.0f)
        {
            z += randomVariation;
        }
        Vector3 eulers = new Vector3(x, y, z);
        transform.Rotate(eulers);

    }
}
