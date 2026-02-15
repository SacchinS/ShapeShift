using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Text tokenBalance;

    public Button closeButton;

    public Sprite equipped;
    public Sprite equip;
    public Sprite buy;

    public Button whiteButton;
    public Button redButton;
    public Button orangeButton;
    public Button yellowButton;
    public Button greenButton;
    public Button blueButton;
    public Button purpleButton;
    public Button pinkButton;
    public Button mintButton;
    public Button tealButton;

    private ColorPreview colorPreview;

    public GameObject error;

    void Awake()
    {
        colorPreview = gameObject.GetComponent<ColorPreview>();
    }

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(Menu);

        whiteButton.onClick.AddListener(White);
        redButton.onClick.AddListener(Red);
        orangeButton.onClick.AddListener(Orange);
        yellowButton.onClick.AddListener(Yellow);
        greenButton.onClick.AddListener(Green);
        blueButton.onClick.AddListener(Blue);
        purpleButton.onClick.AddListener(Purple);
        pinkButton.onClick.AddListener(Pink);
        mintButton.onClick.AddListener(Mint);
        tealButton.onClick.AddListener(Teal);

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
        tokenBalance.text = "" + PlayerPrefs.GetInt("Tokens", 0);
    }

    void Menu()
    {
        SceneManager.LoadScene("Menu Screen");
    }

    void RedCheck()
    {
        if (PlayerPrefs.GetInt("Red", 0) == 0)
        {
            redButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            redButton.gameObject.GetComponent<Image>().sprite = equip;
        }

    }

    void OrangeCheck()
    {
        if (PlayerPrefs.GetInt("Orange", 0) == 0)
        {
            orangeButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            orangeButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void YellowCheck()
    {

        if (PlayerPrefs.GetInt("Yellow", 0) == 0)
        {
            yellowButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            yellowButton.gameObject.GetComponent<Image>().sprite = equip;
        }

    }

    void GreenCheck()
    {

        if (PlayerPrefs.GetInt("Green", 0) == 0)
        {
            greenButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            greenButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void BlueCheck()
    {
        if (PlayerPrefs.GetInt("Blue", 0) == 0)
        {
            blueButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            blueButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void PurpleCheck()
    {
        if (PlayerPrefs.GetInt("Purple", 0) == 0)
        {
            purpleButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            purpleButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void PinkCheck()
    {
        if (PlayerPrefs.GetInt("Pink", 0) == 0)
        {
            pinkButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            pinkButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void MintCheck()
    {
        if (PlayerPrefs.GetInt("Mint", 0) == 0)
        {
            mintButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            mintButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void TealCheck()
    {
        if (PlayerPrefs.GetInt("Teal", 0) == 0)
        {
            tealButton.gameObject.GetComponent<Image>().sprite = buy;
        }

        else
        {
            tealButton.gameObject.GetComponent<Image>().sprite = equip;
        }
    }

    void White()
    {
        whiteButton.gameObject.GetComponent<Image>().sprite = equipped;
        colorPreview.White();
        PlayerPrefs.SetString("Color", "white");
        PlayerPrefs.Save();
        RedCheck();
        OrangeCheck();
        YellowCheck();
        GreenCheck();
        BlueCheck();
        PurpleCheck();
        PinkCheck();
        MintCheck();
        TealCheck();
    }

    void Red()
    {
        if ((PlayerPrefs.GetInt("Red",0) == 0) && (PlayerPrefs.GetInt("Tokens",0) >= 100))
        {
            PlayerPrefs.SetString("Color", "red");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 100));
            PlayerPrefs.SetInt("Red", 1);
            redButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Red();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            GreenCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Red",0) == 1)
        {
            PlayerPrefs.SetString("Color", "red");
            PlayerPrefs.Save();

            redButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Red();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            GreenCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Orange()
    {
        if ((PlayerPrefs.GetInt("Orange", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 100))
        {
            PlayerPrefs.SetString("Color", "orange");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 100));
            PlayerPrefs.SetInt("Orange", 1);
            orangeButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Orange();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            RedCheck();
            YellowCheck();
            GreenCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Orange", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "orange");
            PlayerPrefs.Save();

            orangeButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Orange();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            RedCheck();
            YellowCheck();
            GreenCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Yellow()
    {
        if ((PlayerPrefs.GetInt("Yellow", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 100))
        {
            PlayerPrefs.SetString("Color", "yellow");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 100));
            PlayerPrefs.SetInt("Yellow", 1);
            yellowButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Yellow();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            RedCheck();
            GreenCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Yellow", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "yellow");
            PlayerPrefs.Save();

            yellowButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Yellow();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            RedCheck();
            GreenCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Green()
    {
        if ((PlayerPrefs.GetInt("Green", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 100))
        {
            PlayerPrefs.SetString("Color", "green");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 100));
            PlayerPrefs.SetInt("Green", 1);
            greenButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Green();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Green", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "green");
            PlayerPrefs.Save();

            greenButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Green();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Blue()
    {
        if((PlayerPrefs.GetInt("Blue", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 100))
        {
            PlayerPrefs.SetString("Color", "blue");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 100));
            PlayerPrefs.SetInt("Blue", 1);
            blueButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Blue();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            GreenCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Blue", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "blue");
            PlayerPrefs.Save();

            blueButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Blue();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            GreenCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Purple()
    {
        if ((PlayerPrefs.GetInt("Purple", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 100))
        {
            PlayerPrefs.SetString("Color", "purple");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 100));
            PlayerPrefs.SetInt("Purple", 1);
            purpleButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Purple();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            GreenCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Purple", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "purple");
            PlayerPrefs.Save();

            purpleButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Purple();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            GreenCheck();
            PinkCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Pink()
    {
        if ((PlayerPrefs.GetInt("Pink", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 200))
        {
            PlayerPrefs.SetString("Color", "pink");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 200));
            PlayerPrefs.SetInt("Pink", 1);
            pinkButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Pink();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            GreenCheck();
            MintCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Pink", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "pink");
            PlayerPrefs.Save();

            pinkButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Pink();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            GreenCheck();
            MintCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Mint()
    {
        if ((PlayerPrefs.GetInt("Mint", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 200))
        {
            PlayerPrefs.SetString("Color", "mint");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 200));
            PlayerPrefs.SetInt("Mint", 1);
            mintButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Mint();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            GreenCheck();
            TealCheck();
        }

        else if (PlayerPrefs.GetInt("Mint", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "mint");
            PlayerPrefs.Save();

            mintButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Mint();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            GreenCheck();
            TealCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void Teal()
    {
        if ((PlayerPrefs.GetInt("Teal", 0) == 0) && (PlayerPrefs.GetInt("Tokens", 0) >= 200))
        {
            PlayerPrefs.SetString("Color", "teal");

            PlayerPrefs.SetInt("Tokens", (PlayerPrefs.GetInt("Tokens", 0) - 200));
            PlayerPrefs.SetInt("Teal", 1);
            tealButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Teal();
            PlayerPrefs.Save();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            GreenCheck();
        }

        else if (PlayerPrefs.GetInt("Teal", 0) == 1)
        {
            PlayerPrefs.SetString("Color", "teal");
            PlayerPrefs.Save();

            tealButton.gameObject.GetComponent<Image>().sprite = equipped;
            colorPreview.Teal();

            whiteButton.gameObject.GetComponent<Image>().sprite = equip;
            OrangeCheck();
            YellowCheck();
            RedCheck();
            BlueCheck();
            PurpleCheck();
            PinkCheck();
            MintCheck();
            GreenCheck();
        }

        else
        {
            ErrorStart();
        }
    }

    void ErrorStart()
    {
        error.SetActive(true);
        Invoke("ErrorEnd", 1);
    }

    void ErrorEnd()
    {
        error.SetActive(false);
    }
}
