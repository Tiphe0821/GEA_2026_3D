using UnityEngine;

public class Lesson09 : MonoBehaviour
{
    public int gold = 100;
    public int position = 3;

    [ContextMenu("골드 보기")]
    private void ShowGold()
    {
        Debug.Log(gold);
    }



    [ContextMenu("Hello")]
    private void Hello()
    {
        Debug.Log("Hello");
    }

    // 아래부터 테스트 함수들


    [ContextMenu("Test_01")]
    private void Test_01()
    {
        int hp = 10;
        Debug.Log(hp);
    }



    [ContextMenu("Test_02")]
    private void Test_02()
    {
        int hp = 7;
        Debug.Log(hp);  
    }



    [ContextMenu("예측 1")]
    void Predict1()
    {
        int hp = 10;
        hp = hp - 3;
        Debug.Log(hp);  // 7
        hp = 20;
        Debug.Log(hp);  // 20
        int maxHp = hp;
        hp = 5;
        Debug.Log(maxHp);   // 20
    }



    [ContextMenu("Test_04")]
    private void Test_04()
    {

    }

}
