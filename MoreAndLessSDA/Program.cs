using System;

public class LogicalExpressionEvaluator
{
    public static bool Evaluate(string expression)
    {
        try
        {
            // Удаляем пробелы из выражения
            expression = expression.Replace(" ", "");

            // Ищем операторы и разбиваем строку на левую и правую часть
            if (expression.Contains("=="))
                return Evaluate(expression, "==");
            if (expression.Contains("!="))
                return Evaluate(expression, "!=");
            if (expression.Contains("<="))
                return Evaluate(expression, "<=");
            if (expression.Contains(">="))
                return Evaluate(expression, ">=");
            if (expression.Contains("<"))
                return Evaluate(expression, "<");
            if (expression.Contains(">"))
                return Evaluate(expression, ">");

            throw new ArgumentException("Выражение не содержит поддерживаемого оператора.");
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Ошибка при обработке выражения: " + ex.Message);
        }
    }

    private static bool Evaluate(string expression, string op)
    {
        string[] parts = expression.Split(new string[] { op }, StringSplitOptions.None);
        if (parts.Length != 2)
            throw new ArgumentException("Некорректное выражение.");

        int left = int.Parse(parts[0]);
        int right = int.Parse(parts[1]);

        switch (op)
        {
            case "==":
                return left == right;
            case "!=":
                return left != right;
            case "<=":
                return left <= right;
            case ">=":
                return left >= right;
            case "<":
                return left < right;
            case ">":
                return left > right;
            default:
                throw new ArgumentException("Неизвестный оператор.");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите логическое выражение (например, 3>2):");
        string input = Console.ReadLine();

        try
        {
            bool result = Evaluate(input);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}