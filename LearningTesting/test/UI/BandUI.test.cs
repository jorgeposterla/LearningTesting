using LearningTesting.src.framework.automation;
using LearningTesting.src.pages;
using LearningTesting.src.pages.locators;

namespace LearningTesting.test.UI;

[TestFixture]
public class BandUITest : AutomationBase
{
    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifySearchPageTitle()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string expectedPageTitle = "Search results for \"Metallica\"";

        // test steps
        test.Log(Status.Info, "Step 1: Search for " + entityName);
        var desambiguation = header.Search(entityType, entityName);
        test.Log(Status.Info, "Step 2: Get the page title");
        string dTitle = desambiguation.GetPageTitle();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(dTitle, Is.EqualTo(expectedPageTitle), "Validate the page title is the expected one");
    }

    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifyBandProfileIsDisplayed()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string title = "Search results for \"Metallica\"";
        string expectedPageTitle = "Metallica";

        // test steps
        test.Log(Status.Info, "Step 1: Search for " + entityName);
        var desambiguation = header.Search(entityType, entityName);
        var profile = desambiguation.TransitionToProfile(title);
        test.Log(Status.Info, "Step 2: Get the page title");
        string pTitle = profile.GetPageTitle();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(pTitle, Is.EqualTo(expectedPageTitle), "Validate the page title is the expected one");
    }

    [Test]
    [Category("UI")]
    [Author("Cristian Maillard")]
    public void VerifyBandStatus()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Metallica";
        string title = "Search results for \"Metallica\"";
        string expectedEntityStatus = "Active";

        // test steps
        test.Log(Status.Info, "Step 1: Search for " + entityName);
        var desambiguation = header.Search(entityType, entityName);
        var profile = desambiguation.TransitionToProfile(title);
        test.Log(Status.Info, "Step 2: Get the band status");
        string pStatus = profile.GetBandStatus();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(pStatus, Is.EqualTo(expectedEntityStatus), "Validate the band status is \"Active\"");
    }

    [Test]
    [Category("UI")]
    [Author("Jorge Posterla")]
    public void CountMembers()
    {
        // test variables
        string entityType = "band_name";
        string entityName = "Rata_Blanca";
        int expectedMembersCount = 5;

        // test steps
        test.Log(Status.Info, "Step 1: Search for " + entityName);
        var desambiguation = header.Search(entityType, entityName);
        var members = desambiguation.TransitionToMembers();
        test.Log(Status.Info, "Step 2: Get the current members count");
        int membersCount = members.GetMembersCount();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        Assert.That(membersCount, Is.EqualTo(expectedMembersCount), "Validate the number of members");
    }

    [Test]
    [Category("UI")]
    [Author("Jorge Posterla")]
    public void VerifyLastRecordName()
    {
        // Test variables
        string expectedRecordName = "Luna Park 2019";
        //string expectedRecordName = "Tormenta eléctrica"; //The penultimate element

        // Test steps
        test.Log(Status.Info, "Step 1: Get the name of the last record");
        //string penultimateRecordName = Records.GetPenultimateRecordName().GetAwaiter().GetResult();
        string lastRecordName = Records.GetLastRecordName().GetAwaiter().GetResult();
        test.Log(Status.Info, "Assert: Compare expected result with obtained one");
        //Assert.That(penultimateRecordName, Is.EqualTo(expectedRecordName), "Validate the penultimate record name");
        Assert.That(lastRecordName, Is.EqualTo(expectedRecordName), "Validate the last record name");
    }

    [Test]
    [Category("UI")]
    [Author("Jorge Posterla")]
    public void GetAverageReviews()
    {
        // Test variables
        string entityType = "band_name";
        string entityName = "Rata_Blanca";
        double expectedAverageRating = 73.76;

        // Test steps
        test.Log(Status.Info, "Step 1: Search for " + entityName);
        var desambiguation = header.Search(entityType, entityName);
        var reviews = desambiguation.TransitionToReviews();
        test.Log(Status.Info, "Step 2: Get the average rating");
        double averageRating = reviews.CalculateAverageRating();
        Assert.That(averageRating, Is.EqualTo(expectedAverageRating), "Validate the average rating");
    }

}