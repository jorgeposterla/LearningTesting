using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using LearningTesting.src.pages;

namespace LearningTesting.src.framework.automation;

public class AutomationBase
{
    protected IWebDriver myDriver;
    protected StartBrowser startBrowser;
    public Header header;
    public Homepage homepage;
    public static ExtentTest test;
    public static ExtentReports extent = new ExtentReports();

    [OneTimeSetUp]
    public void ExtentStart()
    {
        string reportPath = @"C:\Users\Jorge\source\repos\OpenBootcamp\TestProject2\TestProject2\test\Reports";
        ExtentHtmlReporter logger = new ExtentHtmlReporter (reportPath);
        extent.AttachReporter(logger);
    }

    [SetUp]
    public void Setup()
    {
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        var testType = TestContext.CurrentContext.Test.Properties["Category"].Contains("UI");
        if(testType)
        {
            test.Log(Status.Info, "UI test started");
            myDriver = new StartBrowser().StartSelectedBrowser(Browsers.Chrome, Environments.prod);
            header = new Header(myDriver);
            homepage = new Homepage(myDriver);
        }
        else
        {
            test.Log(Status.Info, "API test started");
        }
    }

    [TearDown]
    public void TearDown()
    {
        var result = TestContext.CurrentContext.Result.Outcome.ToString();
        switch (result)
        {
            case "Inconclusive":
                test.Log(Status.Warning, MarkupHelper.CreateLabel("* INCONCLUSIVE *", ExtentColor.Yellow));
                break;

            case "Skipped":
                test.Log(Status.Skip, MarkupHelper.CreateLabel("* SKIPPED *", ExtentColor.Yellow));
                break;

            case "Passed":
                test.Log(Status.Pass, MarkupHelper.CreateLabel("* PASSED *", ExtentColor.Green));
                break;

            case "Failed":
                test.Log(Status.Fail, MarkupHelper.CreateLabel("* FAILED *", ExtentColor.Red));
                break;

            default:
                test.Log(Status.Info, MarkupHelper.CreateLabel("* There was a problem while running the test case *", ExtentColor.Red));
                break;
        }
        if(TestContext.CurrentContext.Test.Properties["Category"].Contains("UI"))
        {
            myDriver.Quit();
        }
    }

    [OneTimeTearDown]
    public void ExtentClose()
    {
        extent.Flush();
    }
}
