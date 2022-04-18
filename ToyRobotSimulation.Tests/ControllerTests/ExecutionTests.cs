using Xunit.Abstractions;
using ToyRobotSimulation.Controller;
using Xunit;
using System.IO;
using System;

namespace ToyRobotSimulation.Tests.ControllerTests
{
    public class ExecutionTests
    {
        private const string SuccessTestData1 = "SuccessTestData1.txt";
        private const string SuccessTestData2 = "SuccessTestData2.txt";
        private const string SuccessTestData3 = "SuccessTestData3.txt";
        private const string InvalidFormatTestData = "InvalidFormatTestData.txt";
        private const string InvalidPositionTestData = "InvalidPositionTestData.txt";

        private static Execution GetCodeUnderTest(string fileName)
        {
            string TestData = EmbededResourceUtils.GetEmbededResource(fileName) ?? throw new FileNotFoundException($"File {fileName} not found in embeded resources");
            string[] commands = TestData.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return new Execution(commands);
        }

        [Theory]
        [Trait("TestType", "UnitTest")]
        [InlineData(SuccessTestData1)]
        [InlineData(SuccessTestData2)]
        [InlineData(SuccessTestData3)]
        public void Execution_WhenPassedValidInputs_ReturnsValidResults(string fileName)
        {
            var resolver = GetCodeUnderTest(fileName);
            string result = resolver.Execute();
            
            Assert.NotNull(result);
            switch (fileName)
            {
                case SuccessTestData1:
                    Assert.Equal("0,1,NORTH", result);            
                    break;
                case SuccessTestData2:
                    Assert.Equal("0,0,WEST", result);
                    break;
                case SuccessTestData3:
                    Assert.Equal("3,3,NORTH", result);
                    break;
            }
        }

        [Theory]
        [Trait("TestType", "UnitTest")]
        [InlineData(InvalidFormatTestData)]
        [InlineData(InvalidPositionTestData)]
        public void Execution_WhenPassedInValidInputs_ThrowsException(string fileName)
        {
            var resolver = GetCodeUnderTest(fileName);

            Assert.Throws<ArgumentException>(() => resolver.Execute());
        }

    }
}
