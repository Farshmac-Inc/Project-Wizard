using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Pooler_Types;

public class SkillObjectPooler : MonoBehaviour
{
    public static SkillObjectPooler ObjectPool;

    [SerializeField] private List<SkillObjectInfo> objectInfo;

    private Dictionary<SkillObjectInfo.ObjectType, Pool> pools;

    private void Awake()
    {
        if (ObjectPool == null) ObjectPool = this;
        ObjectPool.InitializePool();
    }

    private void InitializePool()
    {
        pools = new Dictionary<SkillObjectInfo.ObjectType, Pool>();

        var emptyGameObject = new GameObject();

        foreach (var obj in objectInfo)
        {
            var _container = Instantiate(emptyGameObject, transform, false);
            _container.name = obj.Type.ToString();
            pools[obj.Type] = new Pool(_container.transform);
            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstantiateObjectPrefab(obj.Type, _container.transform);
                pools[obj.Type].Object.Enqueue(go);
            }
        }
        Destroy(emptyGameObject);
    }

    private GameObject InstantiateObjectPrefab(SkillObjectInfo.ObjectType _type, Transform _parent)
    {
        var go = Instantiate(objectInfo.Find(x => x.Type == _type).Object, _parent);
        go.SetActive(false);
        return go;
    }

    public GameObject GetSkillObject(SkillObjectInfo.ObjectType type)
    {
        var obj = pools[type].Object.Count > 0 ? pools[type].Object.Dequeue() : InstantiateObjectPrefab(type, pools[type].Container);
        obj.GetComponent<SkillObjectTemplate>().Pooler = gameObject;
        obj.SetActive(true);
        return obj;
    }

    public void ObjectReturnPool(GameObject _object)
    {
        var _skillObjectTemplate = _object.GetComponent<SkillObjectTemplate>();
        pools[_skillObjectTemplate.Type].Object.Enqueue(_object);
        _object.SetActive(false);
    }
}
