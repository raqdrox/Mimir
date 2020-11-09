using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class LevelLoader : MonoBehaviour
{
    public Animator transition; 

    public int sceneNum;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(LoadLevel());
        }
    }
    public void LoadNextLevel(){
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        Debug.Log("starting transistion");
        //play anim
        transition.SetTrigger("end");
        Debug.Log("transition end");
        //wait
        yield return new WaitForSeconds(1.5f);
        //load scene
        SceneManager.LoadScene(sceneNum); 

    }
}
