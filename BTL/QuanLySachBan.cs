using System;
using System.IO;

namespace BTL
{

    internal class QuanLySachBan
    {
        private StreamReader sr;
        private StreamWriter sw;
        private string tentep = "sachban.txt";
        private string chitiet = "chitietsachban.txt";
        private QuanLySachBan quanLySachBan;
        public QuanLySachBan()
        {

        }

        public void HienthiSach()
        {

            sr = new StreamReader(tentep);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] tmp = s.Split('.');
                if (tmp.Length >= 3)
                {
                    // 3 cot: masach, ten sach, so luong
                    Console.WriteLine(tmp[0] + "\t\t" + tmp[1] + "\t\t" + tmp[2]);
                }
            }
            sr.Close();
        }

        public void HienChitiet()
        {
            Console.Write("Nhap ma sach de hien thi chi tiet: ");
            string masach = Console.ReadLine();
            sr = new StreamReader(chitiet);

            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] tmp = s.Split('.');
                if (tmp[0] == masach)
                {
                    // masach ten sach,tentg, the loai, NXB, ngay ban,giaban
                    Console.WriteLine(tmp[0] + "\t" + tmp[1] + "\t" + tmp[2] + "\t" + tmp[3] + "\t" + tmp[5] + "\t" + tmp[6] + "\t" + tmp[7]);

                }
            }

            sr.Close();
        }
        public void Them()
        {
            sw = new StreamWriter(tentep, true);
            Console.Write("Nhap ma sach: ");
            string masach = Console.ReadLine();
            Console.Write("Nhap ten sach: ");
            string tensach = Console.ReadLine();
            Console.Write("Nhap so luong: ");
            string soluong = Console.ReadLine();
            sw.WriteLine($"{masach}.{tensach}.{soluong}");
            sw.Close();

            Console.WriteLine("Nhap chi tiet hoa don ");
            sw = new StreamWriter(chitiet, true);
            while (true)
            {
                Console.Write("Nhap ma sach chi tiet: ");
                string masachct = Console.ReadLine();
                Console.Write("Nhap ten sach chi tiet: ");
                string tensachct = Console.ReadLine();
                Console.Write("Nhap ten tac gia: ");
                string tenTG = Console.ReadLine();
                Console.Write("Nhap the loai: ");
                string theloai = Console.ReadLine();
                Console.Write("Nhap NXB: ");
                string NXB = Console.ReadLine();
                Console.Write("Nhap gia ban: ");
                string giaban = Console.ReadLine();
                DateTime ngayNhap = DateTime.MinValue; 
                bool ngayHopLe = false;
                while (!ngayHopLe)
                {
                    Console.Write("Nhap ngay ban (dd/MM/yyyy): ");
                    string ngayNhapStr = Console.ReadLine();
                    if (DateTime.TryParseExact(ngayNhapStr, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out ngayNhap))
                    {
                        ngayHopLe = true;
                    }
                    else
                    {
                        Console.WriteLine("Ngay nhap khong hop le, vui long nhap theo dinh dang dd/MM/yyyy.");
                    }
                }

                sw.WriteLine($"{masachct}.{tensachct}.{tenTG}.{theloai}.{NXB}.{ngayNhap.ToString("dd/MM/yyyy")}.{giaban}");
                Console.Write("Ban co muon nhap tiep hay khong (yes/no): ");
                string s = Console.ReadLine();
                if (s.ToUpper() == "NO")
                    break;
            }
            sw.Close();
        }

        public void Xoa()
        {
            Console.Write("Nhap ma sach: ");
            string masach = Console.ReadLine();
            string data = "";
            sr = new StreamReader(tentep);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] tmp = s.Split('.');
                if (tmp[0] == masach)
                {
                    continue;
                }
                else
                {
                    data += tmp[0] + "." + tmp[1] + "." + tmp[2];

                }
            }
            sr.Close();
            sw = new StreamWriter(tentep);
            sw.Write(data);
            sw.Close();
            data = "";
            sr = new StreamReader(chitiet);
            while ((s = sr.ReadLine()) != null)
            {
                string[] tmp = s.Split('.');
                if (tmp[0] == masach)
                {
                    continue;
                }
                else
                {
                    data += tmp[0] + "." + tmp[1] + "." + tmp[2] + "." + tmp[3] + "." + tmp[4] + "." + tmp[5] + "." + tmp[6] + "";

                }
            }
            sr.Close();
            sw = new StreamWriter(chitiet);
            sw.Write(data);
            sw.Close();
        }
        public int LayGia(string maSach)
        {
            int gia = 0;
            using (StreamReader sr = new StreamReader(chitiet))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] tmp = s.Split('.');
                    if (tmp[0] == maSach)
                    {
                        gia = int.Parse(tmp[6]);
                        break;
                    }
                }
            }
            return gia;
        }

        public void Menu()
        {

            while (true)
            {

                Console.Clear();

                Console.WriteLine("\t\t╔══════════════════════ MENU ════════════════════════╗");
                Console.WriteLine("\t\t║            1. Hien thi danh sach                   ║");
                Console.WriteLine("\t\t║            2. Them                                 ║");
                Console.WriteLine("\t\t║            3. Xoa                                  ║");
                Console.WriteLine("\t\t║            4. Quay lai                             ║");
                Console.WriteLine("\t\t╚════════════════════════════════════════════════════╝");
                Console.Write("\t\tHay chon mot muc (1-4): ");
                string Tam = Console.ReadLine();
                if (Tam.Length == 1 && Tam[0] >= '1' && Tam[0] <= '4')
                {
                    int choice = int.Parse(Tam);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Ma sach\t\tTen sach\tSo Luong");
                            HienthiSach();
                            break;
                        case 2:
                            Them();
                            break;
                        case 3:
                            Xoa();
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
