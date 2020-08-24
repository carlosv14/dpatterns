using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality(ItemProxy item)
        {
            var engine = new ItemQualityRuleEngine.Builder()
                .WithAgedBrieRule()
                .WithBackstagePassesRule()
                .WithConjuredItemRule()
                .WithSulfurasRule()
                .Build();
            engine.ApplyRules(item);
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
               this.UpdateQuality(new ItemProxy(this.Items[i]));
            }
        }
    }
}
