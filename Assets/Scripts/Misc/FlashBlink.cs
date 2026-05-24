using System;
using UnityEngine;

public class FlashBlink : MonoBehaviour
{
    [SerializeField] private MonoBehaviour damagebleObject;
    [SerializeField] private Material blinkMaterial;
    [SerializeField] private float blinkDuration=0.2f;

    private float _blinkTimer;
    private Material _defaultMaterial;
    private SpriteRenderer _spriteRenderer;
    private bool _isBlinking;
    

    private void Awake()
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _defaultMaterial=_spriteRenderer.material;
        _isBlinking=true;

        
    }
    private void Start()
    {
        if (damagebleObject is Player player)
        {
            player.OnFlashBlink += DamagebleObject_OnFlashBlink;
        }
    }

    private void DamagebleObject_OnFlashBlink(object sender, EventArgs e)
    {
        SetBlinkingMaterial();
    }

    private void Update()
    {
       if (_isBlinking)
        {
            _blinkTimer -= Time.deltaTime;
            if (_blinkTimer < 0)
            {
                SetDefautMaterial();
            }
        }
    }
    private void SetBlinkingMaterial()
    {
        _blinkTimer = blinkDuration;
        _spriteRenderer.material = blinkMaterial;
    }
    private void SetDefautMaterial()
    {
        _spriteRenderer.material = _defaultMaterial;
    }
    public void StopBlinking()
    {
        SetDefautMaterial();
        _isBlinking = false;
    }
    private void OnDestroy()
    {
        if (damagebleObject is Player player)
        {
            player.OnFlashBlink -= DamagebleObject_OnFlashBlink;
        }
    }
}
