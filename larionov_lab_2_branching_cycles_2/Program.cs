namespace larionov_lab_2_branching_cycles_2
{
    class TasksInfo
    {
        public const string TASK_1 = "Пользователь задает промежутки для двух аргументов и шаг.\n" +
            "Программа выводит на экран значения функции.";

        public const string TASK_3 = "Определить, лежат ли две точки с координатами (x1, y1) и (x2, y2) в одной четверти.\n" +
            "Если лежат, вычислить периметр треугольника, вершинами которого являются начало координат и данные точки.\n" +
            "Если все точки лежат на одной прямой, вывести сообщение об этом.\n" +
            "Если точки в одной четверти не лежат, определить, лежат ли они в одной полуплоскости.";

        public const string TASK_7 = "Вычислить значние суммы бесконечного ряда\n" +
            "с точностью до члена ряда, по модулю меньшего E";

        public const string TASK_9 = "Дано натуральное число N. Вычислить сумму";
    }

    class MyInput
    {
        public int inputData(string text, int min, int max, int defaultValue = -1)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;


            while (true)    //Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();

                if (xStr == "")
                    return defaultValue;

                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else if (x < min && x > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число должно лежать в промежутке [{min}; {max}]!");
                }
                else
                    break;
            }

            return x;
        }

        public double inputDoubleData(string text, int min, int max, double defaultValue = -1)
        {

            string xStr = "";
            bool isNumber = false;
            double x = 0;

            while (true)    //Цикл с предусловием
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();

                if (xStr == "")
                    return defaultValue;

                isNumber = double.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число");
                }
                else if (x < min && x > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число должно лежать в промежутке [{min}; {max}]!");
                }
                else
                    break;
            }

            return x;
        }
    }

    class MyQuestion
    {
        public const string QUESTION_RANDOM_DATA = "Сгенерировать данные случайным образом [y/n]?";
        public const string QUESTION_IN_ORDER_DATA = "Взять числа по порядку [y/n]?";
        public const string QUESTION_SHOW_CALC = "Показывать ход вычислений [y/n]?";

        public bool isQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }
    }

    class Task1
    {
        private const int MIN = -1000;
        private const int MAX = 1000;

        private struct arguments
        {
            public double x;
            public double x1;
        }

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

        private arguments inputDouble(string arg)
        {
            double x = 0, x1 = 0;

            MyInput myInput = new MyInput();

            while (true) //Цикл с предусловием
            {
                Console.ResetColor();

                x = myInput.inputData($"\nВведите начальное значение {arg} (число): ", MIN, MAX);
                x1 = myInput.inputData($"\nВведите промежуток для {arg} (число): ", MIN, MAX);

                if (x >= x1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка аргумент {arg}: {x} >= {x1}");
                }
                else
                    break;
            }

            arguments result = new arguments();
            result.x = x;
            result.x1 = x1;
            return result;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_1);

            arguments P = inputDouble("P");
            arguments Q = inputDouble("Q");

            MyInput myInput = new MyInput();
            double step = myInput.inputDoubleData("\nВведите шаг (число): ", 0, MAX);

            function1(P.x, P.x1, Q.x, Q.x1, step);
        }

    }

    class Task3
    {
        const int MIN = -50;
        const int MAX = 50;

        private struct point
        {
            public double x;
            public double y;
            public string name;
        };

        private int quarter(point pnt)
        {
            double x = pnt.x;
            double y = pnt.y;

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

        private double lengthSection(point pnt1, point pnt2)
        {

            string point1 = pnt1.name;
            double x1 = pnt1.x;
            double y1 = pnt1.y;

            string point2 = pnt2.name;
            double x2 = pnt2.x;
            double y2 = pnt2.y;

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

        private bool isInLine(point pnt1, point pnt2, point pnt3)
        {

            string point1 = pnt1.name;
            double x1 = pnt1.x;
            double y1 = pnt1.y;

            string point2 = pnt2.name;
            double x2 = pnt2.x;
            double y2 = pnt2.y;

            string point3 = pnt3.name;
            double x3 = pnt3.x;
            double y3 = pnt3.y;

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

        private bool isInHalf(point a, point b)
        {
            string point1 = a.name;
            double x1 = a.x;
            double y1 = a.y;

            string point2 = b.name;
            double x2 = b.x;
            double y2 = b.y;

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
            Console.WriteLine(TasksInfo.TASK_3);

            MyQuestion myQuestion = new MyQuestion();
            bool isRandom = myQuestion.isQuestion(MyQuestion.QUESTION_RANDOM_DATA);

            bool isError = false;

            point a, b, c;
             a.name = "A";
             b.name = "B";

             c.name = "C";
            c.x = 0;
            c.y = 0;

            if (isRandom)
            {
                Random rnd = new Random();
                a.x = rnd.Next(MIN, MAX);
                a.y = rnd.Next(MIN, MAX);

                b.x = rnd.Next(MIN, MAX);
                b.y = rnd.Next(MIN, MAX);
            }
            else
            {
                MyInput myInput = new MyInput();

                a.x = myInput.inputData("\nВведите координату X1: ", MIN, MAX);
                a.y = myInput.inputData("\nВведите координату Y1: ", MIN, MAX);

                b.x = myInput.inputData("\nВведите координату X2: ", MIN, MAX);
                b.y = myInput.inputData("\nВведите координату Y2: ", MIN, MAX);
            }

            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nПолученные координаты: А({a.x}; {a.y}); B({b.x}; {b.y}).\n");
            Console.ResetColor();


            int varQuarter = quarter(a);

            if (varQuarter != 0 && quarter(b) == varQuarter)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nТочки : А({a.x}; {a.y}); B({b.x}; {b.y}) - лежат в одной четверти ({quarterToStr(varQuarter)})\n");
                Console.ResetColor();

                Console.WriteLine($"Вычислим периметр треугольника А({a.x}; {a.y}); B({b.x}; {b.y}); C(0; 0)\n");

                double ab = lengthSection(a, b);
                double bc = lengthSection(b, c);
                double ca = lengthSection(c, a);

                Console.WriteLine($"\nP треугольника ABC = {ab} + {bc} + {ca}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"P треугольника ABC = {ab + bc + ca}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nТочки: А({a.x}; {a.y}); B({b.x}; {b.y}) - не лежат в одной четверти\n");
                Console.ResetColor();

                if (isInHalf(a, b) && isInHalf(b, c) && isInHalf(a, c))
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

           

            if (isInLine(a, b, c))
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
        private const double EXACTNESS = 0.00001, DEFAULT_X = 0.5;

        private int factorial(int n)
        {
            int factorial = 1;

            for (int i = 1; i <= n; i++)  ////Цикл с ппараметром
                factorial *= i;

            return factorial;
        }

        public void init()
        {

            Console.WriteLine(TasksInfo.TASK_7);

            int n = 1;
            double current = 0, sum = 0, prev;

            string MASK = "0.#########################";

            Console.WriteLine($"\nВычислить значение суммы бесконечного ряда c точностью  E = {EXACTNESS.ToString(MASK)}\n");

            MyInput myInput = new MyInput();
            double x = myInput.inputDoubleData($"Введите значение X или нажмите Enter для X = {DEFAULT_X}: ", 0, 1, DEFAULT_X);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"x = {x}");
            Console.ResetColor();


            Console.WriteLine("{0,30}   |{1,30}", "Слагаемое", "Сумма");
            Console.WriteLine("{0,30}   |{1,30}", current, sum);
            
            do   //Цикл с постусловием
            {
                prev = current;
                current = (Math.Pow(x, n) / factorial(n));

                sum += current;

                Console.WriteLine("{0,30}   |{1,30}", current.ToString(MASK), sum.ToString(MASK));

                n += 2;

            }
            while (Math.Abs(current - prev) > EXACTNESS);

            double check = (Math.Exp(x) - Math.Exp(-x)) / 2;

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
        private const int MAX_N = 200;

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


        private double sum1(int k, string MASK)
        {
            double prev = 0, current = 0, sum = 0;
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int i = 1; i < 3; ++i)   ////Цикл с параметром
            {
                prev = current;
                current = (1 / (Math.Pow(k, 2) + i));

                sum = current + prev;

                Console.WriteLine("{0,30}   |{1,30}", current.ToString(MASK), sum.ToString(MASK));
            }

            return sum;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_9);

            MyInput myInput = new MyInput();
            int n = myInput.inputData($"Введите натуральное число (Не больше {MAX_N}): ", 1, MAX_N);

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
                Console.WriteLine("\nВведите номер задачи: ");

                Console.WriteLine("\n1) " + TasksInfo.TASK_1);
                Console.WriteLine("\n3) " + TasksInfo.TASK_3);
                Console.WriteLine("\n7) " + TasksInfo.TASK_7);
                Console.WriteLine("\n9) " + TasksInfo.TASK_9);

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