
namespace Loot
{
    public class XpLoot : Loot, ILootShowListener, ILootHideListener
    {
        
        private void Awake()
        {
            Init();
            linkedEntity.AddLootShowListener(this);
            linkedEntity.AddLootHideListener(this);
        }

        public void OnShow(LootEntity entity)
        {
            gameObject.SetActive(true);
        }

        public void OnHide(LootEntity entity)
        {
            gameObject.SetActive(false);
        }
    }
}