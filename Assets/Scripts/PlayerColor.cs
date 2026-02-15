using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public SpriteRenderer sprite;
    public ParticleSystem ps;

    void Awake()
    {
        Destroy(GameObject.Find("Menu Music"));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Color", "white") == "white")
        {
            sprite.color = new Color32(255, 255, 255, 255);
            ps.startColor = new Color32(255, 255, 255, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "red")
        {
            sprite.color = new Color32(255, 96, 95, 255);
            ps.startColor = new Color32(255, 96, 95, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "orange")
        {
            sprite.color = new Color32(254, 160, 45, 255);
            ps.startColor = new Color32(254, 160, 45, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "yellow")
        {
            sprite.color = new Color32(254, 254, 105, 255);
            ps.startColor = new Color32(254, 254, 105, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "green")
        {
            sprite.color = new Color32(113, 254, 105, 255);
            ps.startColor = new Color32(113, 254, 105, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "blue")
        {
            sprite.color = new Color32(0, 169, 255, 255);
            ps.startColor = new Color32(0, 169, 255, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "purple")
        {
            sprite.color = new Color32(191, 71, 254, 255);
            ps.startColor = new Color32(191, 71, 254, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "pink")
        {
            sprite.color = new Color32(255, 129, 247, 255);
            ps.startColor = new Color32(255, 129, 247, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "mint")
        {
            sprite.color = new Color32(153, 254, 224, 255);
            ps.startColor = new Color32(153, 254, 224, 255);
        }
        else if (PlayerPrefs.GetString("Color", "white") == "teal")
        {
            sprite.color = new Color32(13, 254, 237, 255);
            ps.startColor = new Color32(13, 254, 237, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
