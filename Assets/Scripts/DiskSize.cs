using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskSize : MonoBehaviour
{

    public float Radius = 10;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(Radius * 2, this.transform.localScale.y, Radius * 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
