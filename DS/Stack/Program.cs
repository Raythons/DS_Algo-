// See https://aka.ms/new-console-template for more information




using System.Text;
using System;







// PostFix 


static short Precidence(char op)
{
    if (op == '+' || op == '-')
        return 1;
    if (op == '*' || op == '/')
        return 2;
    return 0;
}

static string InfixToPostFix(string Infix)
{
    var Operators = new Stack<char>();
    string PostFix = "";

    for (int i = 0; i < Infix.Length; i++)
    {
        if (char.IsDigit(Infix[i]))
            PostFix += Infix[i];
        else
        {
            while (Operators.Count != 0 &&
                    Precidence(Operators.Peek()) >= Precidence(Infix[i])
                )
                PostFix += Operators.Pop();
            Operators.Push(Infix[i]);
        }
    }

}






string str = "accxggxas";
str = Remove_Dublicate(str);

Console.WriteLine(str);


// LeetCode
static string Remove_Dublicate(string str)
{

    var Characters = new Stack<char>();
    char LastInserted = ' ';

    for (int i = 0; i < str.Length; i++)
    {
        char ch = str[i];
        if (Characters.Count != 0 && Characters.Peek() == ch)
        {
            Characters.Pop();
        }
        else
            Characters.Push(ch);
    }
    string NewStr = "";
    while (Characters.Count != 0)
    {
        NewStr += Characters.Pop();
    }
    return NewStr;
}


// string exp = "{}}";

// bool IsValidExp = isValidParens(exp);

// Console.WriteLine(IsValidExp.ToString());

static bool IsLeftParen(char paran)
{
    if (paran == '[' || paran == '{' || paran == '(')
        return true;
    return false;
}
static char GetOpenParen(char ch)
{
    if (ch == ']')
        return '[';
    if (ch == '}')
        return '{';
    if (ch == '(')
        return ')';
    return 'n';
}
// LeetCode Problem  20
static bool isValidParens(string str)
{
    Stack<char> Parentheses = new Stack<char>();
    for (int i = 0; i < str.Length; i++)
    {
        char ch = str[i];
        if (IsLeftParen(ch))
            Parentheses.Push(ch);
        else if (Parentheses.Count == 0 || Parentheses.Pop() != GetOpenParen(ch))
            return true;
    }
    return Parentheses.Count == 0;
}






// int reversed = Reverse_Int(1234);

// Console.WriteLine(reversed);

// static int Reverse_Int(int number)
// {
//     Stack<int> st = new Stack<int>();
//     int Reversed = 0;
//     while (number > 0)
//     {
//         int digit = number % 10;
//         number /= 10;
//         st.Push(digit);
//     }
//     int tens = 1;
//     while (st.Count != 0)
//     {
//         Reversed += st.Pop() * tens;
//         tens *= 10;
//     }
//     return Reversed;
// }



// string s = "Hello Mother Fucker";
// Console.WriteLine("Hello Mother Fucker");
// string gg = Reverse_String(ref s);

// Console.WriteLine(gg);

// PS Here
static string Reverse_String(ref string Str)
{
    Stack<char> st = new Stack<char>();
    string Reversed = "";
    for (int i = 0; i < Str.Length - 1; i++)
    {
        if (Str[i] == ' ')
        {
            while (st.Count != 0)
            {
                Reversed += st.Pop();
            }
            Reversed += ' ';
        }
        st.Push(Str[i]);
    }
    return Reversed;
}
