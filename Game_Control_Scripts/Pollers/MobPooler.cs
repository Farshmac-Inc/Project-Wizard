using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pooler_Types;

public class MobPooler : MonoBehaviour
{
    public static MobPooler MobPool;

    [SerializeField] private List<MobInfo> mobInfo;
    private Dictionary<MobInfo.MobType, Pool> pools;

    private void Awake()
    {
        if (MobPool == null) MobPool = this;
        MobPool.InitializePool();
    }

    private void InitializePool()
    {
        pools = new Dictionary<MobInfo.MobType, Pool>();

        var emptyGameObject = new GameObject();

        foreach (var mob in mobInfo)
        {
            var _container = Instantiate(emptyGameObject, transform, false);
            _container.name = mob.Type.ToString();
            pools[mob.Type] = new Pool(_container.transform);
            for (int i = 0; i < mob.StartCount; i++)
            {
                var go = InstantiateMobPrefab(mob.Type, _container.transform);
                pools[mob.Type].Object.Enqueue(go);
            }
        }
        Destroy(emptyGameObject);
    }

    private GameObject InstantiateMobPrefab(MobInfo.MobType _type, Transform _parent)
    {
        var go = Instantiate(mobInfo.Find(x => x.Type == _type).Mob, _parent);
        go.SetActive(false);
        return go;
    }

    public GameObject GetMob(MobInfo.MobType _type)
    {
        var obj = pools[_type].Object.Count > 0 ? pools[_type].Object.Dequeue() : InstantiateMobPrefab(_type, pools[_type].Container);
        obj.GetComponent<MobDamageble>().Pooler = gameObject;
        obj.SetActive(true);
        return obj;
    }

    public void MobKilled(GameObject _mob)
    {
        var MobTemplate = _mob.GetComponent<MobTemplate>();
        pools[MobTemplate.Type].Object.Enqueue(_mob);

        _mob.SetActive(false);
    }
}
