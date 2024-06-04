using UnityEngine;
using UnityEngine.UI;

public class HuarongPage : MonoBehaviour
{
    public Button TipBtn;
    public GameObject Hint;
    public Button Exit;
    private RiddleGameData riddle = new RiddleGameData();
    public Transform TipEnter;//进入提醒
    public Text Scroe;
    public Button ExitBtn;
    public Image Bg;
    private void Awake()
    {
        TipBtn.onClick.AddListener(() =>
        {
            Hint.gameObject.SetActive(true);
        });
        Exit.onClick.AddListener(() => {Hint.gameObject.SetActive(false); });
    }

    private void Start()
    {
        RemindData remindData = new RemindData();
        remindData.ID = 1011;
        remindData.RemindText = "提醒文字";
        remindData.Title = "难度降低50%";
        remindData.Descore = -10;
        remindData.RemindType = 0;
        riddle.RemindDatas.Add(remindData);
        RemindData remindData1 = new RemindData();
        remindData1.ID = 1012;
        remindData1.RemindText = "提醒文字";
        remindData1.Title = "难度降低80%";
        remindData1.RemindType = 0;
        remindData1.Descore = -30;
        riddle.RemindDatas.Add(remindData1);

        riddle.Score = 50;
        Scroe.text = riddle.Score.ToString();
    }

    void HinBtnClick(GameObject btn)
    {
        int ridid = int.Parse(btn.name.Replace("HintBtn", ""));
        foreach (var item in riddle.RemindDatas)
        {
            if (item.ID == ridid)
            {
                if (riddle.Score >= item.Descore * -1)
                {
                    riddle.Score = riddle.Score - item.Descore;
                    if (ridid == 1011)
                    {
                        Hint.SetActive(false);
                        transform.Find("GameView").GetComponent<GameView>().Remind(0);
                    }
                    else if (ridid == 1012)
                    {
                        Hint.SetActive(false);
                        transform.Find("GameView").GetComponent<GameView>().Remind(1);
                    }
                    else
                        TipEnter.transform.parent.parent.Find("Answer" + ridid).gameObject.SetActive(true);
                }
            }
        }
    }
}
