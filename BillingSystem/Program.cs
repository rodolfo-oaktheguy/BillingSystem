namespace BillingSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            string appTitle = "Billing System - Member B";
            Console.WriteLine(appTitle);
            Application.Run(new LoginForm());
        }
    }
}