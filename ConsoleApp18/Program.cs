using ConsoleAppTest18;
using System;
using System.Threading.Tasks;


class Program
{
    static async Task Main()
    {
        Console.WriteLine("Welcome to the OTP sending system");

        // Generate a random 6-digit OTP
        Random random = new();
        int OTPNumber = random.Next(100000, 999999);
        //Console.WriteLine($"Your OTP (for testing) is: {OTPNumber}");

        // Create EmailSystem object
        EmailSystem email = new(
            host: "smtp.gmail.com",
            port: 587,
            user: "snilesh2797@gmail.com",      // <-- put your Gmail address here
            pass: "hoexwdkojlfybbwp",         // <-- use Gmail App Password (not normal password)
            ssl: true
        );

        // Send OTP email
        bool flag = await email.SendEmailAsync(
            toEmail: "snilesh2797@gmail.com",
            subject: "Your OTP Email",
            body: $@"
<html>
  <body style='font-family: Arial, sans-serif; background-color: #f6f8fa; padding: 30px;'>
    <div style='max-width: 500px; margin: auto; background: #ffffff; border-radius: 10px; padding: 25px; box-shadow: 0 2px 6px rgba(0,0,0,0.1);'>
      <h2 style='color: #333; text-align: center;'>🔐 Email Verification OTP</h2>
      <p style='font-size: 16px; color: #555;'>
        Dear User,<br><br>
        Thank you for verifying your email with <b>UpGrad</b>.<br>
        Please use the following OTP to complete your verification process:
      </p>

      <div style='text-align: center; margin: 30px 0;'>
        <span style='font-size: 32px; font-weight: bold; color: #2b6cb0;'>{OTPNumber}</span>
      </div>

      <p style='font-size: 15px; color: #777;'>
        This OTP is valid for <b>10 minutes</b>. Please do not share it with anyone.
      </p>

      <hr style='border:none; border-top:1px solid #eee; margin: 20px 0;'>

      <p style='font-size: 14px; color: #999; text-align: center;'>
        Regards,<br>
        <b>Team UpGrad Support</b><br>
        <a href='https://www.upgrad.com' style='color:#2b6cb0; text-decoration:none;'>www.upgrad.com</a>
      </p>
    </div>
  </body>
</html>"

        );

        Console.WriteLine(flag ? "✅ Email sent successfully!" : "❌ Email not sent");

        // Ask user to enter the OTP
        Console.WriteLine("Please enter your OTP:");
        int userOTP = Convert.ToInt32(Console.ReadLine());

        // Validate OTP
        if (userOTP == OTPNumber)
        {
            Console.WriteLine("✅ OTP is correct");
        }
        else
        {
            Console.WriteLine("❌ OTP is incorrect");
        }
    }
}
