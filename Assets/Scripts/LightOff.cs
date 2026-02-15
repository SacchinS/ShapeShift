using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.activeSelf == false)
            {
                this.gameObject.GetComponent<Animator>().SetBool("gameOver", true);
            }
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("gameOver", true);
        }

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
