using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

    public float speed;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (((gameObject.name == "Spikes" || gameObject.name == "Spikes 2")) && (gameObject.transform.position.x <= -40.33219f))
        {
            gameObject.transform.position = new Vector2(31.9f, -4.7f);
        }
    }
}
