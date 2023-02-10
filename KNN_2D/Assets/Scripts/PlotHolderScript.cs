using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlotHolderScript : MonoBehaviour
{
    public GameObject yAxisTickObject;
    public GameObject xAxisTickObject;

    public GameObject maleDatapointObject;
    public GameObject maleDatapointObjectRed;
    // public GameObject maleDatapointObjectYellow;
    public GameObject femaleDatapointObject;
    public GameObject femaleDatapointObjectRed;
    // public GameObject femaleDatapointObjectYellow;
    public GameObject unclassifiedDatapointObject;

    public Material blueMaterial;
    public Material pinkMaterial;
    public Material yellowMaterial;
    public Material redMaterial;

    private List<DataPoint> dataPointsForClassification = new List<DataPoint>();
    private List<int> dataPointIdsAlreadyLoaded = new List<int>();

    private DataPoint classifiedDataPoint = null;



    //Vector3 dataPointNormalScale = new Vector3((float)0.05, (float)0.05, (float)0.05);

    // Start is called before the first frame update
    void Start()
    {

        // initialize y-axis-ticks
        double tmpCoordinate = -0.4;
        while (tmpCoordinate < 0.5)
        {
            var tick = Instantiate(yAxisTickObject, new Vector3((float)-0.5, (float)tmpCoordinate, 2), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
            tmpCoordinate = tmpCoordinate + 0.1;
        }

        // initialize x-axis-ticks
        tmpCoordinate = -0.4;
        while (tmpCoordinate < 0.5)
        {
            var tick = Instantiate(xAxisTickObject, new Vector3((float)tmpCoordinate, (float)-0.5, 2), Quaternion.identity);
            tick.transform.parent = gameObject.transform;
            tmpCoordinate = tmpCoordinate + 0.1;
        }


     }

    // Update is called once per frame
    void Update()
    {

    }


    private GameObject CreateGameObjectForDataPoint(Vector3 dataPointNormalPosition, GameObject dataPointGameObject)
    {
        // Consider plot scaling on the normal DataPoint position
        Vector3 plotLocalScale = gameObject.transform.localScale;
        Vector3 dataPointNormalPositionScaled = Vector3.Scale(dataPointNormalPosition, plotLocalScale);

        // Add plot position to DataPoint position
        Vector3 plotPosition = gameObject.transform.position;
        Vector3 dataPointPosition = dataPointNormalPositionScaled + plotPosition;

        // Instantiate DataPoint
        var datapointInstance = Instantiate(dataPointGameObject, dataPointPosition, gameObject.transform.rotation, gameObject.transform);

        return datapointInstance;
    }

    private GameObject AddClassifiedDatapoint(Gender classifiedGender, Vector3 dataPointNormalPosition)
    {
        if (classifiedGender == Gender.Male)
        {
            return CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObjectRed);
        }
        else if (classifiedGender == Gender.Female)
        {
            return CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObjectRed);
        }
        else
        {
            return CreateGameObjectForDataPoint(dataPointNormalPosition, unclassifiedDatapointObject);
        }
    }

    // TODO: edge case: multiple neighbors in same distance?
    // - There is no good way to handle this 
    // Currently, the datapoint that was added first is considered when multiple points have the same distance

    private Gender Classify(int k, int weight, int height)
    {
        // reset highlighted datapoints 
        ResetHighlightedDatapoints();

        // delete last classified datapoint
        if (classifiedDataPoint != null)
        {
            Destroy(classifiedDataPoint.GameObject);
            classifiedDataPoint = null;
        }

        // if no data point was created yet return unclassifed
        if (!dataPointsForClassification.Any())
        {
            return Gender.Unclassified;
        }

        // calculate distances to all other points
        foreach (DataPoint dataPoint in dataPointsForClassification)
        {
            dataPoint.Distance = Mathf.Sqrt(Mathf.Pow((dataPoint.Weight - weight), 2) + (Mathf.Pow((dataPoint.Height - height), 2)));
            Debug.Log("dataPoint.Distance = " + dataPoint.Distance);
        }

        Debug.Log("dataPointsForClassification count = " + dataPointsForClassification.Count());


        // sort data points by distance
        List<DataPoint> dataPointsForClassificationSorted = dataPointsForClassification.OrderBy(o => o.Distance).ToList();

        Debug.Log("dataPointsForClassificationSorted count = " + dataPointsForClassificationSorted.Count());


        // only consider k nearest data points
        List<DataPoint> dataPointsForClassificationSortedAndTrimmed = dataPointsForClassificationSorted.Take(k).ToList();

        Debug.Log("dataPointsForClassificationSortedAndTrimmed count = " + dataPointsForClassificationSortedAndTrimmed.Count());

        // highlight datapoints that were used for classification
        foreach (DataPoint dataPoint in dataPointsForClassificationSortedAndTrimmed)
        {
            // change material of gameobject
            dataPoint.GameObject.GetComponent<MeshRenderer>().material = yellowMaterial;
        }

        // count male/female points
        int maleCounter = 0;
        int femaleCounter = 0;
        foreach (DataPoint dataPoint in dataPointsForClassificationSortedAndTrimmed)
        {
            if (dataPoint.Gender == Gender.Male)
            {
                maleCounter++;
            }
            if (dataPoint.Gender == Gender.Female)
            {
                femaleCounter++;
            }
        }

        // return classified gender
        if (femaleCounter > maleCounter)
        {
            return Gender.Female;
        }
        else if (maleCounter > femaleCounter)
        {
            return Gender.Male;
        }
        else
        {
            return Gender.Unclassified;
        }
    }

    private void ResetHighlightedDatapoints()
    {
        foreach (DataPoint dataPoint in dataPointsForClassification)
        {
            // change material of gameobject
            if (dataPoint.Gender == Gender.Male)
            {
                dataPoint.GameObject.GetComponent<MeshRenderer>().material = blueMaterial;
            }
            if (dataPoint.Gender == Gender.Female)
            {
                dataPoint.GameObject.GetComponent<MeshRenderer>().material = pinkMaterial;
            }
        }
    }


    // ---------------------------------- Handling QR Codes ----------------------------------
    public void HandleQrCode(string qrCodeData)
    {
        // Homer Simpson - 90kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 1")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(1))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.4, (float)0.9, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(1, 90, 180, Gender.Male, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(1);
            }
        }

        // Marge Simpson - 70kg - 1,70m
        if (qrCodeData == "KNN Tutorial Card 2")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(2))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.85, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(2, 70, 170, Gender.Female, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(2);
            }
        }

        // Rick Sanchez - 70kg - 1,90m
        if (qrCodeData == "KNN Tutorial Card 3")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(3))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.95, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(3, 70, 190, Gender.Male, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(3);
            }
        }

        // Summer Smith - 70kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 4")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(4))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.2, (float)0.9, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(4, 70, 180, Gender.Female, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(4);
            }
        }

        // Randy Marsh - 80kg - 1,70m
        if (qrCodeData == "KNN Tutorial Card 5")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(5))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.3, (float)0.85, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(4, 80, 170, Gender.Male, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(5);
            }
        }

        // Liane Cartman - 60kg - 1,50m
        if (qrCodeData == "KNN Tutorial Card 6")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(6))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.1, (float)0.75, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(4, 60, 150, Gender.Female, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(6);
            }
        }

        // Peter Griffin - 100kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 7")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(7))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.5, (float)0.9, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(4, 100, 180, Gender.Male, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(7);
            }
        }

        // Lois Griffin - 65kg - 1,60m
        if (qrCodeData == "KNN Tutorial Card 8")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(8))
            {
                Vector3 dataPointNormalPosition = new Vector3((float)0.15, (float)0.8, 0);
                GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObject);
                dataPointsForClassification.Add(new DataPoint(4, 65, 160, Gender.Female, dataPointGameObject));
                dataPointIdsAlreadyLoaded.Add(8);
            }
        }

        // Test Card 1 - k=1 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 1")
        {
            Gender classifiedGender = Classify(1, 80, 180);
            Vector3 dataPointNormalPosition = new Vector3((float)0.3, (float)0.9, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 80, 180, classifiedGender, dataPointGameObject);
        }

        // Test Card 1 - k=2 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 2")
        {
            Gender classifiedGender = Classify(2, 80, 180);
            Vector3 dataPointNormalPosition = new Vector3((float)0.3, (float)0.9, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 80, 180, classifiedGender, dataPointGameObject);
        }

        // Test Card 1 - k=3 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 3")
        {
            Gender classifiedGender = Classify(3, 80, 180);
            Vector3 dataPointNormalPosition = new Vector3((float)0.3, (float)0.9, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 80, 180, classifiedGender, dataPointGameObject);
        }

        // Test Card 2 - k=1 - 60kg - 1,60m
        if (qrCodeData == "KNN Test Card 2 1")
        {
            Gender classifiedGender = Classify(1, 60, 160);
            Vector3 dataPointNormalPosition = new Vector3((float)0.1, (float)0.8, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 60, 160, classifiedGender, dataPointGameObject);
        }

        // Test Card 2 - k=2 - 60kg - 1,60m
        if (qrCodeData == "KNN Test Card 2 2")
        {
            Gender classifiedGender = Classify(2, 60, 160);
            Vector3 dataPointNormalPosition = new Vector3((float)0.1, (float)0.8, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 60, 160, classifiedGender, dataPointGameObject);
        }

        // Test Card 2 - k=3 - 60kg - 1,60m
        if (qrCodeData == "KNN Test Card 2 3")
        {
            Gender classifiedGender = Classify(3, 60, 160);
            Vector3 dataPointNormalPosition = new Vector3((float)0.1, (float)0.8, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 60, 160, classifiedGender, dataPointGameObject);
        }

        // Test Card 3 - k=1 - 100kg - 2m
        if (qrCodeData == "KNN Test Card 3 1")
        {
            Gender classifiedGender = Classify(1, 100, 200);
            Vector3 dataPointNormalPosition = new Vector3((float)0.5, 1, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 100, 200, classifiedGender, dataPointGameObject);
        }

        // Test Card 3 - k=2 - 100kg - 2m
        if (qrCodeData == "KNN Test Card 3 2")
        {
            Gender classifiedGender = Classify(2, 100, 200);
            Vector3 dataPointNormalPosition = new Vector3((float)0.5, 1, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 100, 200, classifiedGender, dataPointGameObject);
        }

        // Test Card 3 - k=3 - 100kg - 2m
        if (qrCodeData == "KNN Test Card 3 3")
        {
            Gender classifiedGender = Classify(3, 100, 200);
            Vector3 dataPointNormalPosition = new Vector3((float)0.5, 1, 0);
            GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
            classifiedDataPoint = new DataPoint(1, 100, 200, classifiedGender, dataPointGameObject);
        }

        // Reset Card
        if (qrCodeData == "KNN Reset")
        {
            foreach (DataPoint dataPoint in dataPointsForClassification)
            {
                Destroy(dataPoint.GameObject);
            }
            dataPointsForClassification.Clear();
            dataPointIdsAlreadyLoaded.Clear();

            if (classifiedDataPoint != null)
            {
                Destroy(classifiedDataPoint.GameObject);
                classifiedDataPoint = null;
            }
        }
    }

    public void TestFunctionForButton()
    {
        //HandleQrCode("KNN Tutorial Card 1");
        //HandleQrCode("KNN Tutorial Card 2");
        //HandleQrCode("KNN Tutorial Card 3");
        //HandleQrCode("KNN Tutorial Card 4");

        //HandleQrCode("KNN Test Card 1 2");

    }


    public void TestFunctionForButton2()
    {

        //HandleQrCode("KNN Test Card 2 3");
    }
}
