using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            //System.Console.WriteLine("hello");
            
            String input_expression = "3+4*2/(1-5)^2^3";
            int input_length = input_expression.Length;

            System.Console.WriteLine("input_expression=" + input_expression);
            System.Console.WriteLine("input_length=" + input_length);
            

            string current_token = "";
            string output_tokens = "";
            string token_type = "";

            var operators_list = new List<string>() { "+", "/", "*", "-", "^" };

            // TODO - NEED TO KNOW ASSOCIATIVE AND PRECEDENCE OF OPERATOR. SOME SORT OF LOOK UP TABLE?

            Stack<string> operator_type_stack = new Stack<string>();
            Stack<string> operator_value_stack = new Stack<string>();
            // how to operator_stack.Push("one"); how to operator_stack.Pop()
            //operator_type_stack.Push("two");
            //operator_type_stack.Pop());

            for (int token_pos = 1; token_pos <= input_length; token_pos++ )
            {
                current_token = input_expression.Substring(token_pos-1, 1);

                System.Console.WriteLine("token_pos=" + token_pos);
                System.Console.WriteLine("current_token=" + current_token);

                // if token is a number then push it to the output queue (or a variable, etc)
                if ( Char.IsNumber(current_token, 0) ) 
                        {
                    token_type = "number";
                    //output_tokens = output_tokens + current_token;
                    }

                // detect function
                if (current_token == "F")
                {
                    token_type = "function";

                    //output_tokens = output_tokens + current_token;
                }
                // detect operator
                if (operators_list.Contains(current_token) ) // || is OR in C#
                {
                    token_type = "operator";
                    //output_tokens = output_tokens + current_token;
                }

                if (current_token == "(" )
                {

                    token_type = "left_bracket";

                }
                if (current_token == ")")
                {

                    token_type = "right_bracket";

                }

                if (current_token == "F")
                {

                    token_type = "function";

                }


                switch (token_type)

                {
                    case "number":
                        Console.WriteLine("handle number");
                        output_tokens = output_tokens + current_token;

                        break;

                    case "operator":
                        Console.WriteLine("handle operator");
                        // todo
                        break;

                    case "function":
                        Console.WriteLine("handle function");
                        operator_type_stack.Push(token_type);
                        operator_value_stack.Push(current_token);

                        break;

                    case "left_bracket":
                        operator_type_stack.Push(token_type);
                        operator_value_stack.Push(current_token);
                        break;

                    case "right_bracket":
                        while (operator_type_stack.Peek() != "left_bracket") // TODO-DEAL WITH INFINTE LOOP
                        {
                            operator_type_stack.Pop(); // doing nothing with this
                            
                            output_tokens = output_tokens + operator_value_stack.Pop(); // 

                        }

                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;




                } // end switch

                //String str = "non-numeric";
                //System.Console.WriteLine(Char.IsNumber('8')); // Output: "True"
                System.Console.WriteLine(Char.IsNumber(current_token,0)); // position zero! (is first position)
                System.Console.WriteLine("token_type=" + token_type);
                System.Console.WriteLine("");

                //System.Console.WriteLine(Char.IsNumber(current_token, 3)); // 
                //output_tokens


                // if token is a function then push it to the operator stack

                // if token is a operator then
                // while


                // end 

            } // end for


            Console.ReadLine();

        }
    }
}
