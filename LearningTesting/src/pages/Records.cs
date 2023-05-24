using HtmlAgilityPack;

namespace LearningTesting.src.pages
{
    internal class Records
    {
        public static async Task<string> GetLastRecordName()
        {
            using var httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync("https://www.metal-archives.com/band/discography/id/1931/tab/all");

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var tableBody = htmlDoc.DocumentNode.SelectSingleNode("//table[@class='display discog']/tbody");

            var lastRow = tableBody.SelectNodes("tr").Last();

            var releaseName = lastRow.SelectSingleNode("td[1]/a").InnerText;

            return releaseName;
        }
        // Just to test how to get the penultimate element
        //public static async Task<string> GetPenultimateRecordName()
        //{
        //    using var httpClient = new HttpClient();
        //    string response = await httpClient.GetStringAsync("https://www.metal-archives.com/band/discography/id/1931/tab/all");

        //    var htmlDoc = new HtmlDocument();
        //    htmlDoc.LoadHtml(response);

        //    var tableBody = htmlDoc.DocumentNode.SelectSingleNode("//table[@class='display discog']/tbody");

        //    var rows = tableBody.SelectNodes("tr");
        //    var penultimateRow = rows[rows.Count - 2]; // Get the penultimate element

        //    var releaseName = penultimateRow.SelectSingleNode("td[1]/a").InnerText;

        //    return releaseName;
        //}


    }
}
