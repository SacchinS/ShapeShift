using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayScreen : MonoBehaviour
{
    public Button playButton;
    public Button shopButton;
    public Button helpButton;

    public Button leftToggle;
    public Button rightToggle;

    public GameObject shape;
    public Text shapeLabel;
    private int sides;

    Animator anim;

    public Button sound;
    public Button reset;

    public GameObject music;

    public GameObject resetMenu;
    public Button resetYes;
    public Button resetNo;

    public GameObject soundSettings;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Button soundMenuQuit;

    public GameObject musicIcon;
    public GameObject soundIcon;

    public Image shapePreview;

    void Awake()
    {
        DontDestroyOnLoad(music);
    }

    // Start is called before the first frame update
    void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("soundSlider", 1);
        musicSlider.value = PlayerPrefs.GetFloat("musicSlider", 1);

        sides = 0;
        anim = shape.GetComponent<Animator>();

        playButton.onClick.AddListener(GameScreen);
        helpButton.onClick.AddListener(TutorialScreen);
        shopButton.onClick.AddListener(ShopScreen);

        leftToggle.onClick.AddListener(toggleLeft);
        rightToggle.onClick.AddListener(toggleRight);

        sound.onClick.AddListener(SoundMenu);
        reset.onClick.AddListener(Reset);

        resetYes.onClick.AddListener(ResetYes);
        resetNo.onClick.AddListener(ResetNo);

        soundMenuQuit.onClick.AddListener(SoundMenuClose);

        if (GameObject.Find("Menu Music") == null)
        {
            music.SetActive(true);
            music.GetComponent<AudioSource>().ignoreListenerVolume = true;
        }

        else
        {
            Destroy(music);
        }

        if (PlayerPrefs.GetString("Color", "white") == "white")
        {
            White();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "red")
        {
            Red();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "orange")
        {
            Orange();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "yellow")
        {
            Yellow();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "green")
        {
            Green();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "blue")
        {
            Blue();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "purple")
        {
            Purple();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "pink")
        {
            Pink();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "mint")
        {
            Mint();
        }
        else if (PlayerPrefs.GetString("Color", "white") == "teal")
        {
            Teal();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameSoundVolume();
    }

    void GameScreen()
    {
        if (PlayerPrefs.GetInt("tutorialDone", 1) == 2)
        {
            SceneManager.LoadScene("Play Screen");
        }

        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }
    
    void TutorialScreen()
    {
        SceneManager.LoadScene("Tutorial");
        PlayerPrefs.SetInt("tutorialDone", 2);
        PlayerPrefs.Save();
    }

    void ShopScreen()
    {
        SceneManager.LoadScene("Shop"); 
    }

    void toggleLeft()
    {
        if (sides == 0)
        {
            sides = 5;
        }

        else
        {
            sides -= 1;
        }

        shapeToggle();
    }

    void toggleRight()
    {
        if (sides == 5)
        {
            sides = 0;
        }

        else
        {
            sides += 1;
        }
        
        shapeToggle();
    }

    void textChange()
    {
        if (sides == 0)
        {
            shapeLabel.text = "Triangle";
        }

        else if (sides == 1)
        {
            shapeLabel.text = "Square<size=30>\n(Rectangle)</size>";
        }

        else if (sides == 2)
        {
            shapeLabel.text = "Pentagon";
        }

        else if (sides == 3)
        {
            shapeLabel.text = "Hexagon";
        }

        else if (sides == 4)
        {
            shapeLabel.text = "Heptagon";
        }

        else if (sides == 5)
        {
            shapeLabel.text = "Octagon";
        }
    }

    void shapeToggle()
    {
        anim.SetInteger("sides", sides + 3);
        textChange();
    }

    void SoundMenu()
    {
        soundSettings.SetActive(true);
    }

    void GameSoundVolume()
    {
        AudioListener.volume = sfxSlider.value;
        GameObject.Find("Menu Music").GetComponent<AudioSource>().volume = 0.1f * (musicSlider.value);

        PlayerPrefs.SetFloat("soundSlider", sfxSlider.value);
        PlayerPrefs.SetFloat("musicSlider", musicSlider.value);

        PlayerPrefs.Save();

        if (soundSettings.activeSelf)
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

            if (sfxSlider.value == 0)
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 0);
            }
            else if (sfxSlider.value < 0.35f)
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 1);
            }
            else if (sfxSlider.value < 0.7f)
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 2);
            }
            else
            {
                soundIcon.GetComponent<Animator>().SetInteger("sound", 3);
            }
        }
    }

    void SoundMenuClose()
    {
        soundSettings.SetActive(false);
    }

    void Reset()
    {
        resetMenu.SetActive(true);
    }

    void ResetYes()
    {
        PlayerPrefs.DeleteAll();
        shapePreview.color = new Color32(255, 255, 255, 255);
        resetMenu.SetActive(false);
    }

    void ResetNo()
    {
        resetMenu.SetActive(false);
    }

    public void White()
    {
        shapePreview.color = new Color32(255, 255, 255, 255);
    }

    public void Red()
    {
        shapePreview.color = new Color32(255, 96, 95, 255);
    }

    public void Orange()
    {
        shapePreview.color = new Color32(254, 160, 45, 255);
    }

    public void Yellow()
    {
        shapePreview.color = new Color32(254, 254, 105, 255);
    }

    public void Green()
    {
        shapePreview.color = new Color32(113, 254, 105, 255);
    }

    public void Blue()
    {
        shapePreview.color = new Color32(0, 169, 255, 255);
    }

    public void Purple()
    {
        shapePreview.color = new Color32(191, 71, 254, 255);
    }

    public void Pink()
    {
        shapePreview.color = new Color32(255, 129, 247, 255);
    }

    public void Mint()
    {
        shapePreview.color = new Color32(153, 254, 224, 255);
    }

    public void Teal()
    {
        shapePreview.color = new Color32(13, 254, 237, 255);
    }
}
