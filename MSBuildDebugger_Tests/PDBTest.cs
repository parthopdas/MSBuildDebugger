using MSBuildDebugger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace MSBuildDebugger_Tests
{
    /// <summary>
    ///This is a test class for PDBTest and is intended
    ///to contain all PDBTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PDBTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"MSBuildDebugger_Tests\TestResources\Microsoft.Common.targets")]
        [DeploymentItem(@"MSBuildDebugger_Tests\TestResources\Microsoft.Common.targets.PDBInfo")]
        public void CreateTest_MS_Common()
        {
            string executablePath = Path.Combine(TestContext.TestDeploymentDir, "Microsoft.Common.targets");
            PDB actual = PDB.Create(executablePath);
            string actualPdbInfo = actual.ToString();
            string actualPdbInfoPath = Path.Combine(TestContext.TestDeploymentDir, "Microsoft.Common.targets.pdbinfo.actual");
            File.WriteAllText(actualPdbInfoPath, actualPdbInfo);

            string expectedPdbInfoPath = Path.Combine(TestContext.TestDeploymentDir, "Microsoft.Common.targets.pdbinfo");
            string expectedPdbInfo = File.ReadAllText(expectedPdbInfoPath);

            bool correctPdbGeneration = string.Equals(expectedPdbInfo, actualPdbInfo, StringComparison.Ordinal);
            
            Assert.IsTrue(
                correctPdbGeneration, 
                "PDB created incorrectly: Compare {0} {1}", expectedPdbInfoPath, actualPdbInfoPath
            );
        }

        /// <summary>
        ///A test for Create
        ///</summary>
        [TestMethod()]
        [DeploymentItem(@"MSBuildDebugger_Tests\TestResources\Microsoft.DevDiv.Native.targets")]
        [DeploymentItem(@"MSBuildDebugger_Tests\TestResources\Microsoft.DevDiv.Native.targets.PDBInfo")]
        public void CreateTest_DevDiv_Native()
        {
            string executablePath = Path.Combine(TestContext.TestDeploymentDir, "Microsoft.DevDiv.Native.targets");
            PDB actual = PDB.Create(executablePath);
            string actualPdbInfo = actual.ToString();
            string actualPdbInfoPath = Path.Combine(TestContext.TestDeploymentDir, "Microsoft.DevDiv.Native.targets.pdbinfo.actual");
            File.WriteAllText(actualPdbInfoPath, actualPdbInfo);

            string expectedPdbInfoPath = Path.Combine(TestContext.TestDeploymentDir, "Microsoft.DevDiv.Native.targets.pdbinfo");
            string expectedPdbInfo = File.ReadAllText(expectedPdbInfoPath);

            bool correctPdbGeneration = string.Equals(expectedPdbInfo, actualPdbInfo, StringComparison.Ordinal);

            Assert.IsTrue(
                correctPdbGeneration,
                "PDB created incorrectly: Compare {0} {1}", expectedPdbInfoPath, actualPdbInfoPath
            );
        }
    }
}
