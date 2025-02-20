using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNodeData
{
    public bool isAvailable = false;

    public void UpdateAvailability(bool newValue)
    {
        isAvailable = newValue;
    }
}


