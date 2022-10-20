namespace Translator
{

    /*Modules to use*/

    using System;
    using System.Text.RegularExpressions;

    public static class Translator
    {

        public static void Main()
        {

            /*Declaration of variables*/

            string? choice = null;
            string? input = null;
            string[] oct_Arr = { "000", "001", "010", "011", "100", "101", "110", "111" };
            string[] hex_Arr = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001",
                "1010", "1011", "1100", "1101", "1110", "1111" };
            string[]? characters;
            int count = 0;
            int answer;
            string answer2;
            List<string> end = new List<string>();
            string reg_Oct = @"^[0-1]+[0-1]+[0-1]$";
            Regex pattern_Oct = new Regex(reg_Oct);
            string reg_Hex = @"^[0-1]+[0-1]+[0-1]+[0-1]$";
            Regex pattern_Hex = new Regex(reg_Hex);

            /*Ask the user for an input of which mode he is wishing to use*/

            Console.WriteLine("Please enter the type of value you want to convert your binary into (Hex/Oct)");
            choice = Console.ReadLine();

            /*Depending on the choice, use case x*/

            switch (choice)
            {

                /*When Octal mode is chosen...*/

                case "Oct":

                    /*Asking for the binary input*/

                    Console.Write("\n");
                    Console.WriteLine("Please, enter your binary numbers (separated by a space)");
                    input = Console.ReadLine();
                    
                    /*Splitting the string in groups of 3*/

                    characters = input.Split(' ');

                    for(int i = 0; i < characters.Length; i++)
                    {
                        foreach (char c in characters[i])
                        {
                            count++;
                        }
                        if (count > 3 || count < 3)
                        {
                            Console.WriteLine("Invalid amount of binary values");
                            Environment.Exit(0x1);
                        }
                        else if (count == 3)
                        {

                            /*Check if the string only contains 0s and 1s*/

                            if (!pattern_Oct.IsMatch(characters[i]))
                            {
                                Console.WriteLine("Only 0 and 1 shall be used");
                                Environment.Exit(0x2);
                            }
                            count = 0;
                            for (int j = 0; j < oct_Arr.Length; j++)
                            {

                                /*For each group of 3 characters, translate them into their Octal equivalent*/

                                switch (characters[i])
                                {
                                    case var value when value == oct_Arr[j]:
                                        if (value == "0000")
                                        {
                                            answer = 0;
                                        }
                                        else
                                        {
                                            answer = Array.IndexOf(oct_Arr, value);
                                        }
                                        answer2 = answer.ToString();
                                        end.Add(answer2);
                                        break;
                                }
                            }
                        }
                    }

                    /*Print the results in the console as a string*/

                    var arr = end.ToArray();

                    Console.Write("\n");
                    Console.WriteLine($"Result for {input} in Octal:");
                    for (int k = 0; k < arr.Length; k++)
                    {
                        Console.Write(arr[k]);
                    }
                    Console.Write("\n");
                    break;

                /*When Hexadecimal mode is chosen...*/

                case "Hex":

                    /*Asking for the binary input*/

                    Console.Write("\n");
                    Console.WriteLine("Please, enter your binary numbers (separated by a space)");
                    input = Console.ReadLine();

                    /*Splitting the string in groups of 4*/

                    characters = input.Split(' ');

                    for (int i = 0; i < characters.Length; i++)
                    {
                        foreach (char c in characters[i])
                        {
                            count++;
                        }
                        if (count > 4 || count < 4)
                        {
                            Console.WriteLine("Invalid amount of binary values");
                            Environment.Exit(0x3);
                        }
                        else if (count == 4)
                        {
                            /*Check if the string only contains 0s and 1s*/

                            if (!pattern_Hex.IsMatch(characters[i]))
                            {
                                Console.WriteLine("Only 0 and 1 shall be used");
                                Environment.Exit(0x4);
                            }
                            count = 0;
                            for (int j = 0; j < hex_Arr.Length; j++)
                            {

                                /*For each group of 4 characters, translate them into their Hexadecimal equivalent*/

                                switch (characters[i])
                                {
                                    case var value when value == hex_Arr[j]:
                                        if (value == "0000")
                                        {
                                            answer = 0;
                                        }
                                        else
                                        {
                                            answer = Array.IndexOf(hex_Arr, value);
                                        }

                                        /*Check if the value is over 9. If so, switch them to their equivalent Hexadecimal letter*/

                                        switch (answer)
                                        {
                                            case 10:
                                                answer2 = "A";
                                                end.Add(answer2);
                                                break;

                                            case 11:
                                                answer2 = "B";
                                                end.Add(answer2);
                                                break;

                                            case 12:
                                                answer2 = "C";
                                                end.Add(answer2);
                                                break;

                                            case 13:
                                                answer2 = "D";
                                                end.Add(answer2);
                                                break;

                                            case 14:
                                                answer2 = "E";
                                                end.Add(answer2);
                                                break;

                                            case 15:
                                                answer2 = "F";
                                                end.Add(answer2);
                                                break;

                                            default:
                                                answer2 = answer.ToString();
                                                end.Add(answer2);
                                                break;
                                        }
                                        break;
                                }
                            }
                        }
                    }

                    /*Print the results in the console as a string*/

                    var arr2 = end.ToArray();

                    Console.Write("\n");
                    Console.WriteLine($"Result for {input} in Hexadecimal:");
                    for (int k2 = 0; k2 < arr2.Length; k2++)
                    {
                        Console.Write(arr2[k2]);
                    }
                    Console.Write("\n");
                    break;

                    /*If the chosen mode isn't a valid option...*/

                default:
                    Console.WriteLine("Invalid option");
                    Environment.Exit(0x5);
                    break;
            }
        }
    }
}
