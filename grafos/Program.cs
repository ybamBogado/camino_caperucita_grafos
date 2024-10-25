using System;
using tp7;

public class Program
{
    public static void Main()
    {
        var bosque = new Grafo<string>();

        var caperucita = new Vertice<string>("Casa de Caperucita");
        var claro1 = new Vertice<string>("Claro 1");
        var claro2 = new Vertice<string>("Claro 2");
        var claro3 = new Vertice<string>("Claro 3");
        var claro4 = new Vertice<string>("Claro 4");
        var claro5 = new Vertice<string>("Claro 5");
        var claro6 = new Vertice<string>("Claro 6");
        var abuelita = new Vertice<string>("Casa de la Abuelita");

        bosque.agregarVertice(caperucita);
        bosque.agregarVertice(claro1);
        bosque.agregarVertice(claro2);
        bosque.agregarVertice(claro3);
        bosque.agregarVertice(claro4);
        bosque.agregarVertice(claro5);
        bosque.agregarVertice(claro6);
        bosque.agregarVertice(abuelita);

        bosque.conectar(caperucita, claro2, 15);
        bosque.conectar(caperucita, claro3, 20);
        bosque.conectar(caperucita, claro4, 8);
        bosque.conectar(claro2, claro4, 38);
        bosque.conectar(claro2, claro6, 30);
        bosque.conectar(caperucita, claro1, 10);
        bosque.conectar(claro3, claro5, 3);
        bosque.conectar(claro1, claro3, 5);
        bosque.conectar(claro4, claro6, 45);
        bosque.conectar(claro5, claro6, 7);
        bosque.conectar(claro6, abuelita, 15);
        bosque.conectar(claro5, abuelita, 35); 

        int maxFrutales = 30;
        var camino = bosque.recorridoSeguroMaxFrutales(caperucita, abuelita, maxFrutales);

        Console.WriteLine("Camino seguro con la mayor cantidad de frutales:");
        foreach (var nodo in camino)
        {
            Console.WriteLine(nodo);
        }
    }
}
