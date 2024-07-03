using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private Material daySkybox;
    [SerializeField]
    private Material nightSkybox;
    [SerializeField]
    private Light mainLight;

    private Rigidbody rb;
    private float forceFactor = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float fx = Input.GetAxis("Horizontal") * Time.timeScale * forceFactor;
        float fz = Input.GetAxis("Vertical") * Time.timeScale * forceFactor;
        //rb.AddForce(fx, 0, fz);

        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f;
        camForward = camForward.normalized;

        Vector3 moveDirection = 
            fz * camForward +
            fx * Camera.main.transform.right;
        rb.AddForce(moveDirection);

        if(Input.GetKeyDown(KeyCode.N))
        {
            if(UnityEngine.RenderSettings.skybox == daySkybox)
            {
                UnityEngine.RenderSettings.skybox = nightSkybox;
                UnityEngine.RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
                UnityEngine.RenderSettings.ambientIntensity = 0f;
                mainLight.intensity = 0f;
            }
            else
            {
                UnityEngine.RenderSettings.skybox = daySkybox;
                UnityEngine.RenderSettings.skybox.SetFloat("_Exposure", 1f);
                UnityEngine.RenderSettings.ambientIntensity = 1f;
                mainLight.intensity = 1f;
            }
        }
    }
}
