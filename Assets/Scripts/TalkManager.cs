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
        talkData.Add(1000, new string[] { "안녕?:1000", "뉴비니?:1001" });
        talkData.Add(20000, new string[] { "누군가 사용한 흔적이 있는 책상이다."});
        talkData.Add(10000, new string[] {"평범한 나무 상자이다." });
        talkData.Add(2000, new string[] { "이번에 새로 온 주민이니?:2000", "잘 부탁한다 그래:2001" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);

        talkData.Add(10 + 1000, new string[] { "안녕?:1000", "혹시 뉴비니?:1001",
            "그럼 이 퀘스트를 먼저 깨는 걸 추천할게:1000", "아랫집에 널 필요로 하는 사람이 있으니 그쪽으로 가 봐.:1002" });

        talkData.Add(11 + 2000, new string[] { "여, 반가워 신입:2000", "혹시 내 동전 좀 찾아줄 수 있겠니?:2001" });

        talkData.Add(20 + 1000, new string[] { "루도의 동전?:1000", "돈을 잃어버리면 못쓰지!:1003", "나중에 쓴소리 좀 해야겠어:1003" });

        talkData.Add(20 + 2000, new string[] { "찾으면 꼭 가져다줘..:2001" });
        talkData.Add(20 + 5000, new string[] { "동전을 주웠다" });

        talkData.Add(21 + 2000, new string[] { "내 돈을 찾아줘서 고마워~:2000" });

        nameData.Add(1000, "루나");
        nameData.Add(2000, "스티브");



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

