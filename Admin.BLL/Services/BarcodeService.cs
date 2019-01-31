using HtmlAgilityPack;

namespace Admin.BLL.Services
{
    public class BarcodeService
    {
        public void Get(string barcode)
        {
            var url = $"http://www.barkodid.com/{barcode}";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var list = doc.GetElementbyId("");
        }
    }
}
