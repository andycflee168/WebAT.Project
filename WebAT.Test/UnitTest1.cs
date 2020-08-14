using NUnit.Framework;
using System.IO;
using WebAT.Classes;

namespace WebAT.Test
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
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.IsTrue(File.Exists($"c:/Workspace/WebAT.Project/WebAT/google.json"));
        }
    }
}