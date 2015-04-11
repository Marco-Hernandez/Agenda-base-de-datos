using System;

namespace Programa
{
    class Principal
    {
        bool salir;

        Principal()
        {
        }

        public void menu()
        {
            Contacto contacto = new Contacto();
            int opcion;
            string Id, Nombre, Telefono;
            Console.Write("1.- Ver todos los contactos"+
                "\n2.- Agregar contacto"+
                "\n3.- Editar contacto"+
                "\n4.- Eliminar contacto"+
                "\n5.- Salir"+
                "\n\nElegir la opcion: ");
            try
            {
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcion)
                {
                    case 1: contacto.mostrarTodos();
                         break;
                    case 2: Console.Write("Ingrese Nombre: ");
                        Nombre = Console.ReadLine();
                        Console.Write("Ingrese Telefono: ");
                        Telefono = Console.ReadLine();
                        contacto.insertarRegistroNuevo(Nombre,Telefono);
                        Console.Write("Contacto Agregado..");
                        Console.Clear();
                        break;
                    case 3: Console.Write("Ingrese ID: ");
                        Id = Console.ReadLine();
                        if (contacto.consultaId(Id).Length > 0)
                        {
                            Console.Write("Dame el nombre: ");
                            Nombre = Console.ReadLine();
                            Console.Write("Dame el telefono: ");
                            Telefono = Console.ReadLine();
                            contacto.editarRegistro(Id,Nombre,Telefono);
                        }
                        else
                            Console.WriteLine("ID inexistente");
                        Console.Clear();
                        break;
                    case 4: Console.Write("Ingrese ID: ");
                        Id = Console.ReadLine();
                        if (contacto.consultaId(Id).Length > 0)
                        {
                            Console.WriteLine("Contacto Eliminado");
                            contacto.eliminarRegistroPorId(Id);
                        }
                        else
                            Console.WriteLine("ID inexistente");
                        Console.Clear();
                        break;
                    case 5: Console.WriteLine("Esta saliendo del programa");
                        salir = true;
                        break;
                    default: Console.WriteLine("Ingrese otra Opcion");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n\t\t Debe ingresar un entero");
            }

        }


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.White;
            Principal principal = new Principal();
            do
            {
                Console.Clear();
                principal.menu();
                Console.ReadKey();
            } while (!principal.salir);
        }
    }
}