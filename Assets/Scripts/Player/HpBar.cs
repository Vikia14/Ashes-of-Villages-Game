using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    
    public Image HPBar;
    private void Start()
    {
        HPBar = GetComponent<Image>();
        
    }
    private void Update()
    {
        HpLose();
    }

    private void HpLose()
    {
        if (_player != null)
        {
           
            HPBar.fillAmount = (float)_player._currentHealf / 100f;
        }
           
    }
}
