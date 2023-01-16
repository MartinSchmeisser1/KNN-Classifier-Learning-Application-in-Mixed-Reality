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
    private List<GameObject> dataPointList;



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


        // TEST: Initialize DataPoints

        //var maleDatapoint1 = Instantiate(maleDatapointObject, new Vector3((float)0.3, (float)0.4, 2), Quaternion.identity);
        //maleDatapoint1.transform.parent = gameObject.transform;

        //var maleDatapoint2 = Instantiate(maleDatapointObject, new Vector3((float)0.3, (float)0.3, 2), Quaternion.identity);
        //maleDatapoint2.transform.parent = gameObject.transform;


        //var femaleDatapoint1 = Instantiate(femaleDatapointObject, new Vector3(0, (float)0.3, 2), Quaternion.identity);
        //femaleDatapoint1.transform.parent = gameObject.transform;

        //var femaleDatapoint2 = Instantiate(femaleDatapointObject, new Vector3((float)-0.1, (float)0.2, 2), Quaternion.identity);
        //femaleDatapoint2.transform.parent = gameObject.transform;

        //var datapoint1 = Instantiate(maleDatapointObject, new Vector3((float)0.4, (float)0.4, 2), Quaternion.identity);
        //datapoint1.transform.parent = gameObject.transform;

        //var datapoint = Instantiate(femaleDatapointObject, new Vector3((float)0.2, (float)0.35, 2), Quaternion.identity);
        //datapoint.transform.parent = gameObject.transform

       

    }

    // Update is called once per frame
    void Update()
    {
        
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
