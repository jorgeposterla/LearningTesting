using LearningTesting.src.framework.automation;
using LearningTesting.src.framework.controls;

namespace LearningTesting.src.pages;

public class Desambiguation : AutomationBase
{
    private Label pageTitle;
    
    public Desambiguation(IWebDriver myDriver)
    {
        this.myDriver = myDriver;
        Init(myDriver);
    }

    private void Init(IWebDriver myDriver)
    {
        pageTitle = new Label(myDriver, myDriver.FindElement(By.XPath("//h1[@class='page_title']")));
    }

    public string GetPageTitle()
    {
        return pageTitle.Text;
    }

    public Profile TransitionToProfile(string title)
    {
        try
        {
            while(pageTitle.Displayed == true)
            {

            }
        }
        catch
        {
        }
        return new Profile(myDriver);
    }

    public Members TransitionToMembers()
    {
        try
        {
            while (pageTitle.Displayed == true)
            {

            }
        }
        catch
        {
        }
        return new Members(myDriver);
    }
    
    public Reviews TransitionToReviews()
    {
        try
        {
            while (pageTitle.Displayed == true)
            {

            }
        }
        catch
        {
        }
        return new Reviews(myDriver);
    }
}