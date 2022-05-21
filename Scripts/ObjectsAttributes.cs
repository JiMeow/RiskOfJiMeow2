using UnityEngine;

public class ObjectsAttributes : MonoBehaviour
{
    public int Hp;
    public int Atk;
    public int Def;
    public int Exp;
    public int Gold;

    public void attack(GameObject enermy)
    {
        ObjectsAttributes e = enermy.GetComponent<ObjectsAttributes>();
        e.GetComponent<ObjectsAttributes>().wasAttacked(e.Atk);
    }
    public void wasAttacked(int damage)
    {
        Hp -= damage * (100 - Def) / 100;
        Debug.Log(Hp);
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
