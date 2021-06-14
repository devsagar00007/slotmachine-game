using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle_drag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] game_manager gm;
    [SerializeField] slot1trigger s1t;
    [SerializeField] GameObject firstpos, secondpos,fps,jackpot;
    bool handle;
    public int camm;
    private void OnMouseDrag()
    {if(handle == false)
        {
            transform.rotation = Quaternion.Euler(90, 0, 0);
            gm.spinwheel(true);// giving start bool to game_manager to start rotating slots
            s1t.stop = false;
            handle = true;
            camm = 1;
        }
    }
    public void reset()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        handle = false;
      
        Invoke("camm_inc", 1);
    }
    void camm_inc()
    {
        jackpot.SetActive(false);
        camm = 2;
        
    }
    private void FixedUpdate()
    {
        if(camm == 1)
        {
            fps.transform.position = Vector3.Lerp(fps.transform.position, secondpos.transform.position, Time.deltaTime * 4f);
           
        }
        else if(camm == 2)
        {
            fps.transform.position = Vector3.Lerp(fps.transform.position, firstpos.transform.position, Time.deltaTime * 4f);
           
        }
    }
}
