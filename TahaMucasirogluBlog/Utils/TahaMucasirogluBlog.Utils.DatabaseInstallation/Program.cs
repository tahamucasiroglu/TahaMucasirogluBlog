using System.Diagnostics;

internal class Program
{
 

    private static async Task Main(string[] args)
    {
        string projectMainDir = Directory.GetCurrentDirectory();
        projectMainDir = projectMainDir.Substring(0, projectMainDir.LastIndexOf("\\TahaMucasirogluBlog\\") + "\\TahaMucasirogluBlog\\".Length);

        Delay();
        await DbMigrations(projectMainDir);
        Delay();
        await DbUpdate(projectMainDir);

    }


    static void Delay(int delayTime = 3)
    {
        for (int i = delayTime; i >= 1; i--)
        {
            Console.WriteLine($"{i}...");
            Thread.Sleep(1000); // 1 saniye bekle
        }
    }



    static async Task DbMigrations(string projectMainDir)
    {
        
        Console.WriteLine("Db Migrations Başlıyor");
        DateTime date = DateTime.Now;
        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = "powershell";
        processStartInfo.Arguments = $"dotnet ef migrations add AutoMig_{date.Year}_{date.Month}_{date.Day}_{date.Hour}_{date.Minute}_{date.Second} --context TahaMucasirogluBlogContext --project Infrastructure\\TahaMucasirogluBlog.Infrastructure.Repository\\TahaMucasirogluBlog.Infrastructure.Repository.csproj --startup-project Presentation\\TahaMucasirogluBlog.Presentation.API\\TahaMucasirogluBlog.Presentation.API.csproj --output-dir Migrations";
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = false;
        processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
        processStartInfo.WorkingDirectory = projectMainDir;
        processStartInfo.RedirectStandardInput = false;
        processStartInfo.RedirectStandardOutput = false;
        using (Process process = new Process())
        {
            process.StartInfo = processStartInfo;
            process.Start();
            await process.WaitForExitAsync();
        }
        Console.WriteLine("Db Migrations Bitti");
    }


    static async Task DbUpdate(string projectMainDir)
    {
        Console.WriteLine("Db Update Başlıyor");
        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = "powershell";
        processStartInfo.Arguments = $"dotnet ef database update --context TahaMucasirogluBlogContext --project Infrastructure/TahaMucasirogluBlog.Infrastructure.Repository/TahaMucasirogluBlog.Infrastructure.Repository.csproj --startup-project Presentation/TahaMucasirogluBlog.Presentation.API/TahaMucasirogluBlog.Presentation.API.csproj";
        processStartInfo.UseShellExecute = false;
        processStartInfo.CreateNoWindow = false;
        processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
        processStartInfo.WorkingDirectory = projectMainDir;
        processStartInfo.RedirectStandardInput = false;
        processStartInfo.RedirectStandardOutput = false;
        using (Process process = new Process())
        {
            process.StartInfo = processStartInfo;
            process.Start();
            await process.WaitForExitAsync();
        }
        Console.WriteLine("Db Update Bitti");
    }


















}