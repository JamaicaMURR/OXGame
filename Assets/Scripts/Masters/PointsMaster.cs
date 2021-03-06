using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Bycicles.Ranges;

public class PointsMaster : MonoBehaviour
{
    int _dispalyPoints;

    [HideInInspector]
    public int points;

    float _timePassed;

    public CentralPort central;
    public Text displayField;

    public int mergeReward = 1;
    public int progressionBonus = 1;
    public int pauserBonusPlank = 5;
    public int heartBonusPlank = 7;

    public float cypherRefreshPeriod = 0.1f;

    public event IntEvent OnReward;
    public event IntEvent OnPausersReward;
    public event IntEvent OnHeartsReward;

    //==================================================================================================================================================================
    void Awake()
    {
        central.inputHandler.OnEscape += RememberRecord;
        central.heartsMaster.OnZeroUnits += RememberRecord;
        central.mergeMaster.AtMerged += Reward;
    }

    void Update()
    {
        _timePassed += central.independentClocks.DeltaTime;

        displayField.text = _dispalyPoints.ToString();

        if(_timePassed >= cypherRefreshPeriod)
        {
            if(points - _dispalyPoints != 0)
                _dispalyPoints++;

            _timePassed -= cypherRefreshPeriod;
        }
    }

    //==================================================================================================================================================================
    public int CalcReward(int totalMerged)
    {
        int mergesToReward = totalMerged - 1;
        int rewardPoints = (int)((2 * mergeReward + progressionBonus * (mergesToReward - 1)) / 2f * mergesToReward); // summ of members of arithmetic progression

        return rewardPoints;
    }

    //==================================================================================================================================================================
    void Reward(int totalMerged)
    {
        if(totalMerged > 1)
        {
            int rewardPoints = CalcReward(totalMerged);

            int pausersReward = totalMerged - pauserBonusPlank + 1;
            int heartsReward = totalMerged - heartBonusPlank + 1;

            if(pausersReward > 0)
            {
                if(OnPausersReward != null && central.pausersMaster.Units != central.pausersMaster.MaximalUnits)
                    OnPausersReward(pausersReward.NotAbove(central.pausersMaster.MaximalUnits - central.pausersMaster.Units));

                central.pausersMaster.Units += pausersReward;
            }

            if(heartsReward > 0)
            {
                if(OnHeartsReward != null && central.heartsMaster.Units != central.heartsMaster.MaximalUnits)
                    OnHeartsReward(heartsReward.NotAbove(central.heartsMaster.MaximalUnits - central.heartsMaster.Units));

                central.heartsMaster.Units += heartsReward;
            }

            if(OnReward != null)
                OnReward(rewardPoints);

            points += rewardPoints;
        }
    }

    void RememberRecord()
    {
        int oldRec = PlayerPrefs.GetInt("record");

        if(points > oldRec)
            PlayerPrefs.SetInt("record", points);
    }

}
