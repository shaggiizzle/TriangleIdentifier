using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleIdentifier;
using Moq;
using System.IO;

namespace TriangleIdentifierTest
{
  [TestClass]
  public class UnitTest2
  {
    private Mock<ITriangleIdentifier> mockedIdentifier = new Mock<ITriangleIdentifier>();
    private ConsoleTriangleIdentifier consoleIdentifier;

    [TestInitialize]
    public void Setup()
    {     
      mockedIdentifier.Setup(mock => mock.AddSide(It.IsAny<int>())).Returns("");
      mockedIdentifier.Setup(mock => mock.SideCount).Returns(1);
      consoleIdentifier = new ConsoleTriangleIdentifier(mockedIdentifier.Object);
    }

    [TestCleanup]
    public void Cleanup()
    {
      StreamWriter standardOut = new StreamWriter(Console.OpenStandardOutput());
      standardOut.AutoFlush = true;
      Console.SetOut(standardOut);
    }

    [TestMethod]
    public void ValidInputTest()
    {
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);
        using (StringReader reader = new StringReader(String.Format("1{0}exit{0}", Environment.NewLine)))
        {
          Console.SetIn(reader);
          consoleIdentifier.Run();
        }
        string[] outputArray = sw.ToString().Split(sw.NewLine.ToCharArray());
        Assert.AreEqual("Enter side 2:", outputArray[0]);
        mockedIdentifier.Verify(x => x.AddSide(It.IsAny<int>()), Times.Exactly(1));
      }
    }

    [TestMethod]
    public void InvalidInputTest()
    {
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);
        using (StringReader reader = new StringReader(String.Format("not a number{0}exit{0}", Environment.NewLine)))
        {
          Console.SetIn(reader);
          consoleIdentifier.Run();
        }
        string[] outputArray = sw.ToString().Split(sw.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

        Assert.AreEqual("You did not enter a valid value", outputArray[1]);
        mockedIdentifier.Verify(x => x.AddSide(It.IsAny<int>()), Times.Never());
      }
    }

    [TestMethod]
    public void ValidWithReturnInputTest()
    {
      mockedIdentifier.Setup(mock => mock.AddSide(It.IsAny<int>())).Returns("Equilateral");
      using (StringWriter sw = new StringWriter())
      {
        Console.SetOut(sw);
        using (StringReader reader = new StringReader(String.Format("1{0}exit{0}", Environment.NewLine)))
        {
          Console.SetIn(reader);
          consoleIdentifier.Run();
        }
        string[] outputArray = sw.ToString().Split(sw.NewLine.ToCharArray());
        Assert.AreEqual("Enter side 2:", outputArray[0]);
        mockedIdentifier.Verify(x => x.AddSide(It.IsAny<int>()), Times.Exactly(1));
      }
    }
  }
}
