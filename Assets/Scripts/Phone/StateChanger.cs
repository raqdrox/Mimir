using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateChanger : MonoBehaviour
{
    public int imgState = 0;
    private int Frame;
    private int objcode;
    public BatteryLevel blvl = null;
    public SignalLevel slvl = null;
    public Image Image;
    public Sprite state_0, state_1, state_2, state_3, state_4;
   
    void Start()
    {
        Frame = 0;
        Image = this.GetComponent<Image>();
        if(blvl!=null)
        {
            blvl = blvl.GetComponent<BatteryLevel>();
            objcode = 0;
        }
        else
        {
            slvl = slvl.GetComponent<SignalLevel>();
            objcode = 1;
        }
    }


    void Update()
    {
        Frame++;

        if (Frame ==  6000 && imgState < 4)
        {
            Frame = 0;
        }
        if (Frame % 30 == 0)
        {
            if (objcode==1)
            {
                switch ((int)(slvl.GetLevel()/20))
                {

                    case 0:
                        Image.sprite = state_0;
                        break;
                    case 1:
                        Image.sprite = state_1;
                        break;
                    case 2:
                        Image.sprite = state_2;
                        break;
                    case 3:
                        Image.sprite = state_3;
                        break;
                    case 4:
                        Image.sprite = state_4;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch ((int)(blvl.GetLevel()/20))
                {

                    case 0:
                        Image.sprite = state_0;
                        break;
                    case 1:
                        Image.sprite = state_1;
                        break;
                    case 2:
                        Image.sprite = state_2;
                        break;
                    case 3:
                        Image.sprite = state_3;
                        break;
                    case 4:
                        Image.sprite = state_4;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
