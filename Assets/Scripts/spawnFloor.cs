using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFloor : MonoBehaviour
{
    public int radius;     //will actually do radius + 0.5
    public GameObject tilePrefab;
    private Vector3 position;
    private Vector3 rotation;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = -radius; i < radius + 1; i++)
        {
            for (int j = -radius; j < radius + 1; j++)
            {
                if (i*i + j*j <= radius*radius)
                {
                    position = new Vector3(i - 0.5f, -tilePrefab.transform.localScale.y, j + 0.5f);
                    Instantiate(tilePrefab, position, new Quaternion(0, 0, 0, 0));
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
