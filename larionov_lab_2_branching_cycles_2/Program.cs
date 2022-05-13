namespace larionov_lab_2_branching_cycles_2
{

    class Task1
    {

        private void function1(double p, double p1, double q, double q1, double step)
        {
            Console.WriteLine($"\nШаг: {step}\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           -");
            Console.WriteLine("           | p + q");
            Console.WriteLine("           | -------, если q >= 100,");
            Console.WriteLine("           | 2 * q");
            Console.WriteLine("           |");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("f(p, q) = < p - 2 * q, если 0 < q < 100, p > 20");
            Console.WriteLine("           |");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("           |");
            Console.WriteLine("           | p - 3 * q - в остальных случаях");
            Console.WriteLine("           -\n");

            Console.ResetColor();

            if (step > p1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка аргумент P: шаг не должен быть больше длинны промежутка!");
                return;
            }

            if (step > q1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка аргумент Q: шаг не должен быть больше длинны промежутка!");
                return;
            }

            double y = 0;
            string f = "";

            Console.WriteLine("{0,10}   |{1,10}   |{2,30}   |{3,10}", "p", "q", "f(p, q)", "y");

            while (p < p1 && q < q1) ////Цикл с предусловием
            {

                if (q >= 100)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    f = $"({p} + {q}) / (2 * {q})";
                    y = (p + q) / (2 * q) ;
                }
                else if (0 < q && q < 100 && p > 20)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    f = $"{p} - 2 * {q}";
                    y = p - 2*q;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    f = $"{p} - 3 * {q}";
                    y = p - 3 * q;
                }

                y = Math.Round(y, 2);
                Console.WriteLine("{0,10}   |{1,10}   |{2,30}   |{3,10}", p, q, f, y);

                p += step;
                q += step;

            }

            Console.ResetColor();
        }

        private double inputData(string text)
        {

            string xStr = "";
            bool isNumber = false;
            double x = 0;

            while (true)    ////Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = double.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else
                    break;
            }

            return x;
        }

        private double[] inputDouble(string arg)
        {
            double x = 0, x1 = 0;

            while (true) ////Цикл с предусловием
            {
                Console.ResetColor();

                x = inputData($"\nВведите начальное значение {arg} (число): ");
                x1 = inputData($"\nВведите промежуток для {arg} (число): ");

                if (x >= x1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка аргумент {arg}: {x} >= {x1}");
                }
                else
                    break;
            }

            double[] array = { x, x1 };
            return array;
        }

        private double inputStep()
        {
            double step;

            while (true) ////Цикл с предусловием
            {
                Console.ResetColor();

                step = inputData("\nВведите шаг (число): ");

                if (step <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Шаг не должен быть равен 0 или меньше 0!");
                }
                else
                    break;
            }

            return step;
        }

        public void init()
        {
            double[] P = inputDouble("P");
            double[] Q = inputDouble("Q");
            double step = inputStep();

            function1(P[0], P[1], Q[0], Q[1], step);
        }

    }

    class Task3
    {

        private double inputData(string text)
        {

            string xStr = "";
            bool isNumber = false;
            double x = 0;

            while (true)  ////Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = double.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else
                    break;
            }

            return x;
        }

        private int quarter(double[] coord)
        {
            double x = coord[0];
            double y = coord[1];

            if (x > 0)
            {
                if (y > 0) return 1;
                if (y < 0) return 4;
            }
            else if (x < 0)
            {
                if (y > 0) return 2;
                if (y < 0) return 3;
            }
            
            return 0;
        }

        private string quarterToStr(int x)
        {
            if (x == 1) return "I";
            if (x == 2) return "II";
            if (x == 3) return "III";
            if (x == 4) return "IV";
            return "0";
        }

        private double lengthSection(string point1, double[] coord1, string point2, double[] coord2)
        {
            double x1 = coord1[0];
            double y1 = coord1[1];

            double x2 = coord2[0];
            double y2 = coord2[1];

            Console.WriteLine($"{point1}({x1}; {y1})");
            Console.WriteLine($"{point2}({x2}; {y2})\n");

            Console.WriteLine($"{point1}{point2} = квадратный корень из (x2 - x1)^2 + (y2 - y1)^2");
            Console.WriteLine($"{point1}{point2} = квадратный корень из ({x2} - {x1})^2 + ({y2} - {y1})^2");

            double intervalX = x2 - x1;
            double intervalY = y2 - y1;

            Console.WriteLine($"{point1}{point2} = квадратный корень из {intervalX}^2 + {intervalY}^2");

            double squareIntervalX = intervalX * intervalX;
            double squareIntervalY = intervalY * intervalY;

            Console.WriteLine($"{point1}{point2} = квадратный корень из {squareIntervalX} + {squareIntervalY}");

            double underRoot = squareIntervalX + squareIntervalY;

            Console.WriteLine($"{point1}{point2} = квадратный корень из {underRoot}");

            double result = Math.Sqrt(underRoot);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{point1}{point2} = {result}\n");
            Console.ResetColor();

            return result;
        }

        private bool isInLine(string point1, double[] coord1, string point2, double[] coord2, string point3, double[] coord3)
        {
         
            double x1 = coord1[0];
            double y1 = coord1[1];

            double x2 = coord2[0];
            double y2 = coord2[1];

            double x3 = coord3[0];
            double y3 = coord3[1];

            Console.WriteLine($"{point1}({x1}; {y1})");
            Console.WriteLine($"{point2}({x2}; {y2})");
            Console.WriteLine($"{point3}({x3}; {y3})\n");

            Console.WriteLine("Точки лежат на одной прямой если:\n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("|x2 - x1   y2 - y1|");
            Console.WriteLine("|                 | = 0", " ", " ");
            Console.WriteLine("|x3 - x1   x3 - x1|\n");
            Console.ResetColor();

            Console.WriteLine("|{0,12}   {1,12}|", $"{x2} - {x1}", $"{y2} - {y1}");
            Console.WriteLine("|{0,12}   {1,12}| = 0", " ", " ");
            Console.WriteLine("|{0,12}   {1,12}|\n", $"{x3} - {x1}", $"{y3} - {y1}");

            double var1 = x2 - x1;
            double var2 = y2 - y1;

            double var3 = x3 - x1;
            double var4 = y3 - y1;

            Console.WriteLine("|{0,5}   {1,5}|", $"{var1}", $"{var2}");
            Console.WriteLine("|{0,5}   {1,5}| = 0", " ", " ");
            Console.WriteLine("|{0,5}   {1,5}|\n", $"{var3}", $"{var4}");

            Console.WriteLine($"{var1} * {var4} - {var2} * {var3} = 0");

            double a = var1 * var4;
            double b = var2 * var3;

            Console.WriteLine($"{a} - {b} = 0\n");

            double result = a - b;

            bool isInLine = result == 0;
            string message = "";

            if (isInLine)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result} = 0");
                message = "лежат на одной прямой";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{result} != 0");
                message = "не лежат на одной прямой";
            }

            Console.WriteLine($"Соответственно точки {point1}; {point2}; {point3} - {message}\n");

            Console.ResetColor();
            return isInLine;
        }

        private bool isInHalf(string point1, double[] a, string point2, double[] b)
        {
            double x1 = a[0];
            double y1 = a[1];

            double x2 = b[0];
            double y2 = b[1];

            bool isInHalf = x1 * x2 > 0 || y1 * y2 > 0;

            string message = $"Точки: {point1}; {point2}";

            if (isInHalf)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                message += " - лежат в одной полуплоскости.";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                message += " - не лежат в одной полуплоскости.";
            }

            Console.WriteLine(message + "\n");
            
            return isInHalf;
        }

        public void init()
        {
            Console.WriteLine("\nХотите сгенерировать точки случайным образом? [y/n]");
            bool isRandom = Console.ReadLine()?.ToLower() != "n";

            bool isError = false;

            double x1 = 0, y1 = 0;
            double x2 = 0, y2 = 0;

            const int MIN_RANDOM = -50;
            const int MAX_RANDOM = 50;

            if (isRandom)
            {
                Random rnd = new Random();

                x1 = rnd.Next(MIN_RANDOM, MAX_RANDOM);
                y1 = rnd.Next(MIN_RANDOM, MAX_RANDOM);

                x2 = rnd.Next(MIN_RANDOM, MAX_RANDOM);
                y2 = rnd.Next(MIN_RANDOM, MAX_RANDOM);
            }
            else
            {
                x1 = inputData("\nВведите координату X1: ");
                y1 = inputData("\nВведите координату Y1: ");

                x2 = inputData("\nВведите координату X2: ");
                y2 = inputData("\nВведите координату Y2: ");
            }

            double[] a = { x1, y1 };
            double[] b = { x2, y2 };
            double[] c = { 0, 0 };

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nПолученные координаты: А({x1}; {y1}); А({x2}; {y2}).\n");
            Console.ResetColor();


            int varQuarter = quarter(a);

            if (varQuarter != 0 && quarter(b) == varQuarter)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nТочки : А({x1}; {y1}); B({x2}; {y2}) - лежат в одной четверти ({quarterToStr(varQuarter)})\n");
                Console.ResetColor();

                Console.WriteLine($"Вычислим периметр треугольника А({x1}; {y1}); B({x2}; {y2}); C(0; 0)\n");

                double ab = lengthSection("A", a, "B", b);
                double bc = lengthSection("B", b, "C", c);
                double ca = lengthSection("C", c, "A", a);

                Console.WriteLine($"\nP треугольника ABC = {ab} + {bc} + {ca}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"P треугольника ABC = {ab + bc + ca}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nТочки : А({x1}; {y1}); B({x2}; {y2}) - не лежат в одной четверти\n");
                Console.ResetColor();

                if (isInHalf("A", a, "B", b) && isInHalf("B", b, "C", c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Точки А, B, C лежат в одной полуплоскости");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Точки А, B, C не лежат в одной полуплоскости!");
                }
            }

           

            if (isInLine("A", a, "B", b, "C", c))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Точки лежат на одной прямой");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Точки не лежат на одной прямой!");
            }

            Console.ResetColor();  
        
        }
    }

    class Task7
    {
        private double inputData(string text, double defaultX)
        {

            string xStr = "";
            bool isNumber = false;
            double x = 0;

            while (true)   ////Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = double.TryParse(xStr, out x);

                if (!isNumber)
                {
                    if (xStr == "")
                        return defaultX;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else
                    break;
            }

            return x;
        }

        private int factorial(int n)
        {
            int factorial = 1;

            for (int i = 1; i <= n; i++)  ////Цикл с ппараметром
                factorial *= i;

            return factorial;
        }

        private double f(double x, int n)
        {
            double result = Math.Pow(x, n) / factorial(n);
            return result;
        }

        private double checkF(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / 2;
        }

        public void init()
        {
            double EXACTNESS = 0.00001, DEFAULT_X = 0.5;

            int factorial = 1, n = 1;
            double current = 0, sum = 0, prev;

            string MASK = "0.#########################";

            Console.WriteLine($"\nВычислить значение суммы бесконечного ряда c точностью  E = {EXACTNESS.ToString(MASK)}\n");

            double x = inputData($"Введите значение X или нажмите Enter для X = {DEFAULT_X}: ", DEFAULT_X);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"x = {x}");
            Console.ResetColor();


            Console.WriteLine("{0,30}   |{1,30}", "Слагаемое", "Сумма");
            Console.WriteLine("{0,30}   |{1,30}", current, sum);

            do   //Цикл с постусловием
            {
                prev = current;
                current = f(x, n);

                sum += current;

                Console.WriteLine("{0,30}   |{1,30}", current.ToString(MASK), sum.ToString(MASK));

                n += 2;

            }
            while (Math.Abs(current - prev) > EXACTNESS);

            double check = checkF(x);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСумма ряда равна: {0,30}", sum);
            Console.ResetColor();

            Console.WriteLine("Значение функции проверки: {0,21}", check);

            double difference = Math.Abs(check - sum);

            string message = "";

            if (difference <= EXACTNESS)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                message = "Вычисления выполнены с необходимой точностью.";

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                message = "Вычисления неточны!";
            }

            Console.WriteLine($"\nРазность: {difference.ToString(MASK)}");
            Console.WriteLine($"{message}\n");

            Console.ResetColor();

        }
    }

    class Task9
    {
        private int inputData(string text, int maxCount)
        {

            string xStr = "";
            bool isNumber = true;
            int x;

            while (true)   //Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    if (xStr == "")
                        return maxCount;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else if (x > maxCount)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число не более {maxCount}!");
                }
                else if (x < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число более 0!");
                }
                else
                    break;
            }

            return x;
        }

        private void draw(string n)
        {
            Console.WriteLine($"\n  {n}          k+1");
            Console.WriteLine("#######      #######");
            Console.WriteLine(" #    #       #    #");
            Console.WriteLine("  #            #              1");
            Console.WriteLine("   #            #          ---------");
            Console.WriteLine("  #            #            k^2 + i");
            Console.WriteLine(" #    #       #    #");
            Console.WriteLine("#######      #######");
            Console.WriteLine("  k=1          i=1");
        }


        private double f1(int k, int n)
        {
            return 1 / (Math.Pow(k, 2) + n);
        }

        private double sum1(int k, string MASK)
        {
            double prev = 0, current = 0, sum = 0;
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 1; i < 3; ++i)   ////Цикл с параметром
            {
                prev = current;
                current = f1(k, i);

                sum = current + prev;

                Console.WriteLine("{0,30}   |{1,30}", current.ToString(MASK), sum.ToString(MASK));
            }

            return sum;
        }

        public void init()
        {
            const int MAX_N = 200;

            int n = inputData($"Введите натуральное число (Не больше {MAX_N}): ", MAX_N);

            draw("N");

            Console.ForegroundColor = ConsoleColor.Green;
            draw(n.ToString());
            Console.ResetColor();

            double prev = 0, current = 0, sum = 0;

            string MASK = "0.#########################";
            Console.WriteLine("{0,30}   |{1,30}", "Слагаемое", "Сумма");


            for (int k = 1; k < n; ++k)   ////Цикл с параметром
            {
                prev = sum;
                current = sum1(k, MASK);
                sum = current + prev;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,30}   |{1,30}\n", current.ToString(MASK), sum.ToString(MASK));
            }

            Console.WriteLine($"Сумма равна: {sum.ToString(MASK)}\n");
            Console.ResetColor();

        }
    }

    class Class1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Варинат №16. Ларионов Никита Юрьевич. гр. 110з\n");

            bool isGo = true;


            while (isGo)  ////Цикл с предусловием
            {
                Console.WriteLine("\nВведите номер задачи \"1\", \"3\", \"7\" или \"9\": ");
                Console.WriteLine("Для выхода введите \"0\": ");

                string selectStr = Console.ReadLine();

                switch (selectStr)
                {
                    case "1":
                        Task1 task1 = new Task1();
                        task1.init();
                        break;

                    case "3":
                        Task3 task3 = new Task3();
                        task3.init();
                        break;

                    case "7":
                        Task7 task7 = new Task7();
                        task7.init();
                        break;

                    case "9":
                        Task9 task9 = new Task9();
                        task9.init();
                        break;

                    case "0":
                        isGo = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекорректные данные!");
                        Console.ResetColor();
                        break;

                }
            }


        }

    }

}