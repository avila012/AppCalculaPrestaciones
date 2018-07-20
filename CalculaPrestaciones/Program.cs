using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculaPrestaciones
{
    class Program
    {

        public static void Main(string[] args)
        {
            DatosEmpleado();

            Console.ReadKey();



            /* Valores de prueba 

            int dias = Math.Abs((Convert.ToDateTime("01/06/2010").Date - Convert.ToDateTime("01/07/2018").Date).Days);
            int meses = dias / 30;
            int años = meses / 12;
            Console.WriteLine("Cantidad de días: {0}", dias);
            Console.WriteLine("Cantidad de Meses: {0}", meses);
            Console.WriteLine("Cantidad de Años: {0}", años);
            double sueldo = 60000 / 23.83;
            Console.WriteLine("Sueldo Diario: {0}", Math.Round(sueldo,2));

            Console.WriteLine("Cesantia: " + CalculaCesantia(sueldo,meses));
            Console.WriteLine("Preaviso: " + CalculaPreaviso(sueldo,meses));
            Console.WriteLine("Navidad: " + CalculaSalarioNavidad(sueldo,meses));
            Console.WriteLine("Vacaciones: " + CalculaVacaciones(sueldo,meses));
            
            Console.WriteLine(CalculaPreaviso(60000/23.83,96));
            
            */

        }


        static void DatosEmpleado()
        {
            bool preavisado, incluyeCesantia, incluyeVacaciones, incluyeSalarioNavidad;

            Console.Clear();
            Console.WriteLine("<<<<Programa Calcula las prestaciones del empleado>>>>");
            Espacio();

            Console.WriteLine("Introduzca los datos del empleado");
            EspacioDoble();
            Console.Write("Cedula Identidad (En formato 999-9999999-9): ");
            var cedula = Console.ReadLine();
            Espacio();
            Console.Write("Nombre Completo: ");
            var Nombre = Console.ReadLine();
            Espacio();
            Console.Write("Empresa: ");
            var empresa = Console.ReadLine();
            Espacio();

            Console.Write("Fecha Entrada (En formato dd/mm/aaaa): ");
            DateTime fechaEntrada = DateTime.Parse(Console.ReadLine());
            Espacio();

            Console.Write("Fecha Salida (En formato dd/mm/aaaa): ");
            DateTime fechaSalida = DateTime.Parse(Console.ReadLine());
            EspacioDoble();

            Console.Write("Sueldo Mensual: ");
            double sueldoMensual = double.Parse(Console.ReadLine());
            Espacio();

            Console.WriteLine("---Seleccione las inclusiones que competen---");
            Console.Write("Responder con 1: SI o 2:NO");
            EspacioDoble();

            Console.Write("Fué usted Pre-avisado?: ");
            preavisado = Console.ReadLine().Equals("1") ? true : false;
            Espacio();
            Console.Write("Desea incluir Cesantia?: ");
            incluyeCesantia = Console.ReadLine().Equals("1") ? true : false;
            Espacio();
            Console.Write("Tomó Vacaciones del ultimo año?: ");
            incluyeVacaciones = Console.ReadLine().Equals("1") ? true : false;
            Espacio();
            Console.Write("Incluir Salario Navidad?: ");
            incluyeSalarioNavidad = Console.ReadLine().Equals("1") ? true : false;
            Espacio();


            //Calcula Sueldo Diaria
            double sueldoDiario = sueldoMensual / 23.83;

            //Calcula Meses
            int dias = Math.Abs((fechaSalida.Date - fechaEntrada.Date).Days);

            DateTime fechaInicioAño = new DateTime(DateTime.Now.Year, 1, 1);

            int diasActual = Math.Abs((fechaInicioAño.Date - fechaSalida.Date).Days);

            int meses = ( dias / 30);

            int años = meses / 12;

            if (incluyeCesantia)
            {
                Console.WriteLine("Monto por Cesantía: {0}, años ({1}.)", CalculaCesantia(sueldoDiario, meses), años);
            }

            if (preavisado)
            {
                Console.WriteLine("Monto Preaviso: " + CalculaPreaviso(sueldoDiario, meses));
            }

            if (incluyeVacaciones)
            {
                Console.WriteLine("Monto Vacaciones: " + CalculaVacaciones(sueldoDiario, meses));
            }

            if (incluyeSalarioNavidad)
            {
                Console.WriteLine("salario Navidad: " + CalculaSalarioNavidad(sueldoMensual, fechaSalida, sueldoDiario));
            }
        }



        static double CalculaCesantia(double sueldo, int meses)
        {
            //Calcula el monto de acuerdo al tiempo del empleado en la empresa.

            if ((meses / 12) > 5) return Math.Round(((sueldo * 23) * (meses / 12)),2);
            else if (meses >= 1)  return Math.Round(((sueldo * 21) * (meses / 12)),2);
            else if (meses >= 6)  return Math.Round((sueldo * 13),2);
            else if (meses >= 3)  return Math.Round((sueldo * 6),2);
            else                  return 0;
        }


        static double CalculaPreaviso(double sueldo, int meses)
        {

            //Calcula el monto de acuerdo al tiempo del empleado en la empresa.

            if (meses >= 12)      return Math.Round((sueldo * 28), 2);
            else if (meses >= 6)  return Math.Round((sueldo * 14), 2);
            else if (meses >= 3)  return Math.Round((sueldo * 7), 2);
            else                  return 0;

        }


        static double CalculaVacaciones(double sueldo, int meses)
        {
            //Calcula el monto de acuerdo al tiempo del empleado en la empresa.

            if (meses >= 60) return Math.Round((sueldo * 18), 2);
            else if (meses >= 12) return Math.Round((sueldo * 14), 2);
            else return 0;

        }


        static double CalculaSalarioNavidad(double sueldoTotal, DateTime fSalida, double sueldoDia)
        {
            //Calcula el monto de acuerdo al tiempo del empleado en la empresa.

            return Math.Round((((sueldoTotal / 12) * (fSalida.Month - 1)) + (sueldoDia * fSalida.Day)), 2);

        }


        static void Espacio()
        {
            Console.WriteLine();
        }


        static void EspacioDoble()
        {
            Console.WriteLine();
            Console.WriteLine();
        }
        
    }
}

