using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProviderQuality.Console;

namespace ProviderQuality.Tests
{
    [TestClass]
    public class UpdateQualityAwardsTests
    {
        [TestMethod]
        public void TestImmutabilityOfBlueDistinctionPlus()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Distinction Plus", SellIn = 0, Quality = 80}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Distinction Plus");
            Assert.IsTrue(app.Awards[0].Quality == 80);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 80);
        }

        [TestMethod]
        public void TestBlueDistinctionPlusSellInValueNeverDecreases()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Distinction Plus", SellIn = 1, Quality = 80}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Distinction Plus");
            Assert.IsTrue(app.Awards[0].SellIn == 1);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].SellIn == 1);

        }

        [TestMethod]
        public void TestBlueComparQualityeMaximumValueIs50()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Compare", SellIn = 10, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Compare");
            Assert.IsTrue(app.Awards[0].Quality == 50);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 50);

        }
        [TestMethod]
        public void TestBlueCompareQualityValueIsNeverNegative()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Compare", SellIn = 1, Quality = -1}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Compare");
            Assert.IsTrue(app.Awards[0].Quality == -1);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality > 0);

        }

        [TestMethod]
        public void TestBlueCompareIncreasesBy3When5daysLeft()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Compare", SellIn = 3, Quality = 44}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Compare");
            Assert.IsTrue(app.Awards[0].Quality == 44);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 47);

        }
        [TestMethod]
        public void TestBlueCompareIncreasesBy2WhenLessThan10daysLeftButMoreThan5DaysLeft()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Compare", SellIn = 8, Quality = 44}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Compare");
            Assert.IsTrue(app.Awards[0].Quality == 44);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 46);

        }

        [TestMethod]
        public void TestBlueCompareDropsToZeroAfterExpirationDate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Compare", SellIn = 0, Quality = 44}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Compare");
            Assert.IsTrue(app.Awards[0].Quality == 44);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 0);

        }

        [TestMethod]
        public void TestBlueCompareSellInValueDecreasesBy1AfterUpdate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Compare", SellIn = 1, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Compare");
            Assert.IsTrue(app.Awards[0].SellIn == 1);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].SellIn == 0);

        }


        [TestMethod]
        public void TestBlueFirstQualityIncreasesBy1BeforeExpirationAfterUpdate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue First", SellIn = 1, Quality = 49}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue First");
            Assert.IsTrue(app.Awards[0].Quality == 49);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 50);

        }

        [TestMethod]
        public void TestBlueFirstQualityIncreasesBy2AfterExpirationAfterUpdate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue First", SellIn = 0, Quality = 48}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue First");
            Assert.IsTrue(app.Awards[0].Quality == 48);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 50);

        }


        [TestMethod]
        public void TestBlueFirstQualityMaximumValueIs50()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue First", SellIn = 0, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue First");
            Assert.IsTrue(app.Awards[0].Quality == 50);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 50);

        }
        [TestMethod]
        public void TestBlueFirstSellInValueDecreasesBy1AfterUpdate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue First", SellIn = 10, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue First");
            Assert.IsTrue(app.Awards[0].SellIn == 10);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].SellIn == 9);

        }

        [TestMethod]
        public void TestBlueStarQualityDecreasesBy2BeforeExpiration()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Star", SellIn = 1, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Star");
            Assert.IsTrue(app.Awards[0].Quality == 50);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 48);

        }

        [TestMethod]
        public void TestBlueStarQualityDecreasesBy4AfterExpiration()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Star", SellIn = 0, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Star");
            Assert.IsTrue(app.Awards[0].Quality == 50);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 46);

        }

        [TestMethod]
        public void TestBlueStarQualityIsNeverNegative()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Star", SellIn = 1, Quality = 0}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Star");
            Assert.IsTrue(app.Awards[0].Quality == 0);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 0);

        }

        [TestMethod]
        public void TestBlueStarSellInValueDecreasesBy1AfterUpdate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Blue Star", SellIn = 10, Quality = 0}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Blue Star");
            Assert.IsTrue(app.Awards[0].SellIn == 10);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].SellIn == 9);

        }

        [TestMethod]
        public void TestStandardAwardQualityIsNeverNegative()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Gov Quality Plus", SellIn = 0, Quality = 0}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Gov Quality Plus");
            Assert.IsTrue(app.Awards[0].Quality == 0);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 0);

        }
        [TestMethod]
        public void TestStandardSellInValueDecreasesBy1AfterUpdate()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name = "Gov Quality Plus", SellIn = 10, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Gov Quality Plus");
            Assert.IsTrue(app.Awards[0].SellIn == 10);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].SellIn == 9);

        }

        [TestMethod]
        public void TestStandardAwardQualityDecreasesBy1BeforeExpiration()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name =  "Gov Quality Plus", SellIn = 1, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Gov Quality Plus");
            Assert.IsTrue(app.Awards[0].Quality == 50);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 49);

        }

        [TestMethod]
        public void TestStandardAwardQualityDecreasesBy2AfterExpiration()
        {
            var app = new Program()
            {
                Awards = new List<Award>
                {
                    new Award {Name =  "Gov Quality Plus", SellIn = 0, Quality = 50}
                }
            };

            Assert.IsTrue(app.Awards.Count == 1);
            Assert.IsTrue(app.Awards[0].Name == "Gov Quality Plus");
            Assert.IsTrue(app.Awards[0].Quality == 50);

            app.UpdateQuality();

            Assert.IsTrue(app.Awards[0].Quality == 48);

        }

        // +++To Do - 1/10/2013: Discuss with team about adding more tests.  Seems like a lot of work for something
        //                       that probably won't change.  I watched it all in the debugger and know everything works
        //                       plus QA has already signed off and no one has complained.
    }
}
