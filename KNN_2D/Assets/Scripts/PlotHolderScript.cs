using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.Plastic.Newtonsoft.Json.Linq;
using UnityEngine;

public class PlotHolderScript : MonoBehaviour
{
    public GameObject yAxisTickObject;
    public GameObject xAxisTickObject;

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

    private JObject jsonConfig;


    // Start is called before the first frame update
    void Start()
    {
        // read JSON
        jsonConfig = JObject.Parse(File.ReadAllText(@"Assets\Config\card_configuration.json"));
    }

    public void HandleQrCode(string qrCodeData)
    {
        // Homer Simpson - 90kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 1")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(1))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard1"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard1"]["height"];

                HandleMaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(1);
            }
        }

        // Marge Simpson - 70kg - 1,70m
        if (qrCodeData == "KNN Tutorial Card 2")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(2))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard2"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard2"]["height"];

                HandleFemaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(2);
            }
        }

        // Rick Sanchez - 70kg - 1,90m
        if (qrCodeData == "KNN Tutorial Card 3")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(3))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard3"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard3"]["height"];

                HandleMaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(3);
            }
        }

        // Summer Smith - 70kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 4")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(4))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard4"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard4"]["height"];

                HandleFemaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(4);
            }
        }

        // Randy Marsh - 80kg - 1,70m
        if (qrCodeData == "KNN Tutorial Card 5")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(5))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard5"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard5"]["height"];

                HandleMaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(5);
            }
        }

        // Liane Cartman - 60kg - 1,50m
        if (qrCodeData == "KNN Tutorial Card 6")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(6))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard6"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard6"]["height"];

                HandleFemaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(6);
            }
        }

        // Peter Griffin - 100kg - 1,80m
        if (qrCodeData == "KNN Tutorial Card 7")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(7))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard7"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard7"]["height"];

                HandleMaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(7);
            }
        }

        // Lois Griffin - 65kg - 1,60m
        if (qrCodeData == "KNN Tutorial Card 8")
        {
            if (!dataPointIdsAlreadyLoaded.Contains(8))
            {
                // load card information from JSON
                int weight = (int)jsonConfig["tutorialcards"]["tutorialcard8"]["weight"];
                int height = (int)jsonConfig["tutorialcards"]["tutorialcard8"]["height"];

                HandleFemaleTutorialcardInternal(weight, height);

                dataPointIdsAlreadyLoaded.Add(8);
            }
        }

        // Test Card 1 - k=1 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 1")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard11"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard11"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard11"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 1 - k=2 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 2")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard12"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard12"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard12"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 1 - k=3 - 80kg - 1,80m
        if (qrCodeData == "KNN Test Card 1 3")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard13"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard13"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard13"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 2 - k=1 - 60kg - 1,60m
        if (qrCodeData == "KNN Test Card 2 1")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard21"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard21"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard21"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 2 - k=2 - 60kg - 1,60m
        if (qrCodeData == "KNN Test Card 2 2")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard22"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard22"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard22"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 2 - k=3 - 60kg - 1,60m
        if (qrCodeData == "KNN Test Card 2 3")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard23"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard23"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard23"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 3 - k=1 - 100kg - 2m
        if (qrCodeData == "KNN Test Card 3 1")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard31"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard31"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard31"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 3 - k=2 - 100kg - 2m
        if (qrCodeData == "KNN Test Card 3 2")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard32"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard32"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard32"]["height"];

            HandleTestcardInternal(k, weight, height);
        }

        // Test Card 3 - k=3 - 100kg - 2m
        if (qrCodeData == "KNN Test Card 3 3")
        {
            // load card information from JSON
            int k = (int)jsonConfig["testcards"]["testcard33"]["k"];
            int weight = (int)jsonConfig["testcards"]["testcard33"]["weight"];
            int height = (int)jsonConfig["testcards"]["testcard33"]["height"];

            HandleTestcardInternal(k, weight, height);
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
    private void HandleFemaleTutorialcardInternal(int weight, int height)
    {
        // calculate 3D position from card information
        double xPoisiton = -0.5 + ((double)weight / 100);
        double yPoisiton = (double)height / 200;

        Vector3 dataPointNormalPosition = new Vector3((float)xPoisiton, (float)yPoisiton, 0);

        GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, femaleDatapointObject);
        dataPointsForClassification.Add(new DataPoint(weight, height, Gender.Female, dataPointGameObject));
    }

    private void HandleMaleTutorialcardInternal(int weight, int height)
    {
        // calculate 3D position from card information
        double xPoisiton = -0.5 + ((double)weight / 100);
        double yPoisiton = (double)height / 200;

        Vector3 dataPointNormalPosition = new Vector3((float)xPoisiton, (float)yPoisiton, 0);

        GameObject dataPointGameObject = CreateGameObjectForDataPoint(dataPointNormalPosition, maleDatapointObject);
        dataPointsForClassification.Add(new DataPoint(weight, height, Gender.Male, dataPointGameObject));
    }

    private void HandleTestcardInternal(int k, int weight, int height)
    {
        // calculate 3D position from card information
        double xPoisiton = -0.5 + ((double)weight / 100);
        double yPoisiton = (double)height / 200;

        Vector3 dataPointNormalPosition = new Vector3((float)xPoisiton, (float)yPoisiton, 0);

        Gender classifiedGender = Classify(k, weight, height);
        GameObject dataPointGameObject = AddClassifiedDatapoint(classifiedGender, dataPointNormalPosition);
        classifiedDataPoint = new DataPoint(weight, height, classifiedGender, dataPointGameObject);
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
