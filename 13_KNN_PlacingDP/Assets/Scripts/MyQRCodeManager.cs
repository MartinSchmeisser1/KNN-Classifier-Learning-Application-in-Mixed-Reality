using QRTracking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQRCodeManager : MonoBehaviour
{
    public QRCodesManager qRCodesManager;

    public void StartScan()
    {
        // start QR tracking with the press of a button
        qRCodesManager.StartQRTracking();
    }
    public void StopScan()
    {
        // Stop the tracking with the press of a button
        qRCodesManager.StopQRTracking();
    }
}
