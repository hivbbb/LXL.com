using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RockSpawner : MonoBehaviour
{
    private Tilemap tilemap;
    public GameObject environment;
    public GameObject Rockresource1;
    public GameObject Rockresource2;
    public GameObject Rockresource3;
    public int Rock1count;
    public int Rock2count;
    public int Rock3count;
    private List<Vector3> grassTileWorldPos = new List<Vector3>();
    private bool[] grassTileHasEmptySlot;
    private int grassTileCount;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        Vector3Int tmOrg = tilemap.origin;
        Vector3Int tmSz = tilemap.size;

        for (int x = tmOrg.x; x < tmSz.x; x++)
        {
            for (int y = tmOrg.y; y < tmSz.y; y++)
            {
                if (tilemap.GetTile(new Vector3Int(x, y, 0)) != null)
                {

                    Vector3 cellToWorldPos = tilemap.GetCellCenterWorld(new Vector3Int(x, y, 0));
                    grassTileWorldPos.Add(cellToWorldPos);

                }
            }
        }

        grassTileCount = grassTileWorldPos.Count;

        grassTileHasEmptySlot = new bool[grassTileCount];
        for (int i = 0; i < grassTileCount; i++)
        {
            grassTileHasEmptySlot[i] = true;
        }

        Randomresource(Rockresource1, Rock1count);
        Randomresource(Rockresource2, Rock2count);
        Randomresource(Rockresource3, Rock3count);

    }
    public void Randomresource(GameObject resource, int resourcecount)
    {
        for (int i = 0; i < resourcecount; i++)
        {
            int aRandomTile = Random.Range(0, grassTileCount);
            if (grassTileHasEmptySlot[aRandomTile])
            {
                Vector3 spawnPos = grassTileWorldPos[aRandomTile];
                GameObject a = Instantiate(resource, spawnPos, Quaternion.identity);
                a.transform.parent = environment.transform;
                grassTileHasEmptySlot[aRandomTile] = false;
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
