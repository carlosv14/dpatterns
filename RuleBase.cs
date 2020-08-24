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

        public void UpdateItem(ItemProxy item)
        {
            AdjustQuality(item);

            AdjustSellIn(item);

            if (item.SellIn < 0)
            {
                AdjustQualityForNegativeSellIn(item);
            }
        }
        public abstract void AdjustQuality(ItemProxy item);
        public abstract void AdjustSellIn(ItemProxy item);
        public abstract void AdjustQualityForNegativeSellIn(ItemProxy item);
    }

    public class NormalItemRule : RuleBase
    {
        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
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

        public override void AdjustQuality(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementQuality();
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.DecrementQuality();
            item.DecrementSellIn();
        }
    }

    public class BackstagePassesRule : RuleBase
    {
        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public override void AdjustQuality(ItemProxy item)
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
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
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

        public override void AdjustQuality(ItemProxy item)
        {
            item.IncrementQuality();
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            item.DecrementSellIn();
            item.IncrementQuality();
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            item.IncrementQuality();
        }
    }

    public class SulfurasRule : RuleBase
    {

        public override bool IsMatch(ItemProxy item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public override void AdjustQuality(ItemProxy item)
        {
            //
        }

        public override void AdjustSellIn(ItemProxy item)
        {
            //
        }

        public override void AdjustQualityForNegativeSellIn(ItemProxy item)
        {
            //
        }
    }
}
