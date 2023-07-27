using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingTags : MonoBehaviour
{

    public const string gameController = "GameController";

    public enum BlockLocation
    {
        A,
        B, 
        C,
        D,
        E,
        F
    }public enum BUldingType
    {
        A,
        B, 
        C,
        D,
        E,
        F
    }
    //blocks
    public const string blockA = "Block A";
    public const string blockB = "Block B";
    public const string blockC = "Block C";
    public const string blockD = "Block D";
    public const string blockE = "Block E";
    public const string blockF = "Block F";
    //buildings
    public const string buildingA = "Building A";
    public const string buildingB = "Building B";
    public const string buildingC = "Building C";
    public const string buildingD = "Building D";
    public const string buildingE = "Building E";
    public const string buildingF = "Building F";

}
