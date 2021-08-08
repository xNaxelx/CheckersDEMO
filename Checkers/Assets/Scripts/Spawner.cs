using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject CellWhite, CellBlack, barier;
    [SerializeField] private Grid _grid;
    private bool CellColorBlack = true;
    public static List<GameObject> checks_storage = new List<GameObject>(24);

    void Awake()
    {
        //check
        for (float x = 0, y = 0; y < 8; y++)
        {
            if (y % 2 == 1) { x++; }
            for (; x < 8; x += 2)
            {
                if (y < 3)
                { checks_storage.Add(GameObject.Instantiate(CellWhite, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity)); }
                else if (y > 4)
                { checks_storage.Add(GameObject.Instantiate(CellBlack, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity)); }
                CellColorBlack = !CellColorBlack;
            }
            CellColorBlack = !CellColorBlack;
            x = 0;

        }
        //barier
        for (int x = -2, y = -1; x < 10; x++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
        for (int x = -2, y = -2; x < 10; x++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
        for (int x = -2, y = 8; x < 10; x++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
        for (int x = -2, y = 9; x < 10; x++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }

        for (int x = -2, y = 0; y < 8; y++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
        for (int x = -1, y = 0; y < 8; y++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
        for (int x = 8, y = 0; y < 8; y++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
        for (int x = 9, y = 0; y < 8; y++)
        {
            GameObject.Instantiate(barier, _grid.LocalToWorld(new Vector3(x, y, -1)), Quaternion.identity);
        }
    }

}