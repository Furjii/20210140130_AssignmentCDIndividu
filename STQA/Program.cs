using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA
{
    /// <summary>
    /// Node class
    /// </summary>
    /// <remarks> class node berisi variabel namaObat, dssObat, hargaObat,idObat </remarks>
    class Node
    {

        public string namaObat, dssObat, hargaObat;
        public int idObat;
        public Node next;
        public Node prev;

    }
    /// <summary>
    /// main class
    /// </summary>
    /// <remarks> class program dapat melakukan penambahan, pencarian,penambahan, pengurutan dan pengahapusan </remarks>
    class Program
    {
        /// <summary>
        /// Class program
        /// </summary>
        /// <remarks> mendeklarasikan node sebagai null </remarks>
       
        Node START;
        public Program()
        {
            START = null;
        }
        /// <summary>
        /// Operasi pencarian
        /// </summary>
        /// <param name="dssObat">jenis barang yang dicari</param>
        /// <param name="previous">node sebelum code current</param>
        /// <param name="current">node yang sedang ditempati</param>
        /// <returns>hasil dari pencarian</returns>
        public bool Search(string dssObat, ref Node previous, ref Node current)
        {
            for (current = previous = START; current != null && string.Compare(dssObat, current.dssObat) == 0; previous = current, current = current.next)
            {
                Console.WriteLine(" -> " + current.dssObat + "  " + current.idObat + "  " + current.namaObat + "  " + current.hargaObat + "  ");
            }
            return (current != null);
        }
        /// <summary>
        /// operasi jika list tidak ada
        /// </summary>
        /// <returns>jika data tidak ada akan mengembalikan perintah program bahwa data kosong, jika ada akan melanjutkan operasi program </returns>
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// operasi pengurutan data
        /// </summary>
        /// <remarks> jika data masih kosong akan menampilkan tulisan "data kosong", jika data tersedia makan akan otomatis menampilkan data secara ber-urutan </remarks>
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData kosong!");
            else
            {
                Console.WriteLine("\nData Obat yang tersedia adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.idObat + " " + currentNode.namaObat + " " + currentNode.dssObat + " " + currentNode.hargaObat + "\n");
            }
        }
        /// <summary>
        /// Operasi Pengurutan data
        /// </summary>
        /// <remarks> jika data masih kosong akan menampilkan tulisan "data kosong", jika data tersedia makan akan otomatis menampilkan data secara berurutan dari yang terbanyak </remarks>
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData Obat kosong");
            else
            {
                Console.WriteLine("\nData Obat dari urutan terbawah " + "adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null; currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.idObat + " " + currentNode.namaObat + " " + currentNode.dssObat + " " + currentNode.hargaObat + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        /// <summary>
        /// Operasi Penambahan data
        /// </summary>
        /// <remarks>pertama akan ada printah untuk mengisi id, nama, dosis, dan harga, jika data yang dimasukkan duplikat maka akan menampilkan kata "Data duplikat tidak diperbolehkan" </remarks>
        public void addobat()
        {
            Console.Write("\nMasukkan id obat: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Obat: ");
            string nama = Console.ReadLine();
            Console.Write("\nMasukkan dosis Obat: ");
            string dosis = Console.ReadLine();
            Console.Write("\nMasukkan harga Obat: ");
            string harga = Console.ReadLine();

            Node newnode = new Node();
            newnode.idObat = id;
            newnode.namaObat = nama;
            newnode.hargaObat = harga;
            newnode.dssObat = dosis;


            if (START == null || id == START.idObat)
            {
                if ((START != null) && (id == START.idObat))
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                id != current.idObat; previous = current, current =
                current.next)
            {
                if (id == current.idObat)
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        /// <summary>
        /// Operasi menghapus data
        /// </summary>
        /// <param name="dssObat"> dosis obat yang akan dihapus </param>
        /// <returns> data dosis obat yang dipilih akan dihapus </returns>
        public bool delObat(string dssObat)
        {
            Node previous, current;
            previous = current = null;
            if (Search(dssObat, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;

            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        /// <summary>
        /// Tampilan utama program
        /// </summary>
        /// <param name="args">untuk meneruskan argumen</param>
        /// <remarks> Program yang akan menampilkan semua data, menampilkan data, mencari data, mengurutkan data dari urutan terbawah, 
        /// menambahkan data, menghapus data dan opsi Exit, dari program dengan opsi pilihan menggunakan korespondensi dengan angka yang
        /// sudah di format sesuai dengan ketentuan. jika memilih salah satu perintah akan menjalankan perintah tersebut, jika memilih angka diluar perintah maka program akan error </remarks>
        static void Main(string[] args)
        {
            Program p = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu Apotek" +
                        "\n 1. Menampilkan semua data Obat" +
                        "\n 2. Mencari sebuah data Obat" +
                        "\n 3. Menampilkan data dari urutan terbawah" +
                        "\n 4. Menambah data Obat" +
                        "\n 5. Menghapus data Obat" +
                        "\n 6. Keluar" +

                        "\n Masukkan pilihan anda (1 - 6): "
                        );
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                p.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData kosong!");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("Masukkan dosis Obat yang ingin dicari: ");
                                string dssObat = Console.ReadLine();
                                if (p.Search(dssObat, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan!");
                                    Console.WriteLine("\nID Obat " + curr.idObat);
                                    Console.WriteLine("\nNama Obat " + curr.namaObat);
                                    Console.WriteLine("\nDosis Obat " + curr.dssObat);
                                    Console.WriteLine("\nHarga Obat " + curr.hargaObat);

                                }
                            }
                            break;
                        case '3':
                            {
                                p.revtraverse();
                            }
                            break;
                        case '4':
                            {

                                p.addobat();
                            }
                            break;
                        case '5':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData Obat Kosong!");
                                    break;
                                }
                                Console.Write("Masukkan dosis obat dari data" + " yang datanya ingin dihapus: ");
                                string dssObat = Console.ReadLine();
                                Console.WriteLine();
                                if (p.delObat(dssObat) == false)
                                    Console.WriteLine("Data tidak ditemukan!");
                                else
                                    Console.WriteLine("Data Dosis Obat " + dssObat + " telah terhapus \n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan salah!");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}