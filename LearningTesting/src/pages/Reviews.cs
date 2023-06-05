using LearningTesting.src.framework.automation;

namespace LearningTesting.src.pages
{
    public class Reviews : AutomationBase
    {
        private readonly IWebDriver driver;
        private readonly By reviewTabLocator = By.XPath("//a[@title='Reviews']");
        private readonly By reviewsTableLocator = By.XPath("//table[@class='display dataTable']");


        public Reviews(IWebDriver driver)
        {
            this.driver = driver;
            Init(driver);
        }
        private void Init(IWebDriver myDriver)
        {
            IWebElement reviewTab = driver.FindElement(reviewTabLocator);
            reviewTab.Click();
            Thread.Sleep(5000);
            //WaitForElementVisible(reviewsTableLocator, 10);
        }
        
        //I gave up using this type of wait for the constant errors

        //public void WaitForElementVisible(By locator, int timeoutInSeconds)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //    wait.Until(driver =>
        //    {
        //        IWebElement element = driver.FindElement(locator);
        //        return element.Displayed;
        //    });
        //}

        public double CalculateAverageRating()
        {
            IWebElement reviewsTable = driver.FindElement(reviewsTableLocator);

            // Get all rows in the table
            IList<IWebElement> rows = reviewsTable.FindElements(By.XPath(".//tbody/tr"));

            double totalRating = 0;
            int rowCount = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                // Get the cell that contains the rating (second cell in each row)
                IWebElement ratingCell = rows[i].FindElements(By.TagName("td"))[1];

                // Get the rating as a numeric value
                double rating = double.Parse(ratingCell.Text.Replace("%", ""));

                totalRating += rating;

                rowCount++;
            }

            double averageRating = totalRating / rowCount;
            averageRating = Math.Round(averageRating, 2);

            return averageRating;
        }

    }
}
