using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    public GameObject player;
    public GameObject loseText;
    private PlayerJump jumpScript;

    public GameObject explosion;

    public Animator loseBGAnim;

    public Text currentScoreT;
    public GameObject newHighScoreT;
    public Text highScoreT;

    int currentScore;
    int highScore;

    public GameObject addToken;
    //Text for during game
    public Text tokenText1;

    public GameObject token;
    public Text tokenText2;

    public GameObject tokenTotal;
    public Text totalLabel;

    public GameObject gameOverUI;
    public GameObject replayButton;
    public GameObject menuButton;

    private int numOfTokens;

    public GameObject redExplosion;

    public AudioSource playerExplode;
    public AudioSource enemyExplode;
    public AudioSource shiftSuccess;
    public AudioSource gameOverSound;

    public bool collideOnce;

    public Button skip;

    // Start is called before the first frame update
    void Start()
    {
        jumpScript = player.GetComponent<PlayerJump>();

        replayButton.GetComponent<Button>().onClick.AddListener(Restart);
        menuButton.GetComponent<Button>().onClick.AddListener(Menu);
        skip.onClick.AddListener(SkipToEnd);

        numOfTokens = 0;

        highScore = PlayerPrefs.GetInt("hScore", 0);

        collideOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = jumpScript.score;
        tokenText1.text = "" + numOfTokens;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Ground") || (col.gameObject.tag == "Spikes") || (col.gameObject.name == "Spikes") || (col.gameObject.name == "Spikes 2") || (col.gameObject.tag == "ShiftPlatform"))
        {
            if (!collideOnce)
            {
                Lose();
            }
        }

        if ((col.gameObject.tag == "TriShift" && jumpScript.sides != 3) || (col.gameObject.tag == "SqShift" && jumpScript.sides != 4) || (col.gameObject.tag == "PenShift" && jumpScript.sides != 5) || (col.gameObject.tag == "HexShift" && jumpScript.sides != 6) || (col.gameObject.tag == "HepShift" && jumpScript.sides != 7) || (col.gameObject.tag == "OctShift" && jumpScript.sides != 8))
        {
            collideOnce = true;
            col.gameObject.transform.parent.Find("Freeform Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = new Color32(255, 0, 0, 255);
            Lose();
        }

        else if ((col.gameObject.tag == "TriShift" && jumpScript.sides == 3) || (col.gameObject.tag == "SqShift" && jumpScript.sides == 4) || (col.gameObject.tag == "PenShift" && jumpScript.sides == 5) || (col.gameObject.tag == "HexShift" && jumpScript.sides == 6) || (col.gameObject.tag == "HepShift" && jumpScript.sides == 7) || (col.gameObject.tag == "OctShift" && jumpScript.sides == 8))
        {
            col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            col.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            col.gameObject.transform.parent.Find("Freeform Light 2D").GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = new Color32(0, 255, 14, 255);
            shiftSuccess.Play();
            addToken.SetActive(true);
            addToken.GetComponent<Animator>().SetTrigger("tokenAcquired");
            numOfTokens += 5;
            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) + 5));
            PlayerPrefs.Save();
            Invoke("TimeReset", 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (jumpScript.sides != (col.gameObject.GetComponent<Enemies>().sides))
            {
                Lose();
            }
            else
            {
                redExplosion.SetActive(true);
                enemyExplode.Play();
                redExplosion.transform.position = col.gameObject.transform.position;
                jumpScript.score += 25;
                jumpScript.scoreText.gameObject.GetComponent<Animator>().SetTrigger("add");
                Invoke("EnemyTimeReset", 0.2f);

                Destroy(col.gameObject);
                Camera.main.GetComponent<CameraZoom>().ZoomActive = false;
                //Camera.main.GetComponent<Obstacles>().enemyAlive = false;
            }
        }
    }

    void EnemyTimeReset()
    {
        redExplosion.SetActive(false);
        Time.timeScale = jumpScript.tempTime;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void TimeReset()
    {
        Time.timeScale = jumpScript.tempTime;
        Camera.main.GetComponent<CameraZoom>().ZoomActive = false;
        addToken.SetActive(false);
    }

    public void Lose()
    {
        explosion.SetActive(true);
        playerExplode.Play();
        Camera.main.GetComponent<AudioSource>().Stop();
        explosion.transform.position = player.transform.position;
        player.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0.25f;

        loseText.SetActive(true);
        loseBGAnim.SetBool("gameOver", true);

        Invoke("ShowSkip", 1f);
        Invoke("CurrentScore", 1.35f);
        Invoke("HighScore", 1.85f);


        if (currentScore > highScore)
        {
            Invoke("SaveScore", 2.35f);
            Invoke("Tokens", 2.85f);
            Invoke("TokenTotal", 3.35f);
            Invoke("Buttons", 3.85f);
        }

        else
        {
            Invoke("Tokens", 2.35f);
            Invoke("TokenTotal", 2.85f);
            Invoke("Buttons", 3.35f);
        }
    }

    void ShowSkip()
    {
        skip.gameObject.SetActive(true);
    }

    void SkipToEnd()
    {
        gameOverSound.volume = 0;
        CurrentScore();
        HighScore();

        if (currentScore > highScore)
        {
            SaveScore();
        }

        Tokens();
        TokenTotal();
        Buttons();
    }

    void CurrentScore()
    {
        Time.timeScale = 0.8f;
        currentScoreT.text = "Current Score: " + jumpScript.score;
        gameOverSound.Play();
    }

    void HighScore()
    {
        highScoreT.text = "High Score: " + highScore;
        gameOverSound.Play();
    }

    void SaveScore()
    {
        newHighScoreT.SetActive(true);
        highScoreT.text = "High Score: " + currentScore;
        PlayerPrefs.SetInt("hScore", currentScore);
        PlayerPrefs.Save();
        gameOverSound.Play();
    }

    void Tokens()
    {
        token.SetActive(true);
        tokenText2.text = "" + numOfTokens;
        gameOverSound.Play();
    }

    void TokenTotal()
    {
        tokenTotal.SetActive(true);
        totalLabel.text = "" + (PlayerPrefs.GetInt("Tokens", 0));
        gameOverSound.Play();
        skip.gameObject.SetActive(false);
    }

    void Buttons()
    {
        replayButton.SetActive(true);
        menuButton.SetActive(true);
    }

    void Menu()
    {
        SceneManager.LoadScene("Menu Screen");
        Time.timeScale = 1;
    }
}
