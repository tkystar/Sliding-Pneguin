using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
public class StageDetection : MonoBehaviour
{
    //public GameObject gameOverTextObj;
    //Text _gameOverText;
    public GameObject IngameCanvas;
    //public GameObject ScoreCanvas;
    public GameObject penguin;
    public GameObject fish;
    PenguinMove penguinMove;
    SpriteRenderer _penguinrenderer;
    SpriteRenderer _fishrenderer;
    Color penguincolor;
    public bool _gameover;
    float _alpha;
    AudioSource _missSound;
    //public GameObject goalObj;
    GoalDetection _goalDetection;
    public static bool _gameclear;
    public GameObject timeTextObj;
    Text _timeText;
    public AudioClip gameOverSound;
    CoinController CoinController;
    public GameObject GameManager;
    //fishGet fishGet;
    // Start is called before the first frame update
    void Start()
    {
        //_gameOverText=gameOverTextObj.GetComponent<Text>();
        //_gameOverText.text="";
        penguinMove=penguin.GetComponent<PenguinMove>();
        _penguinrenderer=penguin.GetComponent<SpriteRenderer>();
        //_fishrenderer=fish.GetComponent<SpriteRenderer>();
        penguincolor=penguin.GetComponent<SpriteRenderer>().color;
        _gameover=false;
        _missSound=this.gameObject.GetComponent<AudioSource>();
        _timeText=timeTextObj.GetComponent<Text>();
        CoinController=GameManager.GetComponent<CoinController>();
        //fishGet=fish.GetComponent<fishGet>();
        //_goalDetection=goalObj.GetComponent<GoalDetection>();
        //penguin.GetComponent<SpriteRenderer> ().color.a=0.3f;
    }
    float _time;
    // Update is called once per frame
    void Update()
    {
        
        if(_gameover)
        {
            _time+=Time.deltaTime;
            float t=0.7f-_time;
            _alpha=t/0.7f;
            //Debug.Log(_alpha);
            if(_alpha>0)
            {
                //penguin.GetComponent<SpriteRenderer> ().color.a=_alpha;
                penguincolor.a=_alpha;
                penguin.GetComponent<SpriteRenderer>().color=penguincolor;
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            gameover();
            StartCoroutine("gameOver");
            getmizuiroPoint();
            greenPoint();
            redPoint();
            pinkPoint();
           yellowPoint();
        }
        if(other.gameObject.tag=="hammer")
        {
            other.gameObject.GetComponent<Collider2D>().enabled=false;
        }
        if(other.gameObject.tag=="fish")
        {
            other.gameObject.GetComponent<Collider2D>().enabled=false;
            //Destroy(other.gameObject);
            _fishrenderer=other.gameObject.GetComponent<SpriteRenderer>();
            _fishrenderer.sortingLayerName="1";
           // other.gameObject.GetComponent<fishGet>().enabled=false;
        }

    }
    
    private IEnumerator gameOver() 
    {
        yield return new WaitForSeconds(1.0f);
        _missSound.clip=gameOverSound;
        _missSound.Play();
        //_gameOverText.text="GameOver";    
        IngameCanvas.SetActive(false);
        //ScoreCanvas.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene("Penguin_Score");
    }
    void gameover()
    {   
        timeTextObj.SetActive(false);
        _missSound.Play();
        penguinMove.enabled=false;
        _gameover=true;
        _penguinrenderer.sortingLayerName="1";
        penguin.GetComponent<Collider2D>().enabled=false;
        //_gameclear=_goalDetection.gameFin;
        gameclear();

    }

    public static bool gameclear() {
        //return _gameManager.totalTime;
        return _gameclear;
    }

    public static int getmizuiroPoint() {
        return CoinController.mizuirocount;
    }
    public static int greenPoint() {
        return CoinController.greencount;
    }
    public static int redPoint() {
        return CoinController.redcount;
    }
    public static int pinkPoint() {
        return CoinController.pinkcount;
    }
    public static int yellowPoint() {
        return CoinController.yellowcount;
    }
}

}