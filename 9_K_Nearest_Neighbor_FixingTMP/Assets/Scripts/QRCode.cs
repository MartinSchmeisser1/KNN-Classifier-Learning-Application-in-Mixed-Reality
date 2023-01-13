using System.Collections;

using System.Collections.Generic;
using UnityEngine;

namespace QRTracking
{
    [RequireComponent(typeof(QRTracking.SpatialGraphNodeTracker))]
    public class QRCode : MonoBehaviour
    {
        public Microsoft.MixedReality.QR.QRCode qrCode;
        private GameObject qrCodeCube;

        

        public float PhysicalSize { get; private set; }
        public string CodeText { get; private set; }

        private TextMesh QRID;
        private TextMesh QRNodeID;
        private TextMesh QRText;
        private TextMesh QRVersion;
        private TextMesh QRTimeStamp;
        private TextMesh QRSize;
        private GameObject QRInfo;
        private bool validURI = false;
        private bool launch = false;
        private System.Uri uriResult;
        private long lastTimeStamp = 0;


        public GameObject maleDatapointObject;
        public GameObject femaleDatapointObject;
        private List<GameObject> dataPointList;

        // Use this for initialization
        void Start()
        {
            PhysicalSize = 0.1f;
            CodeText = "Dummy";
            if (qrCode == null)
            {
                throw new System.Exception("QR Code Empty");
            }

            PhysicalSize = qrCode.PhysicalSideLength;
            CodeText = qrCode.Data;

            qrCodeCube = gameObject.transform.Find("Cube").gameObject;
            QRInfo = gameObject.transform.Find("QRInfo").gameObject;
            QRID = QRInfo.transform.Find("QRID").gameObject.GetComponent<TextMesh>();
            QRNodeID = QRInfo.transform.Find("QRNodeID").gameObject.GetComponent<TextMesh>();
            QRText = QRInfo.transform.Find("QRText").gameObject.GetComponent<TextMesh>();
            QRVersion = QRInfo.transform.Find("QRVersion").gameObject.GetComponent<TextMesh>();
            QRTimeStamp = QRInfo.transform.Find("QRTimeStamp").gameObject.GetComponent<TextMesh>();
            QRSize = QRInfo.transform.Find("QRSize").gameObject.GetComponent<TextMesh>();

            QRID.text = "Id:" + qrCode.Id.ToString();
            QRNodeID.text = "NodeId:" + qrCode.SpatialGraphNodeId.ToString();
            QRText.text = CodeText;

            if (System.Uri.TryCreate(CodeText, System.UriKind.Absolute,out uriResult))
            {
                validURI = true;
                QRText.color = Color.blue;
            }

            QRVersion.text = "Ver: " + qrCode.Version;
            QRSize.text = "Size:" + qrCode.PhysicalSideLength.ToString("F04") + "m";
            QRTimeStamp.text = "Time:" + qrCode.LastDetectedTime.ToString("MM/dd/yyyy HH:mm:ss.fff");
            QRTimeStamp.color = Color.yellow;
            Debug.Log("Id= " + qrCode.Id + "NodeId= " + qrCode.SpatialGraphNodeId + " PhysicalSize = " + PhysicalSize + " TimeStamp = " + qrCode.SystemRelativeLastDetectedTime.Ticks + " QRVersion = " + qrCode.Version + " QRData = " + CodeText);
        }

        void UpdatePropertiesDisplay()
        {

            // Update properties that change
            if (qrCode != null && lastTimeStamp != qrCode.SystemRelativeLastDetectedTime.Ticks)
            {
                QRSize.text = "Size:" + qrCode.PhysicalSideLength.ToString("F04") + "m";

                QRTimeStamp.text = "Time:" + qrCode.LastDetectedTime.ToString("MM/dd/yyyy HH:mm:ss.fff");
                QRTimeStamp.color = QRTimeStamp.color==Color.yellow? Color.white: Color.yellow;
                PhysicalSize = qrCode.PhysicalSideLength;
                Debug.Log("Id= " + qrCode.Id + "NodeId= " + qrCode.SpatialGraphNodeId + " PhysicalSize = " + PhysicalSize + " TimeStamp = " + qrCode.SystemRelativeLastDetectedTime.Ticks + " Time = " + qrCode.LastDetectedTime.ToString("MM/dd/yyyy HH:mm:ss.fff"));

                qrCodeCube.transform.localPosition = new Vector3(PhysicalSize / 2.0f, PhysicalSize / 2.0f, 0.0f);
                qrCodeCube.transform.localScale = new Vector3(PhysicalSize, PhysicalSize, 0.005f);
                lastTimeStamp = qrCode.SystemRelativeLastDetectedTime.Ticks;
                QRInfo.transform.localScale = new Vector3(PhysicalSize/0.2f, PhysicalSize / 0.2f, PhysicalSize / 0.2f);

                // if (action.qrCode.LastDetectedTime.AddSeconds(20) > System.DateTimeOffset.Now)
                // {
                // addDataPoint(QRText.text);
                // addDataPoint("KNN Tutorial Card 1");
                // }  

            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdatePropertiesDisplay();
            if (launch)
            {
                launch = false;
                LaunchUri();
            }
        }

        void LaunchUri()
        {
#if WINDOWS_UWP
            // Launch the URI
            UnityEngine.WSA.Launcher.LaunchUri(uriResult.ToString(), true);
#endif
        }

        public void OnInputClicked()
        {
            if (validURI)
            {
                launch = true;
            }
        // eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        public void addDataPoint(string qrCodeData)
        {
            // Homer Simpson - 90kg - 1,80m
            if (qrCodeData == "KNN Tutorial Card 1")
            {
                var datapoint = Instantiate(maleDatapointObject, new Vector3((float)0.4, (float)0.4, 2), Quaternion.identity);
                datapoint.transform.parent = gameObject.transform;

                dataPointList.Add(datapoint);

            }

            // Marge Simpson - 70kg - 1,70m
            if (qrCodeData == "KNN Tutorial Card 2")
            {
                var datapoint = Instantiate(femaleDatapointObject, new Vector3((float)0.2, (float)0.35, 2), Quaternion.identity);
                datapoint.transform.parent = gameObject.transform;

                dataPointList.Add(datapoint);
            }


            // Rick Sanchez - 70kg - 1,90m
            if (qrCodeData == "KNN Tutorial Card 3")
            {
                var datapoint = Instantiate(maleDatapointObject, new Vector3((float)0.2, (float)0.45, 2), Quaternion.identity);
                datapoint.transform.parent = gameObject.transform;

                dataPointList.Add(datapoint);
            }


            // Summer Smith - 70kg - 1,80m
            if (qrCodeData == "KNN Tutorial Card 4")
            {
                var datapoint = Instantiate(femaleDatapointObject, new Vector3((float)0.2, (float)0.40, 2), Quaternion.identity);
                datapoint.transform.parent = gameObject.transform;

                dataPointList.Add(datapoint);
            }




            //if (qrCodeData == "KNN Reset")
            //{
            //    foreach (GameObject dataPoint in dataPointList)
            //    {
            //        Destroy(dataPoint);
            //    }
            //    dataPointList.Clear();
            //}
        }
    }
}