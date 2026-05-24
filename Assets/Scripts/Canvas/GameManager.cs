using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Синглтон

    [Header("Настройки")]
    public int _requiredKills = 4;
    public GameObject blockWall;
    public int _totalKills = 0;

    void Awake()
    {
            instance = this;
    }

    public void RegisterEnemyDeath()
    {
        _totalKills++;
        Debug.Log($"Врагов убито: {_totalKills}/{_requiredKills}");

        if (_totalKills >= _requiredKills)
        {
            if (blockWall != null)
            {
                Destroy(blockWall);
                Debug.Log("BlockWall уничтожен!");
            }

        }
    }

    public int GetTotalKills()
    {
        return _totalKills;
    }
}