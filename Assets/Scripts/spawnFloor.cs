using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFloor : MonoBehaviour
{
    public int radius;     //will actually do radius + 0.5
    public GameObject tilePrefab;
    private Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(0, -tilePrefab.transform.localScale.y, 0);
        tilePrefab.transform.localScale = new Vector3(radius, tilePrefab.transform.localScale.y, radius);
        Instantiate(tilePrefab, position, new Quaternion(0,0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
