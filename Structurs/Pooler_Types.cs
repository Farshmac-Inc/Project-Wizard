using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pooler_Types
{
    [Serializable]
    public struct MobInfo
    {
        public enum MobType
        {
            [InspectorName("Слабый Моб Метрии")] Weak_Matter,
            [InspectorName("Слабый Моб Энергии")] Weak_Energy,
            [InspectorName("Слабый Моб Тьмы")] Weak_Darkness,
            [InspectorName("Моб Материи")] Medium_Matter,
            [InspectorName("Моб Энергии")] Medium_Energy,
            [InspectorName("Моб Тьмы")] Medium_Darkness,
            [InspectorName("Сильный Моб Материи")] Strong_Matter,
            [InspectorName("Сильный Моб Энергии")] Strong_Energy,
            [InspectorName("Сильный Моб Тьмы")] Strong_Darkness
        }
        public MobType Type;
        public GameObject Mob;
        public int StartCount;
    }
    [Serializable]
    public struct SkillObjectInfo
    {
        public enum ObjectType
        {
            [InspectorName("Огненный шар")] FireBall,
            [InspectorName("Каменный сталагмит")] StoneStalagmite
        }
        public ObjectType Type;
        public GameObject Object;
        public int StartCount;
    }
}
