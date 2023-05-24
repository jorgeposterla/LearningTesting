using OpenQA.Selenium;
using LearningTesting.src.framework.automation;
using LearningTesting.src.framework.controls;
using LearningTesting.src.pages.locators;

namespace LearningTesting.src.pages;

public class Header : AutomationBase
{
    private Dropdown entityDropdown;
    private Textbox searchBox;
    private Button submitButton;

    public Header(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    public void Init(IWebDriver myDriver)
    {
        entityDropdown = new Dropdown(myDriver, myDriver.FindElement(By.XPath(LHeader.entityDropdown)));
        searchBox = new Textbox(myDriver, myDriver.FindElement(By.XPath(LHeader.searchBox)));
        submitButton = new Button(myDriver, myDriver.FindElement(By.XPath(LHeader.submitButton)));
    }

    public Desambiguation Search(string entity, string name)
    {
        entityDropdown.SelectOption(entity);
        searchBox.SendKeys(name);
        submitButton.Click();
        return new Desambiguation(myDriver);
    }
}