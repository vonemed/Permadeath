using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [Header("[Stats]")]
    public float moveSpeed = 20f;
    public int health = 100;
    public int attackDamage = 5;
    public float attackRange = 5f;
    public float attackRate = 1f;
}
