namespace Codebella.WebUI.Models;

public class HeaderPartialModel
{
    private string? title;
    public string? Title
    {
        get { return title; }
        set
        {
            if (title != null && title.Length > 20)
            {
                throw new Exception("Karakter sayısı 20'den fazla olamaz.");
            }
            else
            {
                title = value;
            }
        }
    }

    public string? SubHeader { get; set; }
    public string? BgUrl { get; set; }
}