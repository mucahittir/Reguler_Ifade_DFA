using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reguler_ifade
{
    class Program
    {
        //Her bir durum için ayrı bir method yazıldı ve methodların rekürsiflik özelliğinden yararlanılarak durumların diğer durumlara geçişi sağlandı.
        public static bool Durum1(string karakterKatari, int harfIndex)
        {
            if (karakterKatari.Length == 0 || karakterKatari.Length == harfIndex)
                return true;
            else if (karakterKatari[harfIndex] == 'a')
            {
                harfIndex++;
                return Durum2(karakterKatari, harfIndex);
            }

            else if (karakterKatari[harfIndex] == 'b')
            {
                harfIndex++;
                return Durum3(karakterKatari, harfIndex);
            }
            else
                return false;
        }

        public static bool Durum2(string karakterKatari, int harfIndex)
        {
            if (karakterKatari.Length == harfIndex)
                return false;
            else if (karakterKatari[harfIndex] == 'a')
            {
                harfIndex++;
                return Durum4(karakterKatari, harfIndex);
            }
            else if (karakterKatari[harfIndex] == 'b')
            {
                harfIndex++;
                return Durum1(karakterKatari, harfIndex);
            }
            else
                return false;

        }
        public static bool Durum3(string karakterKatari, int harfIndex)
        {
            if (karakterKatari.Length == harfIndex)
                return false;
            else if (karakterKatari[harfIndex] == 'a')
            {
                harfIndex++;
                return Durum3(karakterKatari, harfIndex);
            }
            else if (karakterKatari[harfIndex] == 'b')
            {
                harfIndex++;
                return Durum1(karakterKatari, harfIndex);
            }
            else
                return false;
        }
        public static bool Durum4(string karakterKatari, int harfIndex)
        {
            if (karakterKatari.Length == harfIndex)
                return true;
            else if (karakterKatari[harfIndex] == 'a')
            {
                harfIndex++;
                return Durum2(karakterKatari, harfIndex);
            }
            else if (karakterKatari[harfIndex] == 'b')
            {
                harfIndex++;
                return Durum4(karakterKatari, harfIndex);
            }
            else
                return false;

        }
        static void Main(string[] args)
        {

            //Bu program Deterministic Finite Automata makinesinin simülatörü olarak tasarlandı.
            //Öncelikle uygulanması gereken regüler ifade: L=((a+b)*ab+(aa)*(bb)*)*
            string karakterKatari;
            //Programın kullanıcı isteği dışında sonlanmaması için sonsuz döngüye sokuldu.
            while(true)
            {
                char cikis;
                Console.WriteLine("Bir karakter katarı giriniz");
                karakterKatari = Console.ReadLine();
                int harfIndex = 0;
                //Yazılan Kontrol mekanizması ile karakter katarının regüler ifadeye uygunluğu test ediliyor.
                if(Durum1(karakterKatari,harfIndex) == true)
                {
                    Console.WriteLine("Bu karakter katarı, tanımlamış olduğunuz dile aittir.");
                }
                else if (Durum1(karakterKatari, harfIndex) == false)
                {
                    Console.WriteLine("Bu karakter katarı, tanımlamış olduğunuz dile ait değildir.");
                }
                Console.WriteLine("Programdan çıkmak için x tuşuna, devam etmek için herhangi bir tuşa basınız.");
                cikis = Console.ReadKey().KeyChar;
                if (cikis == 'x')
                    break;
            }
        }
    }
}
