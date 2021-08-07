using System.Collections;
using UnityEngine;

public partial class SkillManager : MonoBehaviour
{
    public Vector3 EndPoint;
    public Vector3 StartPoint;
    public Transform SkillStartPosition;
    public UI_SkillsIconController UI_Skill;

    private SkillParam currentSelectedSkill;

    [SerializeField]
    public ManaPool[] ManaPools = new ManaPool[3] {
        new ManaPool(ManaType.Matter, 100, 0.1f, 1),
        new ManaPool(ManaType.Energy, 100, 0.1f, 1),
        new ManaPool(ManaType.Darkness, 100, 0.1f, 1)
    };

    private void Start()
    {
        transform.GetComponent<IUserInput>().PointCick += Cast;
        transform.GetComponent<IUserInput>().SkillSelect += SelectCurrentSkill;

        StartPoint = SkillStartPosition.position;
        StartCoroutine(ManaRegenerationCooldown());
    }

    private void SelectCurrentSkill(int skillNumber)
    {
        currentSelectedSkill = SkillList.Skills[skillNumber];
    }

    private IEnumerator ManaRegenerationCooldown()
    {
        foreach (var pool in ManaPools)
        {
            pool.RegerateMana();
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(ManaRegenerationCooldown());
    }

    private void Cast(Vector3 _endPoint)
    {
        var _isEnoughMana = true;
        var _usedMana = currentSelectedSkill.UsedMana;
        var _manaPools = ManaPools;

        for (int i = 0; i < _usedMana.Count; i++)
        {
            for (int y = 0; y < _manaPools.Length; y++)
            {
                if (_manaPools[y].TypeName == _usedMana[i].Type)
                {
                    if (_manaPools[y].CheckRequiredAmountMana(_usedMana[i].ManaCost))
                    {
                        _manaPools[y].SpendMana(_usedMana[i].ManaCost);
                        currentSelectedSkill.UsedSkill(SkillStartPosition.position, _endPoint);
                    }
                    else
                    {
                        _isEnoughMana = false;
                    }
                }
            }
        }
        if (_isEnoughMana)
        {
            ManaPools = _manaPools;
        }
    }
}
