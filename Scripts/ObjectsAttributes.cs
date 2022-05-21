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

    [Header("Health Bar")]
    public Slider healthBar;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        fill.color = gradient.Evaluate(1f);
        Hp = MaxHp;
    }
    public void attack(GameObject enermy)
    {
        ObjectsAttributes e = enermy.GetComponent<ObjectsAttributes>();
        e.GetComponent<ObjectsAttributes>().wasAttacked(e.Atk);
    }
    public void wasAttacked(float damage)
    {
        Hp -= damage * (100 - Def) / 100;
        SetHealthBar();
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void SetHealthBar()
    {
        healthBar.value = Hp / MaxHp;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
