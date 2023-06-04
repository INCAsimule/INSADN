using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float TimeScale = 24.0f * 60.0f * 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = TimeScale;
    }

    // Update is called once per frame
    void Update()
    {
        float dayTime = Time.time % (24.0f * 60.0f * 60.0f);
        this.transform.localRotation = Quaternion.Euler((dayTime / (24.0f)) * 360.0f, 0.0f, 0.0f);
    }
}
