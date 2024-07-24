using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverGeneration : GenerationParent
{
    List<Vector2> possibleNextLocationBottomUp = new List<Vector2>();
    public override void Initialise(ObjectPool targetWaterPool)
    {
        base.Initialise(targetWaterPool);
        generationTemplateName = "River";

        possibleNextLocationBottomUp.Add(new Vector2(-1, 0));                  // allows the generation to choose next tile to turn into water
        possibleNextLocationBottomUp.Add(new Vector2(1, 0));
        possibleNextLocationBottomUp.Add(new Vector2(0, 1));

    }

    public override void GenerateMap(ObjectPool primaryTerrainPool, ObjectPool roadPool)
    {
        Vector2 nextLocation;
        List<Vector2> waterLocations = new List<Vector2>();         // generates a list of target water locations

        int xCoordinate = Random.Range(2, 7);                       // start location of the river
        Vector2 currentLocation = new Vector2(xCoordinate, 0);
            
        waterLocations.Add(currentLocation);
        while (currentLocation.y != 9)                              // code looped until river reaches edge of the map
        {
            nextLocation = currentLocation + possibleNextLocationBottomUp[Random.Range(0, possibleNextLocationBottomUp.Count)];     // random choice + prevents the river from turning wrong way
            if ((nextLocation.x > 1 && nextLocation.x < 8))         // prevents reaching edges of the map
            {
                currentLocation = nextLocation;                     // if new location  >  location added to list
                if (!waterLocations.Contains(currentLocation))
                {
                    waterLocations.Add(currentLocation);
                }
            }
        }

        List<GameObject> freeLand = new List<GameObject>();     // allows to position the road

        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)              // looped based on the map size
            {
                Vector2 checkWaterLocation = new Vector2(x, z);         
                GameObject gameObject;

                if (waterLocations.Contains(checkWaterLocation))        // spawn water
                {
                    gameObject = waterPool.RequestObject();
                }
                else
                {
                    gameObject = primaryTerrainPool.RequestObject();        // otherwise spawn ground
                    freeLand.Add(gameObject);
                }

                Vector3 targetPosition = new Vector3(x, 0, z);      // calculate position + place object
                gameObject.transform.position = targetPosition;
                gameObject.transform.parent = transform;
                gameObject.name = string.Format("{0}, {1}.{2}", primaryTerrainPool.prefab.name, x, z);
            }

        }

        GameObject targetLand = freeLand[Random.Range(0, freeLand.Count)];      // position the road
        Vector3 targetCoordinate = targetLand.transform.position;
        targetLand.SetActive(false);

        GameObject road = roadPool.RequestObject();
        road.transform.position = targetCoordinate;
    }
}
