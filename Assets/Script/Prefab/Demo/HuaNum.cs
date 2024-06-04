using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class HuaNum : MonoBehaviour, IDragHandler, IEndDragHandler
{
    /// <summary>
    /// 物体类型 0 小物体 1横矩形 2 竖矩形 3 正方形
    /// </summary>
    public int type;
    /// <summary>
    /// 物体所占位置
    /// </summary>
    public List<int> num;
    private Vector2 Vector;//第一次拖拽起点
    private bool IsDrag = false;//true 进入拖拽 false 拖拽结束
    private bool IsMove = true;//true 可以移动 false 移动结束 
    public void OnDrag(PointerEventData eventData)
    {
        //第一次进入时，将状态修改并赋值
        if (IsDrag == false && IsMove)
        {
            IsDrag = true;
            Vector = eventData.position;
        }
        if (IsDrag)
        {
            //向右
            if (eventData.position.x - 6 > Vector.x)
            {
                if (IsMove)
                    JudgeMove(3, eventData.position);
            }
            //向左
            if (eventData.position.x + 6 < Vector.x)
            {
                if (IsMove)
                    JudgeMove(2, eventData.position);
            }
            //向上
            if (eventData.position.y - 6 > Vector.y)
            {
                if (IsMove)
                    JudgeMove(0, eventData.position);
            }
            //向下
            if (eventData.position.y + 6 < Vector.y)
            {
                if (IsMove)
                    JudgeMove(1, eventData.position);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        IsDrag = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="Wz">方向 0Up1Down2Left3Rignt</param>
    /// <param name="vector">相对拖拽位置</param>
    void JudgeMove(int Wz, Vector2 vector)
    {
        IsMove = false;
        bool mv = false;//判断是否可以移动
        List<int> empty = transform.parent.GetComponent<GameView>().EmptyNum;
        switch (Wz)
        {
            case 0:
                Debug.Log("向上");
                //单单元格移动
                if (type == 0)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 5 == empty[i])
                        {
                            //重新计算位置
                            empty[i] = num[0];
                            num[0] = num[0] - 5;
                            mv = true;
                            Move(mv, 0);
                            return;
                        }
                    }
                }
                //横矩形移动
                else if (type == 1)
                {
                    bool left = false, right = false;//左右两个单元格都空着，则true
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 5 == empty[i])
                            left = true;
                        if (num[1] - 5 == empty[i])
                            right = true;
                    }
                    if (left && right)
                    {
                        empty[0] = num[0];
                        empty[1] = num[1];
                        num[0] = num[0] - 5;
                        num[1] = num[1] - 5;
                        mv = true;
                    }
                }
                //竖矩形移动
                else if (type == 2)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 5 == empty[i])
                        {
                            //重新计算位置
                            empty[i] = num[1];
                            num[1] = num[0];
                            num[0] = num[0] - 5;
                            mv = true;
                            Move(mv, 0);
                            return;
                        }
                    }
                }
                //正方形移动
                else if (type == 3)
                {
                    bool left = false, right = false;//左右两个单元格都空着，则true
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 5 == empty[i])
                            left = true;
                        if (num[1] - 5 == empty[i])
                            right = true;
                    }
                    if (left && right)
                    {
                        empty[0] = num[2];
                        empty[1] = num[3];
                        num[2] = num[0];
                        num[3] = num[1];
                        num[0] = num[0] - 5;
                        num[1] = num[1] - 5;
                        mv = true;
                    }
                }
                Move(mv, 0);
                break;
            case 1:
                Debug.Log("向下");
                //单单元格移动
                if (type == 0)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] + 5 == empty[i])
                        {
                            //重新计算位置
                            empty[i] = num[0];
                            num[0] = num[0] + 5;
                            mv = true;
                            Move(mv, 1);
                            return;
                        }
                    }
                }
                //横矩形移动
                else if (type == 1)
                {
                    bool left = false, right = false;//左右两个单元格都空着，则true
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] + 5 == empty[i])
                            left = true;
                        if (num[1] + 5 == empty[i])
                            right = true;
                    }
                    if (left && right)
                    {
                        empty[0] = num[0];
                        empty[1] = num[1];
                        num[0] = num[0] + 5;
                        num[1] = num[1] + 5;
                        mv = true;
                    }
                }
                //竖矩形移动
                else if (type == 2)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[1] + 5 == empty[i])
                        {
                            //重新计算位置
                            empty[i] = num[0];
                            num[1] = num[1] + 5;
                            num[0] = num[0] + 5;
                            mv = true;
                            Move(mv, 1);
                            return;
                        }
                    }
                }
                //正方形移动
                else if (type == 3)
                {
                    bool left = false, right = false;//左右两个单元格都空着，则true
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[2] + 5 == empty[i])
                            left = true;
                        if (num[3] + 5 == empty[i])
                            right = true;
                    }
                    if (left && right)
                    {
                        empty[0] = num[0];
                        empty[1] = num[1];
                        num[2] = num[2] + 5;
                        num[3] = num[3] + 5;
                        num[0] = num[0] + 5;
                        num[1] = num[1] + 5;
                        mv = true;
                    }
                }
                Move(mv, 1);
                break;
            case 2:
                Debug.Log("向左");
                //单单元格移动
                if (type == 0)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 1 == empty[i])
                        {
                            //重新计算位置
                            empty[i] = num[0];
                            num[0] = num[0] - 1;
                            mv = true;
                            Move(mv, 2);
                            return;
                        }
                    }
                }
                //横矩形移动
                else if (type == 1)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 1 == empty[i])
                        {
                            empty[i] = num[1];
                            num[0] = num[0] - 1;
                            num[1] = num[1] - 1;
                            mv = true;
                            Move(mv, 2);
                            return;
                        }
                    }
                }
                //竖矩形移动
                else if (type == 2)
                {
                    bool left = false, right = false;
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 1 == empty[i])
                        {
                            left = true;
                        }
                        if (num[1] - 1 == empty[i])
                        { right = true; }
                    }
                    if (left && right)
                    {
                        //重新计算位置
                        empty[0] = num[0];
                        empty[1] = num[1];
                        num[1] = num[1] - 1;
                        num[0] = num[0] - 1;
                        mv = true;
                    }
                }
                //正方形移动
                else if (type == 3)
                {
                    bool left = false, right = false;//左右两个单元格都空着，则true
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] - 1 == empty[i])
                            left = true;
                        if (num[2] - 1 == empty[i])
                            right = true;
                    }
                    if (left && right)
                    {
                        empty[0] = num[1];
                        empty[1] = num[3];
                        num[1] = num[0];
                        num[3] = num[2];
                        num[0] = num[0] - 1;
                        num[2] = num[2] - 1;
                        mv = true;
                    }
                }
                Move(mv, 2);
                break;
            case 3:
                Debug.Log("向右");
                //单单元格移动
                if (type == 0)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] + 1 == empty[i])
                        {
                            if (num[0] % 5 == 0)
                                continue;
                            //重新计算位置
                            empty[i] = num[0];
                            num[0] = num[0] + 1;
                            mv = true;
                            Move(mv, 3);
                            return;
                        }
                    }
                }
                //横矩形移动
                else if (type == 1)
                {
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[1] + 1 == empty[i])
                        {
                            if (num[1] % 5 == 0)
                                continue;
                            empty[i] = num[0];
                            num[0] = num[0] + 1;
                            num[1] = num[1] + 1;
                            mv = true;
                            Move(mv, 3);
                            return;
                        }
                    }
                }
                //竖矩形移动
                else if (type == 2)
                {
                    bool left = false, right = false;
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[0] + 1 == empty[i])
                        {
                            if (num[0] % 5 == 0)
                                continue;
                            left = true;
                        }
                        if (num[1] + 1 == empty[i])
                        {
                            if (num[1] % 5 == 0)
                                continue;
                            right = true;
                        }
                    }
                    if (left && right)
                    {
                        //重新计算位置
                        empty[0] = num[0];
                        empty[1] = num[1];
                        num[1] = num[1] + 1;
                        num[0] = num[0] + 1;
                        mv = true;
                    }
                }
                //正方形移动
                else if (type == 3)
                {
                    bool left = false, right = false;//左右两个单元格都空着，则true
                    for (int i = 0; i < empty.Count; i++)
                    {
                        if (num[1] + 1 == empty[i])
                        {
                            if (num[1] % 5 == 0)
                                continue;
                            left = true;
                        }
                        if (num[3] + 1 == empty[i])
                        {
                            if (num[3] % 5 == 0)
                                continue;
                            right = true;
                        }
                    }
                    if (left && right)
                    {
                        empty[0] = num[0];
                        empty[1] = num[2];
                        num[0] = num[1];
                        num[2] = num[3];
                        num[1] = num[0] + 1;
                        num[3] = num[2] + 1;
                        mv = true;
                    }
                    if (num[1] == 10 && num[3] == 15)//通关
                    {
                        Move(true, 4);//通关
                        transform.parent.parent.Find("Victory").gameObject.SetActive(true);
                        return;
                    }
                }
                Move(mv, 3);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 移动
    /// </summary>
    /// <param name="IsMove">是否移动</param>
    /// <param name="wz">移动方向</param>
    void Move(bool IMove, int wz)
    {
        Tweener twe;
        if (IMove && wz == 0)
        {
            twe = transform.DOLocalMove(transform.localPosition + new Vector3(0, 200), 0.5f);
            twe.OnComplete(() =>
            {
                IsMove = true;
            });
        }
        else if (IMove && wz == 1)
        {
            twe = transform.DOLocalMove(transform.localPosition + new Vector3(0, -200), 0.5f);
            twe.OnComplete(() =>
            {
                //transform.DOShakeScale(0.5f, new Vector3(0.1f, 0.1f, 0), 40);
                IsMove = true;
            });
        }
        else if (IMove && wz == 2)
        {
            twe = transform.DOLocalMove(transform.localPosition + new Vector3(-200, 0), 0.5f);
            twe.OnComplete(() =>
            {
                //transform.DOShakeScale(0.5f, new Vector3(0.1f, 0.1f, 0), 40);
                IsMove = true;
            });
        }
        else if (IMove && wz == 3)
        {
            twe = transform.DOLocalMove(transform.localPosition + new Vector3(200, 0), 0.5f);
            twe.OnComplete(() =>
            {
                //transform.DOShakeScale(0.5f, new Vector3(0.1f, 0.1f, 0), 40);
                IsMove = true;
            });
        }
        else if (IMove && wz == 4)
        {
            twe = transform.DOLocalMove(transform.localPosition + new Vector3(500, 0), 3f);
        }
        else
            IsMove = true;
    }
}
