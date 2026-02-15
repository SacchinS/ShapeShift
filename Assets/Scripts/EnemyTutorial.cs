using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTutorial : MonoBehaviour
{
    public Tutorial tutorialScript;
    public GameObject player;

    public bool once;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Animator>().SetInteger("sides", 5);
        once = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - player.transform.position.x < 10)
        {
            if (once)
            {
                tutorialScript.tutorial6 = true;
                Camera.main.GetComponent<CameraZoom>().ZoomActive = true;
                Time.timeScale = 0;
                once = false;
            }

            else if (Time.timeScale == 0.2f)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
            }
        }
    }
}
