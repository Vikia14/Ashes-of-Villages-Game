using System;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AttackPlayer _playerEnrity;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private FlashBlink _flashBlink;

    private const string Is_Running = "isRunning";
    private const string Is_Attacking = "Attack";
    private const string Is_TakeHit = "TakeHit";
    private const string Is_Death = "IsDie";
    private const string Is_Block = "Block";

    private void Start()
    {
        Player.Instance.OnPlayerDeath += Player_OnPlayerDeath;
    }

    private void Player_OnPlayerDeath(object sender, System.EventArgs e)
    {
        _animator.SetBool(Is_Death, true);
        _flashBlink.StopBlinking();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _flashBlink=GetComponent<FlashBlink>();
    }

    private void Update()
    {
        _animator.SetBool(Is_Running, Player.Instance.IsRunning());
        if (Gameinput.Instance.IsAttacking())
        {
            _animator.SetTrigger(Is_Attacking);
        }
        if (Player.Instance.IsAlive())
        {
            AdjustPlayerFacingDirection();
        }
        if (Gameinput.Instance.IsBlocking())
        {
            _animator.SetTrigger(Is_Block);
        }
    }
    public void TriggerAttackColliderTurnOff()
    {
        _playerEnrity.AttackColliderTurnOff();
    }
    public void TriggerAttackColliderTurnOn()
    {
        _playerEnrity.AttackColliderTurnOn();
    }
    private void AdjustPlayerFacingDirection()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput < 0) // Нажата клавиша A (влево)
        {
            _spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0) // Нажата клавиша D (вправо)
        {
            _spriteRenderer.flipX = false;
        }
        
    }
    private void _playerEnrity_OnTakeHit(object sender, EventArgs e)
    {
        _animator.SetTrigger(Is_TakeHit);
    }
}