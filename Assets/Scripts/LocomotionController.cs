using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public InputActionReference teleportReference = null;
    public GameObject teleportRay;
    [field: SerializeField]
    public bool enableTeleport { get; set; }


    // Update is called once per frame
    void Update()
    {
        float value = teleportReference.action.ReadValue<float>();
        if (value > 0.1f && enableTeleport)
        {
            teleportRay.SetActive(true);
        }
        else
        {
            teleportRay.SetActive(false);
        }

    }
}
