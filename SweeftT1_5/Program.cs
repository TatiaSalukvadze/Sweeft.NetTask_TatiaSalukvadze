//1
Console.WriteLine("'maD am' is palindrom? " + sPalindrome("maD am"));
//2
Console.WriteLine("min number of coins needed for 123 tetri: " + MinSplit(123));
//3
int[] ar = { -3, 0, 1, 2, 4 };
Console.WriteLine("min positive number not contained in { -3, 0, 1, 2, 4 }: " + NotContains(ar));

//4
string test4true = "(()()(()))";
string test4false = "(()()))()";
Console.WriteLine("'(()()(()))' is properly written?: " + IsProperly(test4true));
Console.WriteLine("'(()()))()' is properly written?: " + IsProperly(test4false));
//5
Console.WriteLine("variants to reach step 7: " + CountVariants(7));

Console.ReadLine();

//1
static bool sPalindrome(string text)
{
    if (string.IsNullOrEmpty(text))//if null or empty
        return true;
    string newText = text.Replace(" ", "").ToLower();//remove spaces and make to lower case
    int strLen = newText.Length;
    for (int i = 0; i < strLen / 2; i++)//check first half of string, if it equals second part
    {
        if (newText[i] != newText[strLen - i - 1])
            return false;
    }
    return true;
}
//2
static int MinSplit(int amount)
{
    if (amount <= 0)
        return 0;
    int result = 0;
    //array of coins- tetri, start with largest values
    int[] coins = { 50, 20, 10, 5, 1 };
    //subtract largest values first and gradually continue with smaller values
    foreach (int coin in coins)
    {
        //find how many coin fits in amount
        result += amount / coin;
        //find what's left after subtracting coin value possible number of times 
        amount %= coin;

    }
    return result;
}
//3
static int NotContains(int[] array)
{
    int result = 1;
    array = array.Where(n => n > 0).ToArray();//get only positive values
    Array.Sort(array);//sort it
    int len = array.Length;
    for (int i = 0; i < len; i++)
    {
        if (array[i] > result)//so we found the result( starts by chechink for: array[0] > 1)
            break;
        else if (array[i] == result)//if equal increment(if consecutive numbers- incrementing continues)
            result += 1;

    }
    return result;
}
//4
static bool IsProperly(string sequence)
{
    //using stack, every time we encounter with "(" add new item to stack,
    //and while encountering with ")" call pop() method
    Stack<char> stack = new Stack<char>();
    foreach (char c in sequence)
    {
        if (c == '(')
            stack.Push('(');
        else if (c == ')')
        {
            if (stack.Count == 0)//if closing ")" and nothing to pop, it means there is extra ")" parenthesis
                return false;
            stack.Pop();
        }
    }
    if (stack.Count != 0)//if still notempty, it means there is extra opening "(" parenthesis
        return false;
    return true;
}
//5
//5
static int CountVariants(int stairCount)
{
    if (stairCount <= 1) return 1;
    int[] ar = new int[stairCount + 1];
    //base cases (1 way to rach stair 0, 1 way to reach stair 1)
    ar[0] = 1;
    ar[1] = 1;
    //for upper stairs, we can reach it by prev stair(1 step case) or by stair 2 stairs below( 2step case)
    //so we can sum the number of ways we cound reach previos stair and
    //number of ways we can reach stair 2 stairs below

    for (int i = 2; i <= stairCount; i++)
    {
        ar[i] = ar[i - 1] + ar[i - 2];
    }
    return ar[stairCount];
    //recursive method case 
    //   if( stairCount == 0 || stairCount == 1)
    //     return 1;
    //return CountVariants(stairCount-1) + CountVariants(stairCount-2);
}

