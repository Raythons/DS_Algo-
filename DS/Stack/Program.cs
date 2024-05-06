// See https://aka.ms/new-console-template for more information

using MyStacko;


const int LEN1 = 8;

int[] v1 = new int[] { 73, 74, 788, 71, 69, 72, 76, 73 };

NextGreaterNum(v1, LEN1);
// leetCode
void NextGreaterNum(int[] v, int len)
{
    Stack<int> pos = new(len);

    //  73, 74, 788, 71, 69, 72, 76, 73
    for (int i = 0; i < len; i++)
    {
        while (pos.Count != 0 && v[i] > v[pos.Peek()])
        {
            var index = pos.Peek();
            v[pos.Pop()] = v[i];
        }
        pos.Push(i);
    }

    while (pos.Count != 0)
        v[pos.Pop()] = -1;

    for (int i = 0; i < (int)len; ++i)
        Console.WriteLine($"elemnt  number ${i} is ${v[i]} ");
}


// leetCode Score Of Parentheses
// to do

int ParenthesesScore(string s)
{
    Stack<int> StackScore = new(s.Length);

    StackScore.Push(0);

    for (int i = 0; i < s.Length; i++)
    {
        char c = s[i];
        if (s[i] == '(')
            StackScore.Push(0);
        else
        {
            //(()(()))
            //  LAST = 1 
            int last = StackScore.Pop();

            if (last == 0)
                last = 1;
            else
                last *= 2;


            int ParentPar =  StackScore.Peek() + last;
            StackScore.Pop();
            StackScore.Push(ParentPar);
        }

    }
    return StackScore.Peek() ;
}


// P2 Medium To Hard 

MyStack myStack = new MyStack(5);
myStack.Push(1);
myStack.Push(2);
myStack.Push(3);
myStack.Push(4);

// myStack.reverse();

// myStack.display();



//
int[] Asteroids = new int[] { -2, -2, 1, -2 };
// Asteroid Collision 


var AsteroidList = AsteroidCollision(Asteroids);

for (int i = 0; i < AsteroidList.Length ; i++)
{
    Console.WriteLine(AsteroidList[i]);

}

bool WillCollision(int el1, int el2)
{
    if (el1 < 0 && 0 <= el2 )
        return true;
    return false;
}


int[] CopyArrayFromStack(Stack<int> stack)
{
    if (stack.Count == 0)
    {
        return Array.Empty<int>();
    }

    int[] arr = new int[stack.Count];

    for (int i = arr.Length - 1; i > 0; i--)   
        arr[i] = stack.Pop();
    
    return arr;

}


int[] AsteroidsCollision(int[] asteroids)
{
    Stack<int> AsteroidsStk = new();

    
    for (int i = 0; i < asteroids.Length; i++)
    {
        int asteroid = asteroids[i];

        bool is_exploded = false;
        while (AsteroidsStk.Count != 0 && WillCollision(asteroid, AsteroidsStk.Peek()))
        {
            if(AsteroidsStk.Peek() < -asteroid)
            {
                AsteroidsStk.Pop();
                continue;
            } 
            else if (AsteroidsStk.Peek() == -asteroid)        
                AsteroidsStk.Pop();

            is_exploded = true;
            break;           
        }
        if(!is_exploded)
            AsteroidsStk.Push(asteroid);
    }
   
    asteroids = CopyArrayFromStack(AsteroidsStk);
    
    return asteroids;
}

int[] AsteroidCollision(int[] asteroids)
{
    Stack<int> AsteroidsStk = new();

    int element;
    for (int i = 0; i < asteroids.Length; i++)
    {
        element = asteroids[i];
        if (AsteroidsStk.Count != 0 && WillCollision(element, AsteroidsStk.Peek()))
        {
            bool IsExploded = false;
            while (AsteroidsStk.Count != 0 && AsteroidsStk.Peek() <= -element)
            {
                if(AsteroidsStk.Peek() == -element)
                {
                    IsExploded = true;
                    AsteroidsStk.Pop();
                    break;
                }
                AsteroidsStk.Pop();                               
            }
            if (IsExploded == false)
                AsteroidsStk.Push(element);
        }
        else
            AsteroidsStk.Push(element);
    }
    if (AsteroidsStk.Count == 0)
        return new int[0]; 

    asteroids = new int[AsteroidsStk.Count];
 
    for (int i = asteroids.Length - 1;   i > 0; i--)
    {
        asteroids[i] = AsteroidsStk.Pop();
    }

    return asteroids;
}


// PostFix 
string PostFix = "7^8^9+12*3+2-2";
// Console.WriteLine(InfixToPostFix(PostFix));


static short Precidence(char op)
{
    if (op == '+' || op == '-')
        return 1;
    if (op == '*' || op == '/')
        return 2;
    if (op == '^')
        return 3;

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
        else if (Infix[i] == '(')
            Operators.Push(Infix[i]);
        else if (Infix[i] == ')')
        {
            while (Operators.Peek() != '(')
                PostFix += Operators.Pop();
        }
        else
        {
            while (Operators.Count != 0 &&
                    Precidence(Operators.Peek()) >= Precidence(Infix[i])
                )
            {
                if (Precidence(Infix[i]) == 3 && Precidence(Operators.Peek()) == 3)
                    break;
                PostFix += Operators.Pop();
            }
            Operators.Push(Infix[i]);
        }
    }
    while (Operators.Count != 0)
    {
        PostFix += Operators.Pop();
    }
    return PostFix;

}






string str = "abbaca";
str = Remove_Dublicate(str);

Console.WriteLine(str);


// LeetCode
static string Remove_Dublicate(string str)
{
    var Characters = new Stack<char>();
    // acaca
    for (int i = 0; i < str.Length; i++)
    {
        char ch = str[i];
        if (Characters.Count != 0 && Characters.Peek() == ch)       
            Characters.Pop();      
        else
            Characters.Push(ch);
    }

    string NewStr = "";
    while (Characters.Count != 0)
    {
        NewStr  = Characters.Pop() + NewStr;
    }
    return NewStr;
}


 string exp = "()";

bool IsValidExp = isValidParens(exp);

Console.WriteLine(IsValidExp.ToString());

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
    if (ch == ')')
        return '(';
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
            return false;
    }
    return Parentheses.Count == 0;
}

Console.ReadLine();

int reversed = Reverse_Int(1234);

Console.WriteLine(reversed);
static int Reverse_Int(int number)
{
    Stack<int> st = new Stack<int>();
    int Reversed = 0;
    while (number > 0)
    {
        int digit = number % 10;
        number /= 10;
        st.Push(digit);
    }
    int tens = 1;
    while (st.Count != 0)
    {
        Reversed += st.Pop() * tens;
        tens *= 10;
    }
    return Reversed;
}



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
                Reversed += st.Pop();
            Reversed += ' ';
        } 
        else
            st.Push(Str[i]);
    }
    return Reversed;
}
