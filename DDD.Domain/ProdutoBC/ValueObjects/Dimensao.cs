using System;
using System.Collections.Generic;
using System.Text;

namespace eStore.Domain.ProdutoContext
{
    public class Dimensao
    {
        public double Altura { get; private set; }
        public double Largura { get; private set; }
        public double Profundidade { get; private set; }
        public double Peso { get; private set; }

        public Dimensao(double altura, double largura, double profundidade, double peso)
        {
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
            Peso = peso;
        }
    }
}
