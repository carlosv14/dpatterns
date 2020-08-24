using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace csharpcore
{
    public class ItemQualityRuleEngine
    {
        private readonly IEnumerable<RuleBase> _rules = new List<RuleBase>();

        private ItemQualityRuleEngine(IEnumerable<RuleBase> rules)
        {
            _rules = rules;
            _rules = new List<RuleBase>
            {
                new SulfurasRule(),
                new ConjuredItemRule(),
                new AgedBrieRule(),
                new BackstagePassesRule(),
                new NormalItemRule()
            };
        }

        public void ApplyRules(ItemProxy item)
        {
            foreach (var rule in _rules)
            {
                if (!rule.IsMatch(item)) continue;
                rule.UpdateItem(item);
                break;
            }
        }

        public class Builder
        {
            private readonly List<RuleBase> _builderRules = new List<RuleBase>();

            public Builder WithAgedBrieRule()
            {
                _builderRules.Add(new AgedBrieRule());
                return this;
            }

            public Builder WithSulfurasRule()
            {
                _builderRules.Add(new SulfurasRule());
                return this;
            }

            public Builder WithConjuredItemRule()
            {
                _builderRules.Add(new ConjuredItemRule());
                return this;
            }

            public Builder WithBackstagePassesRule()
            {
                _builderRules.Add(new BackstagePassesRule());
                return this;
            }

            public ItemQualityRuleEngine Build()
            {
                _builderRules.Add(new NormalItemRule());

                return new ItemQualityRuleEngine(_builderRules);
            }
        }
    }
}
