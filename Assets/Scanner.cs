using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scanner : MonoBehaviour
{
    [Header("References")]
    public Transform playerCam;
    public GameObject scannerCam;
    public GameObject scannerTextObj;
    public GameObject scannerRenderTex;

    private TextMeshProUGUI scannerText;
    private ScannerCameraManager scannerCamManager;



    private void Start() {
        // Get references
        scannerText = scannerTextObj.GetComponent<TextMeshProUGUI>();
        scannerCamManager = scannerCam.GetComponent<ScannerCameraManager>();
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        // If Lshift then scan
        if (Input.GetKey(KeyCode.LeftShift)) {
            useScanner();
        }
    }

    private void useScanner() {
        // Ray cast from cam
        RaycastHit hit;
        if (Physics.Raycast(playerCam.position, playerCam.TransformDirection(Vector3.forward), out hit, 100f)) {
            Debug.DrawRay(playerCam.position, playerCam.TransformDirection(Vector3.forward)*100, Color.green);

            // Update text/cam
            updateScannerText("ID: " + hit.transform.name);
            scannerCamManager.moveScannerCam(hit.transform);
        } else {
            Debug.DrawRay(playerCam.position, playerCam.TransformDirection(Vector3.forward)*100, Color.red);

            // Update text
            updateScannerText("None");
        }
    }

    private void updateScannerText(string newText) {
        scannerText.text = newText;
    }
}
