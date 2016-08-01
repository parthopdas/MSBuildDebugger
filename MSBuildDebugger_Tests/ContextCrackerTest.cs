using MSBuildDebugger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MSBuildDebugger_Tests
{
    /// <summary>
    ///This is a test class for ContextCrackerTest and is intended
    ///to contain all ContextCrackerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ContextCrackerTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// No:     Context     Batching    Inactive    Repeat
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_NoBatch_NoInactive_NoRepeat_1()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"
<Project ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Target Name='rebuild'>
    <Message Text='this is from leaf.csproj'></Message>
     <Warning Text='random warning'></Warning>
    <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
       <FormatVersion></FormatVersion>
     <FormatUrl></FormatUrl>
  </Target>
</Project>"
            #endregion
            );
            string expected = string.Format(
            #region Expected Dump
@"{0} [2, 2]
rebuild [3, 4]
Message [4, 6]
Warning [5, 7]
ConvertToAbsolutePath [6, 6]
FormatVersion [7, 9]
FormatUrl [8, 7]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Batching    Inactive    Repeat
        /// Yes:
        /// With dependent targets
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_NoBatch_NoInactive_NoRepeat_2()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"
<Project ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Target Name='rebuild' DependsOnTargets='prebuild'>
    <Message Text='this is from leaf.csproj'></Message>
     <Warning Text='random warning'></Warning>
     <FormatUrl></FormatUrl>
  </Target>

  <Target Name='prebuild'>
    <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
       <FormatVersion></FormatVersion>
  </Target>
</Project>"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [2, 2]
prebuild [9, 4]
ConvertToAbsolutePath [10, 6]
FormatVersion [11, 9]
rebuild [3, 4]
Message [4, 6]
Warning [5, 7]
FormatUrl [6, 7]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Batching    Inactive
        /// Yes:    Repeat
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_NoBatch_NoInactive_YesRepeat_1()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"
<Project ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Target Name='rebuild'>
    <Message Text='this is from leaf.csproj'></Message>
     <Warning Text='random warning'></Warning>
    <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
       <FormatVersion></FormatVersion>
      <FormatVersion></FormatVersion>
     <FormatVersion></FormatVersion>
     <FormatUrl></FormatUrl>
  </Target>
</Project>"
            #endregion
            );
            string expected = string.Format(
            #region Expected Dump
@"{0} [2, 2]
rebuild [3, 4]
Message [4, 6]
Warning [5, 7]
ConvertToAbsolutePath [6, 6]
FormatVersion [7, 9]
FormatVersion [8, 8]
FormatVersion [9, 7]
FormatUrl [10, 7]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Batching    Repeat
        /// Yes:    Inactive
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_NoBatch_YesInactive_NoRepeat_1()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"
<Project ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Target Name='rebuild'>
    <Message Text='this is from leaf.csproj'></Message>
    <Warning Text='random warning'></Warning>
    <ConvertToAbsolutePath Condition='false' Paths=''></ConvertToAbsolutePath>
    <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
    <FormatVersion Condition='false'></FormatVersion>
    <FormatUrl></FormatUrl>
  </Target>
</Project>"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [2, 2]
rebuild [3, 4]
Message [4, 6]
Warning [5, 6]
ConvertToAbsolutePath [7, 6]
FormatUrl [9, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Batching    Repeat
        /// Yes:    Inactive
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_NoBatch_YesInactive_NoRepeat_2()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"
<Project ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Target Name='rebuild'>
    <Message Condition='false' Text='this is from leaf.csproj'></Message>
    <Message Text='this is from leaf.csproj'></Message>
    <Warning Text='random warning'></Warning>
    <ConvertToAbsolutePath Condition='false' Paths=''></ConvertToAbsolutePath>
    <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
    <FormatVersion Condition='false'></FormatVersion>
    <FormatUrl></FormatUrl>
    <FormatUrl Condition='false'></FormatUrl>
  </Target>
</Project>"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [2, 2]
rebuild [3, 4]
Message [5, 6]
Warning [6, 6]
ConvertToAbsolutePath [8, 6]
FormatUrl [10, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Batching    
        /// Yes:    Repeat      Inactive
        /// With dependent targets
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_NoBatch_YesInactive_YesRepeat_1_Complex()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project ToolsVersion='3.5' DefaultTargets='rebuild' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
<Target Name='preprebuild'>
 <Message Condition='false' Text='this is from leaf.csproj'></Message>
    <Message Text='this is from leaf.csproj'></Message>
                             <Warning Text='random warning'></Warning>
  </Target>

  <Target Name='rebuild' DependsOnTargets='prebuild'>
    <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
         <FormatUrl></FormatUrl>
    <FormatUrl></FormatUrl>
  </Target>

<Target Name='prebuild' DependsOnTargets='preprebuild'>
    <ConvertToAbsolutePath Paths='' Condition='false'></ConvertToAbsolutePath>
                <ConvertToAbsolutePath Paths=''></ConvertToAbsolutePath>
    <Message Text='this is from leaf.csproj'></Message>
    <FormatVersion Condition='false'></FormatVersion>
  </Target>

</Project>"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
preprebuild [2, 2]
Message [4, 6]
Warning [5, 31]
prebuild [14, 2]
ConvertToAbsolutePath [16, 18]
Message [17, 6]
rebuild [8, 4]
ConvertToAbsolutePath [9, 6]
FormatUrl [10, 11]
FormatUrl [11, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Repeat      Inactive
        /// Yes:    Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_NoRepeat_1()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Text='%(ExampColl.Identity)'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [7, 6]
Message [7, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Repeat      Inactive
        /// Yes:    Batching
        /// Conditional batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_NoRepeat_1a()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='1'/>
    <ExampColl Include='2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Condition='%(ExampColl.Identity) == 1' Text='...'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [7, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_1a()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl1 Include='Item1'/>
    <ExampColl1 Include='Item2'/>
    <ExampColl2 Include='Item1'/>
    <ExampColl2 Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Text='%(ExampColl1.Identity)'/>
    <Message Text='%(ExampColl2.Identity)'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [8, 4]
Message [10, 6]
Message [10, 6]
Message [10, 6]
Message [10, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_1aa()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl1 Include='Item1'/>
    <ExampColl1 Include='Item2'/>
    <ExampColl2 Include='Item1'/>
    <ExampColl2 Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <FormatUrl Condition='false'/>
    <Message Text='%(ExampColl1.Identity)'/>
    <Message Text='%(ExampColl2.Identity)'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [8, 4]
Message [10, 6]
Message [11, 6]
Message [11, 6]
Message [11, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_1ab()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl1 Include='Item1'/>
    <ExampColl1 Include='Item2'/>
    <ExampColl2 Include='Item1'/>
    <ExampColl2 Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Text='%(ExampColl1.Identity)'/>
    <FormatUrl Condition='false'/>
    <Message Text='%(ExampColl2.Identity)'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [8, 4]
Message [9, 6]
Message [9, 6]
Message [11, 6]
Message [11, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_1b()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Text='%(ExampColl.Identity)'/>
    <FormatUrl Condition='false'/>
    <Message Text='partha0'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [7, 6]
Message [7, 6]
Message [9, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_1c()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <FormatUrl Condition='false'/>
    <Message Text='%(ExampColl.Identity)'/>
    <Message Text='partha0'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [8, 6]
Message [9, 6]
Message [9, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_2()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <FormatUrl Condition='false'/>
    <Message Text='%(ExampColl.Identity)'/>
    <Message Text='partha0'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [8, 6]
Message [9, 6]
Message [9, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_3()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <FormatUrl Condition='false'/>
    <Message Text='%(ExampColl.Identity)'/>
    <FormatUrl Condition='false'/>
    <Message Text='partha0'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [8, 6]
Message [8, 6]
Message [10, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_4()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <FormatUrl/>
    <Message Text='%(ExampColl.Identity)'/>
    <FormatUrl/>
    <Message Text='partha0'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
FormatUrl [7, 6]
Message [8, 6]
Message [8, 6]
FormatUrl [9, 6]
Message [10, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_4a()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='1'/>
    <ExampColl Include='2'/>
  </ItemGroup>
  <Target Name='build'>
    <FormatUrl/>
    <Message Text='...' Condition='%(ExampColl.Identity) == 2'/>
    <FormatUrl/>
    <Message Text='partha0'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
FormatUrl [7, 6]
Message [8, 6]
FormatUrl [9, 6]
Message [10, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_5()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='Item1'/>
    <ExampColl Include='Item2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Text='partha0'/>
    <Message Text='%(ExampColl.Identity)'/>
    <Message Text='partha1'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [8, 6]
Message [9, 6]
Message [9, 6]
Message [9, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        /// <summary>
        /// No:     Context     Inactive
        /// Yes:    Repeat Batching
        /// Conditional batching
        /// </summary>
        [TestMethod()]
        public void ContextCracker_NoContext_YesBatch_NoInactive_YesRepeat_5a()
        {
            string projectFilePath = Utilities.CreateTemporaryProject(
            #region Project Contents
@"<Project DefaultTargets='build' ToolsVersion='3.5' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <ExampColl Include='1'/>
    <ExampColl Include='2'/>
  </ItemGroup>
  <Target Name='build'>
    <Message Text='partha0'/>
    <Message Text='...' Condition='%(ExampColl.Identity) == 2'/>
    <Message Text='partha1'/>
  </Target>
</Project>
"
            #endregion
);
            string expected = string.Format(
            #region Expected Dump
@"{0} [1, 2]
build [6, 4]
Message [8, 6]
Message [9, 6]
Message [9, 6]
"
            #endregion
, Path.GetFileName(projectFilePath));

            string actual = Utilities.BuildProjectAndDumpPdbEntries(projectFilePath);
            Assert.AreEqual(expected, actual, false);
            File.Delete(projectFilePath);
        }

        // Batching, condition, repetation
    }
}
