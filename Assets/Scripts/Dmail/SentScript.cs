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

    private char DigToChar(int a) => a == 0 ? '0' : (char)(a + 48);

    private string GetSendTime()
    {
        char[] TempTime = System.DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy").ToCharArray();
        int TimeMins = ((((int)(TempTime[0] - '0')) * 10 + (int)(TempTime[1] - '0')) * 60) + (((int)(TempTime[3] - '0') * 10) + (int)(TempTime[4] - '0'));
        TimeMins -= 5;
        TempTime[0] = DigToChar(TimeMins / 60 / 10);
        TempTime[1] = DigToChar(TimeMins / 60 % 10);
        TempTime[3] = DigToChar(TimeMins % 60 / 10);
        TempTime[4] = DigToChar(TimeMins % 60 % 10);
        return new string(TempTime);
    }
    public void SceneSwitcher() // Additional steps for D-MAIL
    {
        TimeText.text = GetSendTime();
        SentMessage.GetComponentInChildren<Text>().text = MsgText;
        scene1.SetActive(false);
        scene2.SetActive(true);

    }

}
