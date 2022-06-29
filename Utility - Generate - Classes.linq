<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.FileSystem.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Queryable.dll</Reference>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	try{
		string createdBy = "TS MOGANO";
		string dateCreated = DateTime.Now.ToString("yyyy-MM-dd");
		string directoryCurrent = Directory.GetCurrentDirectory();
		string directoryRoot = Directory.GetParent(directoryCurrent).ToString();
		string directoryLib = Path.Combine(directoryCurrent, "lib");
		string directoryTests = Path.Combine(directoryCurrent, "tests");
		string directoryTestsMS = Path.Combine(directoryTests, "ms-test-working-with-sorting-algorigthms");
		string directoryTestsNUnit = Path.Combine(directoryTests, "nunit-working-with-sorting-algorigthms");
		string[] algorithms = {
			"SelectionSort",
			"BubbleSort",
			"RecursiveBubbleSort",
			"InsertionSort",
			"RecursiveInsertionSort",
			"MergeSort",
			"IterativeMergeSort",
			"QuickSort",
			"IterativeQuickSort",
			"HeapSort",
			"CountingSort",
			"RadixSort",
			"BucketSort",
			"ShellSort",
			"TimSort",
			"CombSort",
			"PigeonholeSort",
			"CycleSort",
			"CocktailSort",
			"StrandSort",
			"BitonicSort",
			"PancakeSort",
			"BinaryInsertionSort",
			"BogoSortOrPermutationSort",
			"PermutationSort",
			"GnomeSort",
			"SleepSort",
			"StructureSort",
			"ByMultipleRulesSort",
			"StoogeSort",
			"TagSort",
			"TreeSort",
			"CartesianTreeSort",
			"OddEvenSort",
			"BrickSort",
			"QuickSortOnSinglyLinkedList",
			"QuickSortOnDoublyLinkedList",
			"ThreeWayQuickSort",
			"MergeSortforLinkedLists",
			"MergeSortforDoublyLinkedList",
			"ThreeWayMergeSort"};
		
		directoryRoot.Dump();
		directoryCurrent.Dump();
		directoryLib.Dump();
		directoryTests.Dump();
		directoryTestsMS.Dump();
		directoryTestsNUnit.Dump();
		
		CleanDirectoryOnly(directoryLib, ".cs");
		CleanDirectoryOnly(directoryTestsMS, ".cs");
		CleanDirectoryOnly(directoryTestsNUnit, ".cs");
		
		foreach(string algorithm in algorithms){
			string libClass = templateLibaryClass(algorithm, createdBy, dateCreated);
			string msTestClass = templateMSTestClass(algorithm, createdBy, dateCreated);
			string nunitClass = templateNUnitTestClass(algorithm, createdBy, dateCreated);
			
			replaceFile(Path.Combine(directoryLib, String.Format("{0}.cs", algorithm)), libClass);
			replaceFile(Path.Combine(directoryTestsMS, String.Format("MSTests{0}Algorithm.cs", algorithm)), msTestClass);
			replaceFile(Path.Combine(directoryTestsNUnit, String.Format("NUnitTests{0}Algorithm.cs", algorithm)), nunitClass);
		}

	}catch(Exception exception){
		exception.Dump();
	}finally{}
}

