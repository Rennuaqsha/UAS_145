using System;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Uas
{

    class node
    {
        public int No_Buku;
        public string Jdl_Buku;
        private string nm_Pengarang;
        public int thn_Terbit;
        public node next;

        public string Nm_Pengarang { get => nm_Pengarang; set => nm_Pengarang = value; }
    }

    class list
    {
        node START;

        public list()
        {
            START = null;
        }

        public void addNote()
        {
            int no_buku;
            string jdl_Buku;
            string nm_Pengarang;
            int thn_Terbit;
            Console.Write("\n Masukkan Nomor Buku yang dicari : ");
            no_buku = (int)Convert.ToInt64(Console.ReadLine());
            Console.Write("\n Masukkan Judul Buku yang dicari : ");
            jdl_Buku = Console.ReadLine();
            Console.Write("\n masukkan nama pengarang : ");
            nm_Pengarang = Console.ReadLine();
            Console.Write("\n Masukkan Tahun Terbit buku : ");
            thn_Terbit = Convert.ToInt32(Console.ReadLine());
            node newnode = new node();
            newnode.thn_Terbit = thn_Terbit;
            newnode.Jdl_Buku = jdl_Buku;

            if(START != null || (thn_Terbit == START.thn_Terbit))
            {
                if ((START != null ) && (thn_Terbit == START.thn_Terbit))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            node previous, current;
            previous = START;
            current = START;
            while ((current != null) && (thn_Terbit >= current.thn_Terbit))
            {
                if(thn_Terbit == current.thn_Terbit)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                current.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }

        public bool delnode(int thn_Terbit)
        {
            node previous, current;
            previous = current = null;
            if (search(thn_Terbit, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool search(int thn_Terbit, ref node previous, ref node current)
        {
            previous = current;
            current = current.next;
            while ((current != null) && (thn_Terbit != current.No_Buku))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }

        public void Traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nThe records in the list are: ");
            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                node currentNode;
                for (currentNode = START; currentNode != null; 
                    currentNode = currentNode.next)
                    Console.Write(currentNode.thn_Terbit + " " + currentNode.No_Buku + "\n");
                Console.WriteLine();
            }
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }


    }
    class program
    {

        static void main(string[] args)
        {
            list obj = new list();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Masukkan Nama pengarang ");
                    Console.WriteLine("2. hapus nama dilist ");
                    Console.WriteLine("3. menampilkan Tahun Terbit yang sama ");
                    Console.WriteLine("4. Menampilkan semua data buku yang ada ");
                    Console.WriteLine("5. Exit");
                    Console.Write("\n Enter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if(obj.listEmpty())
                                {
                                    Console.WriteLine("\n list telah kosong ");
                                }
                                Console.WriteLine("Masukkan Tahun buku dan " + "nama pengarang :");
                                int no_Buku = Convert.ToInt32(Console.ReadLine());
                                if (obj.delnode(no_Buku) == false)
                                    Console.WriteLine("\n record not found.");
                                else
                                    Console.WriteLine("\n record with roll number" + +no_Buku + "Deleted");
                            }
                            break;

                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;


                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                node previous, current;
                                previous = current = null;
                                Console.Write("\n Masukkan Tahun Buku yang dicari " + "dan Nama pengarang : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord Not Found");
                                else
                                {
                                    Console.WriteLine("\nrecord not found");
                                    Console.WriteLine("\nRoll number: " + current.No_Buku);
                                    Console.WriteLine("\nName:" + current.Nm_Pengarang);
                                }
                            }
                            break;

                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value Entered");
                }
            }
        }


    }



}


//3. Operasi yang digunakan dalam algorithma stack ada 2 yaitu : PUSH AND POP 

//4.  REAR and FONT 

//5. A. 5 
//   B. IN ORDER
