using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    GameObject player;
    GameObject janitor;

    private Vector2 startPos;
    public float moveSpeed = 5f;

    public int sides;

    public float tempTime;
    private bool timeChanged;

    public int enemyColor;

    Animator anim;

    void Awake()
    {
        player = GameObject.Find("Player");
        janitor = GameObject.Find("The Janitor...");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        timeChanged = false;
        sides = Random.Range(3, 9);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("sides", sides);

        if (GameObject.Find("Player") != null)
        {
            if (transform.position.x - player.transform.position.x < 12)
            {
                Camera.main.GetComponent<CameraZoom>().ZoomActive = true;

                if (!timeChanged)
                {
                    player.GetComponent<PlayerJump>().tempTime = Time.timeScale;
                    timeChanged = true;
                }

                if (!player.GetComponent<PlayerJump>().paused)
                {
                    Time.timeScale = 0.2f*player.GetComponent<PlayerJump>().tempTime;
                }

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            }

            else
            {
                transform.Translate(Vector2.left * 5 * Time.deltaTime);
            }
        }

        else
        {
            transform.Translate(Vector2.left * 7 * Time.deltaTime);
        }
    }
}
