using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xlook = 30f;
    public float ylook = 30f;
    // Start is called before the first frame update

    public void ProcessLook(Vector2 input)
    {
        float mosX = input.x;
        float mosY = input.y;

        xRotation -= (mosY * Time.deltaTime * ylook);
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * (mosX * Time.deltaTime) * xlook);
    }
}
