using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot1trigger : MonoBehaviour
{
    [SerializeField] game_manager gm;
  [SerializeField] GameObject slot1wheel;
   public bool s1tb,stop;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        correctslot();
    }
    public void correctslot()
    {
        if (s1tb == true)
        {
            slot1wheel.transform.Rotate(Vector3.up * 1f);// if color is not properly aligned with the view
        }
    }
  public  void boolmatch()
    {
        s1tb = true;
    }
    private void OnTriggerStay(Collider other)
    {
       
        if (gm.speed <= 0 && stop == false)
        {
            if (other.transform.tag == "red" )// if player facing color is red
            {
              
                Debug.Log("red");
                s1tb = false;
                gm.firstnumber("red"); // sending player facing color to game_manager
                stop = true;
            }
            else if (other.transform.tag == "yellow")// if player facing color is yellow
            {
                Debug.Log("yellow");
                s1tb = false;
                gm.firstnumber("yellow"); // sending player facing color to game_manager
                stop = true;
            }
            else if (other.transform.tag == "green")// if player facing color is green
            {
                Debug.Log("green");
                s1tb = false;
                gm.firstnumber("green"); // sending player facing color to game_manager
                stop = true;
            }
           

        }
     
    }

}

    
