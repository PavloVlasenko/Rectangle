using NUnit.Framework;
using Rectangle.Impl;

namespace Rectangle.Tests
{
    public class RectangleExtensionsTest
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPositive()
        {
            var rect = new Impl.Rectangle()
            {
                X = 0,
                Y = 0,
                Width = 10,
                Height = 10,
            };
            Assert.True(rect.HasPoint(new (){X = 0, Y = 0}));
            Assert.True(rect.HasPoint(new (){X = 10, Y = 0}));
            Assert.True(rect.HasPoint(new (){X = 5, Y = 0}));
            Assert.True(rect.HasPoint(new (){X = 5, Y = 5}));
            Assert.True(rect.HasPoint(new (){X = 10, Y = 10}));
            
            
            Assert.False(rect.HasPoint(new (){X = -1, Y = -1}));
            Assert.False(rect.HasPoint(new (){X = -2, Y = 0}));
            Assert.False(rect.HasPoint(new (){X = 20, Y = 5}));
            Assert.False(rect.HasPoint(new (){X = 10, Y = 11}));
        }

        [Test]
        public void TestNegative()
        {
            var rect = new Impl.Rectangle()
            {
                X = -10,
                Y = -10,
                Width = 10,
                Height = 10,
            };
            Assert.True(rect.HasPoint(new (){X = 0, Y = 0}));
            Assert.True(rect.HasPoint(new (){X = -10, Y = 0}));
            Assert.True(rect.HasPoint(new (){X = -5, Y = 0}));
            Assert.True(rect.HasPoint(new (){X = -5, Y = -5}));
            Assert.True(rect.HasPoint(new (){X = -10, Y = -10}));
            Assert.True(rect.HasPoint(new (){X = -1, Y = -1}));
            
            
            Assert.False(rect.HasPoint(new (){X = 5, Y = 0}));
            Assert.False(rect.HasPoint(new (){X = 5, Y = 5}));
            Assert.False(rect.HasPoint(new (){X = 10, Y = 0}));
            Assert.False(rect.HasPoint(new (){X = -14, Y = -15}));
        }
    }
}