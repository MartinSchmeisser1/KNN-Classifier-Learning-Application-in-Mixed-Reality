using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotHolderScript : MonoBehaviour
{

    public GameObject yAxisTickObject;
    public GameObject xAxisTickObject;

    public GameObject maleDatapointObject;
    public GameObject maleDatapointObjectRed;
    public GameObject maleDatapointObjectYellow;
    public GameObject femaleDatapointObject;
    public GameObject femaleDatapointObjectRed;
    public GameObject femaleDatapointObjectYellow;
    public GameObject unclassifiedDatapointObject;

    private List<GameObject> dataPointGameObjects = new List<GameObject>();
    private List<DataPoint> dataPointsForClassification = new List<DataPoint>();
    

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
            Vector3 dataPointNormalPosition = new Vector3((float)0.4, (float)0.9, 0);
            addDatapoint(dataPointNormalPosition, maleDatapointObject);
            dataPointsForClassification.Add(new DataPoint(1, 90, 180, Gender.Male));
        }

        // Marge Simpson - 70kg - 1,70m
        if (qrCodeData == "KNN Tutorial Card 2")
        {
            Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.85, 0);
            addDatapoint(dataPointNormalPosition, femaleDatapointObject);
            dataPointsForClassification.Add(new DataPoint(2, 70, 170, Gender.Female));
        }


        // Rick Sanchez - 70kg - 1,90m
        if (qrCodeData == "KNN Tutorial Card 3")
        {
            Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.95, 0);
            addDatapoint(dataPointNormalPosition, maleDatapointObject);
            dataPointsForClassification.Add(new DataPoint(3, 70, 190, Gender.Male));
        }


        // Summer Smith - 70kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 4")
        {
            Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.9, 0);
            addDatapoint(dataPointNormalPosition, femaleDatapointObject);
            dataPointsForClassification.Add(new DataPoint(4, 70, 180, Gender.Female));
        }

        // Test Card 1 - k=1 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 1")
        {
            Gender classifiedGender = classify(1, 80, 180);
            

            // insert classified datapoint
            Vector3 dataPointNormalPosition = new Vector3((float)0.3, (float)0.9, 0);
            if (classifiedGender == Gender.Male)
            {
                addDatapoint(dataPointNormalPosition, maleDatapointObjectRed);
            } else if (classifiedGender == Gender.Female)
            {
                addDatapoint(dataPointNormalPosition, femaleDatapointObjectRed);
            } else
            {
                addDatapoint(dataPointNormalPosition, unclassifiedDatapointObject);
            }

            // todo: highlight DP used for classification
        }



        if (qrCodeData == "KNN Reset")
        {
            foreach (GameObject dataPoint in dataPointGameObjects)
            {
                Destroy(dataPoint);
            }
            dataPointGameObjects.Clear();
            dataPointsForClassification.Clear();
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

    private void addDatapoint(Vector3 dataPointNormalPosition, GameObject dataPointGameObject)
    {
        Vector3 dataPointScale = getScalingForDP();
        Vector3 dataPointPosition = getPositionForDP(dataPointNormalPosition);

        // Instantiate DataPoint
        var datapointInstance = Instantiate(dataPointGameObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

        // Scale DataPoint
        datapointInstance.transform.localScale = dataPointScale;

        dataPointGameObjects.Add(datapointInstance);
    }


    private Gender classify(int k, int weight, int height)
    {

        return Gender.Unclassified;
    }


}
