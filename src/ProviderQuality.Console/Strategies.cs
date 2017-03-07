using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderQuality.Console
{
    public class UpdateStrategyFactory : IUpdateStrategyFactory
    {
        public IUpdateStrategy Create(string name)
        {
            if (name == "Blue Distinction Plus")
            {
                return new BlueDistinctionPlusUpdateStrategy();
            }
            else if (name == "Blue First")
            {
                return new BlueFirstUpdateStrategy();
            }
            else if (name == "Blue Compare")
            {
                return new BlueCompareUpdateStrategy();
            }
            else if (name.Contains("Blue Star"))
            {
                return new StandardAwardUpdateStrategy(2);
            }
            else
            {
                return new StandardAwardUpdateStrategy();
            }
        }
    }

    public class StandardAwardUpdateStrategy : IUpdateStrategy
    {
        private readonly int _qualityLossMultiplier;

        public StandardAwardUpdateStrategy(int qualityLossMultiplier = 1)
        {
            _qualityLossMultiplier = qualityLossMultiplier;
        }

        public void UpdateQuality(Award award)
        {
            award.SellIn--;
            if (award.Quality > 0)
            {
                award.Quality -= _qualityLossMultiplier * (award.SellIn < 0 ? 2 : 1);
            }
            if (award.Quality < 0)
            {
                award.Quality = 0;
            }
        }
    }

    public class BlueCompareUpdateStrategy : IUpdateStrategy
    {
        public void UpdateQuality(Award award)
        {
            award.SellIn--;

            if (award.SellIn < 0)
            {
                award.Quality = 0;
            }
            else if (award.SellIn <= 5)
            {
                award.Quality = award.Quality + 3;
            }
            else if (award.SellIn <= 10)
            {
                award.Quality = award.Quality + 2;
            }
            else if (award.Quality < 50)
            {
                award.Quality++;
            }

            if (award.Quality > 50)
            {
                award.Quality = 50;
            }
        }
    }

    public class BlueFirstUpdateStrategy : IUpdateStrategy
    {
        public void UpdateQuality(Award award)
        {
            award.SellIn--;
            if (award.Quality < 50)
            {
                award.Quality=award.Quality+(award.SellIn < 0 ? 2 : 1); ;
            }
            if (award.Quality > 50)
                award.Quality = 50;
        }
    }


    public class BlueDistinctionPlusUpdateStrategy : IUpdateStrategy
    {
        public void UpdateQuality(Award award) { }
    }

    public interface IUpdateStrategyFactory
    {
        IUpdateStrategy Create(string name);
    }

    public interface IUpdateStrategy
    {
        void UpdateQuality(Award award);
    }
}
