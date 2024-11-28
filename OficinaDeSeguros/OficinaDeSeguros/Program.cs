using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programa Oficina de Seguros  \n");

        //Solicitud a una funcion por la cantidad de conductores
        int cantidadConductores = solicitarCantidadConductores();

        //Se define un arreglo para guardar los datos procesados de la consulta de todos los conductores
        double[] datosConductores = new double[cantidadConductores];

        //Arreglo con valores porcentuales, segun el registro de datos previo
        datosConductores = procesarDatos(cantidadConductores);

        

        // Se muestran los resultados
        Console.WriteLine("\nResultados:\n");
        Console.WriteLine($"Porcentaje de conductores menores de 30 años: {datosConductores[0]:F2}%");
        Console.WriteLine($"Porcentaje de conductores masculinos: {datosConductores[1]:F2}%");
        Console.WriteLine($"Porcentaje de conductores femeninos: {datosConductores[2]:F2}%");
        Console.WriteLine($"Porcentaje de conductores masculinos entre 12 y 30 años: {datosConductores[3]:F2}%");
        Console.WriteLine($"Porcentaje de conductores con registro fuera de Bogotá: {datosConductores[4]:F2}%");
    }


    //Funcion para solicitar la cantidad de registros a procesar
    static int solicitarCantidadConductores()
    {
        // Se pide la cantidad de conductores a procesar
        Console.WriteLine("Ingrese el número de conductores que desea registrar:");
        int cantidadConductores = int.Parse(Console.ReadLine());
        return cantidadConductores;
    }

    // Función que retorna un arreglo con los porcentajes solicitados
    static double[] procesarDatos(int cantidadConductores)
    {
        // Se definen las variables
        int totalConductores = 0; // Total de conductores procesados
        int menores30 = 0; // Conductores menores de 30 años
        int hombres = 0; // Conductores masculinos
        int mujeres = 0; // Conductores femeninos
        int hombres12a30 = 0; // Conductores masculinos con edades entre 12 y 30 años
        int fueraBogota = 0; // Conductores con carros registrados fuera de Bogotá

        // Bucle para ingresar los datos de cada conductor
        for (int i = 0; i < cantidadConductores; i++)
        {
            Console.WriteLine($"Ingrese los datos del conductor {i + 1}:");

            int anioNacimiento;

            // Año de nacimiento
            while (true)
            {
                Console.Write("Año de nacimiento: ");
                string input = Console.ReadLine();

                // Se verifica si la entrada es un número entero
                if (int.TryParse(input, out anioNacimiento))
                {
                    break; // Si es un número entero, salimos del ciclo
                }
                else
                {
                    Console.WriteLine("Valor no válido. Por favor ingresa un número entero para el año de nacimiento.");
                }
            }

            int edad = DateTime.Now.Year - anioNacimiento; // Se calcula la edad

            // Condición para los conductores menores de 30 años
            if (edad < 30)
            {
                menores30++;
            }

            int sexo = solicitarSexoConductor(); // Funcion para solicitar el sexo del conductor

            // Condición para el sexo
            if (sexo == 1) // Femenino
            {
                mujeres++;
            }
            else if (sexo == 2) // Masculino
            {
                hombres++;

                // Condición para hombres con edades entre 12 y 30 años
                if (edad >= 12 && edad <= 30)
                {
                    hombres12a30++;
                }
            }

            int registroCarro = solicitarCiudadRegistro();// Funcion para solicitar la ciudad del accidente

            // Condición para carros registrados fuera de Bogotá
            if (registroCarro == 2)
            {
                fueraBogota++;
            }

            // Se aumenta el contador de conductores
            totalConductores++;
        }


        // Se calculan los porcentajes
        double porcentajeMenores30 = (double)menores30 / totalConductores * 100;
        double porcentajeHombres = (double)hombres / totalConductores * 100;
        double porcentajeMujeres = (double)mujeres / totalConductores * 100;
        double porcentajeHombres12a30 = 0;

        if (hombres > 0)
        {
            porcentajeHombres12a30 = (double)hombres12a30 / hombres * 100;
        }

        double porcentajeFueraBogota = (double)fueraBogota / totalConductores * 100;



        return new double[] { porcentajeMenores30, porcentajeHombres, porcentajeMujeres, porcentajeHombres12a30, porcentajeFueraBogota};
    }


    static int solicitarSexoConductor()
    {
        int sexo;

        while (true)
        {
            Console.Write("Sexo (Femenino: 1, Masculino: 2): ");
            sexo = int.Parse(Console.ReadLine());

            if (sexo == 1 || sexo == 2)
            {
                break; 
            }
            else
            {
                Console.WriteLine("Valor no válido. Por favor ingresa 1 para Femenino o 2 para Masculino.");
            }
        }

        return sexo;

    }


    static int solicitarCiudadRegistro()
    {

        int registroCarro;

        while (true)
        {
                Console.Write("Registro del carro ( Bogotá: 1, Otras ciudades: 2): ");
                registroCarro = int.Parse(Console.ReadLine());

                if (registroCarro == 1 || registroCarro == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor no válido. Por favor ingresa 1 para Bogota o 2 para otras ciudades.");
                }
        }

            return registroCarro;
    }

}
