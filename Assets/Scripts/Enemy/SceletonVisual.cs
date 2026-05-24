using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class SceletonVisual : MonoBehaviour
{

    [SerializeField] private EnemyAI _enemyAI;
    [SerializeField] private EnemyEnrity _enemyEnrity;
    [SerializeField] private GameObject _enemyShadow;
    [SerializeField] private PathMenu pathMenu;
    [SerializeField] private GameManager gameManager;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string IsRunning = "IsRunning";
    private const string TakeHit = "TakeHit";
    private const string IsDie = "IsDie";
    private const string ChasingSpeedMultiplier = "ChasingSpeedMultiplier";
    private const string Attack = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();


    }
    private void Start()
    {
        _enemyAI.OnEnemyAttack += _enemyAI_OnEnemyAttack;
        _enemyEnrity.OnTakeHit += _enemyEnrity_OnTakeHit;
        _enemyEnrity.OnDeath += _enemyEnrity_OnDeath;
    }

    private void _enemyEnrity_OnDeath(object sender, EventArgs e)
    {
        _animator.SetBool(IsDie, true);
        _spriteRenderer.sortingOrder = -1;
        _enemyShadow.SetActive(false);

        GameManager.instance.RegisterEnemyDeath();


    }

    private void _enemyEnrity_OnTakeHit(object sender, EventArgs e)
    {
        _animator.SetTrigger(TakeHit);
    }

    private void Update()
    {

        _animator.SetBool(IsRunning, _enemyAI.IsRunning);
        _animator.SetFloat(ChasingSpeedMultiplier, _enemyAI.GetRoamingAnimationSpeed());
    }
    public void TriggerAttacingAnimationTurnOff()
    {
        _enemyEnrity.PolygonColliderTurnOff();
    }
    public void TriggerAttacingAnimationTurnOn()
    {
        _enemyEnrity.PolygonColliderTurnOn();
    }
    private void OnDestroy()
    {

        _enemyAI.OnEnemyAttack -= _enemyAI_OnEnemyAttack;
        _enemyEnrity.OnTakeHit -= _enemyEnrity_OnTakeHit;
        _enemyEnrity.OnDeath -= _enemyEnrity_OnDeath;
    }
    private void _enemyAI_OnEnemyAttack(object sender, System.EventArgs e)
    {

        _animator.SetTrigger(Attack);
    }



}