using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

[CreateAssetMenu(fileName = "PathfindingData", menuName = "ScriptableObjects/PathfindingData", order = 1)]
public class Pathfinding2Data : ScriptableObject
{
    public List<Cell2> cellsValue;
}
