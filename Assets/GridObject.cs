using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] Grid grid;
    public static GridObject instance;

    private Dictionary<Vector2, GridNodeData> gridNodes = new Dictionary<Vector2, GridNodeData>();

    public void InsertGridNode(Vector2 vector)
    {
        gridNodes.TryAdd(vector, new GridNodeData());
    }

    public void UpdateNodeAvailability(Vector2 vector,bool value)
    {
        gridNodes.TryGetValue(vector, out GridNodeData data);
        data.UpdateAvailability(value);
    }

    public bool CheckNodeAvailability(Vector2 vector)
    {
        gridNodes.TryGetValue(vector, out GridNodeData data);
        if (data != null)
            return data.isAvailable;
        else 
            return false;
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //initialize map with all nodes
        SetMap();
    }

    private void SetMap()
    {
        for (int i = -22; i <= 22; i++)
        {
            for (int j = -12; j <= 12; j++)
            {
                InsertGridNode(new Vector2(i, j));
            }
        }

        for (int i = -22; i <= 22; i++)
        {
            for (int j = -12; j <= 12; j++)
            {
                UpdateNodeAvailability(new Vector2(i, j), true);
            }
        }
        Debug.Log($"Grid all node count: {gridNodes.Keys.Count}");
        //foreach (Vector2 item in gridNodes.Keys)
        //{

        //    gridNodes.TryGetValue(item, out GridNodeData data);
        //    Debug.Log($"Grid all nodes: {item} {data.isAvailable}");
        //}
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.magenta;
        for (int i = -21; i <= 21; i++)
        {
            for (int j = -11; j <= 11; j++)
            {
                if(CheckNodeAvailability(new Vector3(i, j, 0)))
                    Gizmos.DrawSphere(grid.WorldToCell(new Vector3Int(i,j,0)), .25f);
            }
        }
    }
}
