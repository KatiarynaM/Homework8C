// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию
// элементы каждой строки двумерного массива.

Console.Write("Введите количество строк: ");
int rows1 = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns1 = int.Parse(Console.ReadLine()!);
int[,] array1 = GetArray(rows1, columns1, 0, 10);
PrintArray(array1);
Console.WriteLine();
int[,] array12 = GetSelectionSort(array1);
Console.WriteLine($"Массив по убыванию: ");
PrintArray(array12);

//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет
// находить строку с наименьшей суммой элементов.

Console.Write("Введите количество строк: ");
int rows2 = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns2 = int.Parse(Console.ReadLine()!);
int[,] array2 = GetArray(rows2, columns2, 0, 10);
PrintArray(array2);
Console.WriteLine();
GetSelectionSum(array2);
Console.WriteLine($"Суммы элементов строк [{String.Join(",", GetSelectionSum(array2))}]");
FindMinElement(GetSelectionSum(array2));


//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение
// двух матриц.

int[,] array3 = GetArray(4, 4, 1, 3);
Console.WriteLine("Первая матрица");
PrintArray(array3);
Console.WriteLine();
int[,] array4 = GetArray(4, 4, 1, 3);
Console.WriteLine("Вторая матрица");
PrintArray(array4);
Console.WriteLine();
int[,] array34 = GetProduktMatrix(array3, array4);
Console.WriteLine("Произведение матриц");
PrintArray(array34);



//-------------------**Задачи повышенной сложности**---------------------
//Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
/*Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)*/

Console.Write("Введите количество строк: ");
int rows5 = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество столбцов: ");
int columns5 = int.Parse(Console.ReadLine()!);

Console.Write("Введите количество слоев: ");
int layer5 = int.Parse(Console.ReadLine()!);

int[,,] array5 = GetArrayThird(rows5, columns5, layer5, 10, 99);
PrintArrayThrid(array5);


//-----metods----

int[,] GetArray(int m, int n, int minValue, int maxValue){ //случайный двухмерный массив
    int[,] result = new int[m,n];
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            result[i,j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray (int[,] array){//вывод массива
    for(int i = 0; i < array.GetLength(0); i++){
        for(int j = 0; j < array.GetLength(1); j++){
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine();
    }
} 
int[,] GetSelectionSort (int[,] array){//сортировка массива по строкам
      int[,] res = new int[array.GetLength(0),array.GetLength(1)];
      for (int i=0; i<array.GetLength(0);i++){
            for (int j=0; j<array.GetLength(1); j++){
            int max = j;
            int k = j+1;
            for (k=j+1; k<array.GetLength(1); k++){
                  if(array[i,k]>array[i,max]) max=k;
            }
            res[i,j] = array[i,max];
            array[i,max] = array[i,j];
      }
    }
    return res;
}

int[] GetSelectionSum (int[,] array){// сумма по строкам
      int[] sum = new int[array.GetLength(0)];
      for (int i=0; i<array.GetLength(0);i++){
        sum[i]= 0;
            for (int j=0; j<array.GetLength(1); j++){
            sum[i] = sum[i] + array[i,j];
      }
    }
    return sum;
}

void FindMinElement(int[] array){//находим min и его положение
    int min = array[0];
    int minIndex = 1;
    for(int i = 0; i < array.Length; i++){
            if(array[i] < min){
                min = array[i];
               minIndex = i + 1;
            }
        }
        Console.Write($"Минимальная сумма {min} в {minIndex} строке");
        Console.WriteLine();
}
int[,] GetProduktMatrix(int[,] array1, int[,] array2){ //произведение матриц/ !работает только для квадратных!!
    int[,] matrix = new int[array1.GetLength(0),array1.GetLength(0)];
     for (int i=0; i<array1.GetLength(0);i++){
            for (int j=0; j<array1.GetLength(0); j++){
                for (int n=0; n<array1.GetLength(0);n++){
                    matrix[i,j] += (array1[i,n] * array2[n,j]);
                }
            }
     }    
    return matrix;
}

int[,,] GetArrayThird(int m, int n, int k, int minValue, int maxValue){ //случайный трехмерный массив
    int[,,] result = new int[m,n,k];
    for(int i = 0; i < m; i++){
        for(int j = 0; j < n; j++){
            for(int l = 0; l < n; l++){
            result[i,j,l] = new Random().Next(minValue, maxValue + 1);
             foreach (int el in result){  
            if(el == result[i,j,l]){
                result[i,j,l] = new Random().Next(minValue, maxValue + 1);
            }
        }
    }
}
}
    return result;
}

void PrintArrayThrid (int[,,] array){//вывод трехмерного массива
    for(int i = 0; i < array.GetLength(2); i++){
        for(int j = 0; j < array.GetLength(0); j++){
            for(int l = 0; l < array.GetLength(1); l++){
            Console.Write($"{array[j,l,i]}({j},{l},{i}) ");
        }
        Console.WriteLine();
    }
     Console.WriteLine();
} }