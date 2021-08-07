using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(MobDamageble))]
public class MobTemplate : Template
{
    public Pooler_Types.MobInfo.MobType Type;

    [SerializeField] private float speedMovement = 1f;
    private CharacterController model;
    void Start()
    {
        model = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isActive)
        {
            Move();
        }
    }

    public void Spawn(Vector3 _spawnerPosition, Quaternion _spawnRotation)
    {
        isActive = true;

        if (model == null) model = GetComponent<CharacterController>();

        model.enabled = false;
        transform.position = _spawnerPosition;
        transform.rotation = _spawnRotation;
        model.enabled = true;
    }

    private void Move()
    {
        var move = new Vector3(0, 0, -1) * speedMovement * Time.deltaTime;
        move.y = -50f;
        model.Move(move);
    }

    public void Die(GameObject _pooler)
    {
        _pooler.GetComponent<MobPooler>().MobKilled(gameObject);
    }
}
