using System;

namespace BTL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("\t\t╔══════════════════════ MENU ════════════════════════╗");
            Console.WriteLine("\t\t║            1. Quan ly sach nhap                    ║");
            Console.WriteLine("\t\t║            2. Quan ly sach ban                     ║");
            Console.WriteLine("\t\t║            3. Thong ke                             ║");
            Console.WriteLine("\t\t║            4. Hien thi kho                         ║");
            Console.WriteLine("\t\t║            5. Exit                                 ║");
            Console.WriteLine("\t\t╚════════════════════════════════════════════════════╝");
            Console.Write("\t\tNhap lua chon: ");
            string s = Console.ReadLine().Trim();
            Console.Clear();
            if (s == "1")
            {
                QuanLySachNhap obj = new QuanLySachNhap();
                obj.Menu();
            }
            else if (s == "2")
            {
                QuanLySachBan obj = new QuanLySachBan();
                obj.Menu();
            }
            else if (s == "3")
            {
                BaoCaoThongKe obj = new BaoCaoThongKe();
                obj.Menu();
            }
            else if (s == "4")
            {

                KhoSach obj = new KhoSach();
                obj.HienthiKhoSach();
                Console.ReadKey();
                Console.Clear();
                Menu();

            }
            else if (s == "5")
            {
                Environment.Exit(0);
            }
            Console.Clear();
            Menu();


        }
    }
}