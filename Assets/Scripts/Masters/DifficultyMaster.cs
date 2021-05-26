using Bycicles.Ranges;
using UnityEngine;

public class DifficultyMaster : MonoBehaviour
{
    float _averSpawnPeriod;

    float AverSpawnPeriod { get { return _averSpawnPeriod; } set { _averSpawnPeriod = value.NotBelow(minimalAverSpawnPeriod).NotAbove(initialAverSpawnPeriod); } }

    //------------------------------------------------------------------------------------------------------------------------------------------------------------------
    public CentralPort central;

    public float initialAverSpawnPeriod = 2;
    public float minimalAverSpawnPeriod = 0.5f;
    public float decreasingSpawnPeriodStep = 0.05f;
    public float lowSpawnPeriodFluctuationLimit = 0.25f;
    public float highSpawnPeriodFluctuationLimit = 0.25f;

    public int maximalSpawnPeriodAtWhitesCount = 5;
    public int stopSpawnAtWhitesOnField = 5;

    public float oDefaultSpeed = 0.75f;
    public float oOnDarkCellSpeed = 2;
    public float oMergeDashSpeed = 5;

    public bool StopSpawn { get { return central.spawnMaster.WhitesOnField >= stopSpawnAtWhitesOnField; } }

    public float SpawnPeriod { get { return CalculateSpawnPeriod(); } }

    //==================================================================================================================================================================
    private void Awake()
    {
        _averSpawnPeriod = initialAverSpawnPeriod;

        central.mergeMaster.AtMerged += IncreaseDifficulty; // Simple model of difficulty rising: difficulty rises at each merged O
    }

    //==================================================================================================================================================================
    void IncreaseDifficulty(int power)
    {
        AverSpawnPeriod -= power * decreasingSpawnPeriodStep;
    }

    float CalculateSpawnPeriod()
    {
        float minimalThreshold = (AverSpawnPeriod - lowSpawnPeriodFluctuationLimit).NotBelow(0);
        float maximalThreshold = AverSpawnPeriod + highSpawnPeriodFluctuationLimit;
        float whitesDensity = (float)central.spawnMaster.WhitesOnField.NotAbove(maximalSpawnPeriodAtWhitesCount) / maximalSpawnPeriodAtWhitesCount;
        float modificator = (maximalThreshold - minimalThreshold) * whitesDensity;

        return minimalThreshold + modificator;
    }
}
