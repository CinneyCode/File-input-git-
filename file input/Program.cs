using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //add this using directive for file input/output 

namespace file_input
{
    class Program
    {   //filename is Proj6Input.csv in debug folder dd
        static List<string> fullName = new List<string>();
        static List<decimal> salesAmt = new List<decimal>();

        static void Main(string[] args)
        {

            ReadFile();
            //wait for the user to hit a key 
            Console.WriteLine($"The number of salesperson from the  Input File = {fullName.Count}");

            Console.WriteLine("Is there any additional sales to report? Y/N");
            string moreSalesReport = Console.ReadLine();
            switch (moreSalesReport)
            {
                case "Y":
                    Console.WriteLine("Please enter the saleperson full name");
                    string name = Console.ReadLine();
                    int salesPersonIndex = -1;
                    for(int i=0; i< fullName.Count; i++)
                    {
                        if(name.ToLower() == fullName[i].ToLower())
                        {
                            salesPersonIndex = i;
                            break;
                        }
                    }
                    if(salesPersonIndex != -1) //0 equal to salesperson one 
                    {
                        Console.WriteLine("Sales Person Found, now please enter the sales amount to add");
                        int amount =Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The current sales amount for this person is = " + salesAmt[salesPersonIndex]);
                        salesAmt[salesPersonIndex] += amount;
                        Console.WriteLine("Added the new amount to existing amount, the new amount is  = " + salesAmt[salesPersonIndex]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid: SalesPerson not found");
                    }
                    break;
                case "N":
                    //string highestSalePerson = FindTopSalesPerson ( );
                    //Console.WriteLine($" The top ranked sales person is {highestSalePerson}: sales total is  ");
                    Console.WriteLine("Here's the top 3 ranked salesperon and the total amount of all sales: ");
                    
                    break;
            
            }

            string highestSalePerson = FindTopSalesPerson();
            decimal highestNumber = salesAmt.Max();
            Console.WriteLine($"  {highestSalePerson} with sales total of :{highestNumber:C2}  ");

            string secondHighestSalePerson = FindSecondTopSalesPerson();
            decimal secondAmt = FindSecondNumber();
            Console.WriteLine($" {secondHighestSalePerson} with sales total of: {secondAmt:C2} ");

            Console.WriteLine($"");

            Console.ReadKey();
        }
        static void ReadFile ()
        {
            String[] rows = File.ReadAllLines("Proj6Input.csv");
            for (int i=0; i < rows.Length; i++)
            {
                string[] cells = rows[i].Split(','); //not sting, it's a character . will get three cells back 
                string currName = cells[0] + "" + cells[1];
                fullName.Add(currName);
                salesAmt.Add(Convert.ToDecimal(cells[2]));
            }
        }
        static private string FindTopSalesPerson( )
        {
            decimal max = salesAmt.Max(); //you can't loop the string to find max , max function only works in int 
            string outputString = "The highest ranked saleperson is"; //so find the max value and match it with string 
            for (int i=0; i<salesAmt.Count; i++)
            {
                if (salesAmt [i] == max) //match the name of highest sale person in the arry 
                {
                    outputString += " " + fullName[i];
                }
            }

            return outputString; 
        }
        static private string FindSecondTopSalesPerson ( )
        {
            string outputString = "The second highest ranked saleperson is";
            int secondHighestSalePerson = salesAmt.IndexOf(FindSecondNumber());
            string matchedNameForSecondHighest = fullName[secondHighestSalePerson];
           
            return outputString += " " + matchedNameForSecondHighest;
        }

        static private decimal FindSecondNumber()
        {
            decimal first = decimal.MinValue;
            decimal second = decimal.MinValue;
           

            for (int i = 0; i < salesAmt.Count; i++)
            {
               
                if (salesAmt[i] > first )
                {
                    second = first;
                    first = salesAmt[i];
                }
                

            }
            return second;
        }

            
            


            
        




        //return method with top 3 salesperson condition with if method 




        //display method based on top 3 salesperson condidion "if" method 




        //caluclate total sales from all salesperon

    }
}