// Define other methods and classes here
public string SplitCamelCase(string str)
{
	return Regex.Replace( Regex.Replace( str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2" ), @"(\p{Ll})(\P{Ll})", "$1 $2" );
}
private string CapitalizeFirstLetter(string str) {
	str = (str ?? String.Empty);
	return str.Substring(0, 1).ToUpper() + str.Substring(1);
}
private string LowerFirstLetter(string str) {
	str = (str ?? String.Empty);
	return str.Substring(0, 1).ToLower() + str.Substring(1);
}
private void CleanAndDeleteDirectory(string path){
	if(System.IO.Directory.Exists(path)){
		Console.WriteLine("Clean and Delete Directory : {0}", path);
		System.IO.DirectoryInfo rootDir = new DirectoryInfo(path);
		foreach (FileInfo file in rootDir.EnumerateFiles())
		{
		    file.Delete(); 
		}
		foreach (DirectoryInfo dir in rootDir.EnumerateDirectories())
		{
		    CleanAndDeleteDirectory(dir.ToString());
		}
		rootDir.Delete(true);
	}
}
private void CleanDirectoryOnly(string path, string fileExtension = "*.*"){
	if(System.IO.Directory.Exists(path)){
		Console.WriteLine("Cleaning Directory : {0}", path);
		System.IO.DirectoryInfo rootDir = new DirectoryInfo(path);
		IEnumerable<FileInfo> files = rootDir.EnumerateFiles().Where(file => fileExtension.Equals("*.*") || file.Name.EndsWith(fileExtension));
		foreach (FileInfo file in files)
		{
		    file.Delete(); 
		}
		foreach (DirectoryInfo dir in rootDir.EnumerateDirectories())
		{
		    CleanAndDeleteDirectory(dir.ToString());
		}
	}
}
private void createDirectoryIfNotExists(string path){
	if(!System.IO.Directory.Exists(path)){
		Console.WriteLine("Create Directory : {0}", path);
		System.IO.Directory.CreateDirectory(path);
	}
}
private void deleteFileIfExists(string path){
	if(System.IO.File.Exists(path)){
		Console.WriteLine("Delete File : {0}", path);
		System.IO.File.Delete(path);
	}
}
private void createFileIfNotExists(string path, string content){
	if(!System.IO.File.Exists(path)){
		Console.WriteLine("Create File : {0}", path);
		System.IO.File.WriteAllText(path, content);
	}
}
private void replaceFile(string path, string content){
	deleteFileIfExists(path);
	System.IO.File.WriteAllText(path, content);
}
private String templateLibaryClass(string name, string createdBy, string dateCreated){
	StringBuilder sb = new StringBuilder();
	name = SplitCamelCase(name);
	string className = name.Replace(" ", String.Empty);
	string variableName = LowerFirstLetter(className);
	sb.AppendLine("using System;");
	sb.AppendLine("using System.Collections.Generic;");
	sb.AppendLine("using System.Linq;");
	sb.AppendLine("using System.Text;");
	sb.AppendLine("using System.Threading.Tasks;");
	sb.AppendLine("");
	sb.AppendLine("namespace lib");
	sb.AppendLine("{");
	sb.AppendLine("    /// <summary>");
	sb.AppendLine(String.Format("    /// Defines the structure (properties, methods, etc.) and syntax for the {0} Algorithm", name));
	sb.AppendLine("    /// </summary>");
	sb.AppendLine(String.Format("    public interface I{0}", className));
	sb.AppendLine("    {");
	sb.AppendLine("    }");
	sb.AppendLine("    /// <summary>");
	sb.AppendLine(String.Format("    /// Implements the structure (properties, methods, etc.) and syntax for the {0} Algorithm", name));
	sb.AppendLine("    /// </summary>");
	sb.AppendLine(String.Format("    public class {0}: I{0}", className));
	sb.AppendLine("    {");
	sb.AppendLine("    }");
	sb.AppendLine("}");
	sb.AppendLine("");
	return sb.ToString();
}
private String templateMSTestClass(string name, string createdBy, string dateCreated){
	StringBuilder sb = new StringBuilder();
	name = SplitCamelCase(name);
	string className = name.Replace(" ", String.Empty);
	string variableName = LowerFirstLetter(className);
	sb.AppendLine("using lib;");
	sb.AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
	sb.AppendLine("");
	sb.AppendLine("namespace ms_test_working_with_sorting_algorigthms");
	sb.AppendLine("{");
	sb.AppendLine("    /// <summary>");
	sb.AppendLine(String.Format("    /// Defines, sets up and implements the MS (Microsoft) test(s) for the {0} Algorithm", name));
	sb.AppendLine("    /// </summary>");
	sb.AppendLine("    [TestClass]");
	sb.AppendLine(String.Format("    public class MSTests{0}Algorithm", className));
	sb.AppendLine("    {");
	sb.AppendLine(String.Format("        private I{0} {1};", className, variableName));
	sb.AppendLine("");
	sb.AppendLine("        [TestMethod]");
	sb.AppendLine("        public void TestMethod1()");
	sb.AppendLine("        {");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("}");
	sb.AppendLine("");
	return sb.ToString();
}
private String templateNUnitTestClass(string name, string createdBy, string dateCreated){
	StringBuilder sb = new StringBuilder();
	name = SplitCamelCase(name);
	string className = name.Replace(" ", String.Empty);
	string variableName = LowerFirstLetter(className);
	sb.AppendLine("using lib;");
	sb.AppendLine("using NUnit.Framework;");
	sb.AppendLine("");
	sb.AppendLine("namespace nunit_working_with_sorting_algorigthms");
	sb.AppendLine("{");
	sb.AppendLine("    /// <summary>");
	sb.AppendLine(String.Format("    /// Defines, sets up and implements the NUnit test(s) for the {0} Algorithm", name));
	sb.AppendLine("    /// </summary>");
	sb.AppendLine(String.Format("    public class NUnitTests{0}Algorithm", className));
	sb.AppendLine("    {");
	sb.AppendLine(String.Format("        private I{0} {1};", className, variableName));
	sb.AppendLine("        [SetUp]");
	sb.AppendLine("        public void Setup()");
	sb.AppendLine("        {");
	sb.AppendLine("        }");
	sb.AppendLine("");
	sb.AppendLine("        [Test]");
	sb.AppendLine("        public void Test1()");
	sb.AppendLine("        {");
	sb.AppendLine("            Assert.Pass();");
	sb.AppendLine("        }");
	sb.AppendLine("    }");
	sb.AppendLine("}");
	sb.AppendLine("");
	return sb.ToString();
}