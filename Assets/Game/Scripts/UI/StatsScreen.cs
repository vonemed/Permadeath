using Entitas.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MonoBehaviour, IPlayerAnyHealthListener, IAnyXpListener, IPlayerAnyLevelListener
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Slider _expAmount;
    [SerializeField] private Slider _hpAmount;

    private PlayerEntity _linkedEntity;
    
    public void Ctor()
    {
        _linkedEntity = Contexts.sharedInstance.player.CreateEntity();
        _linkedEntity.AddPlayerAnyHealthListener(this);
        _linkedEntity.AddAnyXpListener(this);
        _linkedEntity.AddPlayerAnyLevelListener(this);
        // _linkedEntity.isStatsScreen = true;
    }
    
    public void OnAnyHealth(PlayerEntity entity, float value)
    {
        _hpAmount.value = value;
    }

    public void OnAnyXp(PlayerEntity entity, int value)
    {
        _expAmount.value = value;
    }

    public void OnAnyLevel(PlayerEntity entity, uint value)
    {
        _levelText.SetText($"Level: {value}");
    }
    
    private void OnDestroy()
    {
        // gameObject.Unlink();
        _linkedEntity.Destroy();
    }
}
