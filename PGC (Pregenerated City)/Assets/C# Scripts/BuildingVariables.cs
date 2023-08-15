using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingTags
{

    public enum BuildingType
    {
        Unselected,
        A,
        B, 
        C,
        D,
        E,
        F
    }

    [SerializeField] internal BuildingType blockLocation;
    public BuildingTags() {
        blockLocation = BuildingType.Unselected;
    }
    public BuildingTags(BuildingType BL) {
        blockLocation.Equals(BL);
    }
    public BuildingTags(BuildingTags other) {
        blockLocation = other.blockLocation;
    }

}
/// <summary>
/// A simple attachment  script that handles the variable portion of the Buildings and Blocks
/// </summary>
public class BuildingVariables : MonoBehaviour
{
    [SerializeField] internal BuildingTags buildingTags;
    public enum BlockOrBuilding
    {
        Unselected,
        Block,
        Building
    }
    [SerializeField]internal BlockOrBuilding BOB;

    internal int spawnLimit = 0;

}
