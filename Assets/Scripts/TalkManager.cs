using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    Dictionary<int, string> nameData;
    public Sprite[] portraitArr;
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        nameData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:1000", "�����?:1001" });
        talkData.Add(20000, new string[] { "������ ����� ������ �ִ� å���̴�."});
        talkData.Add(10000, new string[] {"����� ���� �����̴�." });
        talkData.Add(2000, new string[] { "�̹��� ���� �� �ֹ��̴�?:2000", "�� ��Ź�Ѵ� �׷�:2001" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);

        talkData.Add(10 + 1000, new string[] { "�ȳ�?:1000", "Ȥ�� �����?:1001",
            "�׷� �� ����Ʈ�� ���� ���� �� ��õ�Ұ�:1000", "�Ʒ����� �� �ʿ�� �ϴ� ����� ������ �������� �� ��.:1002" });

        talkData.Add(11 + 2000, new string[] { "��, �ݰ��� ����:2000", "Ȥ�� �� ���� �� ã���� �� �ְڴ�?:2001" });

        talkData.Add(20 + 1000, new string[] { "�絵�� ����?:1000", "���� �Ҿ������ ������!:1003", "���߿� ���Ҹ� �� �ؾ߰ھ�:1003" });

        talkData.Add(20 + 2000, new string[] { "ã���� �� ��������..:2001" });
        talkData.Add(20 + 5000, new string[] { "������ �ֿ���" });

        talkData.Add(21 + 2000, new string[] { "�� ���� ã���༭ ����~:2000" });

        nameData.Add(1000, "�糪");
        nameData.Add(2000, "��Ƽ��");



    }

    public string GetName(int id)
    {
        return nameData[id];
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }




    }

    public Sprite GetPortrait(int portraitIndex)
    {
        return portraitData[portraitIndex];
    }

}

