using System;
using System.Linq;

class MatrixOperations
{
    public static void Main(string[] args)
    {
        // Завдання 4: Операції над матрицями
        
        int[,] matrix1 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] matrix2 = { { 7, 8, 9 }, { 10, 11, 12 } };

        Console.WriteLine("Множення матриці на число:");
        PrintMatrix(MultiplyByScalar(matrix1, 2));

        Console.WriteLine("Додавання матриць:");
        PrintMatrix(AddMatrices(matrix1, matrix2));

        Console.WriteLine("Добуток матриць:");
        PrintMatrix(MultiplyMatrices(matrix1, matrix2));

        // Завдання 5: Підрахунок результату арифметичного виразу
        
        string expression = Console.ReadLine();
        Console.WriteLine($"Результат виразу: {CalculateExpression(expression)}");

        // Завдання 6: Зміна регістру першої літери кожного речення
       
        string text = Console.ReadLine();
        Console.WriteLine($"Результат зміни регістру: {ChangeFirstLetterCase(text)}");

        // Завдання 7: Перевірка тексту на неприпустимі слова
        
        string textToCheck = Console.ReadLine();
        string[] forbiddenWords = { "die", "sleep" }; 
        string censoredText = CheckForbiddenWords(textToCheck, forbiddenWords, out int replacements);
        Console.WriteLine($"Результат роботи:\n{censoredText}\nСтатистика: {replacements} заміни.");
    }

    // Завдання 4: Операції над матрицями
    public static int[,] MultiplyByScalar(int[,] matrix, int scalar)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    public static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);
        int[,] result = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    // Завдання 5: Підрахунок результату арифметичного виразу
    public static int CalculateExpression(string expression)
    {
        string[] tokens = expression.Split(new char[] { '+', '-' }, StringSplitOptions.RemoveEmptyEntries);
        int result = int.Parse(tokens[0]);
        for (int i = 1; i < tokens.Length; i++)
        {
            if (expression[i - 1] == '+')
                result += int.Parse(tokens[i]);
            else
                result -= int.Parse(tokens[i]);
        }
        return result;
    }

    // Завдання 6: Зміна регістру першої літери кожного речення
    public static string ChangeFirstLetterCase(string text)
    {
        string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = sentences[i].Trim();
            if (!string.IsNullOrEmpty(sentences[i]))
            {
                sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
            }
        }
        return string.Join(". ", sentences);
    }

    //Pfdlfyyz 7
    public static string CheckForbiddenWords(string text, string[] forbiddenWords, out int replacements)
    {
        replacements = 0;
        foreach (string word in forbiddenWords)
        {
            text = text.Replace(word, new string('*', word.Length));
            replacements++;
        }
        return text;
    }

    
    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
