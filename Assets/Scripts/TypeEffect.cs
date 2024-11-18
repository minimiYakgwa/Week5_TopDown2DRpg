using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;

    // Character Per Seconds
    public int CPS;

    Text msgText;
    int index;
    float interval;
    public bool isAnim;
    AudioSource audioSource;
    public GameObject EndCursor;

    private void Awake()
    {
        msgText = GetComponent<Text>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectingEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
        
    }

    void EffectStart()
    {
        isAnim = true;
        msgText.text = "";
        index = 0;
        interval = 1.0f / CPS;
        EndCursor.SetActive(false);
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectingEnd();
            return;
        }
        msgText.text += targetMsg[index];
        
        // Sound
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            //audioSource.Play();

        index++;
        Invoke("Effecting", interval);
        
    }

    void EffectingEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }
}


