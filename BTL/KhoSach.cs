using System;
using System.IO;

namespace BTL
{
    internal class KhoSach
    {
        private string tentep = "khosach.txt";
        private int slNhap;
        private int slBan;
        public KhoSach()
        {
        }

        public void HienthiKhoSach()
        {
            int slNhap = LaySLNhap();
            int slBan = LaySLBan();

            // Mở tệp để ghi dữ liệu vào
            using (StreamWriter sw = new StreamWriter(tentep))
            {
                // Mở tệp để đọc dữ liệu từ tệp sachnhap.txt
                using (StreamReader sr = new StreamReader("sachnhap.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] tmp = s.Split('.');
                        int slTonKho = slNhap - slBan;
                        string gianhap = LayGiaNhap(tmp[0]);
                        string giaban = LayGiaBan(tmp[0]);
                        // Ghi dữ liệu vào tệp khosach.txt
                        sw.WriteLine($"{tmp[0]}\t{tmp[1]}\t{slTonKho}\t{gianhap}\t{giaban}");
                    }
                }
            }

            // Hiển thị dữ liệu từ tệp khosach.txt ra màn hình
            Console.WriteLine("Ma sach\t\tTen sach\tSo luong ton\tGia nhap\tGia ban");
            using (StreamReader sr = new StreamReader(tentep))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    string fomatdata = $"{data[0], -16}{data[1],-16}{data[2],-16}{data[3],-16}{data[4],-16}";
                    Console.WriteLine(fomatdata);
                }
            }
        }

        public int LaySLNhap()
        {
            int slNhap = 0;
            using (StreamReader sr = new StreamReader("sachnhap.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] tmp = s.Split('.');
                    if (tmp.Length >= 3)
                    {
                        slNhap += int.Parse(tmp[2]);
                    }
                }
            }
            return slNhap;
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

        public string LayGiaNhap(string masachct)
        {
            using (StreamReader sr = new StreamReader("chitietsachban.txt"))
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
    }
}

