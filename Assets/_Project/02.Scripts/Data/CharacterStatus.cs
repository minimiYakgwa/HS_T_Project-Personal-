using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    // 실시간 공격력, 방어력, 명중률, 회피율 버프/디버프 중첩 횟수
    private int _atk = 0;
    private int _def = 0;
    private int _acc = 0;
    private int _eva = 0;

    private int currentHp;

    #region Propertes
    public int ATK => _atk;
    public int DEF => _def;
    public int ACC => _acc;
    public int EVA => _eva;
    public int CurrentHp => currentHp;
    #endregion

    // 버프/디버프를 받을 때 수치값을 업데이트하는 함수
    public bool SetStatus(BuffType type, int count)
    {
        switch (type)
        {
            case BuffType.ATK:
                _atk += Mathf.Clamp(-3, count, 3);
                return true;

            case BuffType.DEF:
                _def += Mathf.Clamp(-3, count, 3);
                return true;

            case BuffType.ACC:
                _acc += Mathf.Clamp(-3, count, 3);
                return true;
            case BuffType.EVA:
                _eva += Mathf.Clamp(-3, count, 3);
                return true;

            default:
                return false;

        }

    }
}

public enum BuffType
{
    ATK, DEF, ACC, EVA
}

