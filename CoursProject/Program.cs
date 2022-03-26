using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursProject
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessageBox.Show("Курсовой проект на тему: \n" +
                "Разработка программы сложной структуры методом нисходящего программирования. ИС «Аптека»\n" +
                "Выполнил студент группы 19ВП1 \n" +
                "Сергеев Александр");
            Application.Run(new Form1());
        }
    }
}
