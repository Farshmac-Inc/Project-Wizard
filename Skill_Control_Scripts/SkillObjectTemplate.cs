using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillObjectTemplate : Template
{
    public Pooler_Types.SkillObjectInfo.ObjectType Type;
    public GameObject Pooler;
    public float LifeTime;

    [SerializeField] protected float throwingObjectSpeedMovement = 1.0f;
    [SerializeField] protected Damage[] damage;

    protected Vector3 throwDirection = new Vector3(0, 0, 1);
    protected bool setActive = false;

    private void Start()
    {
        StartCoroutine(TimeToDeathCounter());
    }

    private void Update()
    {
        Move();
    }

    public void Spawn(Vector3 _startPoint)
    {
        transform.position = _startPoint;
        setActive = true;
    }

    public void Spawn(Vector3 _startPoint, Vector3 _endPoint)
    {
        transform.position = _startPoint;
        throwDirection = _endPoint - _startPoint;
        throwDirection.Normalize();
        setActive = true;
    }

    public abstract void Move();

    public abstract void InternalService();

    public virtual IEnumerator TimeToDeathCounter()
    {
        yield return new WaitForSeconds(LifeTime);
        setActive = false;
        Pooler.GetComponent<SkillObjectPooler>().ObjectReturnPool(gameObject);
    }
}
