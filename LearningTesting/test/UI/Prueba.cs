var driver = new ChromeDriver();

driver.Navigate().GoToUrl("https://www.metal-archives.com/bands/Rata_Blanka/2125");

var currentLineup = driver.FindElement(By.Id("band_tab_members_all"));

var memberList = currentLineup.FindElements(By.ClassName("lineupRow"));

int currentMembersCount = 0;

foreach (var member in memberList)
{
    var memberStatus = member.FindElements(By.TagName("td"))[1].Text;
    if (memberStatus.Contains("Current"))
    {
        currentMembersCount++;
    }
}

Console.WriteLine($"Número de miembros en la sección 'Current lineup': {currentMembersCount}");

driver.Quit();
