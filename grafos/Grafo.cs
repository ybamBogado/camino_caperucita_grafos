using System;
using System.Collections.Generic;

namespace tp7
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		public Grafo()
		{
		}
		
		private List<Vertice<T>>vertices = new List<Vertice<T>>();
	
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}

	
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int posicion) {
			return this.vertices[posicion];
		}
	

		public void DFS(Vertice<T> origen) {
		}
		
		public void BFS(Vertice<T> origen) {
		}

        //metodo actividad buscar camino que no tenga aristas mayores a maxFrutales
        public List<T> recorridoSeguroMaxFrutales(Vertice<T> caperucita, Vertice<T> abuelita, int maxFrutales)
        {
            List<Vertice<T>> mejorCamino = new List<Vertice<T>>();
            List<Vertice<T>> caminoActual = new List<Vertice<T>>();
            HashSet<Vertice<T>> visitados = new HashSet<Vertice<T>>();
            int maxFrutalesAcumulados = 0;

            caminoActual.Add(caperucita);
            BuscarCamino(caperucita, abuelita, maxFrutales, 0, ref maxFrutalesAcumulados, caminoActual, ref mejorCamino, visitados);

            return mejorCamino.ConvertAll(v => v.getDato());
        }

        private void BuscarCamino(Vertice<T> actual, Vertice<T> destino, int maxFrutales, int frutalesAcumulados,
                                  ref int maxFrutalesAcumulados, List<Vertice<T>> caminoActual,
                                  ref List<Vertice<T>> mejorCamino, HashSet<Vertice<T>> visitados)
        {
            if (actual.Equals(destino))
            {
                if (frutalesAcumulados > maxFrutalesAcumulados)
                {
                    maxFrutalesAcumulados = frutalesAcumulados;
                    mejorCamino = new List<Vertice<T>>(caminoActual);
                }
                return;
            }

            visitados.Add(actual);

            foreach (var arista in actual.getAdyacentes())
            {
                Vertice<T> siguiente = arista.getDestino();
                int frutales = arista.getPeso();

                if (!visitados.Contains(siguiente) && frutales <= maxFrutales)
                {
                    caminoActual.Add(siguiente);
                    BuscarCamino(siguiente, destino, maxFrutales, frutalesAcumulados + frutales,
                                 ref maxFrutalesAcumulados, caminoActual, ref mejorCamino, visitados);
                    caminoActual.RemoveAt(caminoActual.Count - 1);
                }
            }

            visitados.Remove(actual);
        }

    }
}
