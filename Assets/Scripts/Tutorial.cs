using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public bool ZoomActive;
    public Vector3[] Target;
    public Camera cam;
    public float Speed;

    public GameObject screenTap;

    bool tutorial1;
    bool tutorial2;
    bool tutorial3;
    bool tutorial4;
    bool tutorial5;
    public bool tutorial6;

    bool isGrounded;
    Rigidbody2D rb;

    public GameObject dialogue;
    Animator diaAnim;

    public GameObject particles;

    public GameObject plusButton;
    public GameObject minusButton;

    public GameObject addToken;
    public GameObject tokenIcon;
    public Text tokenText;

    public GameObject tutorialBG;

    public Button skip;

    public GameObject enemy;
    public GameObject redExplosion;

    public AudioSource enemyExplode;
    public AudioSource shiftSuccess;

    public Animator shapeLabel;

    public EventSystem eventSystem;

    public GameObject enemyRotate;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        diaAnim = dialogue.GetComponent<Animator>();

        skip.onClick.AddListener(SwitchScene);

        Destroy(GameObject.Find("Menu Music"));
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().ignoreListenerVolume = true;
        Camera.main.GetComponent<AudioSource>().volume = 0.15f * (PlayerPrefs.GetFloat("musicSlider", 1f));

        Time.timeScale = 0;
        screenTap.GetComponent<Button>().onClick.AddListener(GameStart);

        tutorial1 = false;
        tutorial2 = false;
        tutorial3 = false;
        tutorial4 = false;
        tutorial5 = false;
        tutorial6 = false;

        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Plus)) || (Input.GetKeyDown(KeyCode.Equals)))
        {
            ExecuteEvents.Execute(plusButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
        }

        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            ExecuteEvents.Execute(minusButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
        }


        if (Input.GetKey(KeyCode.Space) && screenTap.activeSelf)
        {
            GameStart();
        }

        if (tutorial1)
        {
            dialogue.SetActive(true);

            if ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0) && isGrounded)
            {
                Jump();
                tutorial1 = false;
                Invoke("DialogueOff", 1);
            }
        }

        else if (tutorial2)
        {
            isGrounded = true;

            if ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0) && isGrounded)
            {
                Jump();
                tutorial2 = false;
            }
        }

        else if (tutorial3)
        {
            dialogue.SetActive(true);
            diaAnim.SetInteger("dialogue", 2);

            isGrounded = true;
            if ((Input.GetKey(KeyCode.Space) || Input.touchCount > 0) && isGrounded)
            {
                Jump();
                tutorial3 = false;
                Invoke("DialogueOff", 1);
            }
        }

        else if (tutorial4)
        {
            plusButton.GetComponent<Button>().onClick.AddListener(ButtonClick);

            dialogue.SetActive(true);
            diaAnim.SetInteger("dialogue", 3);
            plusButton.SetActive(true);
            minusButton.SetActive(true);
        }

        else if (tutorial5)
        {
            isGrounded = true;
            dialogue.SetActive(true);
            diaAnim.SetInteger("dialogue", 4);

            StartCoroutine(Tutorial5Done());
        }

        else if (tutorial6)
        {
            dialogue.SetActive(true);
            diaAnim.SetInteger("dialogue", 5);
            plusButton.GetComponent<Button>().interactable = true;
	    enemyRotate.GetComponent<TestRotate>().enabled = false;
	    
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tutorial")
        {
            Time.timeScale = 0;

            if (col.gameObject.name == "Tutorial 1")
            {
                tutorial1 = true;
            }

            else if (col.gameObject.name == "Tutorial 2")
            {
                tutorial2 = true;
            }

            else if (col.gameObject.name == "Tutorial 3")
            {
                tutorial3 = true;
            }

            else if (col.gameObject.name == "Tutorial 4")
            {
                tutorial4 = true;
            }

            else if (col.gameObject.name == "Tutorial 5")
            {
                tutorial5 = true;
            }
        }

        else if (col.gameObject.tag == "SqShift")
        {
            col.gameObject.transform.parent.Find("Freeform Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = new Color32(0, 255, 14, 255);
            shiftSuccess.Play();
            addToken.GetComponent<Animator>().SetTrigger("tokenAcquired");
            tokenIcon.SetActive(true);
            tokenText.text = "5";

            Invoke("ShiftReset", 0.5f);
        }

        else if (col.gameObject.tag == "Enemy")
        {
            redExplosion.SetActive(true);
            enemyExplode.Play();
            redExplosion.transform.position = col.gameObject.transform.position;
            Invoke("EnemyTimeReset", 0.2f);

            Destroy(col.gameObject);
            Camera.main.GetComponent<CameraZoom>().ZoomActive = false;
            TutorialOver();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ShiftPlatform")
        {
            cam.GetComponent<CameraZoom>().ZoomActive = true;
            Time.timeScale = 0.5f;
        }
    }

    void EnemyTimeReset()
    {
        redExplosion.SetActive(false);
        Time.timeScale = 1;
    }

    void GameStart()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        screenTap.SetActive(false);
        Time.timeScale = 1;
        ParticlesOn();
    }

    void Jump()
    {
        Time.timeScale = 1;
        rb.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
        isGrounded = false;

        particles.SetActive(false);
        Invoke("ParticlesOn", 0.8f);
    }

    void ShiftReset()
    {
        Time.timeScale = 1;
        cam.GetComponent<CameraZoom>().ZoomActive = false;
    }

    void ParticlesOn()
    {
        particles.SetActive(true);
    }

    IEnumerator Tutorial5Done()
    {
        yield return new WaitForSecondsRealtime(1);
        DisableTutorial5();
    }

    void DisableTutorial5()
    {
        Time.timeScale = 1;
        tutorial5 = false;
        Invoke("DialogueOff", 1);
    }

    void ButtonClick()
    {
        if (tutorial6)
        {
            tutorial6 = false;
            this.gameObject.GetComponent<Animator>().SetInteger("sides", 5);
            shapeLabel.SetInteger("sides", 5);
            Time.timeScale = 0.2f;
	    enemyRotate.GetComponent<TestRotate>().enabled = true;
        }
        
        else if (tutorial4)
        {
            tutorial4 = false;
            this.gameObject.GetComponent<Animator>().SetInteger("sides", 4);
            shapeLabel.SetInteger("sides", 4);
            Time.timeScale = 0.35f;
        }
        plusButton.GetComponent<Button>().interactable = false;
        dialogue.SetActive(false);
    }

    void DialogueOff()
    {
        dialogue.SetActive(false);
    }

    void TutorialOver()
    {
        tutorialBG.GetComponent<Animator>().SetBool("gameOver", true);
        Invoke("MusicOff", 4);
        Invoke("SwitchScene", 7);
    }

    void SwitchScene()
    {
        if (PlayerPrefs.GetInt("tutorialDone", 1) == 1)
        {
            SceneManager.LoadScene("Play Screen");
            PlayerPrefs.SetInt("tutorialDone", 2);
            PlayerPrefs.Save();
        }

        else
        {
            SceneManager.LoadScene("Menu Screen");
            Time.timeScale = 1;
        }
    }

    void MusicOff()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
    }
}
