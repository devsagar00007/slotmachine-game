using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot2trigger : MonoBehaviour
{
    [SerializeField] GameObject slot2wheel;
    [SerializeField] game_manager gm;
    int w_r,c_r;
    string firstslotcolor;
    bool stop,s2tb,match_color;
    string match;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check_slot();
    }
    public void check_slot()
    {
        if (s2tb == true)
        {
            slot2wheel.transform.Rotate(Vector3.up * 1f);// if color is not properly aligned with the view
            match_color = true;// bool to allow the two slots to get compared
        }
    }
    public void checkingfirstslotnumber(string firstslotcolor_,int winround,int currentround)
    {
        firstslotcolor = firstslotcolor_;
        w_r = winround;
        c_r = currentround;
       
    }
    void OnTriggerStay(Collider other)
    {
       
        if (s2tb)
        {
            if (w_r == c_r)
            {
               
                 if(other.transform.tag == firstslotcolor)
                {
                    s2tb = false;// reset the color compare bool
                }
            }
            else if(w_r != c_r)
            {
                if (other.transform.tag != firstslotcolor)
                {
                    Debug.Log("now it's right");
                   s2tb = false;// reset the color compare bool
                }
            }
        }
       
    }

    public void boolmatch()
    {
        s2tb = true;
    }
}
