using System.Collections.Generic;

namespace src.Models;

    public class Pessoa
    {
        public Pessoa()
        {
            this.Nome ="template";
            this.Idade = 0;
            this.contratos = new List<Contrato>();
            this.ativado = true;
        }
        public Pessoa(string nome, int idade,string cpf)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Cpf = cpf;
            this.contratos = new List<Contrato>();
            this.ativado = true;
        }
        public int id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string? Cpf { get; set; }
        public bool ativado { get; set; }
        public List<Contrato> contratos { get; set; }
    }
