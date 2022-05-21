using UnityEngine;
using UnityEngine.UI;
public class ObjectsAttributes : MonoBehaviour
{
    [Header("Stat")]
    public float MaxHp;
    private float Hp;
    public float Atk;
    public float Def;
    public float Exp;
    public float Gold;
    private int killcount;

    [Header("Health Bar")]
    public Slider healthBar;
    public Gradient gradient;
    public Image fill;


    void Start()
    {
        fill.color = gradient.Evaluate(1f);
        Hp = MaxHp;
    }

    // Attack Handle
    public void attack(GameObject enermy)
    {
        ObjectsAttributes e = enermy.GetComponent<ObjectsAttributes>();
        killcount += e.GetComponent<ObjectsAttributes>().wasAttacked(e.Atk);
    }
    public int wasAttacked(float damage)
    {
        Hp -= damage * (100 - Def) / 100;
        SetHealthBar();
        if (Hp <= 0)
        {
            Destroy(gameObject);
            return 1;
        }
        return 0;
    }

    // Health Bar Handle
    private void SetHealthBar()
    {
        healthBar.value = Hp / MaxHp;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }

    // Getter and Setter
    public int GetKillCount()
    {
        return killcount;
    }
}
