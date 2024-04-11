using System;
using System.IO;

namespace BTL
{

    internal class BaoCaoThongKe
    {
        private StreamReader sr;
        private string chitiet = "chitietsachban.txt";
        private QuanLySachBan quanLySachBan;

        public BaoCaoThongKe()
        {
            quanLySachBan = new QuanLySachBan();
        }
        public string LayGiaBan(string masachct)
        {
            using (StreamReader sr = new StreamReader("chitietsachnhap.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] tmp = s.Split('.');
                    if (tmp[0] == masachct)
                        return tmp[6];
                }
            }
            return "";
        }
        public int LaySLBan()
        {
            int slBan = 0;
            using (StreamReader sr = new StreamReader("sachban.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] tmp = s.Split('.');
                    slBan += int.Parse(tmp[2]);
                }
            }
            return slBan;
        }
        public void ThongKeTheoNgay()
        {
            int gia = int.Parse(LayGiaBan(masachct));
        }
        public void ThongKeTheoThang()
        {

        }
        public void ThongKeTheoNam()
        {

        }

        public void Menu()
        {

            while (true)
            {



                Console.Clear();

                Console.WriteLine("\t\t╔══════════════════════ MENU ════════════════════════╗");
                Console.WriteLine("\t\t║            1. Thong ke theo ngay                   ║");
                Console.WriteLine("\t\t║            2. Thong ke theo thang                  ║");
                Console.WriteLine("\t\t║            3. Thong ke theo nam                    ║");
                Console.WriteLine("\t\t║            4. Quay lai                             ║");
                Console.WriteLine("\t\t╚════════════════════════════════════════════════════╝");
                Console.Write("\n\t\t\tHay chon mot muc (1-4):");

                string Tam = Console.ReadLine();
                if (Tam.Length == 1 && Tam[0] >= '1' && Tam[0] <= '4')
                {
                    int choice = int.Parse(Tam);
                    switch (choice)
                    {
                        case 1:
                            ThongKeTheoNgay();
                            break;
                        case 2:
                            ThongKeTheoThang();
                            break;
                        case 3:
                            ThongKeTheoNam();
                            break;
                        case 4:
                            return;

                    }
                }
                Console.ReadKey();
            }
        }
    }
}
