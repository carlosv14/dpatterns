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
            var rules = new List<RuleBase>();
            rules.Add(new SulfurasRule());
            rules.Add(new ConjuredItemRule());
            rules.Add(new AgedBrieRule());
            rules.Add(new BackstagePassesRule());
            rules.Add(new NormalItemRule());

            foreach (var rule in rules)
            {
                if (rule.IsMatch(item))
                {
                    rule.UpdateItem(item);
                    break;
                }
            }
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
