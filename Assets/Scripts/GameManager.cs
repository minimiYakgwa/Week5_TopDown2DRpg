using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Animator talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public TalkManager talkManager;
    public bool isAction;
    public int talkIndex;
    public Image portraitImg;
    public QuestManager questManager;
    public Animator portraitAnim;
    public Sprite currentSprite;
    public TypeEffect talk;
    public GameObject menuSet;
    public Text questTalk;
    public GameObject player;
    public Text npcName;

    void Start()
    {
        GameLoad();
        questTalk.text = questManager.CheckQuest();    
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjectData objData = scanObject.GetComponent<ObjectData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetBool("isShow", isAction);

            

    }

    public void Talk(int id, bool isNpc)
    {
        int questTalkIndex = 0;
        string talkData = "";

        // Set Talk Data
        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            questTalkIndex = questManager.GetQuestTalkIndex(id);
            talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        }
        
        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questTalk.text = questManager.CheckQuest(id);
            return;
        }
        if (isNpc)
        {
            npcName.text = talkManager.GetName(id);
            talk.SetMsg(talkData.Split(":")[0]);

            portraitImg.sprite = talkManager.GetPortrait(int.Parse(talkData.Split(":")[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            if(currentSprite != portraitImg.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                currentSprite = portraitImg.sprite;
            }
        }
        else
        {
            talk.SetMsg(talkData);
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
        

    }

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        Debug.Log("PlayerX saving.....");
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        Debug.Log("PlayerY saving.....");
        PlayerPrefs.SetInt("QustId", questManager.questId);
        Debug.Log("QuestId saving.....");
        PlayerPrefs.SetInt("QustActionIndex", questManager.questActionIndex);
        Debug.Log("QuestActionIndex saving.....");
        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
            return;
        float x = PlayerPrefs.GetFloat("PlayerX");
        Debug.Log("PlayerX Data Loading.....");
        float y = PlayerPrefs.GetFloat("PlayerY");
        Debug.Log("PlayerY Data Loading.....");
        int questId = PlayerPrefs.GetInt("QustId");
        Debug.Log("QuestId Data Loading.....");
        int questActionIndex = PlayerPrefs.GetInt("QustActionIndex");
        Debug.Log("QuestActionIndex Data Loading.....");

        player.transform.position = new Vector3(x, y, 0);
        questManager.questId = questId;
        questManager.questActionIndex = questActionIndex;
        questManager.ControlObject();
    }
    public void GameReset()
    {
        PlayerPrefs.DeleteAll();
        GameExit();
    }

    public void GameExit()
    {
        Application.Quit();
    }

        
}
