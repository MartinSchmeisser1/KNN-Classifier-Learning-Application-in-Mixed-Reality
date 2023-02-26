using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlotHolderScript : MonoBehaviour
{
    public GameObject xAxisObject;
    public GameObject yAxisObject;
    public GameObject zAxisObject;

    public GameObject maleDatapointObject;
    public GameObject maleDatapointObjectRed;
    public GameObject femaleDatapointObject;
    public GameObject femaleDatapointObjectRed;
    public GameObject unclassifiedDatapointObject;

    public Material blueMaterial;
    public Material pinkMaterial;
    public Material yellowMaterial;
    public Material redMaterial;

    private List<DataPoint> dataPointsForClassification = new List<DataPoint>();
    private List<int> dataPointIdsAlreadyLoaded = new List<int>();

    private DataPoint classifiedDataPoint = null;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate X-Axis objects
        float yCoordinate = (float)-0.4;
        while (yCoordinate < 0.5)
        {
            float zCoordinate = 2;
            while (zCoordinate < 3)
            {
                Vector3 position = new Vector3(0, yCoordinate, zCoordinate);
                GameObject axisObject = Instantiate(xAxisObject, position, Quaternion.identity, gameObject.transform.Find("X-Axis"));
                axisObject.transform.localScale = new Vector3(1, (float)0.001, (float)0.001);
                zCoordinate = zCoordinate + (float)0.1;
            }
            yCoordinate = yCoordinate + (float)0.1;
        }

        // Instantiate Y-Axis objects
        float xCoordinate = (float)-0.5;
        while (xCoordinate < 0.5)
        {
            float zCoordinate = 2;
            while (zCoordinate < 3)
            {
                Vector3 position = new Vector3(xCoordinate, (float)0.005, zCoordinate);
                GameObject axisObject = Instantiate(yAxisObject, position, Quaternion.identity, gameObject.transform.Find("Y-Axis"));
                axisObject.transform.localScale = new Vector3((float)0.001, 1, (float)0.001);
                zCoordinate = zCoordinate + (float)0.1;
            }
            xCoordinate = xCoordinate + (float)0.1;
        }

        // Instantiate Z-Axis objects
        xCoordinate = (float)-0.5;
        while (xCoordinate < 0.5)
        {
            yCoordinate = (float)-0.4;
            while (yCoordinate < 0.5)
            {
                Vector3 position = new Vector3(xCoordinate, yCoordinate, (float)2.5);
                GameObject axisObject = Instantiate(zAxisObject, position, Quaternion.identity, gameObject.transform.Find("Z-Axis"));
                axisObject.transform.localScale = new Vector3((float)0.001, (float)0.001, 1);
                yCoordinate = yCoordinate + (float)0.1;
            }
            xCoordinate = xCoordinate + (float)0.1;
        }
    }

    public void HandleQrCode(string qrCodeData)
    {
        // Homer Simpson - 90kg - 1,80m - 2%
        if (qrCodeData == "KNN 3D Tutorial Card 1")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(1))
            {
                HandleMaleTutorialcardInternal(90, 180, 2);

                dataPointIdsAlreadyLoaded.Add(1);
            }
        }

        // Marge Simpson - 70kg - 1,70m - 100%
        if (qrCodeData == "KNN 3D Tutorial Card 2")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(2))
            {
                HandleFemaleTutorialcardInternal(70, 170, 100);

                dataPointIdsAlreadyLoaded.Add(2);
            }
        }

        // Rick Sanchez - 70kg - 1,90m - 30%
        if (qrCodeData == "KNN 3D Tutorial Card 3")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(3))
            {
                HandleMaleTutorialcardInternal(70, 190, 30);

                dataPointIdsAlreadyLoaded.Add(3);
            }
        }

        // Summer Smith - 70kg - 1,80m- 80%
        if (qrCodeData == "KNN 3D Tutorial Card 4")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(4))
            {
                HandleFemaleTutorialcardInternal(70, 180, 80);

                dataPointIdsAlreadyLoaded.Add(4);
            }
        }

        // Randy Marsh - 80kg - 1,70m - 40%
        if (qrCodeData == "KNN 3D Tutorial Card 5")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(5))
            {
                HandleMaleTutorialcardInternal(80, 170, 40);

                dataPointIdsAlreadyLoaded.Add(5);
            }
        }

        // Liane Cartman - 60kg - 1,50m - 70%
        if (qrCodeData == "KNN 3D Tutorial Card 6")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(6))
            {
                HandleFemaleTutorialcardInternal(60, 150, 70);

                dataPointIdsAlreadyLoaded.Add(6);
            }
        }

        // Peter Griffin - 100kg - 1,80m - 50%
        if (qrCodeData == "KNN 3D Tutorial Card 7")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(7))
            {
                HandleMaleTutorialcardInternal(100, 180, 50);

                dataPointIdsAlreadyLoaded.Add(7);
            }
        }

        // Lois Griffin - 65kg - 1,60m - 70%
        if (qrCodeData == "KNN 3D Tutorial Card 8")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(8))
            {
                HandleFemaleTutorialcardInternal(65, 160, 70);

                dataPointIdsAlreadyLoaded.Add(8);
            }
        }

        // Test Card 1 - k=1 - 80kg - 1,80m - 50%
        if (qrCodeData == "KNN 3D Test Card 1 1")
        {
            HandleTestcardInternal(1, 80, 180, 50);
        }

        // Test Card 1 - k=2 - 80kg - 1,80m - 50%
        if (qrCodeData == "KNN 3D Test Card 1 2")
        {
            HandleTestcardInternal(2, 80, 180, 50);
        }

        // Test Card 1 - k=3 - 80kg - 1,80m - 50%
        if (qrCodeData == "KNN 3D Test Card 1 3")
        {
            HandleTestcardInternal(3, 80, 180, 50);
        }

        // Test Card 2 - k=1 - 60kg - 1,60m - 80%
        if (qrCodeData == "KNN 3D Test Card 2 1")
        {
            HandleTestcardInternal(1, 60, 160, 80);
        }

        // Test Card 2 - k=2 - 60kg - 1,60m - 80%
        if (qrCodeData == "KNN 3D Test Card 2 2")
        {
            HandleTestcardInternal(2, 60, 160, 80);
        }

        // Test Card 2 - k=3 - 60kg - 1,60m - 80%
        if (qrCodeData == "KNN 3D Test Card 2 3")
        {
            HandleTestcardInternal(3, 60, 160, 80);
        }

        // Test Card 3 - k=1 - 100kg - 2m - 30%
        if (qrCodeData == "KNN 3D Test Card 3 1")
        {
            HandleTestcardInternal(1, 100, 200, 30);
        }

        // Test Card 3 - k=2 - 100kg - 2m - 30%
        if (qrCodeData == "KNN 3D Test Card 3 2")
        {
            HandleTestcardInternal(2, 100, 200, 30);
        }

        // Test Card 3 - k=3 - 100kg - 2m - 30%
        if (qrCodeData == "KNN 3D Test Card 3 3")
        {
            HandleTestcardInternal(3, 100, 200, 30);
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
    private void HandleFemaleTutorialcardInternal(int weight, int height, int hairvolume)
    {
        // calculate 3D position from card information
        double xPoisiton = -0.5 + ((double)weight / 100);
        double yPoisiton = (double)height / 200;
        double zPoisiton = (double)hairvolume / 100;
        Vector3 dataPointNormalPosition = new Vector3((float)xPoisiton, (float)yPoisiton, (float)zPoisiton);

        GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObject);
        dataPointsForClassification.Add(new DataPoint(weight, height, hairvolume, Gender.Female, dataPointGameObject));
    }

    private void HandleMaleTutorialcardInternal(int weight, int height, int hairvolume)
    {
        // calculate 3D position from card information
        double xPoisiton = -0.5 + ((double)weight / 100);
        double yPoisiton = (double)height / 200;
        double zPoisiton = (double)hairvolume / 100;
        Vector3 dataPointNormalPosition = new Vector3((float)xPoisiton, (float)yPoisiton, (float)zPoisiton);

        GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObject);
        dataPointsForClassification.Add(new DataPoint(weight, height, hairvolume, Gender.Male, dataPointGameObject));
    }

    private void HandleTestcardInternal(int k, int weight, int height, int hairvolume)
    {
        // calculate 3D position from card information
        double xPoisiton = -0.5 + ((double)weight / 100);
        double yPoisiton = (double)height / 200;
        double zPoisiton = (double)hairvolume / 100;
        Vector3 dataPointNormalPosition = new Vector3((float)xPoisiton, (float)yPoisiton, (float)zPoisiton);

        Gender classifiedGender = Classify(k, weight, height, hairvolume);
        GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
        classifiedDataPoint = new DataPoint(weight, height, hairvolume, classifiedGender, dataPointGameObject);
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

    // Edge case: multiple neighbors in same distance?
    // There is no good way to handle this. 
    // Currently, the datapoint that was added first is considered when multiple points have the same distance.
    // I think this is a fair way to handle this.

    private Gender Classify(int k, int weight, int height, int hairvolume)
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
            dataPoint.Distance = Mathf.Sqrt(Mathf.Pow((dataPoint.Weight - weight), 2) + (Mathf.Pow(((dataPoint.Height - height)/2), 2)) + (Mathf.Pow((dataPoint.Hairvolume - hairvolume), 2)));
        }

        // sort data points by distance
        List<DataPoint> dataPointsForClassificationSorted = dataPointsForClassification.OrderBy(o => o.Distance).ToList();

        // only consider k nearest data points
        List<DataPoint> dataPointsForClassificationSortedAndTrimmed = dataPointsForClassificationSorted.Take(k).ToList();

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
}
