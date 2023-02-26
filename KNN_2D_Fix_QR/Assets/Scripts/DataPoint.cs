using UnityEngine;

public enum Gender
{
    Male,
    Female,
    Unclassified
}

class DataPoint
{
    public int Weight { get; private set; }
    public int Height { get; private set; }
    public Gender Gender { get; private set; }
    public float Distance { get; set; }
    public GameObject GameObject { get; set; }

    public DataPoint(int weight, int height, Gender gender, GameObject gameObject)
    {
        Weight = weight;
        Height = height;
        Gender = gender;
        Distance = 0;
        GameObject = gameObject;
    }

}
