using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotHolderInstanciation : MonoBehaviour
{

    public GameObject yAxisTickObject;
    public GameObject xAxisTickObject;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -4; i < 5; i++)
        {
            var tick = Instantiate(yAxisTickObject, new Vector3(-5, i, 15), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
        }


        for (int i = -4; i < 5; i++)
        {
            var tick = Instantiate(xAxisTickObject, new Vector3(i, -5, 15), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
