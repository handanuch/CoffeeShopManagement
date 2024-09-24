namespace CoffeeShop.Utils.Helpers;

public static class RPTHelper
{
    public static (string, string, string) GetRptType(string? rptType)
    {
        switch (rptType)
        {
            case "html":
                return ("HTML5", "text/html", "html");
            case "docx":
                return ("WORDOPENXML", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx");
            case "xlsx":
                return ("EXCELOPENXML", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx");
            default:
                return ("PDF", "application/pdf", "pdf");
        }
    }
}