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
        for (int i = -4; i < 5; i++)
        {
            var tick = Instantiate(yAxisTickObject, new Vector3(-5, i, 2), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
        }

        // initialize x-axis-ticks
        for (int i = -4; i < 5; i++)
        {
            var tick = Instantiate(xAxisTickObject, new Vector3(i, -5, 2), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
        }

        // initialize 0 axis tick number
        var tickNumberNull = Instantiate(tickNumberObject, new Vector3((float)-5.4, (float)-5.5, 2), Quaternion.identity);
        tickNumberNull.transform.parent = gameObject.transform;


        // initialize x axis naming
        var xAxisNaming = Instantiate(tickNumberObject, new Vector3((float)5.7, (float)-5.6, 2), Quaternion.identity);
        xAxisNaming.GetComponent<TMP_Text>().text = "Weight";
        xAxisNaming.transform.parent = gameObject.transform;


        // initialize y axis naming
        var yAxisNaming = Instantiate(tickNumberObject, new Vector3((float) -6.5, (float) 5.2, 2), Quaternion.identity);
        yAxisNaming.GetComponent<TMP_Text>().text = "Height";
        yAxisNaming.transform.parent = gameObject.transform;



        // initialize x axis numbers
        for (int i = 1; i < 10; i++)
        {
            var ticknumber = Instantiate(tickNumberObject, new Vector3(i - 5, (float)-5.6, 2), Quaternion.identity);
            int textNumber = i * 10;
            ticknumber.GetComponent<TMP_Text>().text = textNumber.ToString();
            ticknumber.transform.parent = gameObject.transform;
        }

        // initialize y axis numbers
        for(int i = 1; i < 10; i++)
        {
            var ticknumber = Instantiate(tickNumberObject, new Vector3(-6, -5 + i, 2), Quaternion.identity);
            double textNumber = i * 0.2;
            ticknumber.GetComponent<TMP_Text>().text = textNumber.ToString();
            ticknumber.transform.parent = gameObject.transform;
        }


        // TEST: Initialize DataPoints

        var maleDatapoint1 = Instantiate(maleDatapointObject, new Vector3(3, 4, 2), Quaternion.identity);
        maleDatapoint1.transform.parent = gameObject.transform;

        var maleDatapoint2 = Instantiate(maleDatapointObject, new Vector3(3, 3, 2), Quaternion.identity);
        maleDatapoint2.transform.parent = gameObject.transform;


        var femaleDatapoint1 = Instantiate(femaleDatapointObject, new Vector3(0, 3, 2), Quaternion.identity);
        femaleDatapoint1.transform.parent = gameObject.transform;

        var femaleDatapoint2 = Instantiate(femaleDatapointObject, new Vector3(-1, 2, 2), Quaternion.identity);
        femaleDatapoint2.transform.parent = gameObject.transform;

        var femaleDatapoint3 = Instantiate(femaleDatapointObject, new Vector3(0, 0, 2), Quaternion.identity);
        femaleDatapoint3.transform.parent = gameObject.transform;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
