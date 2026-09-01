using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public int DamageCalculator(DamageInstruct target, DamageInstruct ff)
    {
        return 0;
    }
}

public struct DamageInstruct
{
    public int Damage;
    public int CriticalRate;
    public int DamageType;
    public int DamageAttribute;
}

