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
    public int ID;
    public int Weight;
    public int Height;
    public Gender Gender;

    public DataPoint(int id, int weight, int height, Gender gender)
    {
        ID = id;
        Weight = weight;
        Height = height;
        Gender = gender;
    }

}
