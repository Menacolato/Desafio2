
{
    
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine("==================================");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("    REGISTRO DE CUMPLEAÑOS");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("==================================\n");

        int cantidad = PedirCantidadPersonas();
        string[,] personas = new string[cantidad, 4];

        LlenarDatos(personas);
        MostrarMenu(personas);
    }

    static int PedirCantidadPersonas()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("¿Cuántas personas vas a registrar? ");
        Console.ForegroundColor = ConsoleColor.Black;
        return int.Parse(Console.ReadLine());
    }

    static void LlenarDatos(string[,] personas)
    {
        for (int i = 0; i < personas.GetLength(0); i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n[Persona {i + 1}]");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("Nombre: ");
            personas[i, 0] = Console.ReadLine();

            Console.Write("Día de nacimiento (DD): ");
            personas[i, 1] = Console.ReadLine();

            Console.Write("Mes de nacimiento (MM): ");
            personas[i, 2] = Console.ReadLine();

            Console.Write("Año de nacimiento (AAAA): ");
            personas[i, 3] = Console.ReadLine();
        }
    }

    static void MostrarMenu(string[,] personas)
    {
        bool salir = false;

        while (!salir)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n----- MENÚ PRINCIPAL -----");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("1. Ver cumpleaños de hoy");
            Console.WriteLine("2. Buscar por fecha");
            Console.WriteLine("3. Salir");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\nElige una opción: ");
            Console.ForegroundColor = ConsoleColor.Black;

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CumpleHoy(personas);
                    break;
                case "2":
                    BuscarFecha(personas);
                    break;
                case "3":
                    salir = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n¡Hasta pronto!\n");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }
        }
    }

    static void CumpleHoy(string[,] personas)
    {
        DateTime hoy = DateTime.Now;
        bool hayCumples = false;

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"\n[Hoy {hoy.Day}/{hoy.Month}/{hoy.Year}]");
        Console.ForegroundColor = ConsoleColor.Black;

        for (int i = 0; i < personas.GetLength(0); i++)
        {
            int dia = int.Parse(personas[i, 1]);
            int mes = int.Parse(personas[i, 2]);

            if (dia == hoy.Day && mes == hoy.Month)
            {
                int año = int.Parse(personas[i, 3]);
                int edad = hoy.Year - año;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("¡Cumpleaños! ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"{personas[i, 0]} cumple {edad} años");
                hayCumples = true;
            }
        }

        if (!hayCumples)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Nadie cumple años hoy");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }

    static void BuscarFecha(string[,] personas)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("\n--- BUSCAR POR FECHA ---");
        Console.ForegroundColor = ConsoleColor.Black;

        Console.Write("Día (DD): ");
        int diaBuscar = int.Parse(Console.ReadLine());

        Console.Write("Mes (MM): ");
        int mesBuscar = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"\nResultados para {diaBuscar}/{mesBuscar}:");
        Console.ForegroundColor = ConsoleColor.Black;

        bool encontrado = false;

        for (int i = 0; i < personas.GetLength(0); i++)
        {
            int dia = int.Parse(personas[i, 1]);
            int mes = int.Parse(personas[i, 2]);

            if (dia == diaBuscar && mes == mesBuscar)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"- {personas[i, 0]}");
                Console.ForegroundColor = ConsoleColor.Black;
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("No se encontraron cumpleaños para esta fecha");
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
