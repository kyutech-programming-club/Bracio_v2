using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PasswordPanel : MonoBehaviour
{
    int[] Answer = { 1, 2, 3, 4 };

    // NumberPanel（4つのダイヤル）を参照するための配列
    [SerializeField] NumberPanel[] numberPanels = default;
    public doorOpen dooropen;
    // ボタンが押されたときにパスワードをチェック
    public void OnClickButton()
    {
        if (CheckClear())
        {
            dooropen.OpenDoor();
            Debug.Log("Clear"); // パスワードが正解ならクリア処理
        }
    }

    // 入力されたパスワードが正しいか確認する
    bool CheckClear()
    {
        for (int i = 0; i < numberPanels.Length; i++)
        {
            // 各ダイヤルの数字が正解の配列と一致しなければfalseを返す
            if (numberPanels[i].number != Answer[i])
            {
                return false;
            }
        }
        return true; // すべて一致していればtrueを返す
    }
}