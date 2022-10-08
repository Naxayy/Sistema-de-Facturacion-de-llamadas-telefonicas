using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Telefonica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            byte menu;
            menu:            
            Console.WriteLine("****************************");
            Console.WriteLine("*                          *");
            Console.WriteLine("*  Facturacion Telefonica  *");
            Console.WriteLine("*                          *");
            Console.WriteLine("****************************");
            Console.WriteLine();
            Console.WriteLine("Menu (1-2)");
            Console.WriteLine();
            Console.WriteLine("1- Datos de Clientes");
            Console.WriteLine("2- Calcular costos de clientes");
            Console.WriteLine("3- Exit");
            Console.WriteLine();
            menu = Convert.ToByte(Console.ReadLine());

            Console.Clear();

            switch(menu)
            {
                case 1:
                    DataClient();
                    goto menu;
                case 2:
                    Calculate();
                    goto menu;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    goto menu;
            }
            
            Console.ReadKey();
        }

        public static void DataClient()
        {
            /*
            En el lanzamiento de la app, los tipos de las llamadas (A B C D E) se determinan previamente en una base de datos. Lo mismo
            con el tipo de suscripcion, el id de cliente, el nombre del cliente y los minutos de las llamadas realizadas.
            
            Los costos de las llamadas las clasifique en una letra para fines mas practicos y reducir el margen de error en el tipeo.
            */

            /* A continuacion cree unos datos locales basados en objetos para testear la app*/

            Client client_1 = new Client("Maria", 249652, "A", "BASIC", 120);

            Client client_2 = new Client("Jose", 598233, "B", "BASIC", 60);

            Client client_3 = new Client("Natalia", 451870, "C", "BASIC", 58);

            Client client_4 = new Client("Benjamin", 899540, "D", "BASIC", 63);

            Client client_5 = new Client("Rosa", 256740, "E", "BASIC", 17);

            int menu; //declaro variable de tipo int para agregar futuras opciones
            menu:
            Console.WriteLine();
            Console.WriteLine("Ingrese una opcion (0-5):");
            Console.WriteLine();
            Console.WriteLine("0- Volver");
            Console.WriteLine();
            Console.WriteLine("1- Maria");
            Console.WriteLine("2- Jose");
            Console.WriteLine("3- Natalia");
            Console.WriteLine("4- Benjamin");
            Console.WriteLine("5- Rosa");
            Console.WriteLine();
            menu = int.Parse(Console.ReadLine());

            Console.Clear();

            switch(menu)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("FACTURA");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Nombre: " + client_1.name);
                    Console.WriteLine("Nro. de Cliente: " + client_1.id);
                    Console.WriteLine("Tipo de llamada: " + client_1.call);
                    Console.WriteLine("Tipo de Plan: " + client_1.subscription);
                    Console.WriteLine("Minutos en llamada: " + client_1.minutes);
                    Console.WriteLine("Costo variable: $" + client_1.VariablCost());
                    Console.WriteLine("Costo del plan: $" + client_1.Subscription());
                    Console.WriteLine("Total a Pagar: $" + client_1.TotalCost());                    
                    goto menu;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("FACTURA");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Nombre: " + client_2.name);
                    Console.WriteLine("Nro. de Cliente: " + client_2.id);
                    Console.WriteLine("Tipo de llamada: " + client_2.call);
                    Console.WriteLine("Tipo de Plan: " + client_2.subscription);
                    Console.WriteLine("Minutos en llamada: " + client_2.minutes);
                    Console.WriteLine("Costo variable: $" + client_2.VariablCost());
                    Console.WriteLine("Costo del plan: $" + client_2.Subscription());
                    Console.WriteLine("Total a Pagar: $" + client_2.TotalCost());
                    goto menu;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("FACTURA");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Nombre: " + client_3.name);
                    Console.WriteLine("Nro. de Cliente: " + client_3.id);
                    Console.WriteLine("Tipo de llamada: " + client_3.call);
                    Console.WriteLine("Tipo de Plan: " + client_3.subscription);
                    Console.WriteLine("Minutos en llamada: " + client_3.minutes);
                    Console.WriteLine("Costo variable: $" + client_3.VariablCost());
                    Console.WriteLine("Costo del plan: $" + client_3.Subscription());
                    Console.WriteLine("Total a Pagar: $" + client_3.TotalCost());
                    goto menu;
                case 4:
                    Console.WriteLine();
                    Console.WriteLine("FACTURA");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Nombre: " + client_4.name);
                    Console.WriteLine("Nro. de Cliente: " + client_4.id);
                    Console.WriteLine("Tipo de llamada: " + client_4.call);
                    Console.WriteLine("Tipo de Plan: " + client_4.subscription);
                    Console.WriteLine("Minutos en llamada: " + client_4.minutes);
                    Console.WriteLine("Costo variable: $" + client_4.VariablCost());
                    Console.WriteLine("Costo del plan: $" + client_4.Subscription());
                    Console.WriteLine("Total a Pagar: $" + client_4.TotalCost());
                    goto menu;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("FACTURA");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Nombre: " + client_5.name);
                    Console.WriteLine("Nro. de Cliente: " + client_5.id);
                    Console.WriteLine("Tipo de llamada: " + client_5.call);
                    Console.WriteLine("Tipo de Plan: " + client_5.subscription);
                    Console.WriteLine("Minutos en llamada: " + client_5.minutes);
                    Console.WriteLine("Costo variable: $" + client_5.VariablCost());
                    Console.WriteLine("Costo del plan: $" + client_5.Subscription());
                    Console.WriteLine("Total a Pagar: $" + client_5.TotalCost());
                    goto menu;
                default:
                    Console.WriteLine("Opcion invalida");                    
                    goto menu;
            }            
        }

        public static void Calculate()
        {
            Client_test test_client = new Client_test();
            char reply;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese el nombre del cliente: ");
                test_client.name = Console.ReadLine();
                Console.Clear();
                
                back1:
                Console.WriteLine();        
                Console.WriteLine("Ingrese el nro de cliente (entre 100000 y 999999): ");
                test_client.id = int.Parse(Console.ReadLine());
                Console.Clear();
                if (test_client.id < 100000 || test_client.id > 999999)
                {
                    Console.WriteLine("Valor invalido");
                    goto back1;
                }                
                
                back2:
                Console.WriteLine();
                Console.WriteLine("Ingrese el tipo de plan: ");
                test_client.subscription = Convert.ToString(Console.ReadLine());
                
                Console.Clear();
                if (test_client.subscription != "BASIC")
                {
                    Console.WriteLine("Valor invalido");
                    goto back2;
                }

                back3:
                Console.WriteLine();
                Console.WriteLine("Ingrese el tipo de llamada (A B C D E): ");
                test_client.call = Convert.ToString(Console.ReadLine());                
                Console.Clear();
                if (test_client.call != "A" && test_client.call != "B" && test_client.call != "C" && test_client.call != "D" && test_client.call != "E")
                {   
                    Console.WriteLine("Valor invalido");
                    goto back3;
                }


                back4:
                Console.WriteLine();
                Console.WriteLine("Ingrese los minutos en llamada: ");
                test_client.minutes = int.Parse(Console.ReadLine());
                if (test_client.minutes < 0 || test_client.minutes > 43800)
                {
                    Console.WriteLine("Valor invalido");
                    goto back4;
                }

                Console.WriteLine();
                Console.WriteLine("FACTURA");
                Console.WriteLine("-----------------");
                Console.WriteLine("Nombre: " + test_client.name);
                Console.WriteLine("Nro. de Cliente: " + test_client.id);
                Console.WriteLine("Tipo de llamada: " + test_client.call);
                Console.WriteLine("Tipo de Plan: " + test_client.subscription);
                Console.WriteLine("Minutos en llamada: " + test_client.minutes);
                Console.WriteLine("Costo variable: $" + test_client.VariablCost());
                Console.WriteLine("Costo del plan: $" + test_client.Subscription());
                Console.WriteLine("Total a Pagar: $" + test_client.TotalCost());

                Console.WriteLine();           
                Console.WriteLine("Calcular otra factura? (y/n)");
                reply = Convert.ToChar(Console.ReadLine());
                
                Console.Clear();

            } while (reply == 'y');

            
        }        
    }
}
