using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCGuid : MonoBehaviour
{
    string[] guids =
    {
        "어서오세요! 어떤걸 거래하실건가요?",
        "오늘은 아주 좋은 물건이 들어왔다구요!",
        "어소옵쇼"
    };

    public void guid()
    {
        // 0
        // 1
        // 2

        int rand = Random.Range(0,3);
        Debug.Log(guids[rand]);
        // guids[rand]

        //Debug.Log("어서오세요! 어떤걸 거래하실건가요?");
        //Debug.Log("오늘은 아주 좋은 물건이 들어왔다구요!");
        //Debug.Log("어소옵쇼");
        //Debug.Log("어서오세요! 어떤걸 거래하실건가요?");
        //Debug.Log("어서오세요! 어떤걸 거래하실건가요?");
    }
}
