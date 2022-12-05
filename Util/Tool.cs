namespace Util
{
    public class Tool
    {
        public static string PrintNumInBase(int num, int bas)
        {
            string number = "";

            do
            {
                int m = num % bas;

                if(m < 10)
                    number = m.ToString() + number;
                else
                {
                    char c = "ABCDEF"[m - 10];
                    number = c + number;
                }
                num = num / bas;
            } while (num != 0);

            return number;
        }

        public static bool IsPalindrom(string num)
        {
            int start = 0;
            int end = num.Length -1;


            while (start <= end)
            {
                if (num[start] != num[end])
                    return false;

                start++;
                end--;

            }

            return true;
        }

        public static bool IsMultiPalindriom(int num)
        {
            int noBases = 0;

            for (int i = 2; i <= 16; i++)
            {
                var s = PrintNumInBase(num, i);
                if (IsPalindrom(s))
                {
                    noBases++;
                }

                if (noBases >= 3)
                {
                    return true;
                }


            }

            return false;
        }
    }
}