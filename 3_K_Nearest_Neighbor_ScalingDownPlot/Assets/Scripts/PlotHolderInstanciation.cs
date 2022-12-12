using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlotHolderInstanciation : MonoBehaviour
{

    public GameObject yAxisTickObject;
    public GameObject xAxisTickObject;
    public GameObject tickNumberObject;

    public GameObject maleDatapointObject;
    public GameObject femaleDatapointObject;


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

        // initialize 0 axis tick number
        var tickNumberNull = Instantiate(tickNumberObject, new Vector3((float)-0.54, (float)-0.55, 2), Quaternion.identity);
        tickNumberNull.transform.parent = gameObject.transform;


        // initialize x axis naming
        var xAxisNaming = Instantiate(tickNumberObject, new Vector3((float)0.6, (float)-0.56, 2), Quaternion.identity);
        xAxisNaming.GetComponent<TMP_Text>().text = "Weight";
        xAxisNaming.transform.parent = gameObject.transform;


        // initialize y axis naming
        var yAxisNaming = Instantiate(tickNumberObject, new Vector3((float) -0.65, (float) 0.52, 2), Quaternion.identity);
        yAxisNaming.GetComponent<TMP_Text>().text = "Height";
        yAxisNaming.transform.parent = gameObject.transform;



        // initialize x axis numbers
        tmpCoordinate = 0.1;
        while (tmpCoordinate < 0.9)
        {
            var ticknumber = Instantiate(tickNumberObject, new Vector3((float)((float) tmpCoordinate - 0.5), (float)-0.56, 2), Quaternion.identity);
            double textNumber = tmpCoordinate * 100;
            ticknumber.GetComponent<TMP_Text>().text = textNumber.ToString();
            ticknumber.transform.parent = gameObject.transform;
            tmpCoordinate = tmpCoordinate + 0.1;
        }



        // initialize y axis numbers
        tmpCoordinate = 0.1;
        while (tmpCoordinate < 0.9)
        {
            var ticknumber = Instantiate(tickNumberObject, new Vector3((float)-0.6, (float)(-0.5 + tmpCoordinate), 2), Quaternion.identity);
            double textNumber = tmpCoordinate * 2;
            ticknumber.GetComponent<TMP_Text>().text = textNumber.ToString();
            ticknumber.transform.parent = gameObject.transform;
            tmpCoordinate = tmpCoordinate + 0.1;
        }


        // TEST: Initialize DataPoints

        var maleDatapoint1 = Instantiate(maleDatapointObject, new Vector3((float) 0.3, (float) 0.4, 2), Quaternion.identity);
        maleDatapoint1.transform.parent = gameObject.transform;

        var maleDatapoint2 = Instantiate(maleDatapointObject, new Vector3((float)0.3, (float)0.3, 2), Quaternion.identity);
        maleDatapoint2.transform.parent = gameObject.transform;


        var femaleDatapoint1 = Instantiate(femaleDatapointObject, new Vector3(0, (float)0.3, 2), Quaternion.identity);
        femaleDatapoint1.transform.parent = gameObject.transform;

        var femaleDatapoint2 = Instantiate(femaleDatapointObject, new Vector3((float)-0.1, (float)0.2, 2), Quaternion.identity);
        femaleDatapoint2.transform.parent = gameObject.transform;



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
