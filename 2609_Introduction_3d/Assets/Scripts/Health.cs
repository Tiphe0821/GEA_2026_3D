using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    public int maxHp = 3;
    public int currentHp;
    public Slider hpSilder;
    public float invincibleTime = 0f;   // 플레이어는 0.5
    float lastHitTime = -999f;

    public GameObject dropPrefab;
    public float dropChance = 0.3f;

    public GameObject hitEffect;

    public static int killCount;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        UpdateBar();
        TakeDamage(0);
    }

    public void TakeDamage(int damage)
    {
        if (currentHp <= 0) return;
        if (Time.time < lastHitTime + invincibleTime) return;
        lastHitTime = Time.time;

        currentHp -= damage;
        Debug.Log(name + " HP: " + currentHp);

        Vector3 hitPos = transform.position + Vector3.up;
        if (hitEffect != null)
            Instantiate(hitEffect, hitPos, Quaternion.identity);

        UpdateBar();

        if (currentHp <= 0) Die();
        else Blink();

    }

    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        UpdateBar();
    }

    void Blink()
    {
        SetVisible(false);
        Invoke(nameof(ShowAgain), 0.1f);
    }

    void ShowAgain()
    {
        SetVisible(true);
    }

    void SetVisible(bool on)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = on;
    }



    void UpdateBar()
    {
        if(hpSilder != null) 
            hpSilder.value = (float)currentHp / maxHp;
    }

    void Die()
    {
        if (CompareTag("Player"))
        {
            Debug.Log("게임오버");
            Time.timeScale = 0f;
        }
        else
        {
            killCount++;
            if (dropPrefab != null && Random.value < dropChance)
            {
                Vector3 pos = transform.position + Vector3.up * 0.5f;
                Instantiate(dropPrefab, pos, Quaternion.identity);
            }

            Destroy(gameObject) ;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
