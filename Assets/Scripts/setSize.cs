using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setSize : MonoBehaviour
{

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(radius * 2, this.transform.localScale.y, radius * 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
