using System.Collections;
using UnityEngine;

public class MobSpawnerManager : MonoBehaviour
{

    [SerializeField] private Transform[] spawners;
    [SerializeField] private MobDifficultyLevel[] MobDifficultyLevels;

    [Header("Chance Spawn Parametrs")]
    [Range(0.001f, 1.0f)] [SerializeField] private double reducingChanceOfSpawn = 0.1;
    [Range(0.001f, 1.0f)] [SerializeField] private double increasingChanceOfSpawn = 0.05;


    [Header("Spawn Cooldown Parametrs")]
    [Range(0.01f, 5.0f)] [SerializeField] private float spawnCooldown = 0.2f;
    [Range(0.0001f, 0.1f)] [SerializeField] private float changeCooldown = 0.001f;

    [Header("Mob Difficulty Parametrs")]
    [Range(0.0f, 10.0f)] [SerializeField] private double difficultyCoef = 0;
    [Range(0.001f, 1.0f)] [SerializeField] private double changeDifficultyCoef = 0.01;

    private double[] chanceSpawnOnSpawner = { 1, 1, 1, 1, 1 };

    [System.Serializable]
    struct MobDifficultyLevel
    {
        public Pooler_Types.MobInfo.MobType[] mobsOneDifficultyLevel;
        public double parameterThreshold;
    }

    private void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(spawnCooldown);
        if ((spawnCooldown - changeCooldown) >= 0.01f) spawnCooldown -= changeCooldown;
        Spawn();
        StartCoroutine(WaitAndSpawn());
    }

    private void Spawn()
    {
        int _currentSpawnID = ChooseSpawner();
        ChangeChanceSpawn(_currentSpawnID);
        var _mob = MobPooler.MobPool.GetMob(ChangeMobForSpawn());


        _mob.GetComponent<MobTemplate>().Spawn(spawners[_currentSpawnID].transform.position, new Quaternion(0, 180, 0, 1));
        _mob.transform.position = spawners[_currentSpawnID].transform.position;
        _mob.transform.rotation = new Quaternion(0, 90, 0, 1);
        _mob.GetComponent<MobTemplate>().isActive = true;
    }

    private int ChooseSpawner()
    {
        double[] _res = new double[spawners.Length];
        double _maxValue = 0;
        int _IDSpawner = 0;
        for (int i = 0; i < spawners.Length; i++)
        {
            _res[i] = (double)Random.Range(0, 100) / 100.0 * chanceSpawnOnSpawner[i];
            if (_res[i] > _maxValue)
            {
                _maxValue = _res[i];
                _IDSpawner = i;
            }
        }
        return _IDSpawner;
    }

    private void ChangeChanceSpawn(int _currentSpawner)
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            if (i == _currentSpawner) chanceSpawnOnSpawner[i] -= reducingChanceOfSpawn;
            else chanceSpawnOnSpawner[i] += increasingChanceOfSpawn;
        }
    }

    private Pooler_Types.MobInfo.MobType ChangeMobForSpawn()
    {
        double _danger = (double)Random.Range(0, 10) + difficultyCoef;
        difficultyCoef += changeDifficultyCoef;

        for (int i = MobDifficultyLevels.Length - 1; i >= 0; i--)
        {
            if (_danger >= MobDifficultyLevels[i].parameterThreshold)
            {
                var _mobType = Random.Range(0, MobDifficultyLevels[i].mobsOneDifficultyLevel.Length);
                return MobDifficultyLevels[i].mobsOneDifficultyLevel[_mobType];
            }
        }
        return MobDifficultyLevels[2].mobsOneDifficultyLevel[1];
    }

}
