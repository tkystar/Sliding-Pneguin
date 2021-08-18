using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

namespace penguin
{
public class SceneMana_home : MonoBehaviour
{
    public Button timeattack;
    public Button scroll;
    public Button timelimitbtn;
    public Button timelimit_fish;
    public Button setting;
    public Button back;
    public static float sensitivity;
    public GameObject sensitivitysliderObject;
    Slider sensitivitySlider;
    public static int timelimit;
    public GameObject timelimitsliderObject;
    Slider timelimitSlider;
    public GameObject homecanvas;
    public GameObject adjustcanvas;
    // Start is called before the first frame update
    void Start()
    {
        timeattack.onClick.AddListener(timeattackBtnClicked);
        scroll.onClick.AddListener(scrollBtnClicked);
        timelimitbtn.onClick.AddListener(timelimitBtnClicked);
        timelimit_fish.onClick.AddListener(timelimitfishBtnClicked);
        setting.onClick.AddListener(settingBtnClicked);
        sensitivitySlider = sensitivitysliderObject.GetComponent<Slider>();
        timelimitSlider = timelimitsliderObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void timeattackBtnClicked()
    {
        SceneManager.LoadScene ("Penguin_timeattack");
        sensitivity=sensitivitySlider.value*6;
        timelimit=(int)timelimitSlider.value;
        getSensitivity();
        getTimelimit();
    }
    void scrollBtnClicked()
    {
        SceneManager.LoadScene ("Penguin_Scroll");
        sensitivity=sensitivitySlider.value*6;
        timelimit=(int)timelimitSlider.value;
        getSensitivity();
        getTimelimit();
    }
    void timelimitBtnClicked()
    {
        SceneManager.LoadScene ("Pengui_timelimit");
        sensitivity=sensitivitySlider.value*6;
        timelimit=(int)timelimitSlider.value;
        getSensitivity();
        getTimelimit();
    }
    void timelimitfishBtnClicked()
    {
        SceneManager.LoadScene ("Penguin(fish)_timelimit");
        sensitivity=sensitivitySlider.value*6;
        timelimit=(int)timelimitSlider.value;
        getSensitivity();
        getTimelimit();
    }
    void settingBtnClicked()
    {
        homecanvas.SetActive(false);
        adjustcanvas.SetActive(true);
        //SceneManager.LoadScene ("PenguinInwater");
    }
    
    public static float getSensitivity() {
        //return _gameManager.totalTime;
        return sensitivity;
    }

    public static int getTimelimit() {
        //return _gameManager.totalTime;
        return timelimit;
    }
}

}
