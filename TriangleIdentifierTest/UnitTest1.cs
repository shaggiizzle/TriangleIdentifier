using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleIdentifier;

namespace TriangleClassifierTest
{
  [TestClass]
  public class TriangeClassifierTests
  {
    private ITriangleIdentifier classifier;
    [TestInitialize]
    public void Setup()
    {
      classifier = new TriangleIdentifier.TriangleIdentifier();
    }

    [TestMethod]
    public void InitialStateTest()
    {
      
      Assert.AreEqual(0, classifier.SideCount);
    }

    [TestMethod]
    public void AddSingleSideTest()
    {
      string result = classifier.AddSide(1);

      Assert.AreEqual("", result);
      Assert.AreEqual(1, classifier.SideCount);
    }

    [TestMethod]
    public void AddTwoSidesTest()
    {
      string result = classifier.AddSide(5);
      result = classifier.AddSide(5);

      Assert.AreEqual("", result);
      Assert.AreEqual(2, classifier.SideCount);
    }

    [TestMethod]
    public void EquilateralTest()
    {
      string result = classifier.AddSide(5);
      result = classifier.AddSide(5);
      result = classifier.AddSide(5);

      Assert.AreNotEqual("", result);
      Assert.AreEqual("Equilateral", result);
      Assert.AreEqual(0, classifier.SideCount);
    }

    [TestMethod]
    public void IsolecesTest()
    {
      string result = classifier.AddSide(5);
      result = classifier.AddSide(5);
      result = classifier.AddSide(8);

      Assert.AreNotEqual(result, "");
      Assert.AreEqual("Isosceles", result);
      Assert.AreEqual(0, classifier.SideCount);
    }

    [TestMethod]
    public void ScaleneTest()
    {
      string result = classifier.AddSide(3);
      result = classifier.AddSide(4);
      result = classifier.AddSide(5);

      Assert.AreNotEqual("", result);
      Assert.AreEqual("Scalene", result);
      Assert.AreEqual(0, classifier.SideCount);
    }
  }
}