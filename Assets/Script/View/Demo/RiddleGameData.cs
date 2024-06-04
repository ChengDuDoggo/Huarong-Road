using System.Collections.Generic;
/// <summary>
/// 解谜游戏
/// </summary>
public class RiddleGameData
{
    /// <summary>
    /// ID
    /// </summary>
    public int GameId { get; set; }
    /// <summary>
    /// 游戏名称
    /// </summary>
    public string  GameName { get; set; }
    /// <summary>
    /// 游戏明细
    /// </summary>
    public string  Desc { get; set; }
    /// <summary>
    /// 解谜介绍
    /// </summary>
    public string Note { get; set; }
    /// <summary>
    /// 限定时间
    /// </summary>
    public int Times { get; set; }
    /// <summary>
    /// 图片
    /// </summary>
    public string Image { get; set; }
    /// <summary>
    /// 答案
    /// </summary>
    public string Answer { get; set; }
    /// <summary>
    /// 总分
    /// </summary>
    public int Score { get; set; }
    /// <summary>
    /// 游戏提醒
    /// </summary>
    public List<RemindData> RemindDatas { get; set; }
    /// <summary>
    /// 得分
    /// </summary>
    public int succ_Score { get; set; }
    /// <summary>
    /// 扣分
    /// </summary>
    public int error_Score { get; set; }

    public RiddleGameData()
    {
        RemindDatas = new List<RemindData>();
    }
}

/// <summary>
/// 游戏提醒
/// </summary>
public class RemindData 
{
    /// <summary>
    /// 提醒明细
    /// </summary>
    public string Desc { get; set; }
    /// <summary>
    /// 提醒标题
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// 提醒扣分
    /// </summary>
    public int Descore { get; set; }
    /// <summary>
    /// 提醒文字
    /// </summary>
    public string RemindText { get; set; }
    /// <summary>
    /// 提醒图片
    /// </summary>
    public string Image { get; set; }
    /// <summary>
    /// tixID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 提醒类型
    /// </summary>
    public int RemindType { get; set; }


}