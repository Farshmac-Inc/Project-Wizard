using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUserInput : MonoBehaviour, IUserInput
{
    public event Action<Vector3> PointCick;
    public event Action<int> SkillSelect;

    public float MaxDistance;
    public LayerMask InteractingLayers;

    private RaycastHit hit;
    private Ray ray;

    private void Update()
    {
        if (Input.GetKeyDown(PCInputData.LKM))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, MaxDistance))
            {
                var layer = hit.collider.gameObject.layer;
                if (hit.point != Vector3.zero && (InteractingLayers.value & (1 << layer)) != 0) PointCick?.Invoke(hit.point);
            }
        }
        for (int i = 0; i < PCInputData.Skills.Length; i++)
        {
            if (Input.GetKeyDown(PCInputData.Skills[i])) SkillSelect?.Invoke(i);
        }
    }
}
