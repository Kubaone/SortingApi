namespace Core.ExtensionMethods
{
    public static class ArrayExtensions
    {
        public static int[] SwapNumbers(this int[] numbers, int index1, int index2)
        {
            var temp = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = temp;

            return numbers;
        }
    }
}
