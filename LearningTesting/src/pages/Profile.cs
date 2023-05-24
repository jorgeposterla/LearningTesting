using LearningTesting.src.framework.automation;
using LearningTesting.src.framework.controls;

namespace LearningTesting.src.pages;

public class Profile : AutomationBase
{
    private Label pageTitle;
    private IWebElement bandStatus;

    public Profile(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        pageTitle = new Label(myDriver, myDriver.FindElement(By.XPath("//h1[@class='band_name']/a")));
        bandStatus = new Label(myDriver, myDriver.FindElement(By.XPath("//dt[text()='Status:']/following-sibling::dd[1]")));
    }

    public string GetPageTitle()
    {
        return pageTitle.Text;
    }

    public string GetBandStatus()
    {
        return bandStatus.Text;
    }

    
}