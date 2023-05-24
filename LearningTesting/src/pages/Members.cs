using LearningTesting.src.framework.automation;

namespace LearningTesting.src.pages
{
    public class Members : AutomationBase
    {
        private IWebElement currentMembers;

        public Members(IWebDriver myDriver)
        {
            this.myDriver = myDriver;
            Init(myDriver);
        }
        private void Init(IWebDriver myDriver)
        {
            currentMembers = myDriver.FindElement(By.Id("band_tab_members_current"));
        }
        public int GetMembersCount()
        {
            var memberNames = currentMembers.FindElements(By.XPath("./div/table[@class='display lineupTable']/tbody/tr[position() mod 2 = 1]/td[1]"));
            return memberNames.Count;
        }
    }
}
