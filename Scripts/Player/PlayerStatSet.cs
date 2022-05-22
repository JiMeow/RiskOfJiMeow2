using UnityEngine;
using UnityEngine.UI;

public class PlayerStatSet : MonoBehaviour
{
    public ObjectsAttributes playersAttributes;
    public Text HpText;
    public Text levelText;
    void Update()
    {
        int Hp = (int)Mathf.Round(playersAttributes.GetHp());
        int MaxHp = (int)Mathf.Round(playersAttributes.GetMaxHp());
        int level = (int)Mathf.Round(playersAttributes.GetLevel());
        HpText.text = Hp + "/" + MaxHp;
        levelText.text = level.ToString();
    }
}
