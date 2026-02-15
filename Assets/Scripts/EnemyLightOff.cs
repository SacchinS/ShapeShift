using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Settings Background") != null)
        {

            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>().enabled = true;
        }
    }
}
