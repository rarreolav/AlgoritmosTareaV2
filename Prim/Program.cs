using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


struct Nodo
{
    public int adyacente, peso;
}
class Prim_proof
{
    static int N, E, pesotote, min;
    static int INF = 1 << 30;
    static int[] padre = new int[1000];//Arreglo de padres
    static int[] distancias = new int[1000];//Arreglo para las distancias
    static PriorityQueue Q = new PriorityQueue();//Declaro al PseudoCola de prioridad
    static List<int>[] ady = new List<int>[1000];//Lista de adyacencia
    static int[,] pesos = new int[1000, 1000];//Lista de adyacencia para los pesos
    static bool[] visitado = new bool[1000];

    struct node
    {
        public int x, y, peso;
    }

    static Nodo[] nodo = new Nodo[1000];
    static node[] ar = new node[1000];
    static int Prim(int inicial)
    {
        min = 0;
        Nodo temp1 = new Nodo();
        for (int i = 1; i <= N; i++)
        {
            if (i == inicial)//Condicion para solo meter al inicial a la cola con su distancia en 0
            {
                distancias[inicial] = 0;//La distancia inicial la marcamos con 0 pues no nos cuesta nada llegar o partir de un nodo
                temp1.peso = distancias[inicial];
                temp1.adyacente = inicial;
                Q.push(temp1);
            }
            else
            {//Los demas los metemos a Infinito
                distancias[i] = INF;//Las demas distancias las marcamos con infinito
                padre[i] = 0;//Los demas padre empiezan con un valor NULL
                temp1.peso = distancias[i];
                temp1.adyacente = i;
                Q.push(temp1);
            }
        }

        while (!Q.isEmpty())//Mientras que la cola no este vacía
        {
            Nodo temp = Q.top();//Obtenemos el primer elemento de la Cola
            int u = temp.adyacente;
            int val = temp.peso;
            Q.pop();

            for (int j = 0; j < ady[u].Count(); j++)//para todos los nodos adyacentes a u
            {
                int v = ady[u][j];//Nodo adyacente a u
                                  //Console.WriteLine("min: "+min+" V: " + v + " U: " + u + " Distancia v: " + distancias[v] + " peso[u,v]: " + pesos[u, v]);
                if (!(visitado[v]) && distancias[v] > pesos[u, v])//Si V pertenece a la cola y su distancia es mayor al peso en (u,v)
                {
                    Nodo mete = new Nodo();
                    visitado[v] = true;
                    distancias[v] = pesos[u, v];//Y a las distancias de v le ponemos el peso de u
                    min += distancias[v];//Sumamos las distancias

                    mete.peso = distancias[v];
                    mete.adyacente = v;
                    padre[v] = u;//Al padre de v le asignamos a u

                    Q.push(mete);//Pusheamos al nodo v
                }
            }
        }

        return min;
    }

    static void Main(string[] args)
    {
        string input;
        string[] entry;
        input = Console.ReadLine();
        entry = input.Split(' ');
        N = int.Parse(entry[0]);
        E = int.Parse(entry[1]);

        for (int i = 0; i <= (E * 2); i++)
        {
            ady[i] = new List<int>();
        }

        for (int i = 1; i <= E; i++)
        {
            input = Console.ReadLine();
            entry = input.Split(' ');
            ar[i].x = int.Parse(entry[0]);
            ar[i].y = int.Parse(entry[1]);
            ady[ar[i].x].Add(ar[i].y);
            ady[ar[i].y].Add(ar[i].x);
            ar[i].peso = int.Parse(entry[2]);

        }
        for (int i = 1; i <= E; i++)
        {
            pesos[ar[i].x, ar[i].y] = ar[i].peso;
            pesos[ar[i].y, ar[i].x] = ar[i].peso;

        }

        pesotote = Prim(3);
        Console.WriteLine("Peso final: " + pesotote);
        Console.ReadKey();
    }

}



class PriorityQueue //Clase creada para simular una Cola de prioridad de complejidad O(N log N)
{//Note que la complejidad de un Heap optimo es O(logN)
    public List<Nodo> PseudoQueue = new List<Nodo>();//Declaramos la PseudoCola

    public bool Is(Nodo objeto)
    {
        return PseudoQueue.Contains(objeto);//Preguntamos si está el elemento "objeto"
    }

    public bool isEmpty()
    {
        return PseudoQueue.Count == 0;//Si tiene cero elementos devolverá false
    }

    public PriorityQueue()
    {
        PseudoQueue = new List<Nodo>();//Mediante el constructor creamos la PseudoCola
    }                                 // bajo una Lista

    public void push(Nodo Objeto)
    {
        PseudoQueue.Add(Objeto);//Añadimos el elemento a la PseudoCola
        PseudoQueue.OrderBy(s => s.peso);
        //PseudoQueue.Sort();//Ordenamos la PseudoCola para así asegurar que nos dará prioridad
    }
    public Nodo top()
    {
        Nodo number = PseudoQueue.First<Nodo>();
        return number; //Retornamos el primer elemento de la PseudoCola
    }
    public void pop()
    {
        PseudoQueue.RemoveAt(0);//Removemos el primer elemento de la PseudoCola
    }
}