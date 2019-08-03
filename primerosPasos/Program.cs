using System;
using System.Collections.Generic;
using System.Linq;

namespace primerosPasos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MiClase[] ejemplo = new MiClase[3];
            ejemplo[0] = new MiClase();
            ejemplo[1] = new MiClase();
            ejemplo[2] = new MiClase();

            int[] enteros = new int[5];
            for (int i = 0; i < enteros.Length; i++)
                enteros[i] = 4;

            Console.WriteLine("Numero de elementos: {0}", ejemplo.Length);

            List<MiClase> ejemplo2 = new List<MiClase>();
            foreach(MiClase miClase in ejemplo)
            {
                ejemplo2.Add(miClase);
            }
            ejemplo[2].Variable2 = 3;
            var resultado = ejemplo.Where(elemento => elemento.Variable2 == 3);
            Console.WriteLine("Numero de elementos con variable2 igual a 3: {0}", resultado.Count());
            modifica1(ejemplo);
            resultado = ejemplo.Where(elemento => elemento.Variable2 == 3);
            Console.WriteLine("Numero de elementos con variable2 igual a 3: {0}", resultado.Count());
            var resultado2 = enteros.Where(elemento => elemento == 5);
            Console.WriteLine("Enteros iguales a 5: {0}", resultado2.Count());
            modifica1(enteros);
            resultado2 = enteros.Where(elemento => elemento == 5);
            Console.WriteLine("Enteros iguales a 5: {0}", resultado2.Count());
            int tmp = 5;
            modifica1(tmp);
            Console.WriteLine("5+2={0}", tmp);
            modifica1(ref tmp);
            Console.WriteLine("5+2={0}", tmp);

        }
        public static void modifica1(MiClase[] mis)
        {
            for(int i=0;i<mis.Length;i++)
            {
                mis[i].Variable2 = 3;
            }
        }
        public static void modifica1(int[] mis)
        {
            for (int i = 0; i < mis.Length; i++)
            {
                mis[i]=5;
            }
        }
        public static void modifica1(int mio)
        {
           mio = mio+2;
        }
        public static void modifica1(ref int mio)
        {
            mio += 2;
        }
    }
    partial class MiClase
    {
        int variable1;
        public int Variable1 { get => variable1; set => variable1 = value; }
    }
    partial class MiClase
    {
        int variable2;
        public int Variable2 { get => variable2; set => variable2 = value; }
    }
    partial class MiClase: ISuma
    {
        public MiClase()
        {
            Variable1 = 1;
            variable2 = 2;
        }

        public int suma()
        {
            return variable1+variable2;
        }
    }
    interface ISuma
    {
        int Variable1
        {
            get; set;
        }
         int suma();
    }
}
