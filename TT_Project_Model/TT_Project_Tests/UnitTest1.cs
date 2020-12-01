using NUnit.Framework;
using System.Linq;
using TT_Project_Model;
using TT_Project_Business;

namespace TT_Project_Tests
{
    public class Tests
    {
		CRUDManager _crudManager = new CRUDManager();

		[SetUp]
        public void Setup()
        {
        }

		[Test]
		public void RiderrIsAdded_NumberIncreasesBy1()
		{
			using (var db = new TT_ProjectContext())
			{
				var numberBefore = db.Riders.ToList().Count();

			}

		}
	}
}