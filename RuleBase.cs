using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using Xunit.Abstractions;

namespace csharpcore
{
    public abstract class RuleBase
    {
        public abstract bool IsMatch(ItemProxy item);

        public abstract void UpdateItem(ItemProxy item);
    }

    public class NormalItemRule : RuleBase
    {
        public override void UpdateItem(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementSellIn();
            if (item.SellIn < 0)
            {
                item.DecrementQuality();
            }
        }

        public override bool IsMatch(ItemProxy item)
        {
            return true;
        }
    }

    public class ConjuredItemRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Conjured Mana Cake";
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
            
            item.DecrementSellIn();

            if (item.SellIn < 0)
            {
                item.DecrementQuality();
                item.DecrementSellIn();
            }
        }
    }

    public class BackstagePassesRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.IncrementQuality();
            if (item.SellIn < 11)
            {
                item.IncrementQuality();
            }

            if (item.SellIn < 6)
            {
                item.IncrementQuality();
            }
            item.DecrementSellIn();

            if (item.SellIn < 0)
            {
                item.ResetQuality();
            }
        }
    }

    public class AgedBrieRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Aged Brie";
        }

        public override void UpdateItem(ItemProxy item)
        {
            item.IncrementQuality();
            item.DecrementSellIn();
        }
    }

    public class SulfurasRule : RuleBase
    {
        public override void UpdateItem(ItemProxy item)
        {
           //nada
        }

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
