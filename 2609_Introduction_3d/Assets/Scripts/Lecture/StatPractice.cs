using UnityEngine;

public class StatPractice : MonoBehaviour
{
    public string playerName = "Player";

    public int level = 0;

    public float attack = 12.5f; // f를 넣지 않으면 에러 발생

    public bool isBoss = false;

    [ContextMenu("스탯 확인")]
    public void ShowStat()
    {
        Debug.Log(playerName);
        Debug.Log(level);
        Debug.Log(attack);
        Debug.Log(isBoss);
    }

    [ContextMenu("오버플로")]
    public void Overflow()
    {
        int gold = int.MaxValue;
        Debug.Log(gold);
        gold = gold + 1;
        Debug.Log(gold);
        byte red = 255;
        red++;
        Debug.Log(red);
    }

    [ContextMenu("예측 2")]
    void Predict2()
    {
        int hp = 7;
        int maxHp = 10;
        Debug.Log(hp / maxHp);          // 0
        Debug.Log((float)hp / maxHp);   // 0.7
        Debug.Log(hp / 2);              // 3
        Debug.Log(hp / 2f);             // 3.5
        Debug.Log(hp % 2);              // 1
    }

    [ContextMenu("나머지")]
    void Remainder()
    {
        int shotCount = 6;
        int totalSeconds = 135;

        bool isEven = shotCount % 2 == 0;
        bool strongShot = shotCount % 3 == 0;
        int min = totalSeconds / 60;
        int sec = totalSeconds % 60;
        Debug.Log(min + ":" + sec);
    }

    [ContextMenu("예측 3")]
    void Predict3()
    {
        int a = 1;
        int b = 2;
        Debug.Log("합: " + a + b);           // 합 : 12
        Debug.Log("합: " + (a + b));         // 합 : 3
        Debug.Log(a + b + "점");             // 3점      // 앞에서부터 차례대로 하기 때문에 a + b가 오면 a+b 연산을 하게된다
        Debug.Log("HP " + 7 / 2);            // HP 3
    }


}
