using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotate : MonoBehaviour
{
    public float start;

    // Start is called before the first frame update
    void Start()
    {
        start = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, (start+=0.5f));
    }
}
