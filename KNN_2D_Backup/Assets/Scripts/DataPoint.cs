using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    Male,
    Female,
    Unclassified
}

class DataPoint
{
    public int ID { get; private set; }
    public int Weight { get; private set; }
    public int Height { get; private set; }
    public Gender Gender { get; private set; }
    public float Distance { get; set; }
    public GameObject GameObject { get; set; }

    public DataPoint(int id, int weight, int height, Gender gender, GameObject gameObject)
    {
        ID = id;
        Weight = weight;
        Height = height;
        Gender = gender;
        Distance = 0;
        GameObject = gameObject;
    }

}
