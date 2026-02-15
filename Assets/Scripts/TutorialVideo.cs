using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;  

public class TutorialVideo : MonoBehaviour
{
    public VideoPlayer video1;
    public VideoPlayer video2;
    public VideoPlayer video3;
    public VideoPlayer video4;
    public VideoPlayer video5;
    public VideoPlayer video6;
    public VideoPlayer video7;
    public VideoPlayer video8;

    public Button tapToStart;

    public bool vid2Ready = false;
    public bool vid3Ready = false;
    public bool vid4Ready = false;
    public bool vid5Ready = false;
    public bool vid6Ready = false;
    public bool vid7Ready = false;
    public bool vid8Ready = false;

    public AudioSource shiftBox;
    public AudioSource enemy;
    public AudioSource music;

    public Button plusSide; 
    public Button skip;

    void Awake() {
	Destroy(GameObject.Find("Menu Music"));
    }


    // Start is called before the first frame update
    void Start()
    {
	music.volume *= PlayerPrefs.GetFloat("musicSlider", 1f);
	enemy.volume *= PlayerPrefs.GetFloat("soundSlider", 1f);
	shiftBox.volume *= PlayerPrefs.GetFloat("soundSlider", 1f);

        tapToStart.onClick.AddListener(startTutorial);
	video1.loopPointReached += startVideo2;
	video2.loopPointReached += startVideo3;
	video3.loopPointReached += startVideo4;
	video4.loopPointReached += startVideo5;
	video5.loopPointReached += startVideo6;
	video6.loopPointReached += startVideo7;
	video7.loopPointReached += startVideo8;
	video8.loopPointReached += SwitchScene;

	plusSide.onClick.AddListener(buttonClicked);
	skip.onClick.AddListener(DisableTutorial);
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0) {
		if (vid7Ready) {
			video7.gameObject.SetActive(true);
			Invoke("delayVid6", 0.5f);
		}

		else if (vid5Ready) {
			video5.gameObject.SetActive(true);
			Invoke("delayVid4", 0.5f);
		}

		else if (vid4Ready) {
			video4.gameObject.SetActive(true);
			Invoke("delayVid3", 0.5f);
		}

		else if (vid3Ready) {
			video3.gameObject.SetActive(true);
			Invoke("delayVid2", 0.5f);
		}

		else if (vid2Ready) {
			video2.gameObject.SetActive(true);
			Invoke("delayVid1", 0.5f);
		}
	}
    }

    void delayVid1() {
    	Destroy(video1.gameObject);
    } 
    void delayVid2() {
    	Destroy(video2.gameObject);
    } 
    void delayVid3() {
    	Destroy(video3.gameObject);
    } 
    void delayVid4() {
    	Destroy(video4.gameObject);
    } 
    void delayVid5() {
    	Destroy(video5.gameObject);
    } 
    void delayVid6() {
    	Destroy(video6.gameObject);
    } 
    void delayVid7() {
    	Destroy(video7.gameObject);
    } 

    void shiftBoxSound() {
    	shiftBox.Play();
    }

    void enemySound() {
	enemy.Play();
    }

    void turnOffShiftBox() {
	shiftBox.enabled = false;
    } 

    void turnOffEnemy() {
	plusSide.gameObject.SetActive(false);
	enemy.enabled = false;
    } 

    void startVideo2(VideoPlayer vp) {
	vid2Ready = true;
    }

    void startVideo3(VideoPlayer vp) {
	vid3Ready = true;
    }

    void startVideo4(VideoPlayer vp) {
	vid4Ready = true;
    }

    void startVideo5(VideoPlayer vp) {
	vid5Ready = true;
    }

    void startVideo6(VideoPlayer vp) {
	vid6Ready = true;
	plusSide.gameObject.SetActive(true);
    }

    void startVideo7(VideoPlayer vp) {
	vid7Ready = true;
    }

    void startVideo8(VideoPlayer vp) {
	vid8Ready = true;
	plusSide.GetComponent<Button>().interactable = true;
    }

    void startTutorial() {
    	tapToStart.gameObject.SetActive(false);
	video1.playbackSpeed = 1;
	music.Play();
    } 

    void buttonClicked() {
	if (vid8Ready) {
		video8.gameObject.SetActive(true);
		Invoke("delayVid7", 0.5f);
		Invoke("enemySound", 5);
		Invoke("turnOffEnemy", 5.75f);
	}
	
    	else if (vid6Ready) {
		video6.gameObject.SetActive(true);
		Invoke("delayVid5", 0.5f);
		Invoke("shiftBoxSound", 3);
		Invoke("turnOffShiftBox", 3.75f);
	}
	plusSide.GetComponent<Button>().interactable = false;
    } 

    void SwitchScene(VideoPlayer vp)
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

    void DisableTutorial()
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

}
