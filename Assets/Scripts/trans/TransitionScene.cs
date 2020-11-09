using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransitionScene : MonoBehaviour
{
    public string SceneName="";
    public float TransSpeed=1f;
    public void SceneTrans(){
        Initiate.Fade(SceneName,Color.black,TransSpeed);
    }
}
