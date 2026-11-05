using System;
using UnityEngine;

public class RewardCalc : MonoBehaviour
{
    public int playSeconds = 3725,      // 플레이 시간
        gold = 1234,                    // 획득 골드량
        members = 4,                    // 파티 멤버
        kills = 7,                      // 킬 수 
        expPerKill = 35,                // 킬당 경험치
        totalDamage = 250,              // 총 데미지
        hits = 20;                      // 몇대 때렸지?

    public float expRate = 1.5f;        // 배율


    /// <summary>
    /*      시:분:초.분과 초는 항상 두 자리(1:02:05). ToString 같은 문자열 기능 없이 / 와 % 로만
            어려우면 1시간 2분 5초 식으로 해도 무방

            골드 분배 
            1인당 골드와 나누고 남은 골드(리더 보너스)

            경험치
            기본 경험치 = 처치 수 × 처치당 경험치.최종 = 기본 × 배율, 소수점 버림. 둘 다 출력

            레벨
            레벨마다 100 이 필요. 최종 경험치로 레벨 (1 부터) 과 다음 레벨까지 남은 경험치

            평균 데미지
            totalDamage / hits 를 소수까지
    */
    /// </summary>

    // 1시간      3600s
    // 1분        60s

    int a = 3600;
    int b = 60;


    [ContextMenu("정산")]
    public void Settle()
    {
        int zero = 0;
        int hour = playSeconds / 3600;
        int minute = (playSeconds % 3600) / 60;
        int second = (playSeconds % 3600) % 60;



        // 조건문 X
        //Debug.Log(hour + " : " + zero + minute + " : " + zero + second);        // 이건 아닐텐데? 알았다

        int minute_10 = minute / 10;
        int minute_01 = minute % 10;
    
        int second_10 = second / 10;
        int second_01 = second % 10;

        // 시간 출력
        Debug.Log(hour + ":" + minute_10 + minute_01 + ":" + second_10 + second_01);

        // 조건문 O
        // Debug.Log(hour + " : " + (minute > 10 ? minute : "0" + minute ) + " : " + (second > 10 ? second : "0" + second));

        // 골드 분배
        Debug.Log(gold / 4 + " 골드, " + gold % 4 + " 리더 보너스");

        // 경험치 획득 
        Debug.Log("기본 경험치 : " + expPerKill * kills + " 배율 경험치 : " + expPerKill * kills * expRate);

        // 다음 레벨까지 필요한 경험치
        Debug.Log("현재 레벨 : " + (expPerKill * kills / 100) + " 다음 레벨까지 : " + (totalDamage * kills % 100));

        // 평균 데미지
        Debug.Log("평균 데미지 : " + (float)totalDamage / hits);

    }
}
