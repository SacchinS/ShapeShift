using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerJump : MonoBehaviour
{

    public Rigidbody2D rb;

    public int score = 0;
    public Text scoreText;

    public GameObject trail;

    public bool isGrounded;

    public int sides;

    public PlayerLose loseScript;

    public Camera cam;

    Animator anim;
    public Animator shapeLabel;

    public bool shiftCollide;

    public Button plusButton;
    public Button minusButton;
    public Button screenTap;

    public float tempTime;

    public GameObject touchToStart;

    public EventSystem eventSystem;

    public Button pauseButton;

    public bool paused;
    public float pauseTime;

    public GameObject settingsMenu;
    public Button closeSettings;
    public Button settingsQuit;

    public Slider soundSlider;
    public Slider musicSlider;
    public GameObject soundIcon;
    public GameObject musicIcon;

    Coroutine scoreRoutine;

    public bool isJumping = false;

    void Awake()
    {
        sides = 3;
        loseScript = GameObject.Find("Player Sides").GetComponent<PlayerLose>();
        anim = GetComponent<Animator>();

        plusButton.onClick.AddListener(AddSide);
        minusButton.onClick.AddListener(SubtractSide);
        //screenTap.onClick.AddListener(Jump);

        touchToStart.GetComponent<Button>().onClick.AddListener(GameStart);

        pauseButton.onClick.AddListener(PauseGame);
        closeSettings.onClick.AddListener(PauseGame);
        settingsQuit.onClick.AddListener(SettingsQuit);
        paused = false;
    }

    // Start is called before the first frame update
    public void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("soundSlider", 1);
        musicSlider.value = PlayerPrefs.GetFloat("musicSlider", 1);

        Camera.main.GetComponent<AudioSource>().ignoreListenerVolume = true;
        Time.timeScale = 0;
        scoreRoutine = StartCoroutine(UnscaledScoreChange());
    }

    // Update is called once per frame
    void Update()
    {
        GameSoundVolume();

        if (!touchToStart.activeSelf)
        {
            if ((Input.GetKeyDown(KeyCode.Plus)) || (Input.GetKeyDown(KeyCode.Equals)))
            {
                ExecuteEvents.Execute(plusButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
            }

            else if (Input.GetKeyDown(KeyCode.Minus))
            {
                ExecuteEvents.Execute(minusButton.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
            }
        }

        anim.SetInteger("sides", sides);
        shapeLabel.SetInteger("sides", sides);
        
        if (touchToStart.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }

        if (isGrounded)
        {
            trail.SetActive(true);

            if (Input.GetKey(KeyCode.Space) || isJumping)
            {
                Jump();
            }
        }

        else
        {
            if (shiftCollide)
            {
                trail.SetActive(true);
            }

            else
            {
                trail.SetActive(false);
            }
        }

        if (sides == 3)
        {
            minusButton.interactable = false;
            plusButton.interactable = true;
        }

        else if (sides == 8)
        {
            plusButton.interactable = false;
            minusButton.interactable = true;
        }

        else
        {
            plusButton.interactable = true;
            minusButton.interactable = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            shiftCollide = true;
        }

        else if (col.gameObject.tag == "ShiftPlatform")
        {
            shiftCollide = true;
            isGrounded = false;
            cam.GetComponent<CameraZoom>().ZoomActive = true;
            tempTime = Time.timeScale;
            if (this.gameObject.activeSelf)
            {
                Time.timeScale = 0.35f*tempTime;
            }
            Invoke("jumpReset", 2.1f);
            col.gameObject.tag = "Ground";
        }

        else if ((col.gameObject.name == "Spikes") || (col.gameObject.name == "Spikes 2") || (col.gameObject.tag == "Spikes"))
        {
            loseScript.Lose();
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Ground") || (col.gameObject.tag == "ShiftPlatform"))
        {
            isGrounded = false;
            shiftCollide = false;
        }
    }

    void jumpReset()
    {
        isGrounded = true;
    }

    IEnumerator UnscaledScoreChange()
    {
        while (true)
        {
            scoreChange();
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }

    void scoreChange()
    {
        if (gameObject.activeSelf && Time.timeScale != 0)
        {
            score += 1;
            scoreText.text = "" + score;

            if ((Time.timeScale < 2) && (Camera.main.GetComponent<CameraZoom>().ZoomActive == false))
            {
                Time.timeScale += 0.001f;
            }
        }
    }


    void AddSide()
    {
        isJumping = false;
        if (sides != 8)
        {
            sides += 1;
        }
    }

    void SubtractSide()
    {
        isJumping = false;
        if (sides != 3)
        {
            sides -= 1;
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void GameStart()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        touchToStart.SetActive(false);
        Time.timeScale = 1;
    }

    void PauseGame()
    {
        if (this.gameObject.activeSelf)
        {
            if (!paused)
            {
                pauseTime = Time.timeScale;
                Time.timeScale = 0;
                Camera.main.GetComponent<AudioSource>().Pause();
                paused = true;
                settingsMenu.SetActive(true);
            }

            else
            {
                settingsMenu.SetActive(false);
                Time.timeScale = pauseTime;
                Camera.main.GetComponent<AudioSource>().Play();
                paused = false;
            }
        }

        else
        {
            pauseButton.interactable = false;
        }
    }

    void SettingsQuit()
    {
        SceneManager.LoadScene("Menu Screen");
        Time.timeScale = 1;
    }

    void GameSoundVolume()
    {
        AudioListener.volume = soundSlider.value;
        Camera.main.GetComponent<AudioSource>().volume = 0.15f * (musicSlider.value);

        PlayerPrefs.SetFloat("soundSlider", soundSlider.value);
        PlayerPrefs.SetFloat("musicSlider", musicSlider.value);

        PlayerPrefs.Save();

        if (settingsMenu.activeSelf)
        {
            if (musicSlider.value == 0)
            {
                musicIcon.GetComponent<Animator>().SetInteger("music", 0);
            }
            else if (musicSlider.value < 0.35f)
            {
                musicIcon.GetComponent<Animator>().SetInteger("music", 1);
            }
            else if (musicSlider.value < 0.7f)
            {
                musicIcon.GetComponent<Animator>().SetInteger("music", 2);
            }
            else
            {
                musicIcon.GetComponent<Animator>().SetInteger("music", 3);
            }

            if (soundSlider.value == 0)
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 0);
            }
            else if (soundSlider.value < 0.35f)
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 1);
            }
            else if (soundSlider.value < 0.7f)
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 2);
            }
            else
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 3);
            }
        }
    }
}