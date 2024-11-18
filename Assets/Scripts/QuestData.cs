using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : MonoBehaviour
{
    public string questName;
    public int[] npcId;

    public QuestData(string questName, int[] npcId)
    {
        this.questName = questName;
        this.npcId = npcId;
    }
}
