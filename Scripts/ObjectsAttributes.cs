using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public GameObject playerWasDamage;
    private void playerWasDamageSetDeactive()
    {
        playerWasDamage.SetActive(false);
    }
    public bool WasAttacked(float damage)
    {
        if (gameObject.tag == "Player")
        {
            playerWasDamage.SetActive(true);
            Invoke("playerWasDamageSetDeactive", 0.5f);
        }
        Hp -= damage * (100 - Def) / 100;
        SetHealthBar();
        if (Hp <= 0)
        {
            Debug.Log(gameObject.tag);
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Destroy(gameObject);
            }
            return true;
        }
        return false;
    }

    private void LevelUp()
    {
        level += 1;
        Exp -= MaxExp;
        MaxHp = MaxHp * 130 / 100;
        Hp = MaxHp;
        Atk += 0.2f;
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

    public void AddKillCount()
    {
        killcount += 1;
    }

    public float GetHp()
    {
        return Hp;
    }

    public float GetMaxHp()
    {
        return MaxHp;
    }

    public int GetLevel()
    {
        return level;
    }
}
