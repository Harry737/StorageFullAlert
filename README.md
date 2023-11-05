# Drive Capacity Checker and Email Notifier

This solution checks for drive capacity, and if it's greater than 90%, it sends an email notification to the specified recipients.

## Configuration

Before running the application, make sure to configure the following parameters in your code:

```csharp
string smtpHost = "smtp.test.com"; // Replace with your SMTP server
int smtpPort = 587; // Typically 587 for TLS or 465 for SSL, consult your email service documentation
string fromAddress = "test@test.co.in"; // Replace with your "from" email address
string password = "Password"; // Replace with your email password

message.From = new MailAddress("devops@test.co.in");
message.To.Add("harrypotter@gmail.com"); // Replace with recipient email addresses
message.CC.Add("peter@gmail.com"); // Add additional CC email addresses if needed

## Running the Application

1. Clone this repository or download the source code.

2. Configure the SMTP server details and recipient email addresses as mentioned above.

3. Build the application using your preferred development environment.

4. Publish the application in self-contained mode based on your system architecture. You can use tools like Visual Studio, Visual Studio Code, or the .NET CLI for this purpose.

5. Run the executable (.exe or the file based on your system) to check drive capacity and send email notifications if necessary.

## License

This project is licensed under the MIT License.
