public class PlayerCharacteristics
{
    public float MoveSpeed { get; private set; }
    public float AttackDamage { get; private set; }
    public float AttackSpeed { get; private set; }

    private float baseMoveSpeed = 6;
    private float baseDamage = 10;
    private float baseAttackSpeed = 1;

    private float moveSpeedScale = 1;
    private float attackDamageScale = 1;
    private float attackSpeedScale = 1;

    public PlayerCharacteristics()
    {
        MoveSpeed = baseMoveSpeed;
        AttackDamage = baseDamage;
        AttackSpeed = baseAttackSpeed;
    }

    public void RaiseMoveSpeed(float scale)
    {
        moveSpeedScale += scale;
        MoveSpeed *= baseMoveSpeed * moveSpeedScale;
    }

    public void DecreaseMoveSpeed(float scale)
    {
        moveSpeedScale *= (1 - scale);
        MoveSpeed *= baseMoveSpeed * moveSpeedScale;
    }

    public void RaiseAttackDamage(float scale)
    {
        attackDamageScale += scale;
        AttackDamage = baseDamage * attackDamageScale;
    }

    public void DecreaseAttackDamage(float scale)
    {
        attackDamageScale *= (1 - scale);
        AttackDamage = baseDamage * attackDamageScale;
    }

    public void RaiseAttackSpeed(float scale)
    {
        attackSpeedScale = scale;
        AttackSpeed = baseAttackSpeed * attackSpeedScale;
    }

    public void DecreaseAttackSpeed(float scale)
    {
        attackDamageScale *= (1 - scale);
        AttackDamage = baseDamage * attackDamageScale;
    }
}
