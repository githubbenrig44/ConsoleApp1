using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// todo
// functions with multiple parameters separated by commas
// 



namespace ConsoleApp1
{
    public struct operator_struct // used for a list of operators that the expression evaluator is capable of handling i.e. used as a look up
    {
        public string operator_token, operator_associativity;
        public int operator_precedence;

        public operator_struct(string param_operator_token, string param_operator_associativity, int param_operator_precedence)
        {
            operator_token          = param_operator_token;
            operator_associativity  = param_operator_associativity;
            operator_precedence     = param_operator_precedence;

        }
    }

    public struct stack_struct // used to manage the stack that represents the operators/functions that are being processed by the expression evaluator
    {
        // "fields" in this struct(ure)
        public string stack_type, stack_token, stack_associativity;
        public int stack_precedence;

        // method by which values are assigned to this struct(ure)
        public stack_struct(string param_stack_type, string param_stack_token, string param_stack_associativity, int param_stack_precedence)
        {
            stack_type              = param_stack_type;
            stack_token             = param_stack_token;
            stack_associativity     = param_stack_associativity;
            stack_precedence        = param_stack_precedence;
        }
    }

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //operator_struct array_of_operator_struct;
            //array_of_operator_struct.operator_associativity = "left";
            //array_of_operator_struct.operator_precedence= 1;
            //array_of_operator_struct.operator_token = "/";

            List<operator_struct> list_of_operator_struct = new List<operator_struct>();
            list_of_operator_struct.Add(new operator_struct() { operator_token = "+", operator_associativity = "left", operator_precedence = 2 });
            list_of_operator_struct.Add(new operator_struct() { operator_token = "-", operator_associativity = "left", operator_precedence = 2 });
            list_of_operator_struct.Add(new operator_struct() { operator_token = "/" , operator_associativity = "left", operator_precedence = 3  });
            list_of_operator_struct.Add(new operator_struct() { operator_token = "*", operator_associativity = "left", operator_precedence = 3 });
            list_of_operator_struct.Add(new operator_struct() { operator_token = "^", operator_associativity = "RIGHT", operator_precedence = 4 });

            // WRITE THEM ALL OUT
            Console.WriteLine();
            foreach (operator_struct local_operator_struct in list_of_operator_struct)
            {
                Console.WriteLine(local_operator_struct.operator_token);
                Console.WriteLine(local_operator_struct.operator_associativity);
                Console.WriteLine(local_operator_struct.operator_precedence);
            }


            Console.WriteLine();
            ////list_of_operator_struct.Contains(new operator_struct { operator_token = "/" });
            //System.Console.WriteLine("Contains=" + list_of_operator_struct.Contains(new operator_struct { operator_token = "/", operator_associativity= "left", operator_precedence =1 }));
            ////System.Console.WriteLine("Find= {0}" + list_of_operator_struct.Find(local_var => local_var.operator_token.Contains("/")).operator_token  ) ;
            //System.Console.WriteLine("IndexOf=" + list_of_operator_struct.IndexOf(new operator_struct { operator_token = "/"}) );

            // TESTING -  FIND THE OPERATOR AND OUTPUT ALL ITS ATTRIBUTES USING "FirstOrDefault" METHOD OF "LISTS"
            operator_struct local_found_operator_struct;
            local_found_operator_struct = list_of_operator_struct.FirstOrDefault(local_var => local_var.operator_token == "/"); // returns zero if not found
            System.Console.WriteLine("local_found_operator_struct= " + local_found_operator_struct.operator_token + local_found_operator_struct.operator_precedence + local_found_operator_struct.operator_associativity);

            if (local_found_operator_struct.operator_token == null )
            {
                System.Console.WriteLine("its null");
            }
            else
            {
                System.Console.WriteLine("not NULL");
            }


            // FINDINDEX is another way to find entries in a list. its finds the position (zero start)
            //int var_index = list_of_operator_struct.FindIndex(local_var => local_var.operator_token == "/");
            //System.Console.WriteLine("var_index=" + var_index);

            String input_expression = "3+4*2/(1-5)^2^3";
            int input_length = input_expression.Length;

            System.Console.WriteLine("input_expression=" + input_expression);
            System.Console.WriteLine("input_length=" + input_length);
            

            string current_token = "";
            string output_tokens = "";
            string token_type = "";

            var operators_list = new List<string>() { "+", "/", "*", "-", "^" };


            // instantiate a new instance of Stack using type=stack_struct ("stack_struct" is a custom "type" declared earlier)
            Stack<stack_struct> operator_stack = new Stack<stack_struct>();
            stack_struct popped_struct; // local "variable" which will contain the "record" popped off the stack. its ".fields" will match "stack_struct" type earlier)

            // TESTING - PUSH something onto stack and then pop it off again to make sure its all working
            operator_stack.Push(new stack_struct { stack_type ="operator", stack_token = "/", stack_associativity = "left", stack_precedence = 4 });

            // testing POP
            popped_struct = operator_stack.Pop();
            Console.WriteLine("popped_struct.stack_type="           + popped_struct.stack_type);
            Console.WriteLine("popped_struct.stack_token="          + popped_struct.stack_token);
            Console.WriteLine("popped_struct.stack_associativity="  + popped_struct.stack_associativity);
            Console.WriteLine("popped_struct.stack_precedence="     + popped_struct.stack_precedence);

            for (int token_pos = 1; token_pos <= input_length; token_pos++ )
            {
                current_token = input_expression.Substring(token_pos-1, 1);

                System.Console.WriteLine("token_pos     = " + token_pos);
                System.Console.WriteLine("current_token = " + current_token);

                // detect number
                if ( Char.IsNumber(current_token, 0) ) 
                {
                    token_type = "number";
                }

                // detect function
                if (current_token == "F")
                {
                    token_type = "function";
                }
                // detect operator
                if (operators_list.Contains(current_token) ) // || is OR in C#
                {
                    token_type = "operator";
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

                //    case "operator":
                //        Console.WriteLine("handle operator");
                //        // todo
                //        while ()
                //        {
                //            if (operator_type_stack.Peek() == "function")
                //            {



                //            }
                //            //operator_value_stack.Push(current_token);


                //        }

                //        break;

                    case "function":
                        Console.WriteLine("handle function");
                //        operator_type_stack.Push(token_type);
                //        operator_value_stack.Push(current_token);

                //        break;

                //    case "left_bracket":
                //        operator_type_stack.Push(token_type);
                //        operator_value_stack.Push(current_token);
                //        break;

                //    case "right_bracket":
                //        while (operator_type_stack.Peek() != "left_bracket") // TODO-DEAL WITH INFINTE LOOP
                //        {
                //            operator_type_stack.Pop(); // doing nothing with this
                            
                //            output_tokens = output_tokens + operator_value_stack.Pop(); // 

                //        }

                //        break;
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
