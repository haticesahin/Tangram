using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject tans;
    private PlacementIndicator placementIndicator;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    public void Tans()
    {
         GameObject obj = Instantiate(tans, placementIndicator.transform.position, placementIndicator.transform.rotation);
    }
}
