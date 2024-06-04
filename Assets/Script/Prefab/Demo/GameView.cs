using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    /// <summary>
    /// 空的位置
    /// </summary>
    public List<int> EmptyNum;

    public List<GameObject> Num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Remind(int type)
    {
        if (type == 0)//前进50%
        {
            string str = "pwan1%-400,-300%16|pwan2%-200,-300%17|pwan3%0,-300%18|pwan4%200,100%9|pwan5%300,-300%19,20|pwan6%300,-100%14,15|pwan7%-300,300%1,2|pwan8%100,300%3,4|pwan9%400,200%5,10|pwan10%-100,0%7,8,12,13";
            string[] strings = str.Split('|');
            for (int i = 0; i < strings.Length; i++)
            {
                string[] pwans = strings[i].Split('%');
                Num[i].transform.DOLocalMove(new Vector3(int.Parse(pwans[1].Split(',')[0]), int.Parse(pwans[1].Split(',')[1])), 1f);
                string[] num = pwans[2].Split(',');
                for (int j = 0; j < num.Length; j++)
                {
                    Num[i].GetComponent<HuaNum>().num[j] = int.Parse(num[j]);
                }
            }
            EmptyNum[0] = 6;
            EmptyNum[1] = 11;
        }
        else if (type == 1)
        {
            string str = "pwan1%400,-300%20|pwan2%-200,-100%12|pwan3%-400,-100%11|pwan4%400,-100%15|pwan5%100,-300%18,19|pwan6%-300,-300%16,17|pwan7%-300,300%1,2|pwan8%100,300%3,4|pwan9%400,200%5,10|pwan10%100,0%8,9,13,14";
            string[] strings = str.Split('|');
            for (int i = 0; i < strings.Length; i++)
            {
                string[] pwans = strings[i].Split('%');
                Num[i].transform.DOLocalMove(new Vector3(int.Parse(pwans[1].Split(',')[0]), int.Parse(pwans[1].Split(',')[1])), 1f);
                string[] num = pwans[2].Split(',');
                for (int j = 0; j < num.Length; j++)
                {
                    Num[i].GetComponent<HuaNum>().num[j] = int.Parse(num[j]);
                }
            }
            EmptyNum[0] = 6;
            EmptyNum[1] = 7;
        }
    }
}
