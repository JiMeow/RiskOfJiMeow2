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
    private int level = 1;
    private float MaxExp;

    [Header("Health Bar")]
    public Slider healthBar;
    public Gradient healthgradient;
    public Image healthfill;

    [Header("Exp Bar")]
    public Slider expBar;
    public Gradient expGradient;
    public Image expFill;

    void Start()
    {
        healthfill.color = healthgradient.Evaluate(1f);
        expFill.color = expGradient.Evaluate(0f);
        Hp = MaxHp;
        MaxExp = Mathf.Pow(2, level + 2);
    }

    // Attack Handle
    public void Attack(GameObject enermy)
    {
        ObjectsAttributes e = enermy.GetComponent<ObjectsAttributes>();
        if (e.WasAttacked(Atk))
        {
            killcount += 1;
            Exp += e.Exp;
            Gold += e.Gold;
            if (Exp >= MaxExp)
            {
                LevelUp();
            }
            SetHealthBar();
            SetExpBar();
        }

    }
    public bool WasAttacked(float damage)
    {
        Hp -= damage * (100 - Def) / 100;
        SetHealthBar();
        if (Hp <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }

    private void LevelUp()
    {
        level += 1;
        Exp -= MaxExp;
        Hp = (Hp / MaxHp) * MaxHp + 10;
        MaxHp += 10;
        Atk += 1;
        Def += 1;
        MaxExp = Mathf.Pow(2, level + 2);
    }


    // Health Bar Handle
    private void SetHealthBar()
    {
        healthBar.value = Hp / MaxHp;
        healthfill.color = healthgradient.Evaluate(healthBar.normalizedValue);
    }

    // Exp Bar Handle
    private void SetExpBar()
    {
        expBar.value = Exp / MaxExp;
        expFill.color = expGradient.Evaluate(expBar.normalizedValue);
    }

    // Getter and Setter
    public int GetKillCount()
    {
        return killcount;
    }
}
