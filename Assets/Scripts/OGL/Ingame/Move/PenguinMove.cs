using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin{
    public class PenguinMove : MonoBehaviour
{
    //public GameObject Ground;
    public int fishcounter=0;
    CollisionDetection CollisionDetection;
    Rigidbody2D rb; 
    [SerializeField]public float SPEED;
    float defaultSpeed;
    float fighSpeed;
    float highSpeed;
    Transform transform;
    //public GameObject VeloObj;
    Text VeloTex;
    public GameObject sensiobj;
    [SerializeField]float brake=0.99f;
    Text sensitext;
    //public AudioSource brakesoud;
    public AudioClip brakeclip;
    Animator animator;
    bool jump;
    Vector3 Force;
    public GameObject counterTextObj;
    Text CounterText;

    // Start is called before the first frame update
    void Start()
    {
        SPEED=SceneMana_home.getSensitivity();
        rb=this.GetComponent<Rigidbody2D>();
        rb.velocity=new Vector3(0,0,0);
        defaultSpeed=SPEED;
        highSpeed=2.5f*SPEED;
        //onGround=true;
        //CollisionDetection=Ground.GetComponent<CollisionDetection>();
        transform=this.gameObject.GetComponent<Transform>();
        //VeloTex=VeloObj.GetComponent<Text>();
        this.enabled=false;
        sensitext=sensiobj.GetComponent<Text>();
        animator=this.GetComponent<Animator>();
       // fishcounter=0;
       CounterText=counterTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Move();
        Brake();
        sensitext.text=SPEED.ToString();
        if(SPEED==0)
        {
            SPEED=3;
        }
        //transform.rotation=Quaternion.Euler(0,0,0);
    }

    public void Move(){
		
        //VeloTex.text=rb.velocity.magnitude.ToString();
		/*
        if(Input.GetKeyDown(KeyCode.Space)){
        SPEED=highSpeed;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
        SPEED=defaultSpeed;
        }
*/

   //keyboard&mouse
   /*
		if(Input.GetKey("left")){
			//rb.velocity=new Vector3(-1.0f,0,0)*SPEED;
            Vector3 leftForce=new Vector3(-1.0f,0,0)*SPEED;
            transform.rotation=Quaternion.Euler(0,0,90);
            if(rb.velocity.magnitude<100){

            }
            rb.AddForce(leftForce);
            
		} else if(Input.GetKey("right")){ // 右キーを押し続けていたら
			//rb.velocity=new Vector3(1.0f,0,0)*SPEED;  
            Vector3 rightForce=new Vector3(1.0f,0,0)*SPEED;
            rb.AddForce(rightForce);   
            transform.rotation=Quaternion.Euler(0,0,-90); 
		} else if(Input.GetKey("up")){ // 右キーを押し続けていたら
            //onGround=false;
			///rb.velocity=new Vector3(0,1.0f,0)*SPEED;  
            Vector3 upForce=new Vector3(0,1.0f,0)*SPEED;
            rb.AddForce(upForce);
            transform.rotation=Quaternion.Euler(0,0,0);   
		} else if(Input.GetKey("down")){ // 右キーを押し続けていたら
            //onGround=false;
			//rb.velocity=new Vector3(0,-1.0f,0)*SPEED;   
            Vector3 downForce=new Vector3(0,-1.0f,0)*SPEED;
            rb.AddForce(downForce);
            transform.rotation=Quaternion.Euler(0,0,180);   
		} 

        if(Input.GetKeyUp("left")){
			
            transform.rotation= Quaternion.Euler(0,0,90);
            
		} else if(Input.GetKeyUp("right")){ // 右キーを押し続けていたら
			
            transform.rotation=Quaternion.Euler(0,0,-90);       
		} else if(Input.GetKeyUp("up")){ // 右キーを押し続けていたら
            
            transform.rotation=Quaternion.Euler(0,0,0);       
		} else if(Input.GetKeyUp("down")){ // 右キーを押し続けていたら
            
            transform.rotation=Quaternion.Euler(0,0,180);      
		} */

        ///joystick
        float horizon=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        if(vertical!=null||horizon!=null)
        {
            if(!jump)
            {
                Force=new Vector3(horizon,vertical,0)*SPEED;
            }
            else{
                Force=new Vector3(horizon,vertical,0)*SPEED*3;
            }
            
            rb.AddForce(Force);
            float angle=Mathf.Atan(vertical/horizon)*Mathf.Rad2Deg;
            
            if(horizon>=0)
            {
                transform.rotation=Quaternion.Euler(0,0,angle-90.0f); 
            }
            else
            {
                transform.rotation=Quaternion.Euler(0,0,angle+90.0f); 
            }
             
        
        
        }		

		
/*
        if(Input.GetKeyUp("left")){
			rb.velocity=new Vector2(0,0);
            Debug.Log("A");
		} else if(Input.GetKeyUp("right")){ // 右キーを押し続けていたら
			rb.velocity=new Vector2(0,0);         
		} */
	}

    void Brake()
    {
        if(Input.GetKeyDown("joystick button 2")||Input.GetKeyDown("x"))
        {
            //brakesoud.Play();
            jump=true;
            StartCoroutine("Samples");
            this.GetComponent<AudioSource>().clip=brakeclip;
            this.GetComponent<AudioSource>().Play();

            animator.SetBool("jump",true);
            //rb.velocity *= brake;

        }
        if(Input.GetKey("joystick button 2"))
        {
            //rb.velocity *= brake;
            //brakesoud.Play();
            
        }
        
        if(Input.GetKeyUp("joystick button 2")||Input.GetKeyUp("x"))
        {
            this.GetComponent<AudioSource>().Stop();
            
        }
    }

    IEnumerator Samples() 
    {
        yield return new WaitForSeconds (0.7f);
        jump=false;
        animator.SetBool("jump",false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="fish")
        {
            fishcounter++;
            CounterText.text="×"+fishcounter.ToString();
        }
    }
}
}


