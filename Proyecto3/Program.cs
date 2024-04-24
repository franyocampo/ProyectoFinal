using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class binaryTree
{
    static void Main(string[] args)
    {
        DecisionTreeNode treeEvaluar = new DecisionTreeNode();
        treeEvaluar.jugar();
    }


    internal class DecisionTreeNode
    {
        public string pregunta;
        public DecisionTreeNode si;
        public DecisionTreeNode no;
        public string respuesta;

        public List<String> respuestas; // lista de posibles respuestas.


        public DecisionTreeNode(string pregunta)
        {
            this.pregunta = pregunta;
            si = null;
            no = null;
            respuestas = null;
            respuestas = new List<string>(); // inicializar lista de respuestas

        }
        public DecisionTreeNode()
        {

        }

        public class DecisionTree
        {
            private DecisionTreeNode root;

            public DecisionTree(DecisionTreeNode rootNode)
            {
                root = rootNode;
            }

            public string EvaluarDecision()
            {
                DecisionTreeNode current = root;

                while (current != null)
                {
                    Console.WriteLine(current.pregunta);
                    string respuesta = Console.ReadLine().ToLower();

                    // Si hay mas de una respuesta posible, selecciona aleatoriamente
                    //string respuesta;
                    //if (current.respuestas.Count > 0)
                    //{
                    //    Random rnd = new Random();
                    //    int index = rnd.Next(current.respuestas.Count);
                    //    respuesta = current.respuestas[index];

                    //}
                    //else
                    //{
                    //    respuesta = Console.ReadLine().ToLower();
                    //}

                    if (respuesta == "si")
                    {
                        if (current.si != null)
                        {
                            current = current.si;
                        }
                        else
                        {
                            return current.respuesta;
                        }

                    }
                    else if (respuesta == "no")
                    {
                        if (current.no != null)
                        {
                            current = current.no;
                        }
                        else
                        {
                            return current.respuesta;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Respuesta invalida, Por Favor, Responda 'si o 'no'. ");
                    }
                }

                return null;
            }


        }

        public void jugar()
        {
            // Construir el árbol de decisiones con los síntomas y diagnósticos
            DecisionTreeNode raiz = new DecisionTreeNode("¿Tiene fiebre?");
            raiz.si = new DecisionTreeNode("¿Tiene dolor de cabeza?");
            raiz.no = new DecisionTreeNode("¿Tiene tos persistente?");
            raiz.no.no = new DecisionTreeNode("Gripe, Tratamiento: descanso, líquidos, medicamentos para reducir la fiebre y aliviar los síntomas");
            raiz.no.si = new DecisionTreeNode("¿Tiene producción de esputo?");
            raiz.no.si.no = new DecisionTreeNode("¿Tiene dolor en el pecho?");
            raiz.no.si.no.si = new DecisionTreeNode("Bronquitis, Tratamiento: descanso, líquidos, inhaladores broncodilatadores, medicamentos para aliviar la tos");
            raiz.no.si.si = new DecisionTreeNode("¿Tiene dificultad para respirar?");
            raiz.no.si.si.si = new DecisionTreeNode("Bronquitis, Tratamiento: descanso, líquidos, inhaladores broncodilatadores, medicamentos para aliviar la tos");
            raiz.si.si = new DecisionTreeNode("¿Tiene fatiga?");
            raiz.si.no = new DecisionTreeNode("¿Tiene congestión nasal?");
            raiz.si.no.si = new DecisionTreeNode("Resfriado común, Tratamiento: descanso, líquidos, medicamentos para aliviar la congestión y la tos");
            raiz.si.si.si = new DecisionTreeNode("¿Tiene congestión nasal?");
            raiz.si.si.no = new DecisionTreeNode("¿Tiene estornudos?");
            raiz.si.si.no.si = new DecisionTreeNode("Alergia, Tratamiento: antihistamínicos, descongestionantes, evitación del alérgeno");
            raiz.si.si.si.si = new DecisionTreeNode("¿Tiene dolor de garganta?");
            raiz.si.si.si.no = new DecisionTreeNode("Sinusitis, Tratamiento: analgésicos, descongestionantes, irrigación nasal, humidificadores");
            raiz.si.si.si.si.si = new DecisionTreeNode("Gripe, Tratamiento: descanso, líquidos, medicamentos para reducir la fiebre y aliviar los síntomas");
            raiz.si.si.si.si.no = new DecisionTreeNode("¿Tiene secreción nasal espesa y verde?");

            DecisionTree tree = new DecisionTree(raiz);

            Console.WriteLine("Responde sí o no a las siguientes preguntas: ");
            string mejorOpcion = tree.EvaluarDecision();
            Console.WriteLine($"Presione una tecla para salir");
            Console.ReadKey();
        }

    }
}