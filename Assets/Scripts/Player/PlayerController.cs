using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, IDamageable
{
    private PlayerCharacteristics characteristics;
    private IInputService inputService;
    private Rigidbody2D rb;
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    private PlayerHealthModel playerHealthModel;

    private float speed => characteristics.MoveSpeed;
    private float attackDamage => characteristics.AttackDamage;

    [Inject]
    public void Construct(IInputService inputService, PlayerCharacteristics characteristics)
    {
        this.inputService = inputService;
        this.characteristics = characteristics;
    }
    
    public void LoadCharacteristics()
    {
        playerHealthModel = new(5, 5);
        PlayerHealthView playerHealthView = GetComponentInChildren<PlayerHealthView>();
        PlayerHealthPresenter playerHealthPresenter = new(playerHealthModel, playerHealthView);
        playerHealthModel.Init();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMove = new(rb, characteristics);
        playerAttack = GetComponent<PlayerAttack>();
        LoadCharacteristics();
        SubscribeInput();
    }
    

    private void SubscribeInput()
    {
        inputService.OnFire += playerAttack.OnFire;
        inputService.OnMove += playerMove.Move;
    }
    
    private void OnDestroy()
    {
        inputService.OnFire -= playerAttack.OnFire;
        inputService.OnMove -= playerMove.Move;
    }

    public void GetDamage(float damage)
    {
        playerHealthModel.RemoveHealth((int)damage);
    }
}
