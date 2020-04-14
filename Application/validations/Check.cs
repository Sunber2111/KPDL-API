namespace Application.validations
{
    public static class Check
    {
        public static bool CheckTypePoint(this int number)
        {
            return number == 1 || number == 2 || number == 3 || number == 4;
        }

        public static bool CheckPointTest(this double number)
        {
            return (number <= 10 && number >= 0);
        }
    }
}