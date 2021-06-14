using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    [SerializeField] slot1trigger s1t; [SerializeField] slot2trigger s2t;[SerializeField] slot3trigger s3t;
    [SerializeField] GameObject slot1wheel,slot2wheel,slot3wheel,jackpot;
    public  float speed ,speed2 ,speed3 ;
    public static string firstslotnumber;
    bool s2, s3,rotation,s_d,reset_candw;
    public int currnentround, winninground;
    float s_calltime, s2_calltime, s3_calltime;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }
    public void firstnumber(string color)// the color in first slot
    {
        firstslotnumber = color;
        s2t.checkingfirstslotnumber(firstslotnumber, winninground, currnentround);// sending data to slot2
        s3t.checkingfirstslotnumber(firstslotnumber, winninground, currnentround);
    }

    // Update is called once per frame
    public void spinwheel(bool start)//bool from handle_drag script after handle is dragged
    {
        if(start == true)
        {
            s_d = true;
            reset_candw = false;
            speed = 1200;speed2 = 1100;speed3 = 1000;// adding speed to the slots
            rotation = true;
            start = false;
        }
    }
    void Update()// rotation of slots
    {
        rotate_slots();
        if(Time.time > s_calltime)
        {
            s_calltime = Time.time + 0.1f;
            s_dec();
        }
        if (Time.time > s2_calltime)
        {
            s2_calltime = Time.time + 0.1f;
            speed2_dec();
        }
        if (Time.time > s3_calltime)
        {
            s3_calltime = Time.time + 0.1f;
            speed3_dec();
        }

    }
    void rotate_slots()
    {
        if (rotation == true)
        {
            slot1wheel.transform.Rotate(Vector3.up * speed * Time.deltaTime);
            slot2wheel.transform.Rotate(Vector3.up * speed2 * Time.deltaTime);
            slot3wheel.transform.Rotate(Vector3.up * speed3 * Time.deltaTime);
        }

    }
   
    public void set_c_nandw_n()// set the currentround and winning round
    {if(reset_candw == false)
        {
            if (currnentround != winninground)
            {
                currnentround += 1;
            }
            else if (currnentround == winninground)
            {
                winninground += 1;
                currnentround = 1;
                jackpot.SetActive(true);
            }
            reset_candw = true;
           
        }

       
    }
      public void s_dec()
    { if(s_d == true)
        {
           
            speed -= 10;
            if (speed <= 0)
            {
                s1t.boolmatch();
                s_d = false;
                s2 = true;
                speed2 = 400;
            }
        }
    }
    public void speed2_dec()
    {  if(s2 == true)
        {   speed2 -= 10;
           
            if (speed2 <= 0)
            {
                s2t.boolmatch();
                s3 = true;
                s2 = false;
                speed3 = 300;

            }
        }
    }
   
   
 
    public void speed3_dec()
    {
      if(s3 == true)
        {
           
            speed3 -= 10;
            if (speed3 <= 0)
            {
                s3t.boolmatch();
                s3 = false;
            }   
      }             
    }
}
