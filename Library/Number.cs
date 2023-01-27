using System;

namespace Library
{
    public static class Nubmer
    {
        public static void Create(this Matrix<int> numbers, int row, int column) // ����� �� �������� �������
        {
            int[,] matrix = new int[row, column];
            Random random = new();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = random.Next(2, 10);
                }
            }
            numbers.Add(matrix);
        }
        public static (int, int) CountPositiveOrNegetiveNumb(int firstNumber, int secondNumber, int thirdNumber) // ����� �� ���������� ������������� � ������������� �����
        {
            int countNegative = 0;
            int countPositive = 0;
            if (firstNumber > 0) countPositive++;
            else countNegative++;
            if (secondNumber > 0) countPositive++;
            else countNegative++;
            if (thirdNumber > 0) countPositive++;
            else countNegative++;
            return (countPositive, countNegative);
        }

        public static bool CompareThreeNumber(int number) // ����� �� ��������� 3-�� �������� �����
        {
            if (number / 100 == number % 100 / 10 && number / 100 == number % 10) return true;
            return false;
        }
        private static bool FindNumberInArray(int[] array, int numberForTheSearch) // �������� ����� ��� ���������� ������������� ����� � �������
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == numberForTheSearch) return true;
            }
            return false;
        }
        public static int[] SqurareNegativeNumber(int[] array, int numberForTheSearch) // ����� �� ���������� ������������� ����� � ������� � ���������� �� � �������
        {
            if (FindNumberInArray(array, numberForTheSearch) == false) return array;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) array[i] *= array[i];
            }
            return array;
        }
        public static int CountElementWithOutIntervala(this Matrix<int> numbers, int startInterval, int endInterval) // ����� �� ���������� ������������ ������������� �����
        {
            int countElements = numbers.Copasity;
            for (int i = 0; i < numbers.RowCount; i++)
            {
                for (int j = 0; j < numbers.ColumnCount; j++)
                {
                    for (int k = startInterval; k <= endInterval; k++) // ���� � ���������� ������������
                    {
                        if (numbers[i, j] == k)
                        {
                            countElements--;
                            break;
                        }
                    }
                }
            }
            return countElements;
        }
    }
}
