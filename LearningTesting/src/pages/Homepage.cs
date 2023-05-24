using OpenQA.Selenium;
using LearningTesting.src.framework.automation;
using LearningTesting.src.framework.controls;

namespace LearningTesting.src.pages;

public class Homepage : AutomationBase
{
    public Homepage(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    public void Init(IWebDriver myDriver)
    {

    }
}