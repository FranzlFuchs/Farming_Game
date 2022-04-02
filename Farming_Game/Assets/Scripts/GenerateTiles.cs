using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour
{
    // Start is called before the first frame update

    public int heightNumTiles;
    public int widthNumTiles;
    public GameObject tilePrefab;

    private Vector3 startingPoint = new Vector3(0, 0, 0);
    private Vector3 spawnPoint;


    void Start()
    {

        float heightTile;
        float widthTile;

        heightTile = tilePrefab.GetComponent<MeshRenderer>().bounds.size.z;
        Debug.Log("height" + heightTile);
        widthTile = tilePrefab.GetComponent<MeshRenderer>().bounds.size.x;
        Debug.Log("width" + widthTile);
        spawnPoint = startingPoint;
        for (int w = 0; w < widthNumTiles; w++)
        {
            spawnPoint.x = spawnPoint.x + startingPoint.x + (widthTile * w);
            spawnPoint.z = startingPoint.z;

            for (int h = 0; h < heightNumTiles; h++)
            {
                Instantiate(tilePrefab, spawnPoint, tilePrefab.transform.rotation);
                spawnPoint.x = spawnPoint.x + (widthTile / 2);
                spawnPoint.z = spawnPoint.z +  3 *  (heightTile / 4);

            }

            spawnPoint = startingPoint;
        }

        /*
                for (int w = 0; w < widthNumTiles; w++)
                {
                    spawnPoint.x = spawnPoint.x + startingPoint.x + (w * widthTile);
                    spawnPoint.z = startingPoint.z;

                    for (int h = 0; h < heightNumTiles; h++)
                    {
                        Debug.Log(spawnPoint);
                        spawnPoint.x = spawnPoint.x + (widthTile / 2);
                        spawnPoint.z = spawnPoint.z + (heightTile / 2);
                    }
                }
                */

    }

    // Update is called once per frame
    void Update()
    {

    }
}
