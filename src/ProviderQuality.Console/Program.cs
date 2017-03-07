using System.Collections.Generic;

namespace ProviderQuality.Console
{
    public class Program
    {
        private readonly IUpdateStrategyFactory _strategyFactory = new UpdateStrategyFactory();
        public IList<Award> Awards
        {
            get;
            set;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Updating award metrics...!");

            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 20},
                    new Award {Name = "Blue First", SellIn = 2, Quality = 0},
                    new Award {Name = "ACME Partner Facility", SellIn = 5, Quality = 7},
                    new Award {Name = "Blue Distinction Plus", SellIn = 0, Quality = 80},
                    new Award {Name = "Blue Compare", SellIn = 15, Quality = 20},
                    new Award {Name = "Top Connected Providres", SellIn = 3, Quality = 6},
                    new Award {Name = "Blue Star", SellIn = 3, Quality = 6}
                }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var award in Awards)
            {
                var updateStrategy = _strategyFactory.Create(award.Name);
                updateStrategy.UpdateQuality(award);
            }
        }
    }

}
