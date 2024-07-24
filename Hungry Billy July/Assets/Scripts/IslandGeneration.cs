using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGeneration : GenerationParent
{
    List<Vector2> possibleNextLocation = new List<Vector2>();
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "Island";

        possibleNextLocation.Add(new Vector2(0, -1));
        possibleNextLocation.Add(new Vector2(0, 1));
        possibleNextLocation.Add(new Vector2(1, 0));
        possibleNextLocation.Add(new Vector2(-1, 0));
    }

    public override void GenerateMap(ObjectPool primaryTerrainPool, ObjectPool roadPool)
    {
        List<Vector2> landLocations = new List<Vector2>();
        int xCoordinate = Random.Range(2, 7);
        int zCoordinate = Random.Range(2, 7);
        landLocations.Add(new Vector2(xCoordinate, zCoordinate));

        Vector2 currentLocation = landLocations[0];
        Vector2 nextLocation;

        while (landLocations.Count != 30)
        {
            nextLocation = currentLocation + possibleNextLocation[Random.Range(0, possibleNextLocation.Count)];
            if ((nextLocation.x > 1 && nextLocation.x < 8) && (nextLocation.y > 1 && nextLocation.y < 8))
            {
                currentLocation = nextLocation;
                if (!landLocations.Contains(currentLocation))
                {
                    landLocations.Add(currentLocation);
                }
            }
        }

        List<GameObject> freeLand = new List<GameObject>();

        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                Vector2 checkWaterLocation = new Vector2(x, z);
                GameObject gameObject;

                if (landLocations.Contains(checkWaterLocation))
                {
                    gameObject = primaryTerrainPool.RequestObject();
                    freeLand.Add(gameObject);
                }
                else
                {
                    gameObject = waterPool.RequestObject();
                }

                Vector3 targetPosition = new Vector3(x, 0, z);
                gameObject.transform.position = targetPosition;
                gameObject.transform.parent = transform;
                gameObject.name = string.Format("{0}, {1}.{2}", primaryTerrainPool.prefab.name, x, z);
            }

        }

        GameObject targetLand = freeLand[Random.Range(0, freeLand.Count)];
        Vector3 targetCoordinate = targetLand.transform.position;
        targetLand.SetActive(false);

        GameObject road = roadPool.RequestObject();
        road.transform.position = targetCoordinate;
    }

}
