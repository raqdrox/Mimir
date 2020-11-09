using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SentScript : MonoBehaviour
{
    public int MailType;
    private int MsgSize;
    private string MsgText;
    public GameObject SentMessage;
    public GameObject scene1, scene2;
    public Text TimeText;

    public void SwitchInit(string MsgInput)
    {
        if (MailType == 0) // Used incase of D-MAIL
        {
            MsgText = MsgInput;
            MsgSize = ((int)MsgInput.Length / 12)+1;
            if(MsgSize == 4)
                MsgSize--;
            SceneSwitcher();
            
        }
        else // Used incase of D-RINE
        {
            SentMessage.GetComponentInChildren<Text>().text = MsgInput;
            SentMessage.SetActive(true);
        }
    }

    public void SceneSwitcher() // Additional steps for D-MAIL
    {
        TimeText.text=System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");
        SentMessage.GetComponentInChildren<Text>().text = MsgText;
        scene1.SetActive(false);
        scene2.SetActive(true);

    }

}
