using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Масив з випадковими числами
        Random rand = new Random();
        int[] numbers = new int[20];
        for (int i = 0; i < 20; i++)
        {
            numbers[i] = rand.Next(-20, 21);
        }

        int[] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
        int[] oddNumbers = numbers.Where(x => x % 2 != 0).ToArray();
        int[] sortedAsc = numbers.OrderBy(x => x).ToArray();
        int[] sortedDesc = numbers.OrderByDescending(x => x).ToArray();
        int sum = numbers.Sum();
        int min = numbers.Min();
        int max = numbers.Max();

        using (StreamWriter streamwriter = new StreamWriter(@"D:\index.html"))
        {
            streamwriter.WriteLine("<html>");
            streamwriter.WriteLine("<head>");
            streamwriter.WriteLine("  <title>Випадкові числа та кольорові кола</title>");
            streamwriter.WriteLine("  <meta charset=\"UTF-8\">");
            streamwriter.WriteLine("  <style>");
            streamwriter.WriteLine("    table { width: 50%; border-collapse: collapse; margin: 20px auto; }");
            streamwriter.WriteLine("    th, td { border: 1px solid black; padding: 10px; text-align: center; }");
            streamwriter.WriteLine("    .circle { position: absolute; border-radius: 50%; }");
            streamwriter.WriteLine("  </style>");
            streamwriter.WriteLine("</head>");
            streamwriter.WriteLine("<body>");

            // Виведення таблиць з масивами
            streamwriter.WriteLine("<h2>Масив з випадковими числами</h2>");
            PrintTable(streamwriter, "Усі числа", numbers);
            PrintTable(streamwriter, "Усі парні числа", evenNumbers);
            PrintTable(streamwriter, "Усі непарні числа", oddNumbers);
            PrintTable(streamwriter, "Відсортовані по зростанню", sortedAsc);
            PrintTable(streamwriter, "Відсортовані по спаданню", sortedDesc);

            streamwriter.WriteLine($"<p><b>Сума:</b> {sum}</p>");
            streamwriter.WriteLine($"<p><b>Мінімальне:</b> {min}</p>");
            streamwriter.WriteLine($"<p><b>Максимальне:</b> {max}</p>");

            // 2. Кольорові кола
            streamwriter.WriteLine("<h2>Кольорові кола</h2>");
            streamwriter.WriteLine("<div style='position:relative; height:500px; background-color: #f0f0f0;'>");

            int circlesCount = rand.Next(10, 51);
            for (int i = 0; i < circlesCount; i++)
            {
                int size = rand.Next(10, 101);
                string color = $"#{rand.Next(0x1000000):X6}";
                int top = rand.Next(0, 500 - size);
                int left = rand.Next(0, 800 - size);
                streamwriter.WriteLine($"<div class=\"circle\" style=\"width:{size}px; height:{size}px; background-color:{color}; top:{top}px; left:{left}px;\"></div>");
            }

            streamwriter.WriteLine("</div>");

            // 3. Форма для керування параметрами
            streamwriter.WriteLine("<h2>Налаштування кольорових кіл</h2>");
            streamwriter.WriteLine("<form method=\"get\">");
            streamwriter.WriteLine("  <label>Кількість кіл: <input type=\"number\" name=\"count\" min=\"10\" max=\"50\" value=\"10\"></label><br>");
            streamwriter.WriteLine("  <label>Колір кіл:");
            streamwriter.WriteLine("    <select name=\"color\">");
            streamwriter.WriteLine("      <option value=\"random\">Рандомні</option>");
            streamwriter.WriteLine("      <option value=\"red\">Червоний</option>");
            streamwriter.WriteLine("      <option value=\"green\">Зелений</option>");
            streamwriter.WriteLine("      <option value=\"blue\">Синій</option>");
            streamwriter.WriteLine("    </select>");
            streamwriter.WriteLine("  </label><br>");
            streamwriter.WriteLine("  <label>Рандомний розмір: <input type=\"checkbox\" name=\"random_size\" checked></label><br>");
            streamwriter.WriteLine("  <input type=\"submit\" value=\"Застосувати\">");
            streamwriter.WriteLine("</form>");

            streamwriter.WriteLine("</body>");
            streamwriter.WriteLine("</html>");
        }
    }

    static void PrintTable(StreamWriter streamwriter, string title, int[] numbers)
    {
        streamwriter.WriteLine($"<h3>{title}</h3>");
        streamwriter.WriteLine("<table>");
        streamwriter.WriteLine("  <tr><th>Значення</th></tr>");
        foreach (var num in numbers)
        {
            streamwriter.WriteLine($"  <tr><td>{num}</td></tr>");
        }
        streamwriter.WriteLine("</table>");
    }
}
