using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to SG Corp Bank");
                Console.WriteLine("====================================");
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. Delete Account");
                Console.WriteLine("3. Lookup Account");
                Console.WriteLine("4. Reports");
                Console.WriteLine("\n(Q) to Quit");

                string input = UserPrompts.GetStringFromUser("\nEnter Choice: ");

                if (input.Substring(0, 1).ToUpper() == "Q")
                    break;

                ProcessChoice(input);

            } while (true);
        }
                                            
        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    CreateWorkflow  createWorkflow= new CreateWorkflow();
                    createWorkflow.Execute();
                    break;
                case "2":
                    DeleteWorkflow deleteWorkflow = new DeleteWorkflow();
                    deleteWorkflow.Execute();
                    break;
                case "3":
                    var lookupWorkflow = new LookupWorkflow();
                    lookupWorkflow.Execute();
                    break;
                case "4":
                    var reportWorkflow = new ReportWorkFlow();
                    reportWorkflow.Execute();
                    break;
            }
        }
    }
}
