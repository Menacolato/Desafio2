
{
    {
        // Configuración inicial de colores
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear(); // Aplicar los colores a toda la consola

        bool jugarDeNuevo = true;

        while (jugarDeNuevo)
        {
            // Inicialización del juego
            string[] palabras = { "programacion", "computadora", "tecnologia", "juego", "aprendizaje", "desarrollador" };

            string[,] pistas = {
                { "Es un campo de estudio relacionado con las computadoras.", "Se utiliza para crear software.", "Se necesita un lenguaje para desarrollarla.", "Es una actividad que requiere lógica.", "Está presente en todos los dispositivos." },
                { "Es un dispositivo electrónico.", "Se utiliza para realizar cálculos.", "Tiene una pantalla y un teclado.", "Se utiliza para trabajar y aprender.", "Es una herramienta indispensable en la vida moderna." },
                { "Se refiere a los avances y herramientas tecnológicas.", "Es el motor de la innovación en la actualidad.", "En ella se realizan desarrollos innovadores.", "Impulsa la digitalización en todos los sectores.", "Se asocia con la informática y la ciencia." },
                { "Es una actividad recreativa.", "Puede ser de mesa o digital.", "A menudo involucra un desafío.", "Los videojuegos son una forma de juego.", "Se disfruta en ratos de ocio." },
                { "Proceso mediante el cual se adquieren conocimientos.", "Es un proceso continuo.", "Puede ser formal o informal.", "Nos permite mejorar nuestras habilidades.", "Es una parte clave en el crecimiento personal." },
                { "Es una persona que escribe código.", "Su trabajo involucra programar.", "Desarrolla aplicaciones y software.", "Utiliza diversos lenguajes de programación.", "Puede trabajar de manera independiente o en equipo." }
            };

            Random rand = new Random();
            int indicePalabra = rand.Next(0, palabras.Length);
            string palabraSecreta = palabras[indicePalabra];
            char[] palabraOculta = new char[palabraSecreta.Length];

            for (int i = 0; i < palabraOculta.Length; i++)
            {
                palabraOculta[i] = '_';
            }

            int intentosRestantes = 6;
            int intentosFallidos = 0;
            bool haGanado = false;
            HashSet<char> letrasIntentadas = new HashSet<char>();

            // Mensaje de bienvenida con colores
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("¡Bienvenido al juego del Ahorcado!");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Tienes que adivinar la palabra secreta (tiene {palabraSecreta.Length} letras).");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Tienes un máximo de {intentosRestantes} intentos.");
            Console.ForegroundColor = ConsoleColor.Black;

            // Bucle principal del juego
            while (intentosRestantes > 0 && !haGanado)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\nPalabra actual: {string.Join(" ", palabraOculta)}");
                Console.ForegroundColor = intentosRestantes > 3 ? ConsoleColor.DarkGreen : ConsoleColor.Red;
                Console.WriteLine($"Intentos restantes: {intentosRestantes}");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"Letras intentadas: {string.Join(", ", letrasIntentadas)}");
                Console.ForegroundColor = ConsoleColor.Black;

                // Mostrar pista después del primer intento fallido
                if (intentosFallidos > 0 && intentosFallidos <= pistas.GetLength(1))
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"Pista: {pistas[indicePalabra, intentosFallidos - 1]}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                // Solicitar y validar entrada del usuario
                char letra;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("Ingresa una letra: ");
                    string entrada = Console.ReadLine();

                    if (!string.IsNullOrEmpty(entrada) && entrada.Length == 1)
                    {
                        letra = char.ToLower(entrada[0]);

                        if (!char.IsLetter(letra))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Por favor, ingresa una letra válida.");
                            continue;
                        }

                        if (letrasIntentadas.Contains(letra))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Ya has intentado con esa letra. Prueba con otra.");
                        }
                        else
                        {
                            letrasIntentadas.Add(letra);
                            break;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Por favor, ingresa exactamente una letra.");
                    }
                }

                // Verificar si la letra está en la palabra secreta
                bool letraEncontrada = false;
                for (int i = 0; i < palabraSecreta.Length; i++)
                {
                    if (palabraSecreta[i] == letra)
                    {
                        palabraOculta[i] = letra;
                        letraEncontrada = true;
                    }
                }

                if (!letraEncontrada)
                {
                    intentosRestantes--;
                    intentosFallidos++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Letra incorrecta!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("¡Letra correcta!");
                }

                // Verificar victoria
                if (new string(palabraOculta) == palabraSecreta)
                {
                    haGanado = true;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"\n¡Felicidades! ¡Ganaste! La palabra era: {palabraSecreta}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
            }

            // Mensaje si se quedó sin intentos
            if (!haGanado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nPerdiste. La palabra secreta era: {palabraSecreta}");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            // Preguntar por otra partida
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n¿Quieres jugar otra vez? (S/N): ");
            Console.ForegroundColor = ConsoleColor.Black;
            string respuesta = Console.ReadLine()?.ToUpper();
            jugarDeNuevo = (respuesta == "S");
        }

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Gracias por jugar. ¡Hasta la próxima!");
        Console.ForegroundColor = ConsoleColor.Black;
    }
}