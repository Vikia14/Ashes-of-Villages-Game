using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ExperienceManager : MonoBehaviour
{
    public int _level;
    public int _currebtExp;
    public int _expToLevel=10; 
    public float _expGrownMultiplier=1.2f;
    public Slider _expSlider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainExp(2);
        }
    }

    public void GainExp(int amount)
    {
        _currebtExp += amount;
        if(_currebtExp< _expToLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        _level++;
        _currebtExp -= _expToLevel;
        _expToLevel=Mathf.RoundToInt(_expToLevel* _expGrownMultiplier);
    }
}
