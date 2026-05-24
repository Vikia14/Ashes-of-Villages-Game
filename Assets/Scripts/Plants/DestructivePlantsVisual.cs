using UnityEngine;

public class DestructivePlantsVisual : MonoBehaviour
{
    [SerializeField] private DestructivePlants _destructivePlants;
    [SerializeField] private GameObject _bushDeathVFHPrefab;

    private void Start()
    {
        _destructivePlants.OnDestructiveTakeDamage += DescriptablePlants_OnDestructiveTakeDamage;

    }
    private void DescriptablePlants_OnDestructiveTakeDamage(object sender, System.EventArgs e)
    {
        ShowDeathVFH();
    }
    private void ShowDeathVFH()
    {
        Instantiate(_bushDeathVFHPrefab, _destructivePlants.transform.position, Quaternion.identity);
    }
    private void OnDestroy()
    {
        _destructivePlants.OnDestructiveTakeDamage -= DescriptablePlants_OnDestructiveTakeDamage;
    }
}
