using System.Net.Http;
using System.Net.Mail;
using System.Net;

try
{
    DriveInfo[] allDrives = DriveInfo.GetDrives();

    List<string> drivesfull = new List<string>();

    foreach (DriveInfo d in allDrives)
    {
        if (d.IsReady) // To check if the drive is mounted or ready
        {
            // Calculate the percentage of used space
            double usedSpace = d.TotalSize - d.TotalFreeSpace;
            double percentageFull = (usedSpace / d.TotalSize) * 100;

            if (percentageFull >= 90)
            {
                string driveName = d.Name.TrimEnd(':', '\\');
                drivesfull.Add(driveName);
            }
        }
    }

    string text = "";

    if (drivesfull.Count == 1)
    {
        text = drivesfull[0] + " drive is 90% full";
        SendMail(text);
    }
    else if (drivesfull.Count > 1)
    {
        string drives = string.Join(", ", drivesfull.Take(drivesfull.Count - 1)) + " & " + drivesfull.Last();

        text = drives + " drives are 90% full";
        SendMail(text);
    }
    else
    {
        Console.WriteLine("Drives are in good state!!!");
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


static void SendMail(string mailtemplate)
{
    string filePath = "Template.html"; 
    string content = File.ReadAllText(filePath);
    content = content.Replace("Your drive is 90% full", mailtemplate);

    string smtpHost = "smtp.test.com"; // Replace with your SMTP server
    int smtpPort = 587; // Typically 587 for TLS or 465 for SSL, consult your email service documentation
    string fromAddress = "test@test.co.in"; // Replace with your "from" email address
    string password = "Password"; // Replace with your email password

    // Create a new SMTP client and set up the server details
    using (SmtpClient smtp = new SmtpClient(smtpHost, smtpPort))
    {
        smtp.Credentials = new NetworkCredential(fromAddress, password);
        smtp.EnableSsl = false; // Set to false if your server doesn't use SSL

        // Create a new mail message
        using (MailMessage message = new MailMessage())
        {
            message.From = new MailAddress("devops@test.co.in");
            message.To.Add("harrypotter@gmail.com");
            message.CC.Add("peter@gmail.com");
            message.Subject = "Warning - Flipkar Drive Storage Full";
            message.Body = content;
            message.IsBodyHtml = true; // Indicate the body contains HTML content

            // Send the message
            smtp.Send(message);
            //Console.WriteLine("Mail Sent");
        }
    }

    //Console.WriteLine(content);

}
