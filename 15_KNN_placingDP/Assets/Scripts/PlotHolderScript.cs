using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotHolderScript : MonoBehaviour
{

    public GameObject yAxisTickObject;
    public GameObject xAxisTickObject;

    public GameObject maleDatapointObject;
    public GameObject femaleDatapointObject;
    private List<GameObject> dataPointList = new List<GameObject>();

    Vector3 dataPointNormalScale = new Vector3((float)0.05, (float)0.05, (float)0.05);


    // Start is called before the first frame update
    void Start()
    {

        

        // initialize y-axis-ticks
        double tmpCoordinate = -0.4;
        while(tmpCoordinate < 0.5)
        {
            var tick = Instantiate(yAxisTickObject, new Vector3((float)-0.5, (float)tmpCoordinate, 2), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
            tmpCoordinate = tmpCoordinate + 0.1;
        }

        // initialize x-axis-ticks
        tmpCoordinate = -0.4;
        while (tmpCoordinate < 0.5)
        {
            var tick = Instantiate(xAxisTickObject, new Vector3((float) tmpCoordinate, (float) -0.5, 2), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
            tmpCoordinate = tmpCoordinate + 0.1;
        }


        // ---------------------------------------------- TEST: Initialize DataPoints ----------------------------------------------

        //var maleDatapoint1 = Instantiate(maleDatapointObject, new Vector3((float)0.3, (float)0.4, 2), Quaternion.identity);
        //maleDatapoint1.transform.parent = gameObject.transform;


        // ---------------------------------------------- TEST: Initialize DataPoints dependent on plot position ----------------------------------------------

        //// get scaling and position from helper functions
        //Vector3 dataPointNormalPosition = new Vector3((float)0.4, (float)0.9, 0);
        //Vector3 dataPointScale = getScalingForDP();
        //Vector3 dataPointPosition = getPositionForDP(dataPointNormalPosition);

        //// Instantiate DataPoint
        //var maleDatapoint2 = Instantiate(maleDatapointObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

        //// Scale DataPoint
        //maleDatapoint2.transform.localScale = dataPointScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleQrCode(string qrCodeData)
    {
        // Homer Simpson - 90kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 1")
        {
            // get scaling and position from helper functions
            Vector3 dataPointNormalPosition = new Vector3((float)0.4, (float)0.9, 0);
            Vector3 dataPointScale = getScalingForDP();
            Vector3 dataPointPosition = getPositionForDP(dataPointNormalPosition);

            // Instantiate DataPoint
            var datapointInstance = Instantiate(maleDatapointObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

            // Scale DataPoint
            datapointInstance.transform.localScale = dataPointScale;

            dataPointList.Add(datapointInstance);
        }

        // Marge Simpson - 70kg - 1,70m
        if (qrCodeData == "KNN Tutorial Card 2")
        {
            // get scaling and position from helper functions
            Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.85, 0);
            Vector3 dataPointScale = getScalingForDP();
            Vector3 dataPointPosition = getPositionForDP(dataPointNormalPosition);

            // Instantiate DataPoint
            var datapointInstance = Instantiate(femaleDatapointObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

            // Scale DataPoint
            datapointInstance.transform.localScale = dataPointScale;

            dataPointList.Add(datapointInstance);
        }


        // Rick Sanchez - 70kg - 1,90m
        if (qrCodeData == "KNN Tutorial Card 3")
        {
            // get scaling and position from helper functions
            Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.95, 0);
            Vector3 dataPointScale = getScalingForDP();
            Vector3 dataPointPosition = getPositionForDP(dataPointNormalPosition);

            // Instantiate DataPoint
            var datapointInstance = Instantiate(maleDatapointObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

            // Scale DataPoint
            datapointInstance.transform.localScale = dataPointScale;

            dataPointList.Add(datapointInstance);
        }


        // Summer Smith - 70kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 4")
        {
            // get scaling and position from helper functions
            Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.9, 0);
            Vector3 dataPointScale = getScalingForDP();
            Vector3 dataPointPosition = getPositionForDP(dataPointNormalPosition);

            // Instantiate DataPoint
            var datapointInstance = Instantiate(femaleDatapointObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

            // Scale DataPoint
            datapointInstance.transform.localScale = dataPointScale;

            dataPointList.Add(datapointInstance);
        }




        if (qrCodeData == "KNN Reset")
        {
            foreach (GameObject dataPoint in dataPointList)
            {
                Destroy(dataPoint);
            }
            dataPointList.Clear();
        }
    }


    private Vector3 getScalingForDP()
    {
        Vector3 plotLocalScale = gameObject.transform.localScale;
        Vector3 dataPointScale = Vector3.Scale(dataPointNormalScale, plotLocalScale);
        return dataPointScale;
    }

    private Vector3 getPositionForDP(Vector3 dataPointNormalPosition)
    {
        Vector3 plotLocalScale = gameObject.transform.localScale;
        Vector3 plotPosition = gameObject.transform.position;
        Vector3 dataPointNormalPositionScaled = Vector3.Scale(dataPointNormalPosition, plotLocalScale);
        Vector3 dataPointPosition = dataPointNormalPositionScaled + plotPosition;
        return dataPointPosition;
    }


}
