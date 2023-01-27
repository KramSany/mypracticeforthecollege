using System;

namespace Library
{
    public static class Nubmer
    {
        public static void Create(this Matrix<int> numbers, int row, int column) // метод на создание матрицы
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
        public static (int, int) CountPositiveOrNegetiveNumb(int firstNumber, int secondNumber, int thirdNumber) // метод на нахождение положительных и отрицательных чисел
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

        public static bool CompareThreeNumber(int number) // метод на сравнивая 3-ех значного числа
        {
            if (number / 100 == number % 100 / 10 && number / 100 == number % 10) return true;
            return false;
        }
        private static bool FindNumberInArray(int[] array, int numberForTheSearch) // закрытый метод для нахождения определенного числа в массиве
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == numberForTheSearch) return true;
            }
            return false;
        }
        public static int[] SqurareNegativeNumber(int[] array, int numberForTheSearch) // метод на нахождения отрицательных чисел в массиве и возведение их в квадрат
        {
            if (FindNumberInArray(array, numberForTheSearch) == false) return array;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0) array[i] *= array[i];
            }
            return array;
        }
        public static int CountElementWithOutIntervala(this Matrix<int> numbers, int startInterval, int endInterval) // метод на нахождение максиального повторяющихся чисел
        {
            int countElements = numbers.Copasity;
            for (int i = 0; i < numbers.RowCount; i++)
            {
                for (int j = 0; j < numbers.ColumnCount; j++)
                {
                    for (int k = startInterval; k <= endInterval; k++) // цикл с интервалом пользователя
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
