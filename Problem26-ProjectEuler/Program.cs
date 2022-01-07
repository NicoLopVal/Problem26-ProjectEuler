using System.Numerics;

BigInteger tenDivisor = 10;
for(int i = 1; i <= 2000; i++)
{
    tenDivisor = tenDivisor * 10;
}

double divisionCheck;

List<string> numbers = new List<string>();
numbers.Add("Zero");
numbers.Add("One");

for (double i = 2; i <= 1000; i++)
{
    divisionCheck = 1 / i;
    string numberCheck = divisionCheck.ToString().Substring(2);
    string stringNum;

    stringNum = BigInteger.Divide(tenDivisor, (BigInteger)i).ToString();

    foreach(char number in numberCheck)
    {
        if (number == '0')
            stringNum = "0" + stringNum;
    }
    numbers.Add(stringNum);
}

double longestPattern = 0;
int maxIndex = 0;
int index = 0;
foreach(string number in numbers)
{
    if(LongestPattern(number) > longestPattern)
    {
        longestPattern = LongestPattern(number);
        maxIndex = index;
    }
    index++;
}

Console.WriteLine(maxIndex);


double LongestPattern(string value)
{
    double result = 0;

    bool found = false;

    for(int i = 0; i < value.Length; i++)
    {
        for(int j = 2; j < value.Length-i-j; j++)
        {
            if(value.Substring(i, Math.Min(j, value.Length - i - j)) == value.Substring(i + j, Math.Min(j, value.Length - i - j)) && DifferentDigits(value.Substring(i,j)))
            {
                result = j - i;
                found = true;
                break;
            }
        }
        if (found)
            break;
    }

    return result;
}

bool DifferentDigits(string value)
{
    bool areDifferent = false;
    char firstChar = value[0];

    foreach(char digit in value)
    {
        if(digit != firstChar)
        {
            areDifferent = true;
            break;
        }
    }

    return areDifferent;
}

