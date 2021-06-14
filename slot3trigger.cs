using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot3trigger : MonoBehaviour
{
    [SerializeField] GameObject slot2wheel;
    [SerializeField] game_manager gm;[SerializeField] handle_drag hd;
    int w_r, c_r;
    string firstslotcolor;
    bool stop, s3tb, match_color;
    string match;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        correct_slot();
    }
    public void correct_slot()
    {
        if (s3tb == true)
        {
            slot2wheel.transform.Rotate(Vector3.up * 1f);// if color is not properly aligned with the view
            match_color = true;// bool to allow the two slots to get compared
        }
    }
    public void checkingfirstslotnumber(string firstslotcolor_, int winround, int currentround)
    {
        firstslotcolor = firstslotcolor_;
        w_r = winround;
        c_r = currentround;
     


    }
    void OnTriggerStay(Collider other)
    {
        if (s3tb)
        {
            if (w_r == c_r)
            {

                if (other.transform.tag == firstslotcolor)
                {
                    s3tb = false;// reset the color compare bool
                    Debug.Log("jackpot");
                    gm.set_c_nandw_n();
                    hd.reset();
                }
            }
            else if(w_r != c_r)
            {  if(other.transform.tag == "red"|| other.transform.tag == "green" || other.transform.tag == "yellow")
                {
                    Debug.Log("now it's right");
                    s3tb = false;// reset the color compare bool
                    gm.set_c_nandw_n();
                    hd.reset();
                }
                //if (other.transform.tag != firstslotcolor)
                //{
                //    Debug.Log("now it's right");
                //    s3tb = false;// reset the color compare bool
                //    gm.set_c_nandw_n();
                //    hd.reset();
                //}
            }
        }

    }

    public void boolmatch()
    {
        s3tb = true;
    }
}
