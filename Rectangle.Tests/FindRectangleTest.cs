using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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
        public void TestArgs()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var rectangle = Service.FindRectangle(new() {new()});
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var rectangle = Service.FindRectangle(new() {new(), new(), new()});
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var rectangle = Service.FindRectangle(new() {new(), null});
            });
            Assert.Throws<ArgumentNullException>(() =>
            {
                var rectangle = Service.FindRectangle(null);
            });
        }

        [Test]
        public void TestPredefined()
        {
            static Point p(int x, int y) => new() {X = x, Y = y};
            Assert.Throws<RectangleNotFoundException>(() =>
            {
                var rectangle = Service.FindRectangle(new() {p(0, 0), p(10, 10), p(10, 0), p(0, 10)});
            });
            var points = new List<Point> {p(0, 0), p(10, 10), p(10, 0), p(50, 10)};
            var rect = Service.FindRectangle(points);
            var inRect = points.Where(t => rect.HasPoint(t)).ToList();
            var outRect = points.Where(t => !rect.HasPoint(t)).ToList();
            outRect.Should().ContainSingle();
            inRect.Should().HaveCount(points.Count - 1);
        }

        [Test]
        public void TestRandom()
        {
            var r = new Random();
            for (int i = 0; i < 100; i++)
            {
                var points = Enumerable.Range(1, 20).Select(_ => new Point
                {
                    X = r.Next(-100, 100),
                    Y = r.Next(-100, 100)
                }).ToList();
                if (points.Select(t => (t.X, t.Y)).Distinct().Count() != points.Count())
                {
                    Assert.Throws<ArgumentException>(() => Service.FindRectangle(points));
                    continue;
                }

                try
                {
                    var rect = Service.FindRectangle(points);
                    var inRect = points.Where(t => rect.HasPoint(t)).ToList();
                    var outRect = points.Where(t => !rect.HasPoint(t)).ToList();
                    outRect.Should().ContainSingle();
                    inRect.Should().HaveCount(points.Count - 1);
                }
                catch (RectangleNotFoundException _)
                {
                    Console.WriteLine(
                        $"Rectangle not found for points: {string.Join(' ', points.Select(t => (t.X, t.Y)))}");
                    throw;
                }
            }
        }
    }
}