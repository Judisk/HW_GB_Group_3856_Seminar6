namespace MyMethodsJudisk
{
    public class JudMethod
    {
        public static int SetNumberInt(string text)
        {
            Console.WriteLine(text);
            int number = int.Parse(Console.ReadLine());
            return number;
        }

        public static double SetNumberDouble(string text)
        {
            Console.WriteLine(text);
            double number = double.Parse(Console.ReadLine());
            return number;
        }

        public static void TaskNum(int number)// Вывод какой номер задания 
        {
            System.Console.WriteLine($"__Задание {number}___");
        }

        public static void ShowArrayMetodInt(int[] testArray)// показывает массив с которым работаем для упрощения проверки 
        {
            int[] showArray = testArray;
            var str = string.Join(",", showArray);
            Console.WriteLine(str);
        }
        public static void ShowArrayMetodString(string[] testArray)// показывает массив с которым работаем для упрощения проверки 
        {
            string[] showArray = testArray;
            var str = string.Join(" ", showArray);
            Console.WriteLine(str);
        }

        public static void ShowArrayMetodDouble(double[] testArray)// тоже самое что и выше только double
        {
            double[] showArray = testArray;
            var str = string.Join(" ", showArray);
            Console.WriteLine(str);
        }

        public static int RandomSign(string sign)//если "Yes" то числа могут иметь рандомный знак если любое другое то только +
        {
            int randomSign = 0;
            int signMinus = 1;
            if (sign == "Yes" || sign == "yes" || sign == "y")
            {
                randomSign = new Random().Next(0, 2);
                if (randomSign == 1)
                {
                    signMinus = -1;
                }
            }
            return signMinus;
        }

        public static int[] CreateArrayInt(double degree, int maxSizeArray, string sign)// создаем массив / если введем 0 , 0 то будет полностью случайный массив / degree - до какого числа / maxSizeArray - макс размер массив  
        {

            int signMinus = 1;
            if (degree != 0 && maxSizeArray != 0)
            {
                double maxDegreeDouble = Math.Pow(10, degree);//определяем максимальный размер массив если degree 3 то будет 100-1000 4 1000-10000 
                int maxDegree = Convert.ToInt32(maxDegreeDouble);
                int minDegree = maxDegree / 10;//задаем минимальное число

                int sizeArray = new Random().Next(1, maxSizeArray);// рандомим размер массив он может быть как равен введенному maxSizeArray так и меньше
                int[] rndArray = new int[sizeArray];

                for (int i = 0; i < sizeArray; i++)//проходим по каждому пустому индексу массива и заполняем рандомным числом заданным аргументом
                {
                    signMinus = RandomSign(sign);
                    rndArray[i] = (new Random().Next(minDegree, maxDegree)) * signMinus;
                }
                return rndArray;
            }
            else//если 0,0 dct рандомно
            {
                int[] rndArray = new int[10];//изначально делал тоже рандомным но потом когда мне выпало больше 1000 размер массива посчитал что лучше 10 сделать
                for (int i = 0; i < 10; i++)
                {
                    signMinus = RandomSign(sign);
                    rndArray[i] = (new Random().Next(0, 1000)) * signMinus; //числа решил 0-1000 сделать потому что так проще считать но это омжно изменить и хоть брать до 10^7 как и было изначально
                }
                return rndArray;
            }

        }

        public static double[] CreateArrayDouble(string sign)//создание double массивов по принципу 0,0 в методе выше если ввести yes то числа рандомный знак   
        {
            double signMinus = 1;

            double[] rndArray = new double[10];//изначально делал тоже рандомным но потом когда мне выпало больше 1000 размер массива посчитал что лучше 10 сделать
            for (int i = 0; i < 10; i++)
            {
                signMinus = Convert.ToDouble(RandomSign(sign));

                double fraction = new Random().Next(10, 100);
                double fraction100 = fraction / 100;
                double whole = new Random().Next(1, 100);
                double Resulte = whole + fraction100;
                rndArray[i] = Resulte * signMinus;
            }
            return rndArray;
        }

        public static void ParityCheckInArray(int[] array34)
        {
            ShowArrayMetodInt(array34);//показываем массив

            int count = 0;
            for (int i = 0; i < array34.Length; i++)
            {
                if (array34[i] % 2 == 0)//проверка на четность числа если прошло то прибавляем счетчик
                {
                    ++count;
                }
            }
            System.Console.WriteLine($"количество четных чисел : {count}");
        }

        public static void SumNumOnOddIndexInArray(int[] array36)
        {
            ShowArrayMetodInt(array36);//показываем массив
            int Result = 0;
            for (int i = 0; i < array36.Length; i++)
            {
                if (i % 2 != 0)//проверка на нечетность нидекса
                {
                    Result = array36[i] + Result;
                }
            }
            System.Console.WriteLine($"сумма эл на нечетных идексах : {Result}");
        }//сумма чисел на нечетных индексах

        public static void MinMaxInDoubleArray(double[] array38)//вычисление минимального и максимального числа в массиве и вывод их разницы
        {
            ShowArrayMetodDouble(array38);

            double max = array38[0];
            double min = array38[0];

            for (int i = 1; i < array38.Length; i++)
            {
                if (array38[i] > max)
                {
                    max = array38[i];
                }
                else if (array38[i] < min)
                {
                    min = array38[i];
                }
            }
            double Resulte = max - min;
            System.Console.WriteLine($"max : {max} min: {min} difference: {Resulte}");

        }


        public static bool CheckReady() // проверка хочет ли пользователь продолжить
        {
            Console.WriteLine("Eсли хотите продолжить введите y ");
            string yes = Console.ReadLine();
            return yes == "y";
        }

        public static void CountingNumbersGreatedZero(ref int count)//подсчет чисел больше 0 которые вводит пользователь 
        {
            if (CheckReady())
            {

                int numberM = JudMethod.SetNumberInt("Введите число");
                if (numberM > 0)
                {
                    count++;
                }
                CountingNumbersGreatedZero(ref count);
            }
            else
            {
                Console.WriteLine($"Количество чисел больше 0 равно: {count}");
            }
        }









    }

}