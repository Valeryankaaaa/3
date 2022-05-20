﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задача__3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader fail = new StreamReader("D:\\visual проекты\\задача3.txt"); //чтение файла
            while (!fail.EndOfStream) //цикл выполняется, пока содержимое файла не равно конечному значению
            {
                listBox1.Items.Add(fail.ReadLine() + "\r\n"); //производится вывод содержимого файла в listBox1
            }
            fail.Close(); //закрытие чтения файла
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = 970; //количество пользователей (данные из файла)
            int s = 8200; //размер свободного места на диске (данные из файла)
            int sum = 0; //переменная для накопления суммы
            int mx = 0; //переменная для вычисления максимального количества пользователей 
            int v = 0; //переменная для вычисления максимального размера файла 
            int b = 0; //переменная, предназначенная для присваивания элементов массива
            int[] mas = new int[n+1]; //массив, предназначенный для сортировки 

            StreamReader fail = new StreamReader("D:\\visual проекты\\задача3.txt"); //чтение файла
            string text = fail.ReadLine(); //присваиваем переменной содержимое файла для чтения
            while (text!= null) //цикл выполняется, пока переменная не равна конечному значению
            {
                for (int i = 1; i < mas.Length; i++) //цикл, предназначенный для заполнения нашего массива
                {
                    mas[i] = Convert.ToInt32(fail.ReadLine()); //конвертируем текст в число и заполняем массив
                    listBox1.Items.Add(mas[i] + "\r\n");
                }
                text = fail.ReadLine(); //переход на следующую строку\
            } //производится вывод содержимого файла в listBox1
            Perebor(mas, b); //используя метод, получаем сортированный массив
            label1.Text ="Максимальное количество пользователей: "+ MaxP(mas,n,sum,s,mx); //вывод максимального количества пользователей на экран
            label2.Text= "Максимальный размер файла: " + MaxF(mas,mx,n,sum,s,v); //вывод максимального размера файла на экран

        }
        public static void Perebor(int[] mass, int b) //запускаем метод для перебора массива
        {
            for (int i = 1; i < mass.Length; i++) //запускаем первый цикл для сортировки массива
            {
                for (int j = 1; j < mass.Length - 1; j++) //запускаем второй цикл для сортировки массива 
                {
                    if (mass[j] > mass[j + 1]) //если значение первого элемента массива больше следующего, то выполняются следующие команды...
                    {
                        b = mass[j + 1]; //переменной присваивается значение второго элемента массива
                        mass[j + 1] = mass[j]; //происходит замена первого элемента на второй
                        mass[j] = b; //первому элементу массива присваивается ранее использованная переменная
                    }
                }
            }
        }
        public static int MaxP(int[] mass,int n, int sum, int s,int mx) //запускаем метод для вычисления максимального количества пользователей
        {
            for (int i = 1; i < n; i++) //запускаем цикл для вычисления максимального количества пользователей 
            {
                if (sum + mass[i] <= s) //если сумма элементов будет меньше или равна размеру свободного места на диске, будут выполнятся следующие команды...
                {
                    sum += mass[i]; //производится накопление суммы
                    mx = i; //производим замену переменных
                }
            }
            return mx; //вывод максимального количества пользователей
        }
        public static int MaxF(int[] mass,int mx,int n,int sum,int s,int v) //запускаем метод для вычисления максимального размера файла
        {
            mx = MaxP(mass,n,sum,s,mx); //присваиваем переменной значение, полученное из предыдущего метода
            for (int i = mx; i < n; i++) //запускаем цикл для вычисления максимального размера файла 
            {
                if ((sum - mx) + mass[i] <= s) //если из накопленной суммы вычесть max кол-во пользователей и прибавить значение максимального элемента массива, чтобы при этом в сумме получилось меньше или равно размеру свободного места на диске, будут выполняться команды...
                {
                    sum = sum - mx + mass[i]; //присваиваем сумме новое значение 
                    v = mass[i]; //присваиваем переменной значение элемента массива (максимального размера файла)
                }
            }
            return v; //вывод максимального размера файла 
        }
    }
}

