using System.Collections.Generic;
using NUnit.Framework;

namespace AppartmentFinder
{
  public class Tests
  {
    [Test]
    public void SimplestCase()
    {
      var blocks = new Dictionary<string, bool>[2]
      {
        new Dictionary<string, bool>()
          {
            { "gym", false }
          },
        new Dictionary<string, bool>()
          {
            { "gym", true }
          }
      };

      var finder = new AppartmentFinder();
      int result = finder.Find(blocks);

      Assert.AreEqual(1, result);
    }

    [Test]
    public void SimpleCase()
    {
      var blocks = new Dictionary<string, bool>[2]
      {
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }
        }
      };

      var finder = new AppartmentFinder();
      int result = finder.Find(blocks);

      Assert.AreEqual(0, result);
    }

    [Test]
    public void OriginalCase()
    {
      var blocks = new Dictionary<string, bool>[5]
      {
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }
        },
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", true }, { "store", false }
        },
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", true }, { "store", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", true }
        }
      };

      var finder = new AppartmentFinder();
      int result = finder.Find(blocks);

      Assert.AreEqual(3, result);
    }

    [Test]
    public void HarderCase()
    {
      var blocks = new Dictionary<string, bool>[8]
      {
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", false }
        },
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", true }
        },
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", true }, { "store", false }, { "carwash", true }, { "laundry", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", true }, { "carwash", false }, { "laundry", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", true }, { "carwash", true }, { "laundry", false }
        }
      };

      var finder = new AppartmentFinder();
      int result = finder.Find(blocks);

      Assert.AreEqual(3, result);
    }

    [Test]
    public void InsaneCase()
    {
      var blocks = new Dictionary<string, bool>[20]
      {
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", true }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", true }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", true }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", true }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", true }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", true }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", true }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", true }, { "movie", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", true }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", true }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", true }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", true }, { "kindergarten", false }, { "hospital", false }, { "movie", true }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", true }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", true }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", false }, { "carwash", true }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", false }, { "store", true }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", false }, { "school", true }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        },
        new Dictionary<string, bool>() {
          { "gym", true }, { "school", false }, { "store", false }, { "carwash", false }, { "laundry", false }, { "drugstore", false }, { "theater", false }, { "kindergarten", false }, { "hospital", false }, { "movie", false }
        }
      };

      var finder = new AppartmentFinder();
      int result = finder.Find(blocks);

      Assert.AreEqual(15, result);
    }
  }
}