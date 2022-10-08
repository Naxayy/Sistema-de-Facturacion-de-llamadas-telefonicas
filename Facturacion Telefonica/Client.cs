using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion_Telefonica
{
    internal class Client
    {
        public string name; //nombre del cliente
        public int id;  //numero de cliente 6 cifras

        /*
        Se entiende que los tipos de llamadas son los siguientes:

        TIPO A: Lun a Vie / 8hs a 20hs == $0.20/min
		TIPO B: Lun a Vie / 20hs a 8hs == $0.10/min
		TIPO C: Sab y Dom / $0.10/min
        TIPO D costo segun localidad
        TIPO E costo segun pais 
        */
        public string call;
        public string subscription;    //tipo de suscripcion BASIC
        public int minutes; //cantidad de minutos hablados
        public double amount;   //coste de llamadas por minuto
        public double amount_subs;  //coste de suscripcion
        public double total;    //coste total

        public Client(string name, int id, string call, string subscription, int minutes)
        {
            this.name = name;
            this.id = id;
            this.call = call;
            this.subscription = subscription;
            this.minutes = minutes;
            
            
        }
        public double VariablCost()
        {
            if (call == "A")
            {
                amount = this.minutes * 0.20;
            }
            else if (call == "B" || call == "C")
            {
                amount = this.minutes * 0.10;
            }
            else if (call == "D")
            {
                amount = this.minutes * 0.25;
            }
            else if (call == "E")
            {
                amount = this.minutes * 0.30;
            }
            

            return amount;
        }
        
        public double Subscription()
        {
            if(subscription == "BASIC")
            {
                this.amount_subs = 900;
            }
            
            return amount_subs;           
        }

        public double TotalCost()
        {
            total = this.VariablCost() + this.Subscription();

            return total;
        }

    }
}
