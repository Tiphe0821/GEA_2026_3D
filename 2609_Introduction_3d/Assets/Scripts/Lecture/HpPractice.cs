using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class HpPractice : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp = 70;

    [ContextMenu("체력 퍼센트 출력")]
    public void ShowHP()
    {
        float currentHpPercent = (float)currentHp / maxHp;
        currentHpPercent *= 100f;
        Debug.Log(currentHpPercent + "%");
        Debug.Log((int)currentHpPercent + "%");
    }
}
