using System.Linq;
using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var rectangle = Service.FindRectangle(new[] { new Point() }.ToList());
			Assert.IsNotNull(rectangle);
		}
	}
}