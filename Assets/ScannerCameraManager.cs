using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerCameraManager : MonoBehaviour
{
    [Header("References")]
    public Transform defaultPos;
    public Camera scannerCam;

    [Header("Position")]
    public float distanceFromParent = 2f;

    private Transform scannee;
    

    // Update is called once per frame
    void Update() {
        // // Move to default pos if parent==nul
        // if (scannerCam.transform.parent == null) {
        //     moveScannerCam(defaultParent);
        // }

        // Check if scannee == null
        if (scannee == null) {
            scannee = defaultPos;
        }

        // Update pos
        scannerCam.transform.position = scannee.position + (scannee.forward * distanceFromParent);
        scannerCam.transform.LookAt(scannee);
    }

    public void moveScannerCam(Transform newParent) {
        // Set scannee
        scannee = newParent;

        // Set parent and reset transform
        
        // // Make camera face newParent
        // scannerCam.transform.localPosition = Vector3.back * distanceFromParent;
    }
}
