using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DmailInitiate : MonoBehaviour
{
    public InputField TextInput;
    private string MsgInput;
    public Button btn;
    public GameObject anim;
    private AudioSource ReadingSteinerSound;
    public DmailBackend DmBackObj;
    public SentScript SentObj;
    public AudioSource Notif;
    public void Initiate()
    {
        MsgInput = TextInput.text;
        TextInput.text = "";
        ReadingSteinerSound = this.GetComponent<AudioSource>();
        StartCoroutine(DmailAnim());
        DmBackObj.Send();
    }
    IEnumerator DmailAnim()
    {
        btn.interactable = false;
        ReadingSteinerSound.Play();
        Notif.Play();
        anim.SetActive(true);
        anim.GetComponent<Animator>().SetTrigger("StartDmail");
        yield return new WaitForSeconds(4);
        SentObj.SwitchInit(MsgInput);
        yield return new WaitForSeconds(7);
        anim.SetActive(false);
    }

}