using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPreview : MonoBehaviour
{
    public Button white;
    public Button red;
    public Button orange;
    public Button yellow;
    public Button green;
    public Button blue;
    public Button purple;
    public Button pink;
    public Button mint;
    public Button teal;

    public Image shapePreview;

    public GameObject shopTutorial;

    int sides = 3;
    public Animator anim;
    public Button rightArrow;
    public Button leftArrow;

    void Awake()
    {
        if (PlayerPrefs.GetInt("ShopTutorial", 0) == 0)
        {
            shopTutorial.SetActive(true);
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

    // Start is called before the first frame update
    void Start()
    {
        white.onClick.AddListener(White);
        red.onClick.AddListener(Red);
        orange.onClick.AddListener(Orange);
        yellow.onClick.AddListener(Yellow);
        green.onClick.AddListener(Green);
        blue.onClick.AddListener(Blue);
        purple.onClick.AddListener(Purple);
        pink.onClick.AddListener(Pink);
        mint.onClick.AddListener(Mint);
        teal.onClick.AddListener(Teal);

        rightArrow.onClick.AddListener(AddSide);
        leftArrow.onClick.AddListener(SubtractSide);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("sides", sides);
    }

    public void White()
    {
        shapePreview.color = new Color32(255, 255, 255, 255);
    }

    public void Red()
    {
        shapePreview.color = new Color32(255, 96, 95, 255);
        Invoke("EndTutorial", 1);
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

    void EndTutorial()
    {
        shopTutorial.SetActive(false);
        PlayerPrefs.SetInt("ShopTutorial", 1);
        PlayerPrefs.Save();
    }

    void AddSide()
    {
        if (sides == 8)
        {
            sides = 3;
        }

        else
        {
            sides += 1;
        }
    }

    void SubtractSide()
    {
        if (sides == 3)
        {
            sides = 8;
        }

        else
        {
            sides -= 1;
        }
    }
}
